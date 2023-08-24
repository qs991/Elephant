using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebSocketTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Btn_OpenClient_Click(object sender, EventArgs e)
        {
            ClientTool clientTool = new ClientTool();
            clientTool.Show();
        }

        private void Btn_OpenService_Click(object sender, EventArgs e)
        {
            ServiceTool serviceTool = new ServiceTool();
            serviceTool.Show();
        }
    }
}
