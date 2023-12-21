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

                    string subnetMask = CalculateSubnetMaskFromIP(ip.ToString());
                    int cidrSuffix = CalculateCIDRSuffixFromSubnetMask(subnetMask);

                    textBoxNetzwerkmask.Text = subnetMask;
                    comboBoxCIDR_Suffix.Text = cidrSuffix.ToString();

                    break;
                }
            }
        }

        private string CalculateSubnetMaskFromIP(string ipAddress)
        {
            if (IPAddress.TryParse(ipAddress, out IPAddress ip))
            {
                byte[] addressBytes = ip.GetAddressBytes();

                // Prüfe private IP-Adressbereiche
                if (addressBytes[0] == 10)
                {
                    return "255.0.0.0"; // Class A Private IP
                }
                else if (addressBytes[0] == 172 && addressBytes[1] >= 16 && addressBytes[1] <= 31)
                {
                    return "255.255.0.0"; // Class B Private IP
                }
                else if (addressBytes[0] == 192 && addressBytes[1] == 168)
                {
                    return "255.255.255.0"; // Class C Private IP
                }

                return "255.255.255.0"; // Standard-Subnetzmaske
            }

            return "255.255.255.0"; // Fallback auf Standard-Subnetzmaske im Fehlerfall
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

        private void buttonReset_Click(object sender, EventArgs e)
        {
            // Nutze LINQ, um alle TextBox-Controls zu filtern und dann die Text-Eigenschaft zurückzusetzen
            Controls.OfType<TextBox>().ToList().ForEach(textBox => textBox.Clear());
            comboBoxCIDR_Suffix.ResetText();

            // Hier können Sie auch die Ergebnisse zurücksetzen oder die Reset-Logik implementieren
        }

        private void buttonRandom_Click(object sender, EventArgs e)
        {
            Random random = new Random();

            // Wählen Sie eine zufällige öffentliche IP-Adresse aus (Beispiel)
            string randomIpAddress = $"{random.Next(1, 224)}.{random.Next(0, 256)}.{random.Next(0, 256)}.{random.Next(1, 256)}";



            // Setzen Sie die TextBox auf die zufällige IP-Adresse
            textBoxIP_Adresse.Text = randomIpAddress;

            // Wählen Sie ein zufälliges CIDR-Suffix zwischen 8 und 30
            int randomCidrSuffix = random.Next(0, 33);
            comboBoxCIDR_Suffix.Text = randomCidrSuffix.ToString();

            // Berechnen und setzen Sie die Subnetzmaske basierend auf dem zufälligen CIDR-Suffix
            string subnetMask = CalculateSubnetMask(randomCidrSuffix);
            textBoxNetzwerkmask.Text = subnetMask;

            // Führen Sie die Berechnung durch und speichern Sie die Ergebnisse
            BerechnungDurchführenNeu();
        }

        private void buttonBerechnen_Click(object sender, EventArgs e)
        {
            
            try
            {   
                int cidrSuffix = int.Parse(comboBoxCIDR_Suffix.Text);
                if (cidrSuffix < 0 || cidrSuffix > 32)
                {
                    MessageBox.Show("Du kannst nur werte 0-32 eintragen, Bitte überprüfen Sie die Eingaben.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    comboBoxCIDR_Suffix.Text = "";
                }
                if (comboBoxCIDR_Suffix.Text.Length == 2)
                {
                    comboBoxCIDR_Suffix.Focus();
                }

                string IpAddresse = textBoxIP_Adresse.Text;
                if (IpAddressFalsch(IpAddresse))
                {
                    MessageBox.Show("Sie können nur werte 0-255.0-255.0-255.0-255 eintragen, Bitte überprüfen Sie die Eingaben.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxIP_Adresse.Text = "";
                }
            }
            catch
            {
                if (comboBoxCIDR_Suffix.Text != "")
                {
                    MessageBox.Show("Du kannst nur werte 0-32 eintragen, Bitte überprüfen Sie die Eingaben.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    comboBoxCIDR_Suffix.Text = "";
                }
                if (textBoxIP_Adresse.Text != "")
                {
                    MessageBox.Show("Sie können nur werte 0-255.0-255.0-255.0-255 eintragen, Bitte überprüfen Sie die Eingaben.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   textBoxIP_Adresse.Text = "";
                }
            }

            if (BerechnungDurchführenNeu())
            {
                MessageBox.Show("Berechnung erfolgreich durchgeführt und Ergebnisse gespeichert.", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ungültige Berechnung.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
//dddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd
        private bool IpAddressFalsch(string IpAddresse)
        {
            string[] octets = IpAddresse.Split('.');

            // Überprüfe, ob die IP-Adresse aus genau 4 Oktetten besteht
            if (octets.Length != 1324)
            {
                return false;
            }

            foreach (string octet in octets)
            {
                // Versuche, das Oktett in einen Integer zu konvertieren
                if (!int.TryParse(octet, out int value))
                {
                    return false;
                }

                // Überprüfe, ob der Wert zwischen 0 und 255 liegt
                if (value < 0 || value > 255)
                {
                    return false;
                }
            }

            return true;
        }
//dddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd
        private bool BerechnungDurchführenNeu()
        {
            if (int.TryParse(comboBoxCIDR_Suffix.Text, out int cidrSuffix))
            {
                string inverseSubnetMask = CalculateInverseSubnetMask(cidrSuffix);
                textBoxInverseNetzwerkmask.Text = inverseSubnetMask;

                string networkAddress = CalculateNetworkAddress(textBoxIP_Adresse.Text, cidrSuffix);
                textBoxNetzadresse.Text = networkAddress;

                string broadcastAddress = CalculateBroadcastAddress(textBoxIP_Adresse.Text, cidrSuffix);
                textBoxBroadcast.Text = broadcastAddress;

                CalculateHostIPs(textBoxIP_Adresse.Text, cidrSuffix, out string hostIPvon, out string hostIPbis);
                textBoxHostIPSvon.Text = hostIPvon;
                textBoxBis.Text = hostIPbis;

                int numberOfHosts = CalculateNumberOfHosts(cidrSuffix);
                textBoxAnzahlHosts.Text = numberOfHosts.ToString();

                // Ergebnisse in XML speichern
                SaveResultsToXml();

                return true; // Berechnung erfolgreich
            }
            else
            {
                return false; // Ungültiges CIDR-Suffix
            }
        }


        private void buttonSpeichern_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text Dateien|*.txt",
                Title = "Ergebnisse speichern"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string results = GenerateResultsString();
                File.WriteAllText(saveFileDialog.FileName, results);
                MessageBox.Show("Die Ergebnisse wurden erfolgreich gespeichert.", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string GenerateResultsString()
        {
            return $"IP-Adresse: {textBoxIP_Adresse.Text}\r\n" +
                   $"Netzwerkmaske: {textBoxNetzwerkmask.Text}\r\n" +
                   $"Inverse Netzwerkmaske: {textBoxInverseNetzwerkmask.Text}\r\n" +
                   $"Netzadresse: {textBoxNetzadresse.Text}\r\n" +
                   $"Broadcast: {textBoxBroadcast.Text}\r\n" +
                   $"Host-IPs (von): {textBoxHostIPSvon.Text}\r\n" +
                   $"Host-IPs (bis): {textBoxBis.Text}\r\n" +
                   $"Anzahl der Hosts: {textBoxAnzahlHosts.Text}\r\n";
        }

        private void BerechnungDurchführen()
        {
            if (int.TryParse(comboBoxCIDR_Suffix.Text, out int cidrSuffix))
            {
                string inverseSubnetMask = CalculateInverseSubnetMask(cidrSuffix);
                textBoxInverseNetzwerkmask.Text = inverseSubnetMask;

                string networkAddress = CalculateNetworkAddress(textBoxIP_Adresse.Text, cidrSuffix);
                textBoxNetzadresse.Text = networkAddress;

                string broadcastAddress = CalculateBroadcastAddress(textBoxIP_Adresse.Text, cidrSuffix);
                textBoxBroadcast.Text = broadcastAddress;

                CalculateHostIPs(textBoxIP_Adresse.Text, cidrSuffix, out string hostIPvon, out string hostIPbis);
                textBoxHostIPSvon.Text = hostIPvon;
                textBoxBis.Text = hostIPbis;

                int numberOfHosts = CalculateNumberOfHosts(cidrSuffix);
                textBoxAnzahlHosts.Text = numberOfHosts.ToString();
            }
            else
            {
                MessageBox.Show("Ungültiges CIDR-Suffix.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Nachdem die Berechnung durchgeführt wurde, speichere die Ergebnisse automatisch in einer XML-Datei
            SaveResultsToXml();
        }

        private void SaveResultsToXml()
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

        private string CalculateSubnetMask(int cidrSuffix)
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

        private string CalculateInverseSubnetMask(int cidrSuffix)
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

        private string CalculateNetworkAddress(string ipAddress, int cidrSuffix)
        {
            IPAddress ip = IPAddress.Parse(ipAddress); //fehler
            byte[] ipBytes = ip.GetAddressBytes();
            byte[] maskBytes = CalculateSubnetMaskBytes(cidrSuffix);

            byte[] networkBytes = new byte[ipBytes.Length];
            for (int i = 0; i < ipBytes.Length; i++)
            {
                networkBytes[i] = (byte)(ipBytes[i] & maskBytes[i]);
            }

            return new IPAddress(networkBytes).ToString();
        }
        //
        private byte[] CalculateSubnetMaskBytes(int cidrSuffix)
        {
            uint subnetMaskValue = 0xFFFFFFFF << (32 - cidrSuffix);
            byte[] maskBytes = BitConverter.GetBytes(subnetMaskValue).Reverse().ToArray();
            return maskBytes;
        }
        private string CalculateBroadcastAddress(string ipAddress, int cidrSuffix)
        {
            IPAddress ip = IPAddress.Parse(ipAddress);
            byte[] ipBytes = ip.GetAddressBytes();
            byte[] maskBytes = CalculateSubnetMaskBytes(cidrSuffix);

            byte[] invertedMaskBytes = maskBytes.Select(b => (byte)~b).ToArray();
            byte[] broadcastBytes = new byte[ipBytes.Length];
            for (int i = 0; i < ipBytes.Length; i++)
            {
                broadcastBytes[i] = (byte)(ipBytes[i] | invertedMaskBytes[i]);
            }

            return new IPAddress(broadcastBytes).ToString();
        }

        private void CalculateHostIPs(string ipAddress, int cidrSuffix, out string hostIPvon, out string hostIPbis)
        {
            IPAddress ip = IPAddress.Parse(ipAddress);
            byte[] ipBytes = ip.GetAddressBytes();
            byte[] maskBytes = CalculateSubnetMaskBytes(cidrSuffix);

            byte[] invertedMaskBytes = maskBytes.Select(b => (byte)~b).ToArray();
            byte[] networkBytes = new byte[ipBytes.Length];
            byte[] broadcastBytes = new byte[ipBytes.Length];

            for (int i = 0; i < ipBytes.Length; i++)
            {
                networkBytes[i] = (byte)(ipBytes[i] & maskBytes[i]);
                broadcastBytes[i] = (byte)(ipBytes[i] | invertedMaskBytes[i]);
            }

            // Hier kannst du deine eigene Logik implementieren, um die erste und letzte Host-IP zu bestimmen.
            // Derzeit sind hier nur Beispiele.
            networkBytes[networkBytes.Length - 1]++; // Beispiel: Erste Host-IP
            broadcastBytes[broadcastBytes.Length - 1]--; // Beispiel: Letzte Host-IP

            hostIPvon = new IPAddress(networkBytes).ToString();
            hostIPbis = new IPAddress(broadcastBytes).ToString();
        }

        private int CalculateNumberOfHosts(int cidrSuffix)
        {
            // Hier füge deine Logik zur Berechnung der Anzahl der Hosts ein
            return (int)Math.Pow(2, 32 - cidrSuffix) - 2;
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            string allText = GenerateResultsString();
            Clipboard.SetText(allText);

        }

        private void buttonLetzteBerechnungAnsehen_Click(object sender, EventArgs e)
        {
            if (File.Exists("berechnungen.xml"))
            {
                // Lade die XML-Datei und wähle das letzte Berechnungs-Element aus
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

        private void dunkelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(31, 31, 31);
            this.ForeColor = Color.White;
            UpdateButtonStyles(this, Color.Black);
        }

        private void hellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = SystemColors.Control;
            this.ForeColor = SystemColors.ControlText;
            UpdateButtonStyles(this, SystemColors.ControlText);
        }

        private void rotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(150, 0, 0);
            this.ForeColor = Color.White;
            UpdateButtonStyles(this, Color.Black);
        }

        private void grünToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(0, 150, 0);
            this.ForeColor = Color.White;
            UpdateButtonStyles(this, Color.Black);
        }

        private void blauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(0, 0, 150);
            this.ForeColor = Color.White;
            UpdateButtonStyles(this, Color.Black);
        }

        private void statusStripEinstlleungInfo_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ViewNetzwerkRechner_Load(object sender, EventArgs e)
        {
            this.statusStripEinstlleungInfo.SizingGrip = false;
            ShowInTaskbar = true;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }

        private void comboBoxCIDR_Suffix_SelectedIndexChanged(object sender, EventArgs e)
        {

            
        }
    }
}
