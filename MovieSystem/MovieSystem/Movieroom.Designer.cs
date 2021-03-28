namespace MovieSystem
{
    partial class Movieroom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Movieroom));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtroomCells = new System.Windows.Forms.TextBox();
            this.txtroomRows = new System.Windows.Forms.TextBox();
            this.txtroomName = new System.Windows.Forms.TextBox();
            this.btn_del = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_ADD = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 55);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(685, 439);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick_1);
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescription.Location = new System.Drawing.Point(895, 365);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(181, 18);
            this.txtDescription.TabIndex = 2;
            // 
            // txtroomCells
            // 
            this.txtroomCells.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtroomCells.Location = new System.Drawing.Point(895, 274);
            this.txtroomCells.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtroomCells.Name = "txtroomCells";
            this.txtroomCells.Size = new System.Drawing.Size(181, 18);
            this.txtroomCells.TabIndex = 2;
            // 
            // txtroomRows
            // 
            this.txtroomRows.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtroomRows.Location = new System.Drawing.Point(895, 174);
            this.txtroomRows.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtroomRows.Name = "txtroomRows";
            this.txtroomRows.Size = new System.Drawing.Size(181, 18);
            this.txtroomRows.TabIndex = 2;
            // 
            // txtroomName
            // 
            this.txtroomName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtroomName.Location = new System.Drawing.Point(895, 78);
            this.txtroomName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtroomName.Name = "txtroomName";
            this.txtroomName.Size = new System.Drawing.Size(181, 18);
            this.txtroomName.TabIndex = 2;
            // 
            // btn_del
            // 
            this.btn_del.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_del.BackgroundImage")));
            this.btn_del.Location = new System.Drawing.Point(1047, 434);
            this.btn_del.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(115, 58);
            this.btn_del.TabIndex = 0;
            this.btn_del.UseVisualStyleBackColor = true;
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // btn_update
            // 
            this.btn_update.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_update.BackgroundImage")));
            this.btn_update.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_update.Location = new System.Drawing.Point(895, 434);
            this.btn_update.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(115, 60);
            this.btn_update.TabIndex = 0;
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_ADD
            // 
            this.btn_ADD.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_ADD.BackgroundImage")));
            this.btn_ADD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_ADD.Location = new System.Drawing.Point(752, 436);
            this.btn_ADD.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_ADD.Name = "btn_ADD";
            this.btn_ADD.Size = new System.Drawing.Size(115, 58);
            this.btn_ADD.TabIndex = 0;
            this.btn_ADD.UseVisualStyleBackColor = true;
            this.btn_ADD.Click += new System.EventHandler(this.btn_ADD_Click);
            // 
            // Movieroom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1227, 536);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtroomCells);
            this.Controls.Add(this.txtroomRows);
            this.Controls.Add(this.btn_ADD);
            this.Controls.Add(this.txtroomName);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_del);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Movieroom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "影厅设置";
            this.Load += new System.EventHandler(this.Movieroom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtroomCells;
        private System.Windows.Forms.TextBox txtroomRows;
        private System.Windows.Forms.TextBox txtroomName;
        private System.Windows.Forms.Button btn_del;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_ADD;
    }
}