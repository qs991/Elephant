namespace WebSocketTool
{
    partial class ClientTool
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
            this.Btn_SendMessage = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_Servicepath = new System.Windows.Forms.TextBox();
            this.tb_port = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_Recivemessage = new System.Windows.Forms.TextBox();
            this.tb_sendMessage = new System.Windows.Forms.TextBox();
            this.Btn_JoinService = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Btn_SendMessage
            // 
            this.Btn_SendMessage.Location = new System.Drawing.Point(656, 432);
            this.Btn_SendMessage.Name = "Btn_SendMessage";
            this.Btn_SendMessage.Size = new System.Drawing.Size(121, 60);
            this.Btn_SendMessage.TabIndex = 0;
            this.Btn_SendMessage.Text = "发送";
            this.Btn_SendMessage.UseVisualStyleBackColor = true;
            this.Btn_SendMessage.Click += new System.EventHandler(this.Btn_SendMessage_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "服务器：";
            // 
            // tb_Servicepath
            // 
            this.tb_Servicepath.Location = new System.Drawing.Point(116, 69);
            this.tb_Servicepath.Name = "tb_Servicepath";
            this.tb_Servicepath.Size = new System.Drawing.Size(162, 21);
            this.tb_Servicepath.TabIndex = 2;
            // 
            // tb_port
            // 
            this.tb_port.Location = new System.Drawing.Point(355, 69);
            this.tb_port.Name = "tb_port";
            this.tb_port.Size = new System.Drawing.Size(162, 21);
            this.tb_port.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(308, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "端口：";
            // 
            // tb_Recivemessage
            // 
            this.tb_Recivemessage.Location = new System.Drawing.Point(12, 136);
            this.tb_Recivemessage.Multiline = true;
            this.tb_Recivemessage.Name = "tb_Recivemessage";
            this.tb_Recivemessage.Size = new System.Drawing.Size(765, 259);
            this.tb_Recivemessage.TabIndex = 5;
            // 
            // tb_sendMessage
            // 
            this.tb_sendMessage.Location = new System.Drawing.Point(12, 415);
            this.tb_sendMessage.Multiline = true;
            this.tb_sendMessage.Name = "tb_sendMessage";
            this.tb_sendMessage.Size = new System.Drawing.Size(627, 104);
            this.tb_sendMessage.TabIndex = 6;
            // 
            // Btn_JoinService
            // 
            this.Btn_JoinService.Location = new System.Drawing.Point(604, 57);
            this.Btn_JoinService.Name = "Btn_JoinService";
            this.Btn_JoinService.Size = new System.Drawing.Size(92, 42);
            this.Btn_JoinService.TabIndex = 0;
            this.Btn_JoinService.Text = "加入聊天";
            this.Btn_JoinService.UseVisualStyleBackColor = true;
            this.Btn_JoinService.Click += new System.EventHandler(this.Btn_JoinService_Click);
            // 
            // ClientTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 548);
            this.Controls.Add(this.tb_sendMessage);
            this.Controls.Add(this.tb_Recivemessage);
            this.Controls.Add(this.tb_port);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_Servicepath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btn_JoinService);
            this.Controls.Add(this.Btn_SendMessage);
            this.Name = "ClientTool";
            this.Text = "客户端";
            this.Load += new System.EventHandler(this.ClientTool_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_SendMessage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_Servicepath;
        private System.Windows.Forms.TextBox tb_port;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_Recivemessage;
        private System.Windows.Forms.TextBox tb_sendMessage;
        private System.Windows.Forms.Button Btn_JoinService;
    }
}