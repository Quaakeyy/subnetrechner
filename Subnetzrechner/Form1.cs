using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Policy;
using System.Windows.Forms;
using System.Xml;

namespace Subnetzrechner
{
    public partial class ViewNetzwerkRechner : Form
    {
        private bool isDarkTheme = false;
        private int calculationCounter = 0; // Zählt die Anzahl der durchgeführten Berechnungen
        private string lastCalculationXmlPath; // Speichert den Pfad zur letzten Berechnung


        public ViewNetzwerkRechner()
        {
            InitializeComponent();
        }

        private void UpdateButtonStyles(Control control, Color textColor)
        {
            foreach (Control ctrl in control.Controls)
            {
                if (ctrl is Button button)
                {
                    button.ForeColor = textColor;
                }

                if (ctrl.HasChildren)
                {
                    UpdateButtonStyles(ctrl, textColor);
                }
            }
        }

        private void buttonDeine_IP_Click(object sender, EventArgs e)
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    textBoxIP_Adresse.Text = ip.ToString();

                    string subnetMask = BerechneSubnetMaskVonIP(ip.ToString());
                    int cidrSuffix = CalculateCIDRSuffixFromSubnetMask(subnetMask);

                    textBoxNetzwerkmask.Text = subnetMask;
                    comboBoxCIDR_Suffix.Text = cidrSuffix.ToString();

                    break;
                }
            }
            foreach(Control control in Controls)
            {       
                if (control is TextBox textBox && textBox != textBoxIP_Adresse && textBox != textBoxNetzwerkmask)
                {
                    textBox.Clear();
                }
            }
        }
    

        private string BerechneSubnetMaskVonIP(string ipAddress)
        {
            if (IPAddress.TryParse(ipAddress, out IPAddress ip))
            {
                byte[] addressBytes = ip.GetAddressBytes();

                // Prüfe private IP-Adressbereiche
                if (addressBytes[0] == 10)
                {
                    return "255.0.0.0"; 
                }
                else if (addressBytes[0] == 172 && addressBytes[1] >= 16 && addressBytes[1] <= 31)
                {
                    return "255.255.0.0"; 
                }
                else if (addressBytes[0] == 192 && addressBytes[1] == 168)
                {
                    return "255.255.255.0"; 
                }

                return "255.255.255.0"; 
            }

            return "255.255.255.0";
        }

        private int CalculateCIDRSuffixFromSubnetMask(string subnetMask)
        {
            byte[] ipAddressBytes = IPAddress.Parse(subnetMask).GetAddressBytes();
            int cidrSuffix = 0;

            foreach (byte octet in ipAddressBytes)
            {
                for (int i = 7; i >= 0; i--)
                {
                    if ((octet & (1 << i)) == 0)
                    {
                        return cidrSuffix;
                    }

                    cidrSuffix++;
                }
            }

            return cidrSuffix;
        }
        //Setzt alle Textboxen zurück
        private void buttonReset_Click(object sender, EventArgs e)
        {        
            Controls.OfType<TextBox>().ToList().ForEach(textBox => textBox.Clear());
            comboBoxCIDR_Suffix.ResetText();
        }
        //Generiert eine zufällige IP und CIDR Suffix und berechnet diese automatisch
        private void buttonRandom_Click(object sender, EventArgs e)
        {
            Random random = new Random();
   
            string randomIpAddress = $"{random.Next(1,255)}.{random.Next(0, 255)}.{random.Next(0, 255)}.{random.Next(0, 255)}";

            textBoxIP_Adresse.Text = randomIpAddress;

            int randomCidrSuffix = random.Next(0, 32);
            comboBoxCIDR_Suffix.Text = randomCidrSuffix.ToString();

            string subnetMask = SubnetMaskBerechnen(randomCidrSuffix);
            textBoxNetzwerkmask.Text = subnetMask;

            BerechnungDurchführen();
        }
        //Berechnet die engetragenen werte und gibt Fehler aus
        private void buttonBerechnen_Click(object sender, EventArgs e)
        {
            
            try
            {   
                int cidrSuffix = int.Parse(comboBoxCIDR_Suffix.Text);
                if (cidrSuffix < 0 || cidrSuffix > 32)
                {
                    MessageBox.Show("Sie können nur werte 0-32 eintragen, Bitte überprüfen Sie die Eingaben.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    comboBoxCIDR_Suffix.Text = "";
                }
                if (comboBoxCIDR_Suffix.Text.Length == 2)
                {
                    comboBoxCIDR_Suffix.Focus();
                }
            }
            catch
            {
                if (comboBoxCIDR_Suffix.Text != "")
                {
                    MessageBox.Show("Sie können nur werte 0-32 eintragen, Bitte überprüfen Sie die Eingaben.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    comboBoxCIDR_Suffix.Text = "";
                }
            }

            if (BerechnungDurchführen())
            {
                MessageBox.Show("Berechnung erfolgreich durchgeführt und Ergebnisse gespeichert.", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ungültige Berechnung.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Berechnet die eingetragenen werte
        private bool BerechnungDurchführen()
        {
            if (int.TryParse(comboBoxCIDR_Suffix.Text, out int cidrSuffix))
            {
                string inverseSubnetMask = InverseSubnetMaskBerechnen(cidrSuffix);
                textBoxInverseNetzwerkmask.Text = inverseSubnetMask;

                string networkAddress = NetzwerkAddresseBerechnen(textBoxIP_Adresse.Text, cidrSuffix);

                // Überprüfen ob CalculateNetworkAddress erfolgreich war
                if (string.IsNullOrEmpty(networkAddress))
                {
                    // Löscht die anderen Ergebnisse
                    ErgebnisseLöschen();
                    return false; 
                }

                textBoxNetzadresse.Text = networkAddress;

                string broadcastAddress = BroadcastAddressBerechnen(textBoxIP_Adresse.Text, cidrSuffix);
                textBoxBroadcast.Text = broadcastAddress;

                HostIPsBerechnen(textBoxIP_Adresse.Text, cidrSuffix, out string hostIPvon, out string hostIPbis);
                textBoxHostIPSvon.Text = hostIPvon;
                textBoxBis.Text = hostIPbis;

                int numberOfHosts = AnzahlDerHostsBerechnen(cidrSuffix);
                textBoxAnzahlHosts.Text = numberOfHosts.ToString();
               
                string Subnetmask = SubnetMaskBerechnen(cidrSuffix);
                textBoxNetzwerkmask.Text = Subnetmask;


                // Speichert die ergebnise in einer XML
                ErgebnisseInXmlSpeichern();

                return true; //brechnung erfolgreich
            }
            else
            {
                // Löscht ergebnisse
                ErgebnisseLöschen();
                return false; // Berechnung nicht erfolgreich
            }
        }

        //Logik zum Löschen der Ergebnisse aus der XML-Datei
        private void ErgebnisseLöschenXml()
        {
            File.Delete("berechnungen.xml");
        }
        //alle Ergebnisse werden aus Textboxen und XML-Datei Gelöscht

        private void ErgebnisseLöschen()
        {
            textBoxInverseNetzwerkmask.Text = string.Empty;
            textBoxNetzadresse.Text = string.Empty;
            textBoxBroadcast.Text = string.Empty;
            textBoxHostIPSvon.Text = string.Empty;
            textBoxBis.Text = string.Empty;
            textBoxAnzahlHosts.Text = string.Empty;
            ErgebnisseLöschenXml();
        }
        //Speichert alle Daten in eimem textdocumment
        private void buttonSpeichern_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text Dateien|*.txt",
                Title = "Ergebnisse speichern"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string results = ErstelleErgebnisseString();
                File.WriteAllText(saveFileDialog.FileName, results);
                MessageBox.Show("Die Ergebnisse wurden erfolgreich gespeichert.", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string ErstelleErgebnisseString()
        {
            return 
                   $"IP-Adresse: {textBoxIP_Adresse.Text}\r\n" +
                   $"CIDR-Suffix: {comboBoxCIDR_Suffix.Text}\r\n" +
                   $"Netzwerkmaske: {textBoxNetzwerkmask.Text}\r\n" +
                   $"Inverse Netzwerkmaske: {textBoxInverseNetzwerkmask.Text}\r\n" +
                   $"Netzadresse: {textBoxNetzadresse.Text}\r\n" +
                   $"Broadcast: {textBoxBroadcast.Text}\r\n" +
                   $"Host-IPs (von): {textBoxHostIPSvon.Text}\r\n" +
                   $"Host-IPs (bis): {textBoxBis.Text}\r\n" +
                   $"Anzahl der Hosts: {textBoxAnzahlHosts.Text}\r\n";
        }
        //Speichert werte in einer XML Dokument
        private void ErgebnisseInXmlSpeichern()
        {
            // XML-Dokument erstellen oder vorhandenes öffnen
            XmlDocument xmlDoc = new XmlDocument();
            string xmlFilePath = "berechnungen.xml";

            if (File.Exists(xmlFilePath))
            {
                xmlDoc.Load(xmlFilePath);
            }
            else
            {
                // Wenn die Datei nicht existiert, erstelle sie und füge die Wurzel hinzu
                XmlElement rootElement = xmlDoc.CreateElement("Berechnungen");
                xmlDoc.AppendChild(rootElement);
            }

            // Neues Berechnungs-Element erstellen
            XmlElement calculationElement = xmlDoc.CreateElement("Berechnung");

            // Ergebnisse hinzufügen
            AddXmlElement(calculationElement, "IPAdresse", textBoxIP_Adresse.Text);
            AddXmlElement(calculationElement, "Netzwerkmaske", textBoxNetzwerkmask.Text);
            AddXmlElement(calculationElement, "InverseNetzwerkmaske", textBoxInverseNetzwerkmask.Text);
            AddXmlElement(calculationElement, "Netzadresse", textBoxNetzadresse.Text);
            AddXmlElement(calculationElement, "Broadcast", textBoxBroadcast.Text);
            AddXmlElement(calculationElement, "HostIPvon", textBoxHostIPSvon.Text);
            AddXmlElement(calculationElement, "HostIPbis", textBoxBis.Text);
            AddXmlElement(calculationElement, "AnzahlHosts", textBoxAnzahlHosts.Text);

            // CIDR-Suffix hinzufügen
            AddXmlElement(calculationElement, "CIDRSuffix", comboBoxCIDR_Suffix.Text);

            // Berechnungs-Element zum Dokument hinzufügen
            xmlDoc.DocumentElement?.AppendChild(calculationElement);

            // Dokument speichern
            xmlDoc.Save(xmlFilePath);
        }


        private void AddXmlElement(XmlNode parentNode, string elementName, string elementValue)
        {
            XmlElement newElement = parentNode.OwnerDocument.CreateElement(elementName);
            newElement.InnerText = elementValue;
            parentNode.AppendChild(newElement);
        }

        private string SubnetMaskBerechnen(int cidrSuffix)
        {
            if (cidrSuffix < 0 || cidrSuffix > 32)
            {
                return "255.255.255.255"; // Unerwartetes CIDR-Suffix, gib einen Standardwert zurück oder handle den Fehler entsprechend.
            }

            // Berechnung der Subnetzmaske
            uint subnetMaskValue = 0xFFFFFFFFu << (32 - cidrSuffix);

            byte[] maskBytes = BitConverter.GetBytes(subnetMaskValue);
            Array.Reverse(maskBytes); // Umkehrung der Reihenfolge aufgrund der Little-Endian-Architektur

            return $"{maskBytes[0]}.{maskBytes[1]}.{maskBytes[2]}.{maskBytes[3]}";
        }

        private string InverseSubnetMaskBerechnen(int cidrSuffix)
        {
            if (cidrSuffix < 0 || cidrSuffix > 32)
            {
                return "0.0.0.0"; // Unerwartetes CIDR-Suffix, gib einen Standardwert zurück oder handle den Fehler entsprechend.
            }

            uint inverseSubnetMaskValue = ~((uint)0xFFFFFFFF << (32 - cidrSuffix));
            byte[] inverseMaskBytes = BitConverter.GetBytes(inverseSubnetMaskValue);

            // Umgekehrte Reihenfolge für Little-Endian-Architektur
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(inverseMaskBytes);
            }

            return new IPAddress(inverseMaskBytes).ToString();
        }

        private string NetzwerkAddresseBerechnen(string ipAddress, int cidrSuffix)
        {
            try
            {
                IPAddress ip = IPAddress.Parse(ipAddress);
                byte[] ipBytes = ip.GetAddressBytes();
                byte[] maskBytes = SubnetMaskBytesBerechnen(cidrSuffix);

                byte[] networkBytes = new byte[ipBytes.Length];
                for (int i = 0; i < ipBytes.Length; i++)
                {
                    networkBytes[i] = (byte)(ipBytes[i] & maskBytes[i]);
                }

                return new IPAddress(networkBytes).ToString();
            }
            catch (FormatException)
            {
                // Fehlerbehandlung für ungültige IP-Adresse
                MessageBox.Show("Sie können nur werte 0-255.0-255.0-255.0-255 eintragen, Bitte überprüfen Sie die Eingaben.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        private byte[] SubnetMaskBytesBerechnen(int cidrSuffix)
        {
            uint subnetMaskValue = 0xFFFFFFFF << (32 - cidrSuffix);
            byte[] maskBytes = BitConverter.GetBytes(subnetMaskValue).Reverse().ToArray();
            return maskBytes;
        }
        
        private string BroadcastAddressBerechnen(string ipAddress, int cidrSuffix)
        {
            try
            {
                IPAddress ip = IPAddress.Parse(ipAddress);
                byte[] ipBytes = ip.GetAddressBytes();
                byte[] maskBytes = SubnetMaskBytesBerechnen(cidrSuffix);

                byte[] invertedMaskBytes = maskBytes.Select(b => (byte)~b).ToArray();
                byte[] broadcastBytes = new byte[ipBytes.Length];
                for (int i = 0; i < ipBytes.Length; i++)
                {
                    broadcastBytes[i] = (byte)(ipBytes[i] | invertedMaskBytes[i]);
                }

                return new IPAddress(broadcastBytes).ToString();
            }
            catch (FormatException)
            {
                
                return string.Empty; 
            }
        }
        
        private void HostIPsBerechnen(string ipAddress, int cidrSuffix, out string hostIPvon, out string hostIPbis)
        {
            hostIPvon = string.Empty;
            hostIPbis = string.Empty;

            try
            {
                IPAddress ip = IPAddress.Parse(ipAddress);
                byte[] ipBytes = ip.GetAddressBytes();
                byte[] maskBytes = SubnetMaskBytesBerechnen(cidrSuffix);

                byte[] invertedMaskBytes = maskBytes.Select(b => (byte)~b).ToArray();
                byte[] networkBytes = new byte[ipBytes.Length];
                byte[] broadcastBytes = new byte[ipBytes.Length];

                for (int i = 0; i < ipBytes.Length; i++)
                {
                    networkBytes[i] = (byte)(ipBytes[i] & maskBytes[i]);
                    broadcastBytes[i] = (byte)(ipBytes[i] | invertedMaskBytes[i]);
                }

                networkBytes[networkBytes.Length - 1]++;
                broadcastBytes[broadcastBytes.Length - 1]--;

                hostIPvon = new IPAddress(networkBytes).ToString();
                hostIPbis = new IPAddress(broadcastBytes).ToString();
            }
            catch (FormatException)
            { 
                return;
            }
        }
        
        private int AnzahlDerHostsBerechnen(int cidrSuffix)
        {
            return (int)Math.Pow(2, 32 - cidrSuffix) - 2;
        }
        // Kopiert alle werte von den Textboxen
        private void buttonCopy_Click(object sender, EventArgs e)
        {
            string allText = ErstelleErgebnisseString();
            Clipboard.SetText(allText);
        }

        private void buttonLetzteBerechnungAnsehen_Click(object sender, EventArgs e)
        {
            if (File.Exists("berechnungen.xml"))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("berechnungen.xml");

                XmlNode lastCalculationNode = xmlDoc.SelectSingleNode("/Berechnungen/Berechnung[last()]");

                if (lastCalculationNode != null)
                {
                    // Setze die Werte in die entsprechenden Textboxen
                    textBoxIP_Adresse.Text = lastCalculationNode.SelectSingleNode("IPAdresse").InnerText;
                    textBoxNetzwerkmask.Text = lastCalculationNode.SelectSingleNode("Netzwerkmaske").InnerText;
                    textBoxInverseNetzwerkmask.Text = lastCalculationNode.SelectSingleNode("InverseNetzwerkmaske").InnerText;
                    textBoxNetzadresse.Text = lastCalculationNode.SelectSingleNode("Netzadresse").InnerText;
                    textBoxBroadcast.Text = lastCalculationNode.SelectSingleNode("Broadcast").InnerText;
                    textBoxHostIPSvon.Text = lastCalculationNode.SelectSingleNode("HostIPvon").InnerText;
                    textBoxBis.Text = lastCalculationNode.SelectSingleNode("HostIPbis").InnerText;
                    textBoxAnzahlHosts.Text = lastCalculationNode.SelectSingleNode("AnzahlHosts").InnerText;

                    // Setze den CIDR-Wert in die ComboBox
                    int cidrSuffix;
                    if (int.TryParse(lastCalculationNode.SelectSingleNode("CIDRSuffix")?.InnerText, out cidrSuffix))
                    {
                        comboBoxCIDR_Suffix.Text = cidrSuffix.ToString();
                    }

                    MessageBox.Show("Letzte Berechnung erfolgreich geladen.", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Es wurde noch keine Berechnung durchgeführt.", "Hinweis", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Es wurde noch keine Berechnung durchgeführt.", "Hinweis", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //Setzt den Hintergrund Schwarz, Labels Weiß und Buttons Schwarz
        private void dunkelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(31, 31, 31);
            this.ForeColor = Color.White;
            UpdateButtonStyles(this, Color.Black);
            statusStripEinstlleungInfo.BackColor = Color.FromArgb(31, 31, 31);
            statusStripEinstlleungInfo.ForeColor = Color.White; 

        }
        //Setzt den Hintergrund, Labels und Buttons Zurück
        private void hellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = SystemColors.Control;
            this.ForeColor = SystemColors.ControlText;
            UpdateButtonStyles(this, SystemColors.ControlText);
            statusStripEinstlleungInfo.BackColor = SystemColors.Control;
            statusStripEinstlleungInfo.ForeColor = SystemColors.ControlText;
        }
        //Setzt den Hintergrund Rot, Labels Weiß und Buttons Schwarz
        private void rotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(150, 0, 0);
            this.ForeColor = Color.White;
            UpdateButtonStyles(this, Color.Black);
            statusStripEinstlleungInfo.BackColor = Color.FromArgb(150, 0, 0);
            statusStripEinstlleungInfo.ForeColor = Color.White;
        }
        //Setzt den Hintergrund Grün, Labels Weiß und Buttons Schwarz
        private void grünToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(0, 150, 0);
            this.ForeColor = Color.White;
            UpdateButtonStyles(this, Color.Black);
            statusStripEinstlleungInfo.BackColor = Color.FromArgb(0, 150, 0);
            statusStripEinstlleungInfo.ForeColor = Color.White;
        }
        //Setzt den Hintergrund Blau, Labels Weiß und Buttons Schwarz
        private void blauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(0, 0, 150);
            this.ForeColor = Color.White;
            UpdateButtonStyles(this, Color.Black);
            statusStripEinstlleungInfo.BackColor = Color.FromArgb(0, 0, 150);
            statusStripEinstlleungInfo.ForeColor = Color.White;
        }

        private void statusStripEinstlleungInfo_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        //Zeigt den Icon der Taskbar an und Deaktivert FormIcon sowie den SizingGrip vom StatusSrip
        private void ViewNetzwerkRechner_Load(object sender, EventArgs e)
        {
            this.statusStripEinstlleungInfo.SizingGrip = false;
            ShowInTaskbar = true;
            
        }

        private void comboBoxCIDR_Suffix_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
