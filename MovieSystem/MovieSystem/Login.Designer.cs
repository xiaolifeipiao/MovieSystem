namespace MovieSystem
{
    partial class LoginFrm
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginFrm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.UserAccount = new System.Windows.Forms.TextBox();
            this.UserPwd = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnSingIn = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(0, -9);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(532, 551);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(464, 262);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 1;
            // 
            // UserAccount
            // 
            this.UserAccount.BackColor = System.Drawing.Color.Maroon;
            this.UserAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UserAccount.Location = new System.Drawing.Point(676, 271);
            this.UserAccount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.UserAccount.Name = "UserAccount";
            this.UserAccount.Size = new System.Drawing.Size(130, 21);
            this.UserAccount.TabIndex = 1;
            // 
            // UserPwd
            // 
            this.UserPwd.BackColor = System.Drawing.Color.Maroon;
            this.UserPwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UserPwd.Location = new System.Drawing.Point(676, 318);
            this.UserPwd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.UserPwd.Name = "UserPwd";
            this.UserPwd.PasswordChar = '*';
            this.UserPwd.Size = new System.Drawing.Size(130, 21);
            this.UserPwd.TabIndex = 2;
            // 
            // btnLogin
            // 
            this.btnLogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLogin.BackgroundImage")));
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("幼圆", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLogin.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.btnLogin.Location = new System.Drawing.Point(643, 395);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(56, 27);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "登录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnSingIn
            // 
            this.btnSingIn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSingIn.BackgroundImage")));
            this.btnSingIn.FlatAppearance.BorderSize = 0;
            this.btnSingIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSingIn.Font = new System.Drawing.Font("幼圆", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSingIn.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.btnSingIn.Location = new System.Drawing.Point(758, 398);
            this.btnSingIn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSingIn.Name = "btnSingIn";
            this.btnSingIn.Size = new System.Drawing.Size(56, 22);
            this.btnSingIn.TabIndex = 4;
            this.btnSingIn.Text = "注册";
            this.btnSingIn.UseVisualStyleBackColor = true;
            this.btnSingIn.Click += new System.EventHandler(this.btnSingIn_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuit.BackgroundImage")));
            this.btnQuit.FlatAppearance.BorderSize = 0;
            this.btnQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuit.Font = new System.Drawing.Font("幼圆", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuit.ForeColor = System.Drawing.SystemColors.Window;
            this.btnQuit.Location = new System.Drawing.Point(922, 0);
            this.btnQuit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(28, 28);
            this.btnQuit.TabIndex = 5;
            this.btnQuit.Text = "✖";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // LoginFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MovieSystem.Properties.Resources._111;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(949, 542);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnSingIn);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.UserPwd);
            this.Controls.Add(this.UserAccount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "电影售票系统";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LoginFrm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LoginFrm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LoginFrm_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UserAccount;
        private System.Windows.Forms.TextBox UserPwd;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnSingIn;
        private System.Windows.Forms.Button btnQuit;
    }
}

