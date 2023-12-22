namespace Subnetzrechner
{
    partial class ViewNetzwerkRechner
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewNetzwerkRechner));
            this.IP_Adresse = new System.Windows.Forms.Label();
            this.CIDR_Suffix = new System.Windows.Forms.Label();
            this.Netzwerkmask = new System.Windows.Forms.Label();
            this.InverseNetzwerkmask = new System.Windows.Forms.Label();
            this.AnzahlHosts = new System.Windows.Forms.Label();
            this.Netzadresse = new System.Windows.Forms.Label();
            this.Broadcast = new System.Windows.Forms.Label();
            this.HostIPSvon = new System.Windows.Forms.Label();
            this.bis = new System.Windows.Forms.Label();
            this.textBoxIP_Adresse = new System.Windows.Forms.TextBox();
            this.textBoxNetzwerkmask = new System.Windows.Forms.TextBox();
            this.textBoxInverseNetzwerkmask = new System.Windows.Forms.TextBox();
            this.textBoxAnzahlHosts = new System.Windows.Forms.TextBox();
            this.textBoxNetzadresse = new System.Windows.Forms.TextBox();
            this.textBoxBroadcast = new System.Windows.Forms.TextBox();
            this.textBoxHostIPSvon = new System.Windows.Forms.TextBox();
            this.textBoxBis = new System.Windows.Forms.TextBox();
            this.buttonCopy = new System.Windows.Forms.Button();
            this.buttonSpeichern = new System.Windows.Forms.Button();
            this.buttondeine_IP = new System.Windows.Forms.Button();
            this.buttonRandom = new System.Windows.Forms.Button();
            this.NetzwerkRechner = new System.Windows.Forms.Label();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonRechnen = new System.Windows.Forms.Button();
            this.comboBoxCIDR_Suffix = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.statusStripEinstlleungInfo = new System.Windows.Forms.StatusStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.hintergrundfarbeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dunkelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grünToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blauToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripEinstlleungInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // IP_Adresse
            // 
            this.IP_Adresse.AutoSize = true;
            this.IP_Adresse.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IP_Adresse.Location = new System.Drawing.Point(12, 66);
            this.IP_Adresse.Name = "IP_Adresse";
            this.IP_Adresse.Size = new System.Drawing.Size(69, 15);
            this.IP_Adresse.TabIndex = 1;
            this.IP_Adresse.Text = "IP Adresse:";
            // 
            // CIDR_Suffix
            // 
            this.CIDR_Suffix.AutoSize = true;
            this.CIDR_Suffix.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CIDR_Suffix.Location = new System.Drawing.Point(12, 93);
            this.CIDR_Suffix.Name = "CIDR_Suffix";
            this.CIDR_Suffix.Size = new System.Drawing.Size(73, 15);
            this.CIDR_Suffix.TabIndex = 2;
            this.CIDR_Suffix.Text = "CIDR-Suffix:";
            // 
            // Netzwerkmask
            // 
            this.Netzwerkmask.AutoSize = true;
            this.Netzwerkmask.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Netzwerkmask.Location = new System.Drawing.Point(12, 140);
            this.Netzwerkmask.Name = "Netzwerkmask";
            this.Netzwerkmask.Size = new System.Drawing.Size(98, 15);
            this.Netzwerkmask.TabIndex = 3;
            this.Netzwerkmask.Text = "Netzwerkmaske:";
            // 
            // InverseNetzwerkmask
            // 
            this.InverseNetzwerkmask.AutoSize = true;
            this.InverseNetzwerkmask.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InverseNetzwerkmask.Location = new System.Drawing.Point(12, 168);
            this.InverseNetzwerkmask.Name = "InverseNetzwerkmask";
            this.InverseNetzwerkmask.Size = new System.Drawing.Size(141, 15);
            this.InverseNetzwerkmask.TabIndex = 4;
            this.InverseNetzwerkmask.Text = "Inverse Netzwerkmaske:";
            // 
            // AnzahlHosts
            // 
            this.AnzahlHosts.AutoSize = true;
            this.AnzahlHosts.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnzahlHosts.Location = new System.Drawing.Point(12, 193);
            this.AnzahlHosts.Name = "AnzahlHosts";
            this.AnzahlHosts.Size = new System.Drawing.Size(82, 15);
            this.AnzahlHosts.TabIndex = 5;
            this.AnzahlHosts.Text = "Anzahl Hosts:";
            // 
            // Netzadresse
            // 
            this.Netzadresse.AutoSize = true;
            this.Netzadresse.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Netzadresse.Location = new System.Drawing.Point(12, 221);
            this.Netzadresse.Name = "Netzadresse";
            this.Netzadresse.Size = new System.Drawing.Size(80, 15);
            this.Netzadresse.TabIndex = 6;
            this.Netzadresse.Text = "Netzadresse:";
            // 
            // Broadcast
            // 
            this.Broadcast.AutoSize = true;
            this.Broadcast.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Broadcast.Location = new System.Drawing.Point(12, 247);
            this.Broadcast.Name = "Broadcast";
            this.Broadcast.Size = new System.Drawing.Size(66, 15);
            this.Broadcast.TabIndex = 7;
            this.Broadcast.Text = "Broadcast:";
            // 
            // HostIPSvon
            // 
            this.HostIPSvon.AutoSize = true;
            this.HostIPSvon.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HostIPSvon.Location = new System.Drawing.Point(12, 291);
            this.HostIPSvon.Name = "HostIPSvon";
            this.HostIPSvon.Size = new System.Drawing.Size(79, 15);
            this.HostIPSvon.TabIndex = 8;
            this.HostIPSvon.Text = "Host-Ips von:";
            // 
            // bis
            // 
            this.bis.AutoSize = true;
            this.bis.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bis.Location = new System.Drawing.Point(12, 319);
            this.bis.Name = "bis";
            this.bis.Size = new System.Drawing.Size(27, 15);
            this.bis.TabIndex = 9;
            this.bis.Text = "bis:";
            // 
            // textBoxIP_Adresse
            // 
            this.textBoxIP_Adresse.Location = new System.Drawing.Point(159, 58);
            this.textBoxIP_Adresse.Name = "textBoxIP_Adresse";
            this.textBoxIP_Adresse.Size = new System.Drawing.Size(131, 20);
            this.textBoxIP_Adresse.TabIndex = 11;
            // 
            // textBoxNetzwerkmask
            // 
            this.textBoxNetzwerkmask.Location = new System.Drawing.Point(159, 134);
            this.textBoxNetzwerkmask.Name = "textBoxNetzwerkmask";
            this.textBoxNetzwerkmask.Size = new System.Drawing.Size(131, 20);
            this.textBoxNetzwerkmask.TabIndex = 13;
            // 
            // textBoxInverseNetzwerkmask
            // 
            this.textBoxInverseNetzwerkmask.Location = new System.Drawing.Point(159, 162);
            this.textBoxInverseNetzwerkmask.Name = "textBoxInverseNetzwerkmask";
            this.textBoxInverseNetzwerkmask.ReadOnly = true;
            this.textBoxInverseNetzwerkmask.Size = new System.Drawing.Size(131, 20);
            this.textBoxInverseNetzwerkmask.TabIndex = 14;
            // 
            // textBoxAnzahlHosts
            // 
            this.textBoxAnzahlHosts.Location = new System.Drawing.Point(159, 190);
            this.textBoxAnzahlHosts.Name = "textBoxAnzahlHosts";
            this.textBoxAnzahlHosts.Size = new System.Drawing.Size(131, 20);
            this.textBoxAnzahlHosts.TabIndex = 15;
            // 
            // textBoxNetzadresse
            // 
            this.textBoxNetzadresse.Location = new System.Drawing.Point(159, 218);
            this.textBoxNetzadresse.Name = "textBoxNetzadresse";
            this.textBoxNetzadresse.ReadOnly = true;
            this.textBoxNetzadresse.Size = new System.Drawing.Size(131, 20);
            this.textBoxNetzadresse.TabIndex = 16;
            // 
            // textBoxBroadcast
            // 
            this.textBoxBroadcast.Location = new System.Drawing.Point(159, 246);
            this.textBoxBroadcast.Name = "textBoxBroadcast";
            this.textBoxBroadcast.ReadOnly = true;
            this.textBoxBroadcast.Size = new System.Drawing.Size(131, 20);
            this.textBoxBroadcast.TabIndex = 17;
            // 
            // textBoxHostIPSvon
            // 
            this.textBoxHostIPSvon.Location = new System.Drawing.Point(159, 288);
            this.textBoxHostIPSvon.Name = "textBoxHostIPSvon";
            this.textBoxHostIPSvon.ReadOnly = true;
            this.textBoxHostIPSvon.Size = new System.Drawing.Size(131, 20);
            this.textBoxHostIPSvon.TabIndex = 18;
            // 
            // textBoxBis
            // 
            this.textBoxBis.Location = new System.Drawing.Point(159, 316);
            this.textBoxBis.Name = "textBoxBis";
            this.textBoxBis.ReadOnly = true;
            this.textBoxBis.Size = new System.Drawing.Size(131, 20);
            this.textBoxBis.TabIndex = 19;
            // 
            // buttonCopy
            // 
            this.buttonCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCopy.Location = new System.Drawing.Point(15, 472);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(64, 22);
            this.buttonCopy.TabIndex = 20;
            this.buttonCopy.Text = "Copy";
            this.buttonCopy.UseVisualStyleBackColor = true;
            this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
            // 
            // buttonSpeichern
            // 
            this.buttonSpeichern.Location = new System.Drawing.Point(226, 472);
            this.buttonSpeichern.Name = "buttonSpeichern";
            this.buttonSpeichern.Size = new System.Drawing.Size(64, 22);
            this.buttonSpeichern.TabIndex = 21;
            this.buttonSpeichern.Text = "Speichern";
            this.buttonSpeichern.UseVisualStyleBackColor = true;
            this.buttonSpeichern.Click += new System.EventHandler(this.buttonSpeichern_Click);
            // 
            // buttondeine_IP
            // 
            this.buttondeine_IP.Location = new System.Drawing.Point(121, 472);
            this.buttondeine_IP.Name = "buttondeine_IP";
            this.buttondeine_IP.Size = new System.Drawing.Size(58, 22);
            this.buttondeine_IP.TabIndex = 23;
            this.buttondeine_IP.Text = "Deine IP";
            this.buttondeine_IP.UseVisualStyleBackColor = true;
            this.buttondeine_IP.Click += new System.EventHandler(this.buttonDeine_IP_Click);
            // 
            // buttonRandom
            // 
            this.buttonRandom.Location = new System.Drawing.Point(159, 426);
            this.buttonRandom.Name = "buttonRandom";
            this.buttonRandom.Size = new System.Drawing.Size(130, 22);
            this.buttonRandom.TabIndex = 24;
            this.buttonRandom.Text = "Random";
            this.buttonRandom.UseVisualStyleBackColor = true;
            this.buttonRandom.Click += new System.EventHandler(this.buttonRandom_Click);
            // 
            // NetzwerkRechner
            // 
            this.NetzwerkRechner.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NetzwerkRechner.Location = new System.Drawing.Point(59, 24);
            this.NetzwerkRechner.Name = "NetzwerkRechner";
            this.NetzwerkRechner.Size = new System.Drawing.Size(185, 25);
            this.NetzwerkRechner.TabIndex = 25;
            this.NetzwerkRechner.Text = "IP-Subnetzrechner";
            this.NetzwerkRechner.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(159, 370);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(130, 22);
            this.buttonReset.TabIndex = 29;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonRechnen
            // 
            this.buttonRechnen.Location = new System.Drawing.Point(159, 342);
            this.buttonRechnen.Name = "buttonRechnen";
            this.buttonRechnen.Size = new System.Drawing.Size(130, 22);
            this.buttonRechnen.TabIndex = 27;
            this.buttonRechnen.Text = "Berechnen";
            this.buttonRechnen.UseVisualStyleBackColor = true;
            this.buttonRechnen.Click += new System.EventHandler(this.buttonBerechnen_Click);
            // 
            // comboBoxCIDR_Suffix
            // 
            this.comboBoxCIDR_Suffix.FormattingEnabled = true;
            this.comboBoxCIDR_Suffix.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32"});
            this.comboBoxCIDR_Suffix.Location = new System.Drawing.Point(159, 93);
            this.comboBoxCIDR_Suffix.Name = "comboBoxCIDR_Suffix";
            this.comboBoxCIDR_Suffix.Size = new System.Drawing.Size(131, 22);
            this.comboBoxCIDR_Suffix.TabIndex = 12;
            this.comboBoxCIDR_Suffix.SelectedIndexChanged += new System.EventHandler(this.comboBoxCIDR_Suffix_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(159, 398);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 22);
            this.button1.TabIndex = 28;
            this.button1.Text = "Letzte Berechnung";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonLetzteBerechnungAnsehen_Click);
            // 
            // statusStripEinstlleungInfo
            // 
            this.statusStripEinstlleungInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.statusStripEinstlleungInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.statusStripEinstlleungInfo.Location = new System.Drawing.Point(0, 0);
            this.statusStripEinstlleungInfo.Name = "statusStripEinstlleungInfo";
            this.statusStripEinstlleungInfo.Size = new System.Drawing.Size(301, 22);
            this.statusStripEinstlleungInfo.TabIndex = 30;
            this.statusStripEinstlleungInfo.Text = "statusStrip1";
            this.statusStripEinstlleungInfo.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStripEinstlleungInfo_ItemClicked);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hintergrundfarbeToolStripMenuItem});
            this.toolStripDropDownButton1.Image = global::Subnetzrechner.Properties.Resources.settingscog_87317;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 20);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButtonEinstellung";
            // 
            // hintergrundfarbeToolStripMenuItem
            // 
            this.hintergrundfarbeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dunkelToolStripMenuItem,
            this.hellToolStripMenuItem,
            this.rotToolStripMenuItem,
            this.grünToolStripMenuItem,
            this.blauToolStripMenuItem});
            this.hintergrundfarbeToolStripMenuItem.Name = "hintergrundfarbeToolStripMenuItem";
            this.hintergrundfarbeToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.hintergrundfarbeToolStripMenuItem.Text = "Hintergrundfarbe";
            // 
            // dunkelToolStripMenuItem
            // 
            this.dunkelToolStripMenuItem.Name = "dunkelToolStripMenuItem";
            this.dunkelToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.dunkelToolStripMenuItem.Text = "Dunkel";
            this.dunkelToolStripMenuItem.Click += new System.EventHandler(this.dunkelToolStripMenuItem_Click);
            // 
            // hellToolStripMenuItem
            // 
            this.hellToolStripMenuItem.Name = "hellToolStripMenuItem";
            this.hellToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.hellToolStripMenuItem.Text = "Hell";
            this.hellToolStripMenuItem.Click += new System.EventHandler(this.hellToolStripMenuItem_Click);
            // 
            // rotToolStripMenuItem
            // 
            this.rotToolStripMenuItem.Name = "rotToolStripMenuItem";
            this.rotToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.rotToolStripMenuItem.Text = "Rot";
            this.rotToolStripMenuItem.Click += new System.EventHandler(this.rotToolStripMenuItem_Click);
            // 
            // grünToolStripMenuItem
            // 
            this.grünToolStripMenuItem.Name = "grünToolStripMenuItem";
            this.grünToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.grünToolStripMenuItem.Text = "Grün";
            this.grünToolStripMenuItem.Click += new System.EventHandler(this.grünToolStripMenuItem_Click);
            // 
            // blauToolStripMenuItem
            // 
            this.blauToolStripMenuItem.Name = "blauToolStripMenuItem";
            this.blauToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.blauToolStripMenuItem.Text = "Blau";
            this.blauToolStripMenuItem.Click += new System.EventHandler(this.blauToolStripMenuItem_Click);
            // 
            // ViewNetzwerkRechner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 504);
            this.Controls.Add(this.statusStripEinstlleungInfo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxCIDR_Suffix);
            this.Controls.Add(this.buttonRechnen);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.NetzwerkRechner);
            this.Controls.Add(this.buttonRandom);
            this.Controls.Add(this.buttondeine_IP);
            this.Controls.Add(this.buttonSpeichern);
            this.Controls.Add(this.buttonCopy);
            this.Controls.Add(this.textBoxBis);
            this.Controls.Add(this.textBoxHostIPSvon);
            this.Controls.Add(this.textBoxBroadcast);
            this.Controls.Add(this.textBoxNetzadresse);
            this.Controls.Add(this.textBoxAnzahlHosts);
            this.Controls.Add(this.textBoxInverseNetzwerkmask);
            this.Controls.Add(this.textBoxNetzwerkmask);
            this.Controls.Add(this.textBoxIP_Adresse);
            this.Controls.Add(this.bis);
            this.Controls.Add(this.HostIPSvon);
            this.Controls.Add(this.Broadcast);
            this.Controls.Add(this.Netzadresse);
            this.Controls.Add(this.AnzahlHosts);
            this.Controls.Add(this.InverseNetzwerkmask);
            this.Controls.Add(this.Netzwerkmask);
            this.Controls.Add(this.CIDR_Suffix);
            this.Controls.Add(this.IP_Adresse);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ViewNetzwerkRechner";
            this.Text = "Subnetzrechner";
            this.Load += new System.EventHandler(this.ViewNetzwerkRechner_Load);
            this.statusStripEinstlleungInfo.ResumeLayout(false);
            this.statusStripEinstlleungInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label IP_Adresse;
        private System.Windows.Forms.Label CIDR_Suffix;
        private System.Windows.Forms.Label Netzwerkmask;
        private System.Windows.Forms.Label InverseNetzwerkmask;
        private System.Windows.Forms.Label AnzahlHosts;
        private System.Windows.Forms.Label Netzadresse;
        private System.Windows.Forms.Label Broadcast;
        private System.Windows.Forms.Label HostIPSvon;
        private System.Windows.Forms.Label bis;
        private System.Windows.Forms.TextBox textBoxIP_Adresse;
        private System.Windows.Forms.TextBox textBoxNetzwerkmask;
        private System.Windows.Forms.TextBox textBoxInverseNetzwerkmask;
        private System.Windows.Forms.TextBox textBoxAnzahlHosts;
        private System.Windows.Forms.TextBox textBoxNetzadresse;
        private System.Windows.Forms.TextBox textBoxBroadcast;
        private System.Windows.Forms.TextBox textBoxHostIPSvon;
        private System.Windows.Forms.TextBox textBoxBis;
        private System.Windows.Forms.Button buttonCopy;
        private System.Windows.Forms.Button buttonSpeichern;
        private System.Windows.Forms.Button buttondeine_IP;
        private System.Windows.Forms.Button buttonRandom;
        private System.Windows.Forms.Label NetzwerkRechner;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonRechnen;
        private System.Windows.Forms.ComboBox comboBoxCIDR_Suffix;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.StatusStrip statusStripEinstlleungInfo;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem hintergrundfarbeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dunkelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hellToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grünToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blauToolStripMenuItem;
    }
}

