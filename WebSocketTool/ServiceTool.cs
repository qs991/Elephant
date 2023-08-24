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
using System.Windows.Forms.VisualStyles;

namespace WebSocketTool
{
    public partial class ServiceTool : Form
    {
        public ServiceTool()
        {

            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        /// <summary>
        /// 加载事件 加载IP地址
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ServiceTool_Load(object sender, EventArgs e)
        {
            var ip = IPAddress.Any.ToString();
            this.tb_Servicepath.Text = ip;
        }

        //创建字典 来存放服务端和客服端之间的连接
        Dictionary<string, System.Net.Sockets.Socket> clientList = new Dictionary<string, System.Net.Sockets.Socket>();
        /// <summary>
        /// 开始创建连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ConnectionService_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(CreateStocket) { IsBackground = true };
            th.Start();
        }
        /// <summary>
        /// 创建连接的方法
        /// </summary>
        public void CreateStocket()
        {
            if (string.IsNullOrWhiteSpace(this.tb_Servicepath.Text) || string.IsNullOrWhiteSpace(this.tb_port.Text))
            {
                tb_Recivemessage.AppendText("\r\n服务器地址或者端口不能为空！");
                return;
            }
            //创建服务端电话
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            //创建手机卡
            IPAddress ip = IPAddress.Parse(this.tb_Servicepath.Text);
            IPEndPoint iPEndPoint = new IPEndPoint(ip, int.Parse(this.tb_port.Text));
            //将电话卡插入手机中
            server.Bind(iPEndPoint);
            //开始监听电话卡
            server.Listen(50);//同一时刻允许最大加入数量
            tb_Recivemessage.AppendText("\r\n服务端启动成功!");
            while (true)
            {
                //接受介入的客户端
                Socket client = server.Accept();
                if (client != null)
                {
                    string infor = client.RemoteEndPoint.ToString();//获取远程节点
                    clientList.Add(infor, client);//保存连接
                    tb_Recivemessage.AppendText("\r\n接入服务器成功!");
                    //服务器发送消息至客服端
                    string message = $@"[{infor}]已成功加入聊天室!";
                    SendMsg(message);//发送信息
                    //每一个客服端接入都是一个新的线程
                    Thread clineth = new Thread(RecvieMsg) { IsBackground = true };
                    clineth.Start(client);
                }
                else
                {
                    tb_Recivemessage.AppendText("\r\n接收客服端失败!");
                }
            }
        }
        /// <summary>
        /// 接收客服发送到服务端的信息
        /// </summary>
        public void RecvieMsg(object o)
        {
            Socket client = o as Socket;
            while (true)
            {
                try
                {
                    //定义服务器接收数据的大小
                    byte[] arrMessage = new byte[1024 * 1024];
                    //接收到信息的大小
                    int recLength = client.Receive(arrMessage);
                    if (recLength > 0)
                    {
                        string recMsg = Encoding.UTF8.GetString(arrMessage, 0, recLength);
                        //获取客服端端口号
                        IPEndPoint endpoint = client.RemoteEndPoint as IPEndPoint;
                        //服务器显示客服端端口号和消息
                        tb_Recivemessage.AppendText($"\r\n{DateTime.Now.ToString()},{endpoint.Port.ToString()}:{recMsg}");
                        //服务端发送接收到的消息到客服端
                        SendMsg($"{endpoint.Port.ToString()}:{recMsg}");
                    }

                }
                catch (Exception ee)
                {
                    //关闭客服端
                    client.Close();
                    //移除添加在字典的中的服务端和客户端之间的连接
                    clientList.Remove(client.RemoteEndPoint.ToString());
                    tb_Recivemessage.AppendText($"\r\n接收信息出现错误:{ee.Message}");
                }
            }
        }
        /// <summary>
        /// 发送信息
        /// </summary>
        public void SendMsg(string msg)
        {
            //遍历出字典中的所有线程 
            foreach (var item in clientList)
            {
                byte[] sendMsg = Encoding.UTF8.GetBytes(msg);//以字节的形式进行发送
                item.Value.Send(sendMsg);
            }
        }
        /// <summary>
        /// 发送信息事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_SendMessage_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(SendMessage) { IsBackground = true };
            th.Start();
        }
        public void SendMessage()
        {
            if (!string.IsNullOrWhiteSpace(this.tb_sendMessage.Text))
            {

                SendMsg(this.tb_sendMessage.Text);
                this.tb_sendMessage.Text = "";
            }
        }
    }
}
