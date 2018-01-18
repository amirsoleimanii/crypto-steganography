using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reciever
{
    public partial class Form1 : Form
    {
        string pm = "";
       UdpClient udpClient = new UdpClient(8080);
        public Form1()
        {
            InitializeComponent();
            TextBox.CheckForIllegalCrossThreadCalls = false;
            Thread thdUDPServer = new Thread(new
            ThreadStart(serverThread));
            thdUDPServer.Start();

           
        }

        public void serverThread()
        {
            DateTime first = new DateTime();
            DateTime second = new DateTime();

            int counter = 0;
            while (true)
            {
                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
                Byte[] receiveBytes = udpClient.Receive(ref RemoteIpEndPoint);
                counter++;
                if (counter % 2 == 1)
                    first = DateTime.Now;
                else
                {
                    second = DateTime.Now;
                    if((second-first).TotalSeconds < 10)
                    {
                        pm += "1";
                        textBox1.Text = pm;
                    }
                    else
                    {
                        pm += "0";
                        textBox1.Text = pm;
                    }
                }

                

            }
        }


    }
}
