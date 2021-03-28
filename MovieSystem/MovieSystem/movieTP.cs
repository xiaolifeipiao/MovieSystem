using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieSystem
{
    public partial class movieTP : Form
    {
        SqlDataAdapter da;
        string strcon = PubConstant.ConnectionString;//数据库关键字
        //string strcon = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\MovieSystem.mdf;Integrated Security=True;Connect Timeout=30";
        string str1 = "select * from MovieType";
        public movieTP()
        {
            da = new SqlDataAdapter(str1, strcon);
            InitializeComponent();
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
            txtLX.Text = "";
            txtMS.Text = "";
        }
        

        private void movieTP_Load(object sender, EventArgs e)
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
            txtLX.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtMS.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }
        private void Btn_Add_Click(object sender, EventArgs e)
        {
            if (txtLX.Text.Trim().Equals("") || txtMS.Text.Trim().Equals(""))
            {
                MessageBox.Show("完整信息！");
                return;
            }
            SqlConnection conn = new SqlConnection(strcon);
            try
            {
                string str = "insert into MovieType values(@TypeName,@Description)";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.Add(new SqlParameter("@TypeName", txtLX.Text));
                cmd.Parameters.Add(new SqlParameter("@Description", txtMS.Text));
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
                MessageBox.Show("添加失败");
            }
            finally
            {
                conn.Close();
            }
        }
        private void Btn_Update_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)		//用于判断是否选中了DataGridView中的一行
            {
                MessageBox.Show("请选中一行进行操作！");
                return;
            }
            string str = "update MovieType set TypeName=@TypeName,Description=@Description where Id=@Id";
            SqlConnection conn = new SqlConnection(strcon);
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.Parameters.Add(new SqlParameter("@Id", txtID.Text));
            cmd.Parameters.Add(new SqlParameter("@TypeName", txtLX.Text));
            cmd.Parameters.Add(new SqlParameter("@Description", txtMS.Text));
            conn.Open();
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("修改成功！");
                dataGridView1.DataSource = getData();
                Clear();
            }
            conn.Close();
        }

        private void Btn_Del_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)		//用于判断是否选中了DataGridView中的一行
            {
                MessageBox.Show("请选中一行进行操作！");
                return;
            }
            SqlConnection conn = new SqlConnection(strcon);
            try
            {
                string str = "delete from MovieType where TypeName=@TypeName";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.Add(new SqlParameter("@TypeName", txtLX.Text));
                conn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("数据删除成功");
                }
                dataGridView1.DataSource = getData();
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除失败");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
