using Maticsoft.DBUtility;
using Maticsoft.Model;
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
    public partial class Changepwd : Form
    {
        int a;
        SqlDataAdapter da;
        string strcon = PubConstant.ConnectionString;
        string strsql = "select * from Administrators";
        public Changepwd(List<Administrators> list)
        {
            InitializeComponent();
            foreach (Administrators i in list)
            {
                 a= i.Id;
            }
            da = new SqlDataAdapter(strsql, strcon);
        }
        private DataTable getData()
        {
            DataSet dt = new DataSet(); ;
            da.Fill(dt);
            return dt.Tables[0];
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            try
            {
                //判断是否为空
                if (txtpwd.Text.Trim().Equals("") || txtpwd1.Text.Trim().Equals("") || txtpwd2.Text.Trim().Equals(""))
                {
                    MessageBox.Show("请填写完整的信息！");
                    return;
                }
                //判断原密码是否一致
                string ss = string.Format("select * from Administrators where UserPassword='{0}'", txtpwd.Text);
                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    SqlCommand cmd = new SqlCommand(ss, conn);
                    conn.Open();
                    if ((int)cmd.ExecuteScalar() <= 0)
                    {
                        MessageBox.Show("原密码错误，请重新输入！");
                        return;
                    }
                }
                //判断密码与确认密码是否一致
                if (txtpwd1.Text != txtpwd2.Text)
                {
                    MessageBox.Show("密码和确认密码不相符!");
                    txtpwd1.Text = "";
                    txtpwd2.Text = "";
                    return;
                }
                
               
                string pwd = @"update Administrators set UserPassword = @UserPassword where Id=@id";
                using (SqlConnection conn1 = new SqlConnection(strcon))
                {
                    SqlCommand cmd1 = new SqlCommand(pwd, conn1);
                    cmd1.Parameters.Add(new SqlParameter("@UserPassword", txtpwd1.Text));
                    cmd1.Parameters.Add(new SqlParameter("@Id", a));
                    
                    conn1.Open();
                    cmd1.ExecuteNonQuery();
                    if (cmd1.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("修改成功");
                    }
                }
                this.Close();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改失败");
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Changepwd_Load(object sender, EventArgs e)
        {

        }
    }
}
