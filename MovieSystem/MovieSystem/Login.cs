using Maticsoft.Model;
using MovieSystem.SQLCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieSystem
{
    public partial class LoginFrm : Form
    {
        bool formMove = false;//窗体是否移动
        Point formPoint;//记录窗体的位置


        Thread th;
        public LoginFrm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 改变图片
        /// </summary>
        /// <param name="img">图片</param>
        /// <param name="millisecondsTimeOut">切换图片间隔时间</param>
        private void ChangeImage(Image img, int millisecondsTimeOut)
        {
            this.Invoke(new Action(() =>
            {
                pictureBox1.Image = img;
            })
                );
            Thread.Sleep(millisecondsTimeOut);
        }


        private void FrmLogin_Load(object sender, EventArgs e)
        {
           
            th = new Thread
               (
                   delegate()
                   {

                       while (true)
                       {
                           try
                           {

                               ChangeImage(Image.FromFile(Application.StartupPath + @"\\..\..\images\1.jpg"), 2000);
                               ChangeImage(Image.FromFile(Application.StartupPath + @"\\..\..\images\2.jpg"), 2000);
                               ChangeImage(Image.FromFile(Application.StartupPath + @"\\..\..\images\3.jpg"), 2000);
                               ChangeImage(Image.FromFile(Application.StartupPath + @"\\..\..\images\4.png"), 2000);
                               ChangeImage(Image.FromFile(Application.StartupPath + @"\\..\..\images\5.jpg"), 2000);
                               ChangeImage(Image.FromFile(Application.StartupPath + @"\\..\..\images\6.jpg"), 2000);
                               ChangeImage(Image.FromFile(Application.StartupPath + @"\\..\..\images\7.jpg"), 2000);
                           }
                           catch (System.IO.FileNotFoundException)
                           {
                               MessageBox.Show("There was an error opening the bitmap."+"Please check the path.");
                               break;
                           }

                       }
                   }
               );
            th.IsBackground = true;
            th.Start();
        }
        private void loginfrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            th.Abort();//结束线程
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(UserAccount.Text) && !String.IsNullOrEmpty(UserPwd.Text))
            {    
                string[] a = new string [2];
                a[0] = UserAccount.Text;
                a[1] = UserPwd.Text;
                string sql = @"select * from Administrators where UserAccount=@id and UserPassword=@pwd";
                //根据实体类属性的值，使用SQLHelper.SQLParam()方法生成SQL参数。
                 //int i= DbHelper.Login(sql,a);
                 //if (i > 0)
                 //{
                     List<Administrators> list = new List<Administrators>();
                     list = DbHelper.GetInfo(sql,a);
                     if (list.Count > 0)
                     {
                         //显示主窗体，并通过构造方法将实体对象传递给主窗体。
                         DefaultFrm df = new DefaultFrm(list);
                         df.Show();
                         this.Hide();
                     }
                     else
                     {
                         MessageBox.Show("登录账号或密码有错误！", "提示");
                     }
            }
            else
            {
                MessageBox.Show("登录账号或密码为空！", "提示");
            }
        }

        private void btnSingIn_Click(object sender, EventArgs e)
        {
            RegisterFrm rf = new RegisterFrm();
            rf.Show();
            this.Hide();

        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginFrm_MouseDown(object sender, MouseEventArgs e)
        {
            formPoint = new Point();
            int xOffset;
            int yOffset;
            if (e.Button == MouseButtons.Left)
            {
                xOffset = -e.X - SystemInformation.FrameBorderSize.Width;
                yOffset = -e.Y - SystemInformation.CaptionHeight - SystemInformation.FrameBorderSize.Height;
                formPoint = new Point(xOffset, yOffset);
                formMove = true;//开始移动
            }
        }

        private void LoginFrm_MouseMove(object sender, MouseEventArgs e)
        {
            if (formMove == true)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(formPoint.X, formPoint.Y);
                Location = mousePos;
            }
        }

        private void LoginFrm_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)//按下的是鼠标左键
            {
                formMove = false;//停止移动
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

      
    }

}
