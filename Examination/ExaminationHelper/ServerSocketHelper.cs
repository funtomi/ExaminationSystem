using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExaminationServer {
    public class ServerSocketHelper {
        private static string IP_ADDRESS = ConfigurationManager.AppSettings["IpAddress"];
        private static int END_POINT = Convert.ToInt32(ConfigurationManager.AppSettings["EndPoint"]);
        //创建套接字  
        IPEndPoint _ipe = new IPEndPoint(IPAddress.Parse(IP_ADDRESS), END_POINT);
        Socket _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public void Start()  
        {   
            //绑定端口和IP  
            _socket.Bind(_ipe);  
            //设置监听  
            _socket.Listen(10);
            Thread th = new Thread(StartToReceive);
            th.IsBackground = true;
            th.Start();
            //连接客户端  
            //AsyncAccept(socket);  
        }

        private void StartToReceive() { 
            byte[] recvBytes = new byte[50];

            //由于long占8位字节，所以先获取前8位字节数据
            IAsyncResult iar = _socket.BeginReceive(
                recvBytes,
                0,
                recvBytes.Length,
                SocketFlags.None,
                null,
                null);
            int len = _socket.EndReceive(iar);
            string receivemMsg = Encoding.ASCII.GetString(recvBytes, 0, len);
            if (receivemMsg.IndexOf("heartBeat") > 0)//区分业务消息和心跳检测消息
            {
                _socket.Send(Encoding.ASCII.GetBytes("1"));//回应心跳包 
                StartToReceive();//回应心跳包完成之后继续等待接收
            } else if (receivemMsg == "serviceName")//如果收到这个请求，告诉客户端可以开始发送第一张图片了
            { 
                string order = "0";
                byte[] orderdata = Encoding.ASCII.GetBytes(order);   //把字符串编码为字节
                _socket.Send(Encoding.ASCII.GetBytes("1"));
                recvBytes = new byte[8]; //开始接收图片
                StartToReceive();//回应指令后完成之后继续等待接收
            }  
        }  
  
        /// <summary>  
        /// 连接到客户端  
        /// </summary>  
        /// <param name="socket"></param>  
        private void AsyncAccept(Socket socket)  
        {  
            socket.BeginAccept(asyncResult =>  
            {  
                //获取客户端套接字  
                Socket client = socket.EndAccept(asyncResult);   
                AsyncSend(client, "服务器收到连接请求");  
                AsyncSend(client, string.Format("欢迎你{0}",client.RemoteEndPoint));  
                AsyncReveive(client);  
            }, null);  
        }  
  
        /// <summary>  
        /// 接收消息  
        /// </summary>  
        /// <param name="client"></param>  
        private void AsyncReveive(Socket socket)  
        {  
            byte[] data = new byte[1024];  
            try  
            {  
                //开始接收消息  
                socket.BeginReceive(data, 0, data.Length, SocketFlags.None,  
                asyncResult =>  
                {  
                    int length = socket.EndReceive(asyncResult);  
                    //Console.WriteLine(string.Format("客户端发送消息:{0}", Encoding.UTF8.GetString(data)));  
                }, null);  
            }  
            catch (Exception ex)  
            {  
                Console.WriteLine(ex.Message);  
            }  
        }  
  
        /// <summary>  
        /// 发送消息  
        /// </summary>  
        /// <param name="client"></param>  
        /// <param name="p"></param>  
        public void AsyncSend(Socket client, string p)  
        {  
            if (client == null || p == string.Empty) return;  
            //数据转码  
            byte[] data = new byte[1024];  
            data = Encoding.UTF8.GetBytes(p);  
            try  
            {  
                //开始发送消息  
                client.BeginSend(data, 0, data.Length, SocketFlags.None, asyncResult =>  
                {  
                    //完成消息发送  
                    int length = client.EndSend(asyncResult);  
                    //输出消息  
                    //Console.WriteLine(string.Format("服务器发出消息:{0}", p));  
                }, null);  
            }  
            catch (Exception e)  
            {  
                Console.WriteLine(e.Message);  
            }  
        }  
    }
}
