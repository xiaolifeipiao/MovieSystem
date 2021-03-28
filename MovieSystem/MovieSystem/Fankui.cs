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
    public partial class Fankui : Form
    {
        int a;
        string strcon = PubConstant.ConnectionString;
        public Fankui(List<Administrators> list)
        {
            InitializeComponent();
            foreach (Administrators i in list)
            {
                a = i.Id;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ss = string.Format("select count(*) from Feedback where FeedbackId={0}",a);
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                SqlCommand cmd = new SqlCommand(ss, conn);
                conn.Open();
                if ((int)cmd.ExecuteScalar() <= 0)
                {
                    if (rdo_Yes.Checked)
                    {
                        string choose = @"insert into Feedback (FeedbackId,Options) VALUES (@FeedbackId,@Options)";
                        //MessageBox.Show(choose);
                        using (SqlConnection conn1 = new SqlConnection(strcon))
                        {
                            SqlCommand cmd1 = new SqlCommand(choose, conn1);
                            SqlParameter FeedbackId = new SqlParameter("@FeedbackId",a);
                            cmd1.Parameters.Add(FeedbackId);
                            cmd1.Parameters.Add("@Options", SqlDbType.NVarChar).Value = "Yes";
                            conn1.Open();
                            cmd1.ExecuteNonQuery();
                            MessageBox.Show("亲，感谢您的参与！");
                        }
                    }
                    else if (rdo_No.Checked)
                    {
                        string choose = string.Format("insert into Feedback (FeedbackId,Options) VALUES ({0},@Options)", a);
                            
                        //MessageBox.Show(choose);
                        using (SqlConnection conn1 = new SqlConnection(strcon))
                        {
                            SqlCommand cmd1 = new SqlCommand(choose, conn1);
                            SqlParameter FeedbackId = new SqlParameter("@FeedbackId", a);
                            cmd1.Parameters.Add(FeedbackId);
                            cmd1.Parameters.Add("@Options", SqlDbType.NVarChar).Value = "No";
                            conn1.Open();
                            cmd1.ExecuteNonQuery();
                            MessageBox.Show("亲，请再考虑，期待您下次加入！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("亲，请做出选择哟！");
                    }
                }
                else
                {
                    string choose = string.Format("update Feedback set Options = @Options WHERE (FeedbackID={0})", a);
                    if (rdo_Yes.Checked)
                    {
                         
                        using (SqlConnection conn1 = new SqlConnection(strcon))
                        {
                            SqlCommand cmd1 = new SqlCommand(choose, conn1);
                            cmd1.Parameters.Add("@Options", SqlDbType.NVarChar).Value = "Yes";
                            conn1.Open();
                            cmd1.ExecuteNonQuery();
                            MessageBox.Show("亲，感谢您的参与！");
                        }
                    }
                    else if (rdo_No.Checked)
                    {
                       
                        using (SqlConnection conn1 = new SqlConnection(strcon))
                        {
                            SqlCommand cmd1 = new SqlCommand(choose, conn1);
                            cmd1.Parameters.Add("@Options", SqlDbType.NVarChar).Value = "No";
                            conn1.Open();
                            cmd1.ExecuteNonQuery();
                            MessageBox.Show("亲，请再考虑，期待您下次加入！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("亲，请做出选择哟！");
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Fankui_Load(object sender, EventArgs e)
        {

        }
    }
}
