using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Alchemy;
using Alchemy.Classes;
using System.Net;


namespace AlchameyWebsoket
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var aServer = new WebSocketServer(81, IPAddress.Any)
            {

                OnReceive = OnReceive,
                OnSend = OnSend,
                OnConnect = OnConnect,
                OnConnected = OnConnected,
                OnDisconnect = OnDisconnect,
                TimeOut = new TimeSpan(0, 5, 0)
            };
            richTextBox1.AppendText("Initializing......");
            aServer.Start();

        }

        private void OnDisconnect(UserContext context)
        {
            richTextBox1.AppendText("OnDisconnect.....");
            
        }

        private void OnConnect(UserContext context)
        {
            
            Invoke(new Action(() => richTextBox1.AppendText("OnConnect.............")));
        }

        private void OnSend(UserContext context)
        {
           
            Invoke(new Action(() => richTextBox1.AppendText("OnSend..............\n")));
        }

        private void OnReceive(UserContext context)
        {
            Invoke(new Action(() => richTextBox1.AppendText("OnReceive.....  "+context.DataFrame )));
            context.Send("hi");
        }
        private void OnConnected(UserContext context)
        {
            
            Invoke(new Action(() => richTextBox1.AppendText("Client Connection From : " + context.ClientAddress.ToString())));
        }
    }
}
