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

namespace Subnetzrechner
{
    public partial class ViewNetzwerkRechner : Form
    {
        private int a;
        private int b;
        private int c;
        private int d;

        public ViewNetzwerkRechner()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ViewNetzwerkRechner_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void buttondeine_IP_Click(object sender, EventArgs e)
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                   textBoxIP_Adresse.Text = ip.ToString();
                }
            }
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
            comboBoxCIDR_Suffix.Items.Clear();
            comboBoxCIDR_Suffix.ResetText();
        }

        private void buttonRandom_Click(object sender, EventArgs e)
        {
            Random randomIP = new Random();
            int IPspalt1 = randomIP.Next(1,256);
            IPspalt1 = a;
            int IPspalt2 = randomIP.Next(1,256);
            IPspalt2 = b;
            int IPspalt3 = randomIP.Next(1,256);
            IPspalt3 = c;
            int IPspalt4 = randomIP.Next(1,256);
            IPspalt4 = d;
            textBoxIP_Adresse.Text = randomIP.ToString(a,".",b,".");
        }
    }
}
