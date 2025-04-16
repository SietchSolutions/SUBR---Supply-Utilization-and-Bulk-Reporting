namespace SUBR___Supply_Utilization_and_Bulk_Reporting
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtSystemName = new System.Windows.Forms.TextBox();
            this.txtStationName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbStationType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCreateStation = new System.Windows.Forms.Button();
            this.lblCreateStatus = new System.Windows.Forms.Label();
            this.lblCommander = new System.Windows.Forms.Label();
            this.lblSquadron = new System.Windows.Forms.Label();
            this.lblLastSeen = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.btnDeleteStation = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.flpMaterials = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbStationSelector = new System.Windows.Forms.ComboBox();
            this.cmbSystemSelector = new System.Windows.Forms.ComboBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnLoadLarge = new System.Windows.Forms.Button();
            this.btnLoadMedium400 = new System.Windows.Forms.Button();
            this.btnLoadCustom = new System.Windows.Forms.Button();
            this.btnUnload = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter System Name";
            // 
            // txtSystemName
            // 
            this.txtSystemName.Location = new System.Drawing.Point(131, 52);
            this.txtSystemName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtSystemName.Name = "txtSystemName";
            this.txtSystemName.Size = new System.Drawing.Size(252, 22);
            this.txtSystemName.TabIndex = 1;
            // 
            // txtStationName
            // 
            this.txtStationName.Location = new System.Drawing.Point(132, 125);
            this.txtStationName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtStationName.Name = "txtStationName";
            this.txtStationName.Size = new System.Drawing.Size(252, 22);
            this.txtStationName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 128);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Enter Station Name";
            // 
            // cmbStationType
            // 
            this.cmbStationType.FormattingEnabled = true;
            this.cmbStationType.Location = new System.Drawing.Point(131, 88);
            this.cmbStationType.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbStationType.Name = "cmbStationType";
            this.cmbStationType.Size = new System.Drawing.Size(252, 23);
            this.cmbStationType.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 91);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Enter Station Type";
            // 
            // btnCreateStation
            // 
            this.btnCreateStation.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCreateStation.Location = new System.Drawing.Point(268, 156);
            this.btnCreateStation.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCreateStation.Name = "btnCreateStation";
            this.btnCreateStation.Size = new System.Drawing.Size(115, 27);
            this.btnCreateStation.TabIndex = 6;
            this.btnCreateStation.Text = "Create Station";
            this.btnCreateStation.UseVisualStyleBackColor = true;
            this.btnCreateStation.Click += new System.EventHandler(this.btnCreateStation_Click);
            // 
            // lblCreateStatus
            // 
            this.lblCreateStatus.AutoSize = true;
            this.lblCreateStatus.Location = new System.Drawing.Point(7, 156);
            this.lblCreateStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCreateStatus.Name = "lblCreateStatus";
            this.lblCreateStatus.Size = new System.Drawing.Size(41, 15);
            this.lblCreateStatus.TabIndex = 7;
            this.lblCreateStatus.Text = "Status";
            // 
            // lblCommander
            // 
            this.lblCommander.AutoSize = true;
            this.lblCommander.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommander.Location = new System.Drawing.Point(7, 29);
            this.lblCommander.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCommander.Name = "lblCommander";
            this.lblCommander.Size = new System.Drawing.Size(98, 19);
            this.lblCommander.TabIndex = 8;
            this.lblCommander.Text = "lblCommander";
            // 
            // lblSquadron
            // 
            this.lblSquadron.AutoSize = true;
            this.lblSquadron.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSquadron.Location = new System.Drawing.Point(146, 29);
            this.lblSquadron.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSquadron.Name = "lblSquadron";
            this.lblSquadron.Size = new System.Drawing.Size(82, 19);
            this.lblSquadron.TabIndex = 9;
            this.lblSquadron.Text = "lblSquadron";
            // 
            // lblLastSeen
            // 
            this.lblLastSeen.AutoSize = true;
            this.lblLastSeen.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastSeen.Location = new System.Drawing.Point(357, 29);
            this.lblLastSeen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLastSeen.Name = "lblLastSeen";
            this.lblLastSeen.Size = new System.Drawing.Size(79, 19);
            this.lblLastSeen.TabIndex = 10;
            this.lblLastSeen.Text = "lblLastSeen";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.lblCommander);
            this.groupBox1.Controls.Add(this.btnCreateStation);
            this.groupBox1.Controls.Add(this.lblCreateStatus);
            this.groupBox1.Controls.Add(this.lblLastSeen);
            this.groupBox1.Controls.Add(this.lblSquadron);
            this.groupBox1.Controls.Add(this.txtStationName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbStationType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtSystemName);
            this.groupBox1.Location = new System.Drawing.Point(14, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(774, 211);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Create System";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SUBR___Supply_Utilization_and_Bulk_Reporting.Properties.Resources.animatedEDgif;
            this.pictureBox1.Location = new System.Drawing.Point(517, 52);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(156, 148);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.btnDeleteStation);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.flpMaterials);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cmbStationSelector);
            this.groupBox2.Controls.Add(this.cmbSystemSelector);
            this.groupBox2.Location = new System.Drawing.Point(14, 242);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Size = new System.Drawing.Size(762, 421);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Manager Station";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(250, 38);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(56, 41);
            this.button3.TabIndex = 8;
            this.button3.Text = "Edit System";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnDeleteStation
            // 
            this.btnDeleteStation.Location = new System.Drawing.Point(312, 101);
            this.btnDeleteStation.Name = "btnDeleteStation";
            this.btnDeleteStation.Size = new System.Drawing.Size(56, 41);
            this.btnDeleteStation.TabIndex = 7;
            this.btnDeleteStation.Text = "Delete Station";
            this.btnDeleteStation.UseVisualStyleBackColor = true;
            this.btnDeleteStation.Click += new System.EventHandler(this.btnDeleteStation_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(250, 101);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 41);
            this.button1.TabIndex = 6;
            this.button1.Text = "Edit Station";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // flpMaterials
            // 
            this.flpMaterials.AutoScroll = true;
            this.flpMaterials.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpMaterials.Location = new System.Drawing.Point(391, 25);
            this.flpMaterials.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.flpMaterials.Name = "flpMaterials";
            this.flpMaterials.Size = new System.Drawing.Size(355, 372);
            this.flpMaterials.TabIndex = 5;
            this.flpMaterials.WrapContents = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 92);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "Second Select Existing Station";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 18);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "First Select Existing System";
            // 
            // cmbStationSelector
            // 
            this.cmbStationSelector.FormattingEnabled = true;
            this.cmbStationSelector.Location = new System.Drawing.Point(12, 111);
            this.cmbStationSelector.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbStationSelector.Name = "cmbStationSelector";
            this.cmbStationSelector.Size = new System.Drawing.Size(231, 23);
            this.cmbStationSelector.TabIndex = 1;
            this.cmbStationSelector.Text = "-Select Station-";
            // 
            // cmbSystemSelector
            // 
            this.cmbSystemSelector.FormattingEnabled = true;
            this.cmbSystemSelector.Location = new System.Drawing.Point(12, 48);
            this.cmbSystemSelector.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbSystemSelector.Name = "cmbSystemSelector";
            this.cmbSystemSelector.Size = new System.Drawing.Size(231, 23);
            this.cmbSystemSelector.TabIndex = 0;
            this.cmbSystemSelector.Text = "-Select System-";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.richTextBox1.Location = new System.Drawing.Point(794, 24);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(469, 198);
            this.richTextBox1.TabIndex = 13;
            this.richTextBox1.Text = "";
            // 
            // btnLoadLarge
            // 
            this.btnLoadLarge.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnLoadLarge.Location = new System.Drawing.Point(794, 278);
            this.btnLoadLarge.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnLoadLarge.Name = "btnLoadLarge";
            this.btnLoadLarge.Size = new System.Drawing.Size(167, 36);
            this.btnLoadLarge.TabIndex = 14;
            this.btnLoadLarge.Text = "Load Large 784";
            this.btnLoadLarge.UseVisualStyleBackColor = true;
            this.btnLoadLarge.Click += new System.EventHandler(this.btnLoadLarge_Click);
            // 
            // btnLoadMedium400
            // 
            this.btnLoadMedium400.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnLoadMedium400.Location = new System.Drawing.Point(794, 324);
            this.btnLoadMedium400.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnLoadMedium400.Name = "btnLoadMedium400";
            this.btnLoadMedium400.Size = new System.Drawing.Size(167, 36);
            this.btnLoadMedium400.TabIndex = 15;
            this.btnLoadMedium400.Text = "Load Medium 400";
            this.btnLoadMedium400.UseVisualStyleBackColor = true;
            // 
            // btnLoadCustom
            // 
            this.btnLoadCustom.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnLoadCustom.Location = new System.Drawing.Point(794, 367);
            this.btnLoadCustom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnLoadCustom.Name = "btnLoadCustom";
            this.btnLoadCustom.Size = new System.Drawing.Size(167, 36);
            this.btnLoadCustom.TabIndex = 16;
            this.btnLoadCustom.Text = "Load Custom";
            this.btnLoadCustom.UseVisualStyleBackColor = true;
            // 
            // btnUnload
            // 
            this.btnUnload.Location = new System.Drawing.Point(794, 482);
            this.btnUnload.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnUnload.Name = "btnUnload";
            this.btnUnload.Size = new System.Drawing.Size(167, 44);
            this.btnUnload.TabIndex = 17;
            this.btnUnload.Text = "Unload Cargo";
            this.btnUnload.UseVisualStyleBackColor = true;
            this.btnUnload.Click += new System.EventHandler(this.btnUnload_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1279, 677);
            this.Controls.Add(this.btnUnload);
            this.Controls.Add(this.btnLoadCustom);
            this.Controls.Add(this.btnLoadMedium400);
            this.Controls.Add(this.btnLoadLarge);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "S.U.B.R. - Supply Utilization and Bulk Reporting";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSystemName;
        private System.Windows.Forms.TextBox txtStationName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbStationType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCreateStation;
        private System.Windows.Forms.Label lblCreateStatus;
        private System.Windows.Forms.Label lblCommander;
        private System.Windows.Forms.Label lblSquadron;
        private System.Windows.Forms.Label lblLastSeen;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbStationSelector;
        private System.Windows.Forms.ComboBox cmbSystemSelector;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.FlowLayoutPanel flpMaterials;
        private System.Windows.Forms.Button btnLoadLarge;
        private System.Windows.Forms.Button btnLoadMedium400;
        private System.Windows.Forms.Button btnLoadCustom;
        private System.Windows.Forms.Button btnUnload;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnDeleteStation;
    }
}

