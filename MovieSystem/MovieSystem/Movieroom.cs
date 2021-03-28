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
    public partial class Movieroom : Form
    {
        SqlDataAdapter da;
        string strcon = PubConstant.ConnectionString;
        string strsql = "select * from ScreeningRoom";
        public Movieroom()
        {
            InitializeComponent();
            da = new SqlDataAdapter(strsql, strcon);
        }
        private DataTable getData()
        {
            DataSet dt = new DataSet(); ;
            da.Fill(dt);
            return dt.Tables[0];
        }
        private void Clear()
        {
            txtroomName.Text = "";
            txtroomRows.Text = "";
            txtroomCells.Text = "";
            txtDescription.Text = "";
        }
        private void Movieroom_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = getData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)		//用于判断是否选中了DataGridView中的一行
            {
                MessageBox.Show("请选中一行进行操作");
                return;
            }
            txtroomName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtroomRows.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtroomCells.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtDescription.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void btn_ADD_Click(object sender, EventArgs e)
        {
            try
            {
                //查空
                if (txtroomName.Text.Trim().Equals("") || txtroomRows.Text.Trim().Equals("") || txtroomCells.Text.Trim().Equals("") || txtDescription.Text.Trim().Equals(""))
                {
                    MessageBox.Show("请填写完整的信息！");
                    return;
                }
                //查重
                string ss = string.Format("select count(*) from ScreeningRoom where ScreeningRoomName='{0}'", txtroomName.Text);
                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    SqlCommand cmd = new SqlCommand(ss, conn);
                    conn.Open();
                    if ((int)cmd.ExecuteScalar() > 0)
                    {
                        //conn.Close();
                        MessageBox.Show("影厅重复，请重新输入或更改！");
                        return;
                    }
                }
                DataTable sr = getData();
                DataRow newRow = sr.NewRow();
                newRow["ScreeningRoomName"] = txtroomName.Text;
                newRow["ScreeningRoomRows"] = int.Parse(txtroomRows.Text);
                newRow["ScreeningRoomCells"] = int.Parse(txtroomCells.Text);
                newRow["Description"] = txtDescription.Text;
                //将新行添加到Rows集合
                sr.Rows.Add(newRow);

                //为适配器创建Insert命令
                SqlCommandBuilder builder = new SqlCommandBuilder(da);

                //使用适配器更新数据集
                da.Update(sr);
                MessageBox.Show("影厅信息添加成功");
                dataGridView1.DataSource = getData();
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("添加失败");
            }   
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)		//用于判断是否选中了DataGridView中的一行
            {
                MessageBox.Show("请选中一行进行操作");
                return;
            }
            try
            {
                int i = dataGridView1.CurrentRow.Index;//获取选中行的索引值
                DataTable tStu = getData();
                tStu.Rows[i]["ScreeningRoomName"] = txtroomName.Text;
                tStu.Rows[i]["ScreeningRoomRows"] = int.Parse(txtroomRows.Text);
                tStu.Rows[i]["ScreeningRoomCells"] = int.Parse(txtroomCells.Text);
                tStu.Rows[i]["Description"] = txtDescription.Text;
                //查寻更改过后影厅名是否为空
                if (txtroomName.Text.Trim().Equals("") || txtroomRows.Text.Trim().Equals("") || txtroomCells.Text.Trim().Equals("") || txtDescription.Text.Trim().Equals(""))
                {
                    MessageBox.Show("请填写完整的信息！");
                    return;
                }
                //查寻更改过后影厅名是否重复
                string ss = string.Format("select count(*) from ScreeningRoom where ScreeningRoomName='{0}'", txtroomName.Text);
                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    SqlCommand cmd = new SqlCommand(ss, conn);
                    conn.Open();
                    if ((int)cmd.ExecuteScalar() > 0)
                    {
                        //conn.Close();
                        MessageBox.Show("影厅重复，请重新输入或更改！");
                        return;
                    }
                }
                //为适配器创建Insert命令
                SqlCommandBuilder builder = new SqlCommandBuilder(da);

                //使用适配器更新数据集
                da.Update(tStu);
                MessageBox.Show("数据修改成功");
                dataGridView1.DataSource = getData();
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改失败");
            }
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)		//用于判断是否选中了DataGridView中的一行
            {
                MessageBox.Show("请选中一行进行操作");
                return;
            }
            try
            {
                int i = dataGridView1.CurrentRow.Index;//获取选中行的索引值
                DataTable tStu = getData();
                tStu.Rows[i].Delete();

                //为适配器创建Insert命令
                SqlCommandBuilder builder = new SqlCommandBuilder(da);

                //使用适配器更新数据集
                da.Update(tStu);
                MessageBox.Show("数据删除成功");
                dataGridView1.DataSource = getData();
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除失败");
            }
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)		//用于判断是否选中了DataGridView中的一行
            {
                MessageBox.Show("请选中一行进行操作");
                return;
            }
            txtroomName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtroomRows.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtroomCells.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtDescription.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }
    }
}
