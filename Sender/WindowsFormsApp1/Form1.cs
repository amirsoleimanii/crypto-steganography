using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sender
{
    public partial class Form1 : Form
    {
        string pm = "11101100";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pm = txtbHost.Text;
            UdpClient udpClient = new UdpClient();
            udpClient.DontFragment = true;
            udpClient.Connect(txtbHost.Text, 8080);
            Byte[] senddata = Encoding.ASCII.GetBytes("Hello World");

            for (int i = 0; i < pm.Length; i++)
            {
                if (pm[i] == '1')
                {
                    udpClient.Send(senddata, senddata.Length);
                    udpClient.Send(senddata, senddata.Length);
                }
                else
                {
                    udpClient.Send(senddata, senddata.Length);
                    Thread.Sleep(15000);
                    udpClient.Send(senddata, senddata.Length);
                }
            }

          
        }
    }
}
