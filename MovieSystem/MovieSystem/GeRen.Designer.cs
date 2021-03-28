namespace MovieSystem
{
    partial class GeRen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeRen));
            this.btngo = new System.Windows.Forms.Button();
            this.btnQX = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtD = new System.Windows.Forms.TextBox();
            this.txtname = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btngo
            // 
            this.btngo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btngo.BackgroundImage")));
            this.btngo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btngo.Location = new System.Drawing.Point(298, 313);
            this.btngo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btngo.Name = "btngo";
            this.btngo.Size = new System.Drawing.Size(100, 39);
            this.btngo.TabIndex = 19;
            this.btngo.UseVisualStyleBackColor = true;
            this.btngo.Click += new System.EventHandler(this.btngo_Click);
            // 
            // btnQX
            // 
            this.btnQX.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQX.BackgroundImage")));
            this.btnQX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnQX.Location = new System.Drawing.Point(566, 308);
            this.btnQX.Name = "btnQX";
            this.btnQX.Size = new System.Drawing.Size(74, 48);
            this.btnQX.TabIndex = 18;
            this.btnQX.UseVisualStyleBackColor = true;
            this.btnQX.Click += new System.EventHandler(this.btnQX_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOK.BackgroundImage")));
            this.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOK.Location = new System.Drawing.Point(468, 308);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 48);
            this.btnOK.TabIndex = 17;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtD
            // 
            this.txtD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtD.Location = new System.Drawing.Point(525, 269);
            this.txtD.Name = "txtD";
            this.txtD.Size = new System.Drawing.Size(99, 14);
            this.txtD.TabIndex = 16;
            // 
            // txtname
            // 
            this.txtname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtname.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtname.Location = new System.Drawing.Point(525, 155);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(99, 14);
            this.txtname.TabIndex = 14;
            // 
            // txtID
            // 
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtID.Location = new System.Drawing.Point(525, 214);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(99, 14);
            this.txtID.TabIndex = 15;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(257, 134);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(182, 174);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // GeRen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(899, 473);
            this.Controls.Add(this.btngo);
            this.Controls.Add(this.btnQX);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtD);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.txtID);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "GeRen";
            this.Text = "GeRen";
            this.Load += new System.EventHandler(this.GeRen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btngo;
        private System.Windows.Forms.Button btnQX;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtD;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}