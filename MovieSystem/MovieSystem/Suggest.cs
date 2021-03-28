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
    public partial class Suggest : Form
    {
        int a;
        public Suggest(List<Administrators> list)
        {
            foreach (Administrators i in list)
            {
                a = i.Id;
            }
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strcon = PubConstant.ConnectionString;
            string ss = string.Format("select count(*) from Feedback where FeedbackId={0}",a);
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                SqlCommand cmd = new SqlCommand(ss, conn);
                conn.Open();
                if ((int)cmd.ExecuteScalar() <= 0)
                {
                    string jianyi = @"insert into Feedback (FeedbackId,Sugestions) VALUES (@FeedbackId,@Sugestions)";
                    using (SqlConnection conn1 = new SqlConnection(strcon))
                    {
                        SqlCommand cmd1 = new SqlCommand(jianyi, conn1);
                        SqlParameter FeedbackId = new SqlParameter("@FeedbackId", 1);
                        cmd1.Parameters.Add(FeedbackId);
                        cmd1.Parameters.Add("Sugestions", SqlDbType.NVarChar).Value = textBox1.Text;
                        conn1.Open();
                        cmd1.ExecuteNonQuery();
                        MessageBox.Show("亲，感谢您的宝贵建议！");
                    }
                }
                else
                {
                    string jianyi = string.Format("update Feedback set Sugestions = @Sugestions WHERE (FeedbackID={0})", a);

                    using (SqlConnection conn1 = new SqlConnection(strcon))
                    {
                        SqlCommand cmd1 = new SqlCommand(jianyi, conn1);
                        cmd1.Parameters.Add("@Sugestions", SqlDbType.NVarChar).Value = textBox1.Text;
                        conn1.Open();
                        cmd1.ExecuteNonQuery();
                        MessageBox.Show("亲，感谢您的宝贵建议！");
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Suggest_Load(object sender, EventArgs e)
        {

        }
    }
}
