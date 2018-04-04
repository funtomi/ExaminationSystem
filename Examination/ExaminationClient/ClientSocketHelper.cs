﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationClient {
    class ClientSocketHelper {
        private static string IP_ADDRESS = ConfigurationManager.AppSettings["IpAddress"];
        private static int END_POINT = Convert.ToInt32(ConfigurationManager.AppSettings["EndPoint"]);
        /// <summary>  
        /// 连接到服务器  
        /// </summary>  
        public void AsynConnect() {
            //端口及IP  
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse(IP_ADDRESS),END_POINT);
            //创建套接字  
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //开始连接到服务器  
            client.BeginConnect(ipe, asyncResult => {
                client.EndConnect(asyncResult);
                //向服务器发送消息  
                AsynSend(client, "你好我是客户端");
                AsynSend(client, "第一条消息");
                AsynSend(client, "第二条消息");
                //接受消息  
                AsynRecive(client);
            }, null);
        }

        /// <summary>  
        /// 发送消息  
        /// </summary>  
        /// <param name="socket"></param>  
        /// <param name="message"></param>  
        public void AsynSend(Socket socket, string message) {
            if (socket == null || message == string.Empty) return;
            //编码  
            byte[] data = Encoding.UTF8.GetBytes(message);
            try {
                socket.BeginSend(data, 0, data.Length, SocketFlags.None, asyncResult => {
                    //完成发送消息  
                    int length = socket.EndSend(asyncResult);
                    Console.WriteLine(string.Format("客户端发送消息:{0}", message));
                }, null);
            } catch (Exception ex) {
                Console.WriteLine("异常信息：{0}", ex.Message);
            }
        }

        /// <summary>  
        /// 接收消息  
        /// </summary>  
        /// <param name="socket"></param>  
        public void AsynRecive(Socket socket) {
            byte[] data = new byte[1024];
            try {
                //开始接收数据  
                socket.BeginReceive(data, 0, data.Length, SocketFlags.None,
                asyncResult => {
                    int length = socket.EndReceive(asyncResult);
                    Console.WriteLine(string.Format("收到服务器消息:{0}", Encoding.UTF8.GetString(data)));
                    AsynRecive(socket);
                }, null);
            } catch (Exception ex) {
                Console.WriteLine("异常信息：", ex.Message);
            }
        }  
    }
}
