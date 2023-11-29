using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Subnetzrechner
{
    public partial class ViewNetzwerkRechner : Form
    {
        public ViewNetzwerkRechner()
        {
            InitializeComponent();
        }

        private void buttondeine_IP_Click(object sender, EventArgs e)
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    string ipAddress = ip.ToString();

                    // Hier die Subnetzmaske übernehmen (angenommen, es wurde bereits ein CIDR-Suffix ausgewählt)
                    string cidrString = comboBoxCIDR_Suffix.Text;
                    if (int.TryParse(cidrString, out int cidr))
                    {
                        string subnetMask = CalculateSubnetMask(cidr);
                        SetIPAddressAndSubnetMask(ipAddress, subnetMask);
                    }

                    break; // Breche die Schleife nach der ersten gefundenen IP-Adresse ab
                }
            }
        }
        private void SetIPAddressAndSubnetMask(string ipAddress, string subnetMask)
        {
            textBoxIP_Adresse.Text = ipAddress;
            textBoxNetzwerkmask.Text = subnetMask;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            textBoxAnzahlHosts.Clear();
            textBoxbis.Clear();
            textBoxBroadcast.Clear();
            textBoxHostIPSvon.Clear();
            textBoxInverseNetzwerkmask.Clear();
            textBoxIP_Adresse.Clear();
            textBoxNetzadresse.Clear();
            textBoxNetzwerkmask.Clear();
            comboBoxCIDR_Suffix.ResetText();
        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Dateien|*.txt";
            saveFileDialog.Title = "Ergebnisse speichern";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                // Speichere die Ergebnisse in die ausgewählte Datei
                File.WriteAllText(saveFileDialog.FileName, GetResults());
                MessageBox.Show("Die Ergebnisse wurden erfolgreich gespeichert.", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonRechnen_Click(object sender, EventArgs e)
        {

            // Holen Sie die eingegebenen Werte
            string ipAddressString = textBoxIP_Adresse.Text;
            string cidrString = comboBoxCIDR_Suffix.Text;

            // Überprüfen Sie die Gültigkeit der eingegebenen IP-Adresse und CIDR-Suffix
            if (IPAddress.TryParse(ipAddressString, out IPAddress ipAddress) && int.TryParse(cidrString, out int cidr))
            {
                // Berechnen Sie Subnetzmaske, inverse Netzwerkmaske und Anzahl der Hosts
                var subnetMask = CalculateSubnetMask(cidr);
                var inverseSubnetMask = CalculateInverseSubnetMask(cidr);
                var numberOfHosts = CalculateNumberOfHosts(cidr);

                // Zeigen Sie die Ergebnisse in den entsprechenden Textfeldern an
                textBoxNetzwerkmask.Text = subnetMask;
                textBoxInverseNetzwerkmask.Text = inverseSubnetMask;
                textBoxAnzahlHosts.Text = numberOfHosts.ToString();

                // Weitere Ergebnisse hier entsprechend anzeigen
            }
            else
            {
                // Zeigen Sie eine Fehlermeldung an, wenn die Eingabe ungültig ist
                MessageBox.Show("Ungültige Eingabe. Überprüfen Sie die IP-Adresse und das CIDR-Suffix.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayResult(TextBox textBox, string label, string value)
        {
            textBox.Text = $"{label}: {value}";
        }
        private string CalculateSubnetMask(int cidr)
        {
            uint subnetMask = uint.MaxValue << (32 - cidr);
            Console.WriteLine($"Calculated subnetMask value: {subnetMask}");

            IPAddress ipAddress = new IPAddress(BitConverter.GetBytes(subnetMask));
            Console.WriteLine($"IPAddress from subnetMask: {ipAddress}");

            return ipAddress.ToString();
        }

        private string CalculateInverseSubnetMask(int cidr)
        {
            uint subnetMask = uint.MaxValue << (32 - cidr);
            uint inverseSubnetMask = ~subnetMask;

            return new IPAddress(BitConverter.GetBytes(inverseSubnetMask)).ToString();
        }

        private int CalculateNumberOfHosts(int cidr)
        {
            return (int)Math.Pow(2, 32 - cidr) - 2;
        }

        private void CalculateFromSubnetMask(string subnetMask)
        {
            updatingTextbox = true;

            // Hier kannst du die benötigten Berechnungen durchführen
            // Beispiel: Anzeigen der Subnetzmaske im TextBox-Feld
            lastCalculatedValue = subnetMask;
            textBoxNetzwerkmask.Text = subnetMask;

            updatingTextbox = false;
            // Weitere Berechnungen hier durchführen und die Ergebnisse anzeigen
        }

        private string lastCalculatedValue = string.Empty;
        private bool updatingTextbox = false;



        // Methode, um alle Ergebnisse abzurufen und für die Speicherung zu verwenden
        private string GetResults()
        {
            // Hier kannst du alle Ergebnisse abrufen und zurückgeben
            string results = "";
            results += $"IP-Adresse: {textBoxIP_Adresse.Text}\r\n";
            results += $"Subnetzmaske: {textBoxNetzwerkmask.Text}\r\n";
            results += $"Anzahl der Hosts: {textBoxAnzahlHosts.Text}\r\n";
            // Weitere Ergebnisse hier hinzufügen

            return results;
        }

        private bool suppressTextChangedEvent = false;
        private bool calculating = false;
        private void textBoxNetzwerkmask_TextChanged(object sender, EventArgs e)
        {
            if (!updatingTextbox)
            {
                string userEnteredSubnetMask = textBoxNetzwerkmask.Text;

                if (!string.IsNullOrWhiteSpace(userEnteredSubnetMask))
                {
                    CalculateFromSubnetMask(userEnteredSubnetMask);
                }
                else
                {
                    textBoxNetzwerkmask.Text = string.Empty;
                }
            }
        }
    }
}
