namespace MovieSystem
{
    partial class moviePD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(moviePD));
            this.txtMS = new System.Windows.Forms.TextBox();
            this.txtYT = new System.Windows.Forms.TextBox();
            this.txtSC = new System.Windows.Forms.TextBox();
            this.txtSJ = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtPM = new System.Windows.Forms.TextBox();
            this.btn_Del = new System.Windows.Forms.Button();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMS
            // 
            this.txtMS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMS.Location = new System.Drawing.Point(620, 277);
            this.txtMS.Name = "txtMS";
            this.txtMS.Size = new System.Drawing.Size(208, 14);
            this.txtMS.TabIndex = 1;
            // 
            // txtYT
            // 
            this.txtYT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtYT.Location = new System.Drawing.Point(620, 230);
            this.txtYT.Name = "txtYT";
            this.txtYT.Size = new System.Drawing.Size(208, 14);
            this.txtYT.TabIndex = 1;
            // 
            // txtSC
            // 
            this.txtSC.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSC.Location = new System.Drawing.Point(620, 182);
            this.txtSC.Name = "txtSC";
            this.txtSC.Size = new System.Drawing.Size(208, 14);
            this.txtSC.TabIndex = 1;
            // 
            // txtSJ
            // 
            this.txtSJ.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSJ.Location = new System.Drawing.Point(620, 133);
            this.txtSJ.Name = "txtSJ";
            this.txtSJ.Size = new System.Drawing.Size(208, 14);
            this.txtSJ.TabIndex = 1;
            // 
            // txtID
            // 
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtID.Location = new System.Drawing.Point(620, 39);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(208, 14);
            this.txtID.TabIndex = 1;
            // 
            // txtPM
            // 
            this.txtPM.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPM.Location = new System.Drawing.Point(620, 85);
            this.txtPM.Name = "txtPM";
            this.txtPM.Size = new System.Drawing.Size(208, 14);
            this.txtPM.TabIndex = 1;
            // 
            // btn_Del
            // 
            this.btn_Del.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Del.BackgroundImage")));
            this.btn_Del.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Del.Location = new System.Drawing.Point(744, 320);
            this.btn_Del.Name = "btn_Del";
            this.btn_Del.Size = new System.Drawing.Size(75, 48);
            this.btn_Del.TabIndex = 0;
            this.btn_Del.UseVisualStyleBackColor = true;
            this.btn_Del.Click += new System.EventHandler(this.btn_Del_Click);
            // 
            // btn_Update
            // 
            this.btn_Update.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Update.BackgroundImage")));
            this.btn_Update.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Update.Location = new System.Drawing.Point(648, 320);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(75, 48);
            this.btn_Update.TabIndex = 0;
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Add.BackgroundImage")));
            this.btn_Add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Add.Location = new System.Drawing.Point(543, 320);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(75, 48);
            this.btn_Add.TabIndex = 0;
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 31);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(501, 318);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // moviePD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(860, 386);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtPM);
            this.Controls.Add(this.txtSJ);
            this.Controls.Add(this.txtYT);
            this.Controls.Add(this.txtMS);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.btn_Del);
            this.Controls.Add(this.txtSC);
            this.Controls.Add(this.btn_Add);
            this.Name = "moviePD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "                                                                                 " +
    "                       ";
            this.Load += new System.EventHandler(this.moviePD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMS;
        private System.Windows.Forms.TextBox txtYT;
        private System.Windows.Forms.TextBox txtSC;
        private System.Windows.Forms.TextBox txtSJ;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtPM;
        private System.Windows.Forms.Button btn_Del;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}