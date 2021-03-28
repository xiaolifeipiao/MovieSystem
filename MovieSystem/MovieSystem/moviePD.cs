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
    public partial class moviePD : Form
    {
        SqlDataAdapter da;
        string strcon = PubConstant.ConnectionString;//数据库关键字
        //string strcon = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\MovieSystem.mdf;Integrated Security=True;Connect Timeout=30";
        string str = "select * from MovieLined";
        public moviePD()
        {
            da = new SqlDataAdapter(str, strcon);
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
            txtPM.Text = "";
            txtSJ.Text = "";
            txtSC.Text = "";
            txtYT.Text = "";
            txtMS.Text = "";
        }
        private void moviePD_Load(object sender, EventArgs e)
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
            txtPM.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtSJ.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtSC.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtYT.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            txtMS.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (txtPM.Text.Trim().Equals("") || txtSJ.Text.Trim().Equals("")
             || txtSC.Text.Trim().Equals("") || txtYT.Text.Trim().Equals("") || txtMS.Text.Trim().Equals(""))
            {
                MessageBox.Show("完整信息！");
                return;
            }
            SqlConnection conn = new SqlConnection(strcon);
            try
            {
                string str = "insert into MovieLined values(@MovieId,@MovieTime,@MovieLength,@MovieRoomld,@Description)";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.Add(new SqlParameter("@MovieId", txtPM.Text));
                cmd.Parameters.Add(new SqlParameter("@MovieTime", txtSJ.Text));
                cmd.Parameters.Add(new SqlParameter("@MovieLength", txtSC.Text));
                cmd.Parameters.Add(new SqlParameter("@MovieRoomld", txtYT.Text));
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
                MessageBox.Show("不存在该电影、影厅，或者日期格式不正确，请重新输入！");
            }
            finally
            {
                conn.Close();
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)		//用于判断是否选中了DataGridView中的一行
            {
                MessageBox.Show("请选中一行进行操作！");
                return;
            }
            SqlConnection conn = new SqlConnection(strcon);
            try
            {
                string str = "update MovieLined set MovieId=@MovieId,MovieTime=@MovieTime,MovieLength=@MovieLength,MovieRoomld=@MovieRoomld,Description=@Description where Id=@Id";

                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.Add(new SqlParameter("@Id", txtID.Text));
                cmd.Parameters.Add(new SqlParameter("@MovieId", txtPM.Text));
                cmd.Parameters.Add(new SqlParameter("@MovieTime", txtSJ.Text));
                cmd.Parameters.Add(new SqlParameter("@MovieLength", txtSC.Text));
                cmd.Parameters.Add(new SqlParameter("@MovieRoomld", txtYT.Text));
                cmd.Parameters.Add(new SqlParameter("@Description", txtMS.Text));
                conn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("修改成功！");
                    dataGridView1.DataSource = getData();
                    Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("不可修改影厅号或片名，请重新输入！");
                //CheckId();
            }
            finally
            {
                conn.Close();
            }
        }

        private void btn_Del_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)		//用于判断是否选中了DataGridView中的一行
            {
                MessageBox.Show("请选中一行进行操作！");
                return;
            }
            SqlConnection conn = new SqlConnection(strcon);
            try
            {
                string str = "delete from MovieLined where Id=@Id";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.Add(new SqlParameter("@Id", txtID.Text));
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
