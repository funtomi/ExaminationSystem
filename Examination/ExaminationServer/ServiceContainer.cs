using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationServer {
    public class ServiceContainer {

        /// <summary>
        /// 服务宿主
        /// </summary>
        private ServiceHost _host;
        private static string HOST_ADDRESS = ConfigurationManager.AppSettings["HostAddress"];//宿主地址 

        /// <summary>
        /// 开启服务
        /// </summary>
        public void StartService() {
            try {
                if (_host == null) {
                    _host = new ServiceHost(typeof(WcfServiceLibrary1.Service1));
                    System.ServiceModel.Channels.Binding httpbinding = new BasicHttpBinding();

                    _host.AddServiceEndpoint(typeof(WcfServiceLibrary1.IService1), httpbinding, HOST_ADDRESS);
                    if (_host.Description.Behaviors.Find<System.ServiceModel.Description.ServiceMetadataBehavior>() == null) {
                        ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
                        behavior.HttpGetEnabled = true;

                        behavior.HttpGetUrl = new Uri(HOST_ADDRESS+"/Service1");
                        _host.Description.Behaviors.Add(behavior);

                        _host.Open();
                    }
                }
            } catch (Exception) {
                throw;
            }
        }

        /// <summary>
        /// 关闭服务
        /// </summary>
        public void CloseService() {
            if (_host != null&&_host.State == CommunicationState.Opened) {
                _host.Close();
            }  
        }
    }
}
