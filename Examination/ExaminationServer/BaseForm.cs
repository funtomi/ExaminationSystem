using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExaminationServer {
    public partial class BaseForm : Form {
        ServiceHost Host;
        public BaseForm() {
            InitializeComponent();
        }

        private void BaseForm_Load(object sender, EventArgs e) {
            skinEngine1.SkinFile = "MSN.ssk";
            //Thread newThread = new Thread(ClientListen);
            //newThread.IsBackground = true;
            //newThread.Start();
        }

        private void ClientListen() {
            ServerSocketHelper socket = new ServerSocketHelper();
            socket.Start(); 
        }

        private void button1_Click(object sender, EventArgs e) {
            if (Host == null) {
                Host = new ServiceHost(typeof(WcfServiceLibrary1.Service1));

                System.ServiceModel.Channels.Binding httpbinding = new BasicHttpBinding();

                Host.AddServiceEndpoint(typeof(WcfServiceLibrary1.IService1), httpbinding, "http://localhost:8002");
                if (Host.Description.Behaviors.Find<System.ServiceModel.Description.ServiceMetadataBehavior>() == null) {
                    ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
                    behavior.HttpGetEnabled = true;

                    behavior.HttpGetUrl = new Uri("http://localhost:8002/Service1");
                    Host.Description.Behaviors.Add(behavior);

                    Host.Open();

                    MessageBox.Show("OK");
                } 

            }  
        }

        private void BaseForm_FormClosed(object sender, FormClosedEventArgs e) {
            if (Host != null) {
                Host.Close();
            }  
        }
    }
}
