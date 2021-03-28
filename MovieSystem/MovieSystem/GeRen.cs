using Maticsoft.DBUtility;
using Maticsoft.Model;
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
    public partial class GeRen : Form
    {
        SqlDataAdapter da;
        string strcon = PubConstant.ConnectionString;
        string strsql = "select * from Administrators";
        public GeRen()
        {
            InitializeComponent();
            da = new SqlDataAdapter(strsql, strcon);
        }
        public GeRen(List<Administrators> list1)
        {
            InitializeComponent();
            foreach (Administrators a in list1)
            {
                txtname.Text = a.UserName;
                txtID.Text = a.UserAccount;
                txtD.Text = a.Description;
                //Image O_Image = Image.FromStream(WebRequest.Create(a.UserImage).GetResponse().GetResponseStream());
                pictureBox1.Load(a.UserImage);
            }
        }
        private DataTable getData()
        {
            DataSet dt = new DataSet(); ;
            da.Fill(dt);
            return dt.Tables[0];
        }
        private void Clear()
        {

            txtname.Text = "";
            txtID.Text = "";
            txtD.Text = "";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(strcon);
            try
            {
                string str = @"update Administrators set UserName=@UserName,Description=@Description,UserImage=@UserImage where UserAccount=@UserAccount";
                SqlCommand cmd = new SqlCommand(str, conn);
                //SqlParameter prm = new SqlParameter("@UserName", SqlDbType.Image);
                cmd.Parameters.Add(new SqlParameter("@UserAccount", txtID.Text));
                cmd.Parameters.Add(new SqlParameter("@UserName", txtname.Text));
                cmd.Parameters.Add(new SqlParameter("@Description", txtD.Text));
                cmd.Parameters.Add(new SqlParameter("@UserImage", pictureBox1.ImageLocation));
                conn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("修改成功！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改失败");
                //CheckId();
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnQX_Click(object sender, EventArgs e)
        {
            this.Hide();
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

        private void btngo_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.ShowDialog();
            this.pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            //this.textBox1.Text = openFileDialog1.FileName;
            this.pictureBox1.ImageLocation = openFileDialog1.FileName;
        }

        private void GeRen_Load(object sender, EventArgs e)
        {
            
            //头像加载
            Image image = this.pictureBox1.Image;
            Image newImage = CutEllipse(image, new Rectangle(0, 0, 100, 100), new Size(100, 100));
            this.pictureBox1.Image = newImage;
        }
        //头像圆形处理
        private Image CutEllipse(Image img, Rectangle rec, Size size)
        {
            Bitmap bitmap = new Bitmap(size.Width, size.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                using (TextureBrush br = new TextureBrush(img, System.Drawing.Drawing2D.WrapMode.Clamp, rec))
                {
                    br.ScaleTransform(bitmap.Width / (float)rec.Width, bitmap.Height / (float)rec.Height);
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.FillEllipse(br, new Rectangle(Point.Empty, size));
                }
            }
            return bitmap;
        }
    }
}
