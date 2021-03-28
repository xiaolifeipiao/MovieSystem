namespace MovieSystem
{
    partial class movieTP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(movieTP));
            this.txtMS = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtLX = new System.Windows.Forms.TextBox();
            this.Btn_Add = new System.Windows.Forms.Button();
            this.Btn_Update = new System.Windows.Forms.Button();
            this.Btn_Del = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMS
            // 
            this.txtMS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMS.Location = new System.Drawing.Point(476, 217);
            this.txtMS.Name = "txtMS";
            this.txtMS.Size = new System.Drawing.Size(142, 14);
            this.txtMS.TabIndex = 2;
            // 
            // txtID
            // 
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtID.Location = new System.Drawing.Point(476, 61);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(142, 14);
            this.txtID.TabIndex = 2;
            // 
            // txtLX
            // 
            this.txtLX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLX.Location = new System.Drawing.Point(476, 139);
            this.txtLX.Name = "txtLX";
            this.txtLX.Size = new System.Drawing.Size(142, 14);
            this.txtLX.TabIndex = 2;
            // 
            // Btn_Add
            // 
            this.Btn_Add.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn_Add.BackgroundImage")));
            this.Btn_Add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_Add.Location = new System.Drawing.Point(398, 267);
            this.Btn_Add.Name = "Btn_Add";
            this.Btn_Add.Size = new System.Drawing.Size(60, 39);
            this.Btn_Add.TabIndex = 0;
            this.Btn_Add.UseVisualStyleBackColor = true;
            this.Btn_Add.Click += new System.EventHandler(this.Btn_Add_Click);
            // 
            // Btn_Update
            // 
            this.Btn_Update.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn_Update.BackgroundImage")));
            this.Btn_Update.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_Update.Location = new System.Drawing.Point(499, 267);
            this.Btn_Update.Name = "Btn_Update";
            this.Btn_Update.Size = new System.Drawing.Size(60, 39);
            this.Btn_Update.TabIndex = 0;
            this.Btn_Update.UseVisualStyleBackColor = true;
            this.Btn_Update.Click += new System.EventHandler(this.Btn_Update_Click);
            // 
            // Btn_Del
            // 
            this.Btn_Del.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn_Del.BackgroundImage")));
            this.Btn_Del.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_Del.Location = new System.Drawing.Point(589, 267);
            this.Btn_Del.Name = "Btn_Del";
            this.Btn_Del.Size = new System.Drawing.Size(60, 39);
            this.Btn_Del.TabIndex = 0;
            this.Btn_Del.UseVisualStyleBackColor = true;
            this.Btn_Del.Click += new System.EventHandler(this.Btn_Del_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 33);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(326, 273);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // movieTP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(684, 329);
            this.Controls.Add(this.txtMS);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtLX);
            this.Controls.Add(this.Btn_Add);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.Btn_Update);
            this.Controls.Add(this.Btn_Del);
            this.Name = "movieTP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "                                                                                 " +
    "                   ";
            this.Load += new System.EventHandler(this.movieTP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMS;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtLX;
        private System.Windows.Forms.Button Btn_Add;
        private System.Windows.Forms.Button Btn_Update;
        private System.Windows.Forms.Button Btn_Del;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}