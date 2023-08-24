using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebSocketTool
{
    public partial class ClientTool : Form
    {
        public ClientTool()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        /// <summary>
        /// 定义socket连接
        /// </summary>
        private System.Net.Sockets.Socket socket;
        /// <summary>
        /// 客服端初始化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClientTool_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 加入聊天室
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_JoinService_Click(object sender, EventArgs e)
        {
            // 协议 字节流 IPv4连接
            socket = new System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Stream, System.Net.Sockets.ProtocolType.IP);
            System.Net.IPAddress ip = System.Net.IPAddress.Parse(this.tb_Servicepath.Text);
            System.Net.IPEndPoint endPoint = new System.Net.IPEndPoint(ip, int.Parse(this.tb_port.Text));
            socket.Connect(endPoint);//进行连接服务端

            Thread th = new Thread(RecvieMessage) { IsBackground = true };
            th.Start(socket);
        }
        /// <summary>
        /// 接收消息  不断去尝试接收信息
        /// </summary>
        public void RecvieMessage(object o)
        {
            System.Net.Sockets.Socket client = o as System.Net.Sockets.Socket;
            while (true)
            {
                try
                {
                    //定义客户端接收数据的大小
                    byte[] arrList = new byte[1024 * 1024];
                    //接收信息的大小
                    int recLength = client.Receive(arrList);
                    if (recLength > 0)
                    {
                        this.tb_Recivemessage.AppendText($"\r\n{DateTime.Now.ToString()},{Encoding.UTF8.GetString(arrList, 0, recLength)}");
                    }
                }
                catch (Exception ee)
                {

                    client.Close();
                    tb_Recivemessage.AppendText($"\r\n客服端接受信息出现错误{ee.Message}");

                }
            }
        }
        /// <summary>
        /// 发送信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_SendMessage_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(SendMessage) { IsBackground = true };
            th.Start();
        }
        /// <summary>
        /// 发送消息
        /// </summary>
        public void SendMessage()
        {
            if (!string.IsNullOrWhiteSpace(this.tb_sendMessage.Text))
            {
                byte[] sendMsg = Encoding.UTF8.GetBytes(this.tb_sendMessage.Text);
                socket.Send(sendMsg);
                this.tb_sendMessage.Text = "";//发送完毕后消息清空!
            }
        }
    }
}
