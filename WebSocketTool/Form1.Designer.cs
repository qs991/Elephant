namespace WebSocketTool
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Btn_OpenClient = new System.Windows.Forms.Button();
            this.Btn_OpenService = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Btn_OpenClient
            // 
            this.Btn_OpenClient.Location = new System.Drawing.Point(130, 206);
            this.Btn_OpenClient.Name = "Btn_OpenClient";
            this.Btn_OpenClient.Size = new System.Drawing.Size(192, 110);
            this.Btn_OpenClient.TabIndex = 0;
            this.Btn_OpenClient.Text = "打开客服端";
            this.Btn_OpenClient.UseVisualStyleBackColor = true;
            this.Btn_OpenClient.Click += new System.EventHandler(this.Btn_OpenClient_Click);
            // 
            // Btn_OpenService
            // 
            this.Btn_OpenService.Location = new System.Drawing.Point(486, 206);
            this.Btn_OpenService.Name = "Btn_OpenService";
            this.Btn_OpenService.Size = new System.Drawing.Size(198, 110);
            this.Btn_OpenService.TabIndex = 0;
            this.Btn_OpenService.Text = "打开服务端";
            this.Btn_OpenService.UseVisualStyleBackColor = true;
            this.Btn_OpenService.Click += new System.EventHandler(this.Btn_OpenService_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 552);
            this.Controls.Add(this.Btn_OpenService);
            this.Controls.Add(this.Btn_OpenClient);
            this.Name = "Form1";
            this.Text = "WebSocket简易聊天室";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_OpenClient;
        private System.Windows.Forms.Button Btn_OpenService;
    }
}

