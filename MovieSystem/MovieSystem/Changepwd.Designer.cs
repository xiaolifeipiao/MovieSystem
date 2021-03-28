namespace MovieSystem
{
    partial class Changepwd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Changepwd));
            this.txtpwd = new System.Windows.Forms.TextBox();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.txtpwd2 = new System.Windows.Forms.TextBox();
            this.txtpwd1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtpwd
            // 
            this.txtpwd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtpwd.Location = new System.Drawing.Point(200, 102);
            this.txtpwd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtpwd.Name = "txtpwd";
            this.txtpwd.PasswordChar = '*';
            this.txtpwd.Size = new System.Drawing.Size(233, 18);
            this.txtpwd.TabIndex = 6;
            // 
            // btn_Exit
            // 
            this.btn_Exit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Exit.BackgroundImage")));
            this.btn_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Exit.Location = new System.Drawing.Point(299, 390);
            this.btn_Exit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(100, 58);
            this.btn_Exit.TabIndex = 4;
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_OK.BackgroundImage")));
            this.btn_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_OK.Location = new System.Drawing.Point(109, 390);
            this.btn_OK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(100, 58);
            this.btn_OK.TabIndex = 3;
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // txtpwd2
            // 
            this.txtpwd2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtpwd2.Location = new System.Drawing.Point(200, 308);
            this.txtpwd2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtpwd2.Name = "txtpwd2";
            this.txtpwd2.PasswordChar = '*';
            this.txtpwd2.Size = new System.Drawing.Size(233, 18);
            this.txtpwd2.TabIndex = 2;
            // 
            // txtpwd1
            // 
            this.txtpwd1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtpwd1.Location = new System.Drawing.Point(200, 205);
            this.txtpwd1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtpwd1.Name = "txtpwd1";
            this.txtpwd1.PasswordChar = '*';
            this.txtpwd1.Size = new System.Drawing.Size(233, 18);
            this.txtpwd1.TabIndex = 2;
            // 
            // Changepwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(528, 481);
            this.Controls.Add(this.txtpwd);
            this.Controls.Add(this.txtpwd2);
            this.Controls.Add(this.txtpwd1);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.btn_Exit);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Changepwd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "密码";
            this.Load += new System.EventHandler(this.Changepwd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtpwd;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.TextBox txtpwd2;
        private System.Windows.Forms.TextBox txtpwd1;
    }
}