using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationClient {
    public static class ServiceWindow { 
        /// <summary>
        /// 服务
        /// </summary>
        public static ServiceReference1.Service1Client Service {
            get {
                if (_service.State != System.ServiceModel.CommunicationState.Opened) {
                    try {
                        _service.Open();
                    } catch (Exception) {
                        throw;
                    }
                }
                return _service; 
            }
        }
        private static ServiceReference1.Service1Client _service = new ServiceReference1.Service1Client();

    }
}
