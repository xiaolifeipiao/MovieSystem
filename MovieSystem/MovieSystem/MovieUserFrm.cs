using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieSystem
{
    public partial class MovieUserFrm : Form
    {
        SqlDataAdapter da;
        string strcon =PubConstant.ConnectionString;
        string strsql = "select Id as 序号,UserName as 用户名,UserAccount as 账户,UserPassword as 密码,UserType as 身份,Description as 备注,UserImage as 头像地址 from Administrators";
        public MovieUserFrm()
        {
            InitializeComponent();
            da = new SqlDataAdapter(strsql, strcon);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private DataTable getData()
        {
            DataSet dt = new DataSet(); ;
            da.Fill(dt);
            return dt.Tables[0];
        }
        private void Clear()
        {
            txtID.Text = "";
            txtname.Text = "";
            txtUA.Text = "";
            txtUP.Text = "";
            txtUT.Text = "";
            txtD.Text = "";
            txtimage.Text = "";
        }
        private void CheckId()//检查插入的影片信息是否重复
        {
            string str = "select count(*) from Administrators where UserAccount=@UserAccount";
            SqlConnection conn = new SqlConnection(strcon);
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.Parameters.Add(new SqlParameter("@UserAccount", txtUA.Text));
            conn.Open();
            if ((int)cmd.ExecuteScalar() > 0)
            {
                MessageBox.Show("账号重复，添加失败！");
            }
            conn.Close();
        }
        private void MovieUserFrm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = getData();
            txtID.Enabled = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)		//用于判断是否选中了DataGridView中的一行
            {
                MessageBox.Show("请选中一行进行操作");
                return;
            }
            txtID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtname.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtUA.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtUP.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtUT.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            txtimage.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            txtD.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            pictureBox1.Load(dataGridView1.SelectedRows[0].Cells[6].Value.ToString());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtname.Text.Trim().Equals("") || txtUA.Text.Trim().Equals("") || txtUP.Text.Trim().Equals("") ||
                txtUT.Text.Trim().Equals("") || txtD.Text.Trim().Equals("") || txtimage.Text.Trim().Equals("") )
            {
                MessageBox.Show("完整信息！");
                return;
            }

            string str = "insert into Administrators(UserName,UserAccount,UserPassword,UserType,UserImage,Description) values(@UserName,@UserAccount,@UserPassword,@UserType,@UserImage,@Description) ";
            SqlConnection conn = new SqlConnection(strcon);
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.Parameters.Add(new SqlParameter("@UserName", txtname.Text));
            cmd.Parameters.Add(new SqlParameter("@UserAccount", txtUA.Text));
            cmd.Parameters.Add(new SqlParameter("@UserPassword", txtUP.Text));
            cmd.Parameters.Add(new SqlParameter("@UserType", txtUT.Text));
            cmd.Parameters.Add(new SqlParameter("@UserImage", txtD.Text));
            cmd.Parameters.Add(new SqlParameter("@Description", txtimage.Text));
            
            try
            {
                conn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("添加成功！");
                    dataGridView1.DataSource = getData();//调用数据库
                    Clear();
                }
            }
            catch (Exception ex)
            {
                CheckId();
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)		//用于判断是否选中了DataGridView中的一行
            {
                MessageBox.Show("请选中一行进行操作！");
                return;
            }
            try
            {

                string str = "update Administrators set UserName=@UserName,UserAccount=@UserAccount,UserPassword=@UserPassword,UserType=@UserType,UserImage=@UserImage,Description=@Description where Id=@Id";

                SqlConnection conn = new SqlConnection(strcon);
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.Add(new SqlParameter("@Id", txtID.Text));
                cmd.Parameters.Add(new SqlParameter("@UserName", txtname.Text));
                cmd.Parameters.Add(new SqlParameter("@UserAccount", txtUA.Text));
                cmd.Parameters.Add(new SqlParameter("@UserPassword", txtUP.Text));
                cmd.Parameters.Add(new SqlParameter("@UserType", txtUT.Text));
                cmd.Parameters.Add(new SqlParameter("@UserImage", txtD.Text));
                cmd.Parameters.Add(new SqlParameter("@Description", txtimage.Text));
                conn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("修改成功！");
                    dataGridView1.DataSource = getData();
                    Clear();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("请重新输入！");
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)		//用于判断是否选中了DataGridView中的一行
            {
                MessageBox.Show("请选中一行进行操作");
                return;
            }
            try
            {
                int i = dataGridView1.CurrentRow.Index;//获取选中行的索引值
                DataTable Administrators = getData();
                Administrators.Rows[i].Delete();

                //为适配器创建Insert命令
                SqlCommandBuilder builder = new SqlCommandBuilder(da);

                //使用适配器更新数据集
                da.Update(Administrators
                    );
                MessageBox.Show("数据删除成功");
                dataGridView1.DataSource = getData();
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除失败");
            }
        }

        private void btnsc_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.ShowDialog();
            this.pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            this.txtD.Text = openFileDialog1.FileName;
            this.pictureBox1.ImageLocation = openFileDialog1.FileName;
        }
        private string filename;
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                this.pictureBox1.Image = null;
            }
            //上传图片到pictureBox1
            FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
            Bitmap bmp = new Bitmap(fs);
            this.pictureBox1.Image = bmp;
            //图像适合图片框的大小
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            fs.Close();
            filename = openFileDialog1.FileName.ToString();
        }
    }
}
