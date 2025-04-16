using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DrawingColor = System.Drawing.Color;
public partial class MaterialCard : Panel
{
    public string MaterialName { get; private set; }

    public event Action<MaterialCard> OnCardSelected;

    public MaterialCard(string name, int required, int delivered, int remaining)
    {
        this.Width = 250;
        this.Height = 70;
        this.Margin = new Padding(5);
        this.BorderStyle = BorderStyle.FixedSingle;
        this.MaterialName = name;
        this.Click += (s, e) => OnCardSelected?.Invoke(this);
        var lblTitle = new Label
        {
            Text = $"• {name}",
            Font = new Font("Segoe UI", 10, FontStyle.Bold),
            AutoSize = true,
            Location = new Point(5, 5)
        };

        var lblStats = new Label
        {
            Text = $"Required: {required} | Delivered: {delivered} | Remaining: {remaining}",
            AutoSize = true,
            Location = new Point(5, 30)
        };

        // Make the entire card clickable
        this.Click += OnCardClick;
        lblTitle.Click += OnCardClick;
        lblStats.Click += OnCardClick;

        this.Controls.Add(lblTitle);
        this.Controls.Add(lblStats);
    }

    private void OnCardClick(object sender, EventArgs e)
    {
        this.BackColor = DrawingColor.LightBlue; // Optional: show selected
        OnCardSelected?.Invoke(this);     // Custom event to signal selection
    }
    public void SetInTransit(string commanderName)
    {
        var lblStatus = new Label
        {
            Text = $"🚛 Commander {commanderName} is in transit",
            ForeColor = Color.Black,
            AutoSize = true,
            Dock = DockStyle.Bottom
        };

        this.Controls.Add(lblStatus);
        this.Controls.SetChildIndex(lblStatus, 0); // Ensure it's at the bottom
    }
    public void MarkAsDelivered(string commanderName)
    {
        var lblStatus = new Label
        {
            Text = $"✅ Delivered by Commander {commanderName}",
            ForeColor = Color.LimeGreen,
            AutoSize = true,
            Dock = DockStyle.Bottom,
            Font = new Font("Segoe UI", 9, FontStyle.Bold)
        };

        this.Controls.Add(lblStatus);
        this.Controls.SetChildIndex(lblStatus, 0);
    }
    public void SetDeliveredBy(List<string> commanders)
    {
        // Remove any existing delivery labels first
        foreach (Control ctrl in this.Controls.OfType<Label>().Where(l => l.Name.StartsWith("lblDelivered")).ToList())
        {
            this.Controls.Remove(ctrl);
        }

        if (commanders.Count == 0)
            return; // Don't add any label if nobody delivered

        int yOffset = this.Height - 20;

        foreach (var (commander, index) in commanders.Select((c, i) => (c, i)))
        {
            var lbl = new Label
            {
                Name = $"lblDelivered_{index}",
                Text = $"✅ Delivered by Commander {commander}",
                ForeColor = Color.LimeGreen,
                AutoSize = true,
                Location = new Point(10, yOffset + index * 20),
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };

            this.Controls.Add(lbl);
        }

        // Resize height to fit all
        this.Height += commanders.Count * 20;
    }

}
