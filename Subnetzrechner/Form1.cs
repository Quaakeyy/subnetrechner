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
using System.Windows;
using System.Net.NetworkInformation;




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
            NetworkInterface primaryInterface = GetPrimaryNetworkInterface();
            IPInterfaceProperties ipProperties = primaryInterface.GetIPProperties();


            foreach (UnicastIPAddressInformation ipAddressInfo in ipProperties.UnicastAddresses)
            {
                if (ipAddressInfo.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {

                    IPAddress ipAddress = ipAddressInfo.Address;
                    IPAddress subnetMask = ipAddressInfo.IPv4Mask;

                    textBoxIP_Adresse.Text = ipAddress.ToString();
                    textBoxNetzwerkmask.Text = subnetMask.ToString();
                    break;
                }
            }

        }
        static NetworkInterface GetPrimaryNetworkInterface()
        {
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface networkInterface in networkInterfaces)
            {
                if (networkInterface.OperationalStatus == OperationalStatus.Up && networkInterface.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                {
                    return networkInterface;
                }
            }

            return null;
        }

        private void buttonReset_click(object sender, EventArgs e)
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
        private void buttonRandom_Click(object sender, EventArgs e)
        {
            Random randomIP = new Random();
            int IPspalt1 = randomIP.Next(1, 256);
            int IPspalt2 = randomIP.Next(1, 256);
            int IPspalt3 = randomIP.Next(1, 256);
            int IPspalt4 = randomIP.Next(1, 256);
            textBoxIP_Adresse.Text = Convert.ToString(IPspalt1 + "." +IPspalt2 + "." +IPspalt3 + "." + IPspalt4);
        }

        private void buttonThemes_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(50, 50, 50);
        }
    }
}
