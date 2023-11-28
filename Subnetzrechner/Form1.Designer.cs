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
            this.textBoxbis = new System.Windows.Forms.TextBox();
            this.buttonCopy = new System.Windows.Forms.Button();
            this.buttonDownload = new System.Windows.Forms.Button();
            this.buttonVerlauf = new System.Windows.Forms.Button();
            this.buttondeine_IP = new System.Windows.Forms.Button();
            this.buttonRandom = new System.Windows.Forms.Button();
            this.NetzwerkRechner = new System.Windows.Forms.Label();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonThemes = new System.Windows.Forms.Button();
            this.buttonRechnen = new System.Windows.Forms.Button();
            this.comboBoxCIDR_Suffix = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // IP_Adresse
            // 
            this.IP_Adresse.AutoSize = true;
            this.IP_Adresse.Location = new System.Drawing.Point(12, 61);
            this.IP_Adresse.Name = "IP_Adresse";
            this.IP_Adresse.Size = new System.Drawing.Size(61, 13);
            this.IP_Adresse.TabIndex = 1;
            this.IP_Adresse.Text = "IP Adresse:";
            // 
            // CIDR_Suffix
            // 
            this.CIDR_Suffix.AutoSize = true;
            this.CIDR_Suffix.Location = new System.Drawing.Point(12, 86);
            this.CIDR_Suffix.Name = "CIDR_Suffix";
            this.CIDR_Suffix.Size = new System.Drawing.Size(65, 13);
            this.CIDR_Suffix.TabIndex = 2;
            this.CIDR_Suffix.Text = "CIDR Suffix:";
            // 
            // Netzwerkmask
            // 
            this.Netzwerkmask.AutoSize = true;
            this.Netzwerkmask.Location = new System.Drawing.Point(12, 130);
            this.Netzwerkmask.Name = "Netzwerkmask";
            this.Netzwerkmask.Size = new System.Drawing.Size(80, 13);
            this.Netzwerkmask.TabIndex = 3;
            this.Netzwerkmask.Text = "Netzwerkmask:";
            // 
            // InverseNetzwerkmask
            // 
            this.InverseNetzwerkmask.AutoSize = true;
            this.InverseNetzwerkmask.Location = new System.Drawing.Point(12, 156);
            this.InverseNetzwerkmask.Name = "InverseNetzwerkmask";
            this.InverseNetzwerkmask.Size = new System.Drawing.Size(118, 13);
            this.InverseNetzwerkmask.TabIndex = 4;
            this.InverseNetzwerkmask.Text = "Inverse Netzwerkmask:";
            this.InverseNetzwerkmask.Click += new System.EventHandler(this.label4_Click);
            // 
            // AnzahlHosts
            // 
            this.AnzahlHosts.AutoSize = true;
            this.AnzahlHosts.Location = new System.Drawing.Point(12, 179);
            this.AnzahlHosts.Name = "AnzahlHosts";
            this.AnzahlHosts.Size = new System.Drawing.Size(72, 13);
            this.AnzahlHosts.TabIndex = 5;
            this.AnzahlHosts.Text = "Anzahl Hosts:";
            // 
            // Netzadresse
            // 
            this.Netzadresse.AutoSize = true;
            this.Netzadresse.Location = new System.Drawing.Point(12, 205);
            this.Netzadresse.Name = "Netzadresse";
            this.Netzadresse.Size = new System.Drawing.Size(69, 13);
            this.Netzadresse.TabIndex = 6;
            this.Netzadresse.Text = "Netzadresse:";
            // 
            // Broadcast
            // 
            this.Broadcast.AutoSize = true;
            this.Broadcast.Location = new System.Drawing.Point(12, 229);
            this.Broadcast.Name = "Broadcast";
            this.Broadcast.Size = new System.Drawing.Size(58, 13);
            this.Broadcast.TabIndex = 7;
            this.Broadcast.Text = "Broadcast:";
            // 
            // HostIPSvon
            // 
            this.HostIPSvon.AutoSize = true;
            this.HostIPSvon.Location = new System.Drawing.Point(9, 270);
            this.HostIPSvon.Name = "HostIPSvon";
            this.HostIPSvon.Size = new System.Drawing.Size(70, 13);
            this.HostIPSvon.TabIndex = 8;
            this.HostIPSvon.Text = "Host-Ips von:";
            this.HostIPSvon.Click += new System.EventHandler(this.label8_Click);
            // 
            // bis
            // 
            this.bis.AutoSize = true;
            this.bis.Location = new System.Drawing.Point(12, 296);
            this.bis.Name = "bis";
            this.bis.Size = new System.Drawing.Size(23, 13);
            this.bis.TabIndex = 9;
            this.bis.Text = "bis:";
            // 
            // textBoxIP_Adresse
            // 
            this.textBoxIP_Adresse.Location = new System.Drawing.Point(136, 54);
            this.textBoxIP_Adresse.Name = "textBoxIP_Adresse";
            this.textBoxIP_Adresse.Size = new System.Drawing.Size(150, 20);
            this.textBoxIP_Adresse.TabIndex = 11;
            // 
            // textBoxNetzwerkmask
            // 
            this.textBoxNetzwerkmask.Location = new System.Drawing.Point(136, 124);
            this.textBoxNetzwerkmask.Name = "textBoxNetzwerkmask";
            this.textBoxNetzwerkmask.Size = new System.Drawing.Size(150, 20);
            this.textBoxNetzwerkmask.TabIndex = 13;
            // 
            // textBoxInverseNetzwerkmask
            // 
            this.textBoxInverseNetzwerkmask.Location = new System.Drawing.Point(136, 150);
            this.textBoxInverseNetzwerkmask.Name = "textBoxInverseNetzwerkmask";
            this.textBoxInverseNetzwerkmask.ReadOnly = true;
            this.textBoxInverseNetzwerkmask.Size = new System.Drawing.Size(150, 20);
            this.textBoxInverseNetzwerkmask.TabIndex = 14;
            // 
            // textBoxAnzahlHosts
            // 
            this.textBoxAnzahlHosts.Location = new System.Drawing.Point(136, 176);
            this.textBoxAnzahlHosts.Name = "textBoxAnzahlHosts";
            this.textBoxAnzahlHosts.Size = new System.Drawing.Size(150, 20);
            this.textBoxAnzahlHosts.TabIndex = 15;
            // 
            // textBoxNetzadresse
            // 
            this.textBoxNetzadresse.Location = new System.Drawing.Point(136, 202);
            this.textBoxNetzadresse.Name = "textBoxNetzadresse";
            this.textBoxNetzadresse.ReadOnly = true;
            this.textBoxNetzadresse.Size = new System.Drawing.Size(150, 20);
            this.textBoxNetzadresse.TabIndex = 16;
            // 
            // textBoxBroadcast
            // 
            this.textBoxBroadcast.Location = new System.Drawing.Point(136, 228);
            this.textBoxBroadcast.Name = "textBoxBroadcast";
            this.textBoxBroadcast.ReadOnly = true;
            this.textBoxBroadcast.Size = new System.Drawing.Size(150, 20);
            this.textBoxBroadcast.TabIndex = 17;
            // 
            // textBoxHostIPSvon
            // 
            this.textBoxHostIPSvon.Location = new System.Drawing.Point(136, 267);
            this.textBoxHostIPSvon.Name = "textBoxHostIPSvon";
            this.textBoxHostIPSvon.ReadOnly = true;
            this.textBoxHostIPSvon.Size = new System.Drawing.Size(150, 20);
            this.textBoxHostIPSvon.TabIndex = 18;
            // 
            // textBoxbis
            // 
            this.textBoxbis.Location = new System.Drawing.Point(136, 293);
            this.textBoxbis.Name = "textBoxbis";
            this.textBoxbis.ReadOnly = true;
            this.textBoxbis.Size = new System.Drawing.Size(150, 20);
            this.textBoxbis.TabIndex = 19;
            // 
            // buttonCopy
            // 
            this.buttonCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCopy.Location = new System.Drawing.Point(12, 342);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(132, 20);
            this.buttonCopy.TabIndex = 20;
            this.buttonCopy.Text = "Copy";
            this.buttonCopy.UseVisualStyleBackColor = true;
            // 
            // buttonDownload
            // 
            this.buttonDownload.Location = new System.Drawing.Point(150, 342);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(136, 20);
            this.buttonDownload.TabIndex = 21;
            this.buttonDownload.Text = "Download";
            this.buttonDownload.UseVisualStyleBackColor = true;
            // 
            // buttonVerlauf
            // 
            this.buttonVerlauf.Location = new System.Drawing.Point(12, 368);
            this.buttonVerlauf.Name = "buttonVerlauf";
            this.buttonVerlauf.Size = new System.Drawing.Size(132, 20);
            this.buttonVerlauf.TabIndex = 22;
            this.buttonVerlauf.Text = "Verlauf";
            this.buttonVerlauf.UseVisualStyleBackColor = true;
            // 
            // buttondeine_IP
            // 
            this.buttondeine_IP.Location = new System.Drawing.Point(150, 368);
            this.buttondeine_IP.Name = "buttondeine_IP";
            this.buttondeine_IP.Size = new System.Drawing.Size(136, 20);
            this.buttondeine_IP.TabIndex = 23;
            this.buttondeine_IP.Text = "Deine IP";
            this.buttondeine_IP.UseVisualStyleBackColor = true;
            this.buttondeine_IP.Click += new System.EventHandler(this.buttondeine_IP_Click);
            // 
            // buttonRandom
            // 
            this.buttonRandom.Location = new System.Drawing.Point(12, 394);
            this.buttonRandom.Name = "buttonRandom";
            this.buttonRandom.Size = new System.Drawing.Size(132, 20);
            this.buttonRandom.TabIndex = 24;
            this.buttonRandom.Text = "Random";
            this.buttonRandom.UseVisualStyleBackColor = true;
            // 
            // NetzwerkRechner
            // 
            this.NetzwerkRechner.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NetzwerkRechner.Location = new System.Drawing.Point(12, 9);
            this.NetzwerkRechner.Name = "NetzwerkRechner";
            this.NetzwerkRechner.Size = new System.Drawing.Size(274, 42);
            this.NetzwerkRechner.TabIndex = 25;
            this.NetzwerkRechner.Text = "Netzwerk Rechner";
            this.NetzwerkRechner.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(150, 394);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(136, 20);
            this.buttonReset.TabIndex = 26;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonThemes
            // 
            this.buttonThemes.Location = new System.Drawing.Point(12, 420);
            this.buttonThemes.Name = "buttonThemes";
            this.buttonThemes.Size = new System.Drawing.Size(132, 20);
            this.buttonThemes.TabIndex = 27;
            this.buttonThemes.Text = "Themes op";
            this.buttonThemes.UseVisualStyleBackColor = true;
            // 
            // buttonRechnen
            // 
            this.buttonRechnen.Location = new System.Drawing.Point(150, 420);
            this.buttonRechnen.Name = "buttonRechnen";
            this.buttonRechnen.Size = new System.Drawing.Size(136, 20);
            this.buttonRechnen.TabIndex = 28;
            this.buttonRechnen.Text = "Berechnen";
            this.buttonRechnen.UseVisualStyleBackColor = true;
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
            this.comboBoxCIDR_Suffix.Location = new System.Drawing.Point(136, 86);
            this.comboBoxCIDR_Suffix.Name = "comboBoxCIDR_Suffix";
            this.comboBoxCIDR_Suffix.Size = new System.Drawing.Size(150, 21);
            this.comboBoxCIDR_Suffix.TabIndex = 29;
            // 
            // ViewNetzwerkRechner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 451);
            this.Controls.Add(this.comboBoxCIDR_Suffix);
            this.Controls.Add(this.buttonRechnen);
            this.Controls.Add(this.buttonThemes);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.NetzwerkRechner);
            this.Controls.Add(this.buttonRandom);
            this.Controls.Add(this.buttondeine_IP);
            this.Controls.Add(this.buttonVerlauf);
            this.Controls.Add(this.buttonDownload);
            this.Controls.Add(this.buttonCopy);
            this.Controls.Add(this.textBoxbis);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ViewNetzwerkRechner";
            this.Text = "Subnetzrechner";
            this.Load += new System.EventHandler(this.ViewNetzwerkRechner_Load);
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
        private System.Windows.Forms.TextBox textBoxbis;
        private System.Windows.Forms.Button buttonCopy;
        private System.Windows.Forms.Button buttonDownload;
        private System.Windows.Forms.Button buttonVerlauf;
        private System.Windows.Forms.Button buttondeine_IP;
        private System.Windows.Forms.Button buttonRandom;
        private System.Windows.Forms.Label NetzwerkRechner;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonThemes;
        private System.Windows.Forms.Button buttonRechnen;
        private System.Windows.Forms.ComboBox comboBoxCIDR_Suffix;
    }
}

