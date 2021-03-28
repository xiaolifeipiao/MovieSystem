using Maticsoft.DBUtility;
using MovieSystem.SQLCommon;
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
    public partial class RegisterFrm : Form
    {
        string strcon = PubConstant.ConnectionString;
        public RegisterFrm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(strcon);
            LoginFrm fs = new LoginFrm();

            fs.Show();
            if (txt_username.Text == "")
            {
                MessageBox.Show("用户名不能为空！");
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("账号不能为空！");
            }
            if (txt_pwd.Text == "")
            {
                MessageBox.Show("密码不能为空!");
            }
            if (txt_pwd2.Text == "")
            {
                MessageBox.Show("确认密码不能为空!");
            }
            if (txt_pwd.Text != txt_pwd2.Text)
            {
                MessageBox.Show("密码和确认密码不相符!");
                txt_pwd.Text = "";
                txt_pwd2.Text = "";
                return;
            }
            try
            {
                string sql = string.Format("select count(*) from Administrators where UserAccount='{0}'", textBox2.Text);
                int a = DbHelper.Zhuce(sql);
                if (a == 0)
                {
                    string sql1 = @"insert into Administrators(UserName,UserAccount,UserPassword,UserType,UserImage) values(@UserName,@UserAccount,@UserPassword,2,'C:\Users\19215\Desktop\MovieSystem\MovieSystem\images\1.jpg')";
                   
                    SqlCommand cmd = new SqlCommand(sql1, conn);
                    cmd.Parameters.Add(new SqlParameter("@UserName", txt_username.Text));
                    cmd.Parameters.Add(new SqlParameter("@UserAccount", textBox2.Text));
                    cmd.Parameters.Add(new SqlParameter("@UserPassword", txt_pwd.Text));
                    conn.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("注册成功！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("用户已存在！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Application.Exit();
            }

            finally
            {
                conn.Close();
            }
        }
    }
}
