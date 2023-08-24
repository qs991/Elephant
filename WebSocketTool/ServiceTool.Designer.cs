namespace WebSocketTool
{
    partial class ServiceTool
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_sendMessage = new System.Windows.Forms.TextBox();
            this.tb_Recivemessage = new System.Windows.Forms.TextBox();
            this.tb_port = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_Servicepath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_ConnectionService = new System.Windows.Forms.Button();
            this.Btn_SendMessage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_sendMessage
            // 
            this.tb_sendMessage.Location = new System.Drawing.Point(12, 398);
            this.tb_sendMessage.Multiline = true;
            this.tb_sendMessage.Name = "tb_sendMessage";
            this.tb_sendMessage.Size = new System.Drawing.Size(627, 104);
            this.tb_sendMessage.TabIndex = 14;
            // 
            // tb_Recivemessage
            // 
            this.tb_Recivemessage.Location = new System.Drawing.Point(12, 111);
            this.tb_Recivemessage.Multiline = true;
            this.tb_Recivemessage.Name = "tb_Recivemessage";
            this.tb_Recivemessage.Size = new System.Drawing.Size(765, 259);
            this.tb_Recivemessage.TabIndex = 13;
            // 
            // tb_port
            // 
            this.tb_port.Location = new System.Drawing.Point(355, 44);
            this.tb_port.Name = "tb_port";
            this.tb_port.Size = new System.Drawing.Size(162, 21);
            this.tb_port.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(308, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "端口：";
            // 
            // tb_Servicepath
            // 
            this.tb_Servicepath.Location = new System.Drawing.Point(116, 44);
            this.tb_Servicepath.Name = "tb_Servicepath";
            this.tb_Servicepath.Size = new System.Drawing.Size(162, 21);
            this.tb_Servicepath.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "服务器：";
            // 
            // Btn_ConnectionService
            // 
            this.Btn_ConnectionService.Location = new System.Drawing.Point(604, 32);
            this.Btn_ConnectionService.Name = "Btn_ConnectionService";
            this.Btn_ConnectionService.Size = new System.Drawing.Size(92, 42);
            this.Btn_ConnectionService.TabIndex = 7;
            this.Btn_ConnectionService.Text = "创建聊天室";
            this.Btn_ConnectionService.UseVisualStyleBackColor = true;
            this.Btn_ConnectionService.Click += new System.EventHandler(this.Btn_ConnectionService_Click);
            // 
            // Btn_SendMessage
            // 
            this.Btn_SendMessage.Location = new System.Drawing.Point(656, 411);
            this.Btn_SendMessage.Name = "Btn_SendMessage";
            this.Btn_SendMessage.Size = new System.Drawing.Size(121, 60);
            this.Btn_SendMessage.TabIndex = 8;
            this.Btn_SendMessage.Text = "发送";
            this.Btn_SendMessage.UseVisualStyleBackColor = true;
            this.Btn_SendMessage.Click += new System.EventHandler(this.Btn_SendMessage_Click);
            // 
            // ServiceTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 553);
            this.Controls.Add(this.tb_sendMessage);
            this.Controls.Add(this.tb_Recivemessage);
            this.Controls.Add(this.tb_port);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_Servicepath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btn_ConnectionService);
            this.Controls.Add(this.Btn_SendMessage);
            this.Name = "ServiceTool";
            this.Text = "服务端";
            this.Load += new System.EventHandler(this.ServiceTool_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_sendMessage;
        private System.Windows.Forms.TextBox tb_Recivemessage;
        private System.Windows.Forms.TextBox tb_port;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_Servicepath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btn_ConnectionService;
        private System.Windows.Forms.Button Btn_SendMessage;
    }
}