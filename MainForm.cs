using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace SUBR___Supply_Utilization_and_Bulk_Reporting
{
    public partial class MainForm: Form
    {
        public MainForm()
        {
            InitializeComponent();
            GoogleSheetsHelper.Init();
            var systems = GoogleSheetsHelper.GetAllSystems();
            
            LoadStationTypes();
            this.cmbSystemSelector.SelectedIndexChanged += new System.EventHandler(this.cmbSystemSelector_SelectedIndexChanged);
            this.cmbStationSelector.SelectedIndexChanged += new System.EventHandler(this.cmbStationSelector_SelectedIndexChanged);
            var (commander, ship, squadron, lastSeen) = CommanderHelper.GetCommanderInfo();
            GoogleSheetsHelper.LogCommander(commander, squadron, lastSeen.ToString("s"));
            
            lblCommander.Text = $"CMDR: {commander}";
            lblSquadron.Text = $"Squadron: {squadron}";
            lblLastSeen.Text = $"Last Log: {lastSeen:g}";
            
            

            cmbSystemSelector.Items.Clear();
            cmbSystemSelector.Items.AddRange(systems.ToArray());
            foreach (var system in systems)
            {
                Console.WriteLine($"🌌 {system}");
            }
        }
        private MaterialCard selectedCard;
        private void LoadStationTypes()
        {
            var types = GoogleSheetsHelper.GetAllStationTypes();
            cmbStationType.Items.Clear();
            cmbStationType.Items.AddRange(types.ToArray());

            if (cmbStationType.Items.Count > 0)
                cmbStationType.SelectedIndex = 0;
        }


        private void btnCreateStation_Click(object sender, EventArgs e)
        {
            string systemName = txtSystemName.Text.Trim();
            string stationName = txtStationName.Text.Trim();
            string stationType = cmbStationType.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(systemName) ||
                string.IsNullOrWhiteSpace(stationName) ||
                string.IsNullOrWhiteSpace(stationType))
            {
                lblCreateStatus.Text = "❌ Please enter all fields.";
                return;
            }

            try
            {
                GoogleSheetsHelper.CreateStationFromTemplate(systemName, stationName, stationType, CommanderHelper.GetCommanderName());

                lblCreateStatus.Text = $"✅ '{stationName}' added to '{systemName}'";
            }
            catch (Exception ex)
            {
                lblCreateStatus.Text = "❌ Failed to create station. " + ex.Message;
            }
        }
        
        private void cmbSystemSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSystem = cmbSystemSelector.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(selectedSystem)) return;

            // Load stations from Google Sheets
            var stations = GoogleSheetsHelper.GetStationsInSystem(selectedSystem);

            cmbStationSelector.Items.Clear();
            cmbStationSelector.Items.AddRange(stations.ToArray());
        }
        private void cmbStationSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            string systemName = cmbSystemSelector.SelectedItem?.ToString();
            string stationName = cmbStationSelector.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(stationName)) return;

            var materials = GoogleSheetsHelper.GetStationMaterials(stationName);

            

            flpMaterials.Controls.Clear(); // ❗ Moved this here

            foreach (var (name, required, delivered, remaining) in materials)
            {
                

                var card = new MaterialCard(name, required, delivered, remaining);

                card.OnCardSelected += Card_OnCardSelected; // Optional: respond to clicks
                flpMaterials.Controls.Add(card);
            }
            var inTransit = GoogleSheetsHelper.GetInTransitClaims(systemName, stationName);


            foreach (var (material, commander) in inTransit)
            {
                foreach (Control ctrl in flpMaterials.Controls)
                {
                    if (ctrl is MaterialCard card && card.MaterialName == material)
                    {
                        card.SetInTransit(commander);
                    }
                }
            }

        }// ✅ THIS SHOWS IT ON SCREEN

        private void Card_OnCardSelected(MaterialCard selectedCard)
        {
            // Deselect all other cards
            foreach (Control control in flpMaterials.Controls)
            {
                if (control is MaterialCard card)
                {
                    card.BackColor = SystemColors.Control; // or your neutral color
                }
            }

            // Highlight only the selected card
            selectedCard.BackColor = System.Drawing.Color.LightBlue;

            // Track the selected card
            this.selectedCard = selectedCard;

            // Debug or future logic
            Console.WriteLine($"📦 Selected card: {selectedCard.MaterialName}");
        }
        private void btnLoadLarge_Click(object sender, EventArgs e)
        {
            if (selectedCard == null) return;

            string commander = CommanderHelper.GetCommanderName();
            string squadron = CommanderHelper.GetSquadronName();
            string system = cmbSystemSelector.SelectedItem?.ToString();
            string station = cmbStationSelector.SelectedItem?.ToString();

            int cargoAmount = 784;
            string material = selectedCard.MaterialName;

            // Log pickup
            Console.WriteLine($"🚛 {commander} of {squadron} picked up {cargoAmount} {material} bound for {system} - {station}");

            // ✅ ACTUAL SHEETS WRITE HERE
            GoogleSheetsHelper.LogCargoClaim(commander, squadron, material, cargoAmount, system, station);

            // Visually mark in transit
            selectedCard.SetInTransit(commander);
        }
        private void btnUnload_Click(object sender, EventArgs e)
        {
            string commander = CommanderHelper.GetCommanderName();
            string material = selectedCard.MaterialName;
            string system = cmbSystemSelector.SelectedItem?.ToString();
            string station = cmbStationSelector.SelectedItem?.ToString();
            var allCommanders = GoogleSheetsHelper.GetAllDeliveryCommanders(material, system, station);
            selectedCard.SetDeliveredBy(allCommanders);
            if (selectedCard == null) return;

            

            // Step 1: Update the InTransit row
            GoogleSheetsHelper.MarkAsDelivered(commander, material, system, station);

            // Step 2: Update Delivered/Remaining (implement this next)
            GoogleSheetsHelper.UpdateStationDelivery(material, system, station, 784); // or actual amount

            // Step 3: Visually mark card
            selectedCard.MarkAsDelivered(commander);

            // Step 4: (Later) Update CommanderTotals sheet
            GoogleSheetsHelper.AddToCommanderTotal(commander, material, 784); // optional
        }

        private void btnDeleteStation_Click(object sender, EventArgs e)
        {
            string system = cmbSystemSelector.SelectedItem?.ToString();
            string station = cmbStationSelector.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(system) || string.IsNullOrWhiteSpace(station))
            {
                MessageBox.Show("Please select both a system and station to delete.");
                return;
            }

            // Call the helper
            GoogleSheetsHelper.DeleteStation(system, station);

            MessageBox.Show($"🗑️ Deleted '{station}' from system '{system}'.");

            // Refresh UI dropdowns
            var systems = GoogleSheetsHelper.GetAllSystems();
            cmbSystemSelector.Items.Clear();
            cmbSystemSelector.Items.AddRange(systems.ToArray());

            cmbStationSelector.Items.Clear();
        }


    }


}


