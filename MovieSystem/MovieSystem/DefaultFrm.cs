using Maticsoft.DBUtility;
using Maticsoft.Model;
using MovieSystem.Model;
using MovieSystem.SQLCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieSystem
{
    public enum MovieType
    {
        喜剧=1,冒险=2,幻想=3,悬念=4,记录=5,战争=6,爱情=7,剧情=8,伦理=9,动作=10,科幻=11,犯罪=12
    }

    public partial class DefaultFrm : Form
    {
        int c;

        Thread th;
        //影厅Id
        int SitId = 0;
        //电影排挡的Id
        int MovieLinedId = 0;
        //存放选中的座位
        List<string> lblSelect = new List<string>();
        //存放出票的信息
        List<MovieTicket> list = new List<MovieTicket>();
        //存放出票座位的信息
        List<string> list1 = new List<string>();
        //存放登录人信息
        List<Administrators> list2 = new List<Administrators>();
       
        string movieid;
        string moviename;
        string movieroom;
        string movierid;
        decimal price;
        string sit;
        /// <summary>
        /// 改变图片
        /// </summary>
        /// <param name="img">图片</param>
        /// <param name="millisecondsTimeOut">切换图片间隔时间</param>
        private void ChangeImage(Image img, int millisecondsTimeOut)
        {
            this.Invoke(new Action(() =>
            {
                pictureBox3.Image = img;
            })
                );
            Thread.Sleep(millisecondsTimeOut);
        }
        public void imageLoad()
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
                              MessageBox.Show("There was an error opening the bitmap." + "Please check the path.");
                              break;
                          }

                      }
                  }
              );
            th.IsBackground = true;
            th.Start();
        }
        SqlDataAdapter da;
        string strcon = PubConstant.ConnectionString;//数据库关键字
        //string strcon = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\MovieSystem.mdf;Integrated Security=True;Connect Timeout=30";
        string str = "select Id as 片名ID,MovieName as 片名,MovieActor as 主演,MovieDirector as 导演,MovieType as 类型,MoviePrice as 票价,MovieTime as 时间,MovieFavourable as 优惠,MoviePicturePath as 图片路径,Description as 描述 from MovieInfo";//sql语句
        public DefaultFrm()
        {
            InitializeComponent();
            da = new SqlDataAdapter(str, strcon);
        }
        private DataTable getData()//获取数据库信息的方法
        {
            DataSet dt = new DataSet();
            da.Fill(dt);
            return dt.Tables[0];
        }//接收登录传来的数据
        private void Clear()//清空文本框方法
        {
            txtID.Text = "";
            txtPM.Text = "";
            txtDY.Text = "";
            txtZY.Text = "";
            txtLX.Text = "";
            txtSJ.Text = "";
            txtPJ.Text = "";
            txtYH.Text = "";
            pictureBox4.ImageLocation = null;
        }
        public DefaultFrm(List<Administrators> list)
        {
            da = new SqlDataAdapter(str, strcon);
            InitializeComponent();
            list2 = list;
            foreach (Administrators a in list)
            {
                lblUser1.Text = a.UserName;
                lblShowTime1.Text = a.Time;
                //Image O_Image = Image.FromStream(WebRequest.Create(a.UserImage).GetResponse().GetResponseStream());
                pictureBox2.Load(a.UserImage);
            }
        }

        private void DefaultFrm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = getData();
            txtID.Enabled = false;
            SetTreeView();
            imageLoad();
            //头像加载
            Image image = this.pictureBox2.Image;
            Image newImage = CutEllipse(image, new Rectangle(0, 0, 100, 100), new Size(100, 100));
            this.pictureBox2.Image = newImage;

        }
        private void CheckId()//检查插入的影片信息是否重复
        {
            string str = "select count(*) from MovieInfo where MovieName=@MovieName";
            SqlConnection conn = new SqlConnection(strcon);
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.Parameters.Add(new SqlParameter("@MovieName", txtPM.Text));
            conn.Open();
            if ((int)cmd.ExecuteScalar() > 0)
            {
                MessageBox.Show("影名重复,添加失败！");
            }
            conn.Close();
        }
        public void SetTreeView()
        {
            tvMovie.Nodes.Clear();
            string sql = @"select MovieLined.*,b.MovieName,c.ScreeningRoomName from MovieLined left join MovieInfo as b on MovieLined.MovieId=b.Id left join ScreeningRoom as c on MovieLined.MovieRoomld=c.Id order by MovieLined.MovieTime desc";
            DataTable dt = DbHelper.GetDataTable(sql);
            TreeNode tnRoot = new TreeNode();
            tnRoot.Text = "放影计划";
            //通过两层循环，将电影名称已播放时间组成Tree的节点
            foreach (DataRow dr in dt.Rows)
            {
                TreeNode tnChildren = new TreeNode();
                tnChildren.Name = dr["MovieId"].ToString();
                tnChildren.Text = dr["MovieName"].ToString();
                if (tnRoot.Nodes.Find(tnChildren.Name, false).Count() < 1)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        if (tnChildren.Name == item["MovieId"].ToString())
                        {
                            TreeNode tnChildrenTime = new TreeNode();
                            tnChildrenTime.Name = item["Id"].ToString();
                            tnChildrenTime.Text = item["MovieTime"].ToString();
                            tnChildren.Nodes.Add(tnChildrenTime);
                        }
                    }
                    tnRoot.Nodes.Add(tnChildren);
                }
            }
            tvMovie.Nodes.Add(tnRoot);
            tvMovie.ExpandAll();

        }


        private void SetSit(int id, int movieLinedId)
        {
            //动态显示座位
            string sql = string.Format("select * from ScreeningRoom where Id='{0}'", id);
            DataTable dt = DbHelper.GetDataTable(sql);
            DataRow dr = dt.Rows[0];
            tabPage2.Text = dr["ScreeningRoomName"].ToString();

            movieroom = dr["ScreeningRoomName"].ToString();

            tabPage2.Controls.Clear();
            var width = tabPage2.Width;
            var height = tabPage2.Height;
            int countY = Convert.ToInt32(dr["ScreeningRoomRows"]);
            int countx = Convert.ToInt32(dr["ScreeningRoomCells"]);
            for (int i = 0; i < countY; i++)
            {
                for (int x = 0; x < countx; x++)
                {
                    Label label = new Label();
                    label.BackColor = Color.FromArgb(255, 255, 255, 0);
                    label.Size = new System.Drawing.Size(80, 27);
                    label.Location = new Point((width / countx) * (x) + ((width / countx) / 2 - label.Width / 2),
                    (height / countY) * (i) + ((height / countY) / 2 - label.Height / 2));
                    label.Text = (i + 1) + "-" + (x + 1);
                    label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    tabPage2.Controls.Add(label);
                    //为lable绑定点击事件，获取选中的位置
                    label.DoubleClick += label_Click;
                }

            }

            //获取订单中的座位
            if (movieLinedId != null)
            {

                string sqlMS = string.Format("select * from MovieSell  where MovieLinedld='{0}'", movieLinedId);
                DataTable dtMs = DbHelper.GetDataTable(sqlMS);
                var controls = tabPage2.Controls;
                foreach (DataRow item in dtMs.Rows)
                {
                    foreach (Control control in controls)
                    {
                        if (item["MovieSit"].ToString() == (control as Label).Text)
                        {
                            control.BackColor = Color.FromArgb(255, 255, 0, 0);
                        }
                    }
                }
            }
        }
        // 显示电影信息
        private void SetMovieInfo(DataTable dt)
        {
            lblMovieName.Text = dt.Rows[0]["MovieName"].ToString();
            moviename = dt.Rows[0]["MovieName"].ToString();
            lblMovieActor.Text = dt.Rows[0]["MovieActor"].ToString();
            lblMovieDirector.Text = dt.Rows[0]["MovieDirector"].ToString();
            lblMoviePrice.Text = dt.Rows[0]["MoviePrice"].ToString();
            lblMovieTime.Text = Convert.ToDateTime(dt.Rows[0]["MovieTime"]).ToString("d");
            //枚举处理电影类型
            MovieType a = (MovieType)dt.Rows[0]["MovieType"];
            lblMovieType.Text = a.ToString();
            lblMovieFavourable.Text = dt.Rows[0]["MovieFavourable"].ToString();
            string PathImage = dt.Rows[0]["MoviePicturePath"].ToString();
            //数据库网上图片加载
            //Image O_Image = Image.FromStream(WebRequest.Create(PathImage).GetResponse().GetResponseStream());
            //pictureBox1.Image = O_Image;
            pictureBox1.Load(PathImage);
            lblPrice1.Text = "￥" + lblMoviePrice.Text;
            lblDiscoun1.Text = "￥" + lblMovieFavourable.Text;
        }
        // 绑定点击Label时选中座位的事件
        private void label_Click(object sender, EventArgs e)
        {
            if ((sender as Label).BackColor == Color.FromArgb(255, 255, 0, 0))
            {
                MessageBox.Show("已经出售，请重新选购！");//如果是红色表示已经被人购买
            }
            else
            {
                if ((sender as Label).BackColor == Color.FromArgb(255, 64, 224, 208))
                {
                    (sender as Label).BackColor = Color.FromArgb(255, 255, 255, 0);
                    lblSelect.Remove((sender as Label).Text);
                    lblCount.Text = lblSelect.Count().ToString();
                    decimal total = Convert.ToDecimal(lblMoviePrice.Text)
                         - Convert.ToDecimal(lblMovieFavourable.Text);
                    lblPayment.Text = "￥" + (total * lblSelect.Count()).ToString();
                }
                else
                {
                    (sender as Label).BackColor = Color.FromArgb(255, 64, 224, 208);
                    lblSelect.Add((sender as Label).Text);
                    lblCount.Text = lblSelect.Count().ToString();
                    decimal total = Convert.ToDecimal(lblMoviePrice.Text)
                        - Convert.ToDecimal(lblMovieFavourable.Text);
                    lblPayment.Text = "￥" + (total * lblSelect.Count()).ToString();
                }
            }
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



        private void tvMovie_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if (this.tvMovie.SelectedNode.Level == 2)
            {
                //获取选中的节点
                TreeNode tn = this.tvMovie.SelectedNode;

                int movieLined = Convert.ToInt32(tn.Name);
                //MessageBox.Show(tn.Text);

                movierid = tn.Text;


                string sql1 = string.Format("select * from MovieLined where Id='{0}'", movieLined);

                DataTable dt = DbHelper.GetDataTable(sql1);


                if (dt.Rows.Count > 0)
                {
                    //动态设置座位
                    SitId = Convert.ToInt32(dt.Rows[0]["MovieRoomld"]);
                    SetSit(SitId, movieLined);
                    MovieLinedId = movieLined;
                    //动态显示电影信息
                    int movieId = Convert.ToInt32(dt.Rows[0]["MovieId"]);
                    string sql2 = string.Format("select * from MovieInfo where Id='{0}'", movieId);
                    DataTable dtMI = DbHelper.GetDataTable(sql2);
                    SetMovieInfo(dtMI);
                    //设置电影票张数为0
                    lblCount.Text = "0";
                    lblPayment.Text = "￥0";
                    lblSelect.Clear();
                }

            }
        }

        private void btnTictet_Click(object sender, EventArgs e)
        {
            if (lblSelect.Count() < 1)
            {
                MessageBox.Show("请选择座位！");
            }
            else
            {
                int result = 0;
                //获取选中的位置
                var controls = tabPage2.Controls;
                foreach (Control control in controls)
                {
                    if (control.BackColor == Color.FromArgb(255, 64, 224, 208))
                    {
                        price = Convert.ToDecimal(lblMoviePrice.Text) - Convert.ToDecimal(lblMovieFavourable.Text);
                        sit = (control as Label).Text;
                        list1.Add(sit);
                        MovieTicket mt = new MovieTicket();
                        mt.MovieId = movierid;
                        mt.MoviePrice = price;
                        mt.MovieName = moviename;
                        mt.MovieRoom = movieroom;
                        list.Add(mt);
                        string sql3 = string.Format("insert into MovieSell(MovieLinedld,MovieSit,MovieSellPrice) values({0},'{1}',{2}) ", MovieLinedId, sit, price);
                        result += DbHelper.GetNonQuery(sql3);
                        //MessageBox.Show(list[0].MovieId);
                    }
                }

                if (result > 0)
                {
                    for (int i = 0; i < result; i++)
                    {
                        string li = list1[i];
                        TicketFrm fs = new TicketFrm(list, li);
                        //该窗体打开其他窗体无法操作 
                        fs.ShowDialog();

                    }

                    SetSit(SitId, MovieLinedId);
                }
                else
                {
                    MessageBox.Show("出票失败");

                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("请选择你要观看电影场次");
        }

        private void 退出toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DefaultFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            th.Abort();//结束线程
        }

        private void 刷新SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Controls.Clear(); 
            InitializeComponent();
            SetTreeView();
            imageLoad();
            //头像加载
            Image image = this.pictureBox2.Image;
            Image newImage = CutEllipse(image, new Rectangle(0, 0, 100, 100), new Size(100, 100));
            this.pictureBox2.Image = newImage;

        }

        private void 修改个人信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeRen rd = new GeRen(list2);
            rd.ShowDialog();
        }

        private void 超级管理员管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MovieUserFrm rf = new MovieUserFrm();
            rf.ShowDialog();
        }

        private void 影厅设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Movieroom mr = new Movieroom();
            mr.ShowDialog();
        }

        private void 查看帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help bz = new Help();
            bz.ShowDialog();
        }

        private void 联机隐私声明ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Privacy ys = new Privacy();
            ys.ShowDialog();
        }

        private void 客户反馈选项ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fankui fk = new Fankui(list2);
            fk.ShowDialog();
        }

        private void 发送笑脸ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Administrators i in list2)
            {
                c = i.Id;
            }
            string strcon = PubConstant.ConnectionString;
            string ss = string.Format("select count(*) from Feedback where FeedbackId={0}",c);
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                SqlCommand cmd = new SqlCommand(ss, conn);
                conn.Open();
                if ((int)cmd.ExecuteScalar() <= 0)
                {
                    string choose = @"insert into Feedback (FeedbackId,Evaluate) VALUES (@FeedbackId,@Evaluate)";
                    using (SqlConnection conn1 = new SqlConnection(strcon))
                    {
                        SqlCommand cmd1 = new SqlCommand(choose, conn1);
                        SqlParameter FeedbackId = new SqlParameter("@FeedbackId", c);
                        cmd1.Parameters.Add(FeedbackId);
                        cmd1.Parameters.Add("Evaluate", SqlDbType.NVarChar).Value = "Smile";
                        conn1.Open();
                        cmd1.ExecuteNonQuery();
                        MessageBox.Show("亲，感谢您的参与！");
                    }
                }
                else
                {
                    string choose = @"update Feedback set Evaluate = @Evaluate WHERE (FeedbackID=1)";
                    using (SqlConnection conn1 = new SqlConnection(strcon))
                    {
                        SqlCommand cmd1 = new SqlCommand(choose, conn1);
                        cmd1.Parameters.Add("@Evaluate", SqlDbType.NVarChar).Value = "Smile";
                        conn1.Open();
                        cmd1.ExecuteNonQuery();
                        MessageBox.Show("亲，感谢您的参与！");
                    }
                }
            }
        }

        private void 发送哭脸ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Administrators i in list2)
            {
                c = i.Id;
            }
            string strcon = PubConstant.ConnectionString;
            string ss = string.Format("select count(*) from Feedback where FeedbackId={0}",c);
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                SqlCommand cmd = new SqlCommand(ss, conn);
                conn.Open();
                if ((int)cmd.ExecuteScalar() <= 0)
                {
                    string choose = @"insert into Feedback (FeedbackId,Evaluate) VALUES (@FeedbackId,@Evaluate)";
                    using (SqlConnection conn1 = new SqlConnection(strcon))
                    {
                        SqlCommand cmd1 = new SqlCommand(choose, conn1);
                        SqlParameter FeedbackId = new SqlParameter("@FeedbackId", c);
                        cmd1.Parameters.Add(FeedbackId);
                        cmd1.Parameters.Add("Evaluate", SqlDbType.NVarChar).Value = "Cry";
                        conn1.Open();
                        cmd1.ExecuteNonQuery();
                        MessageBox.Show("亲，感谢您的参与！");
                    }
                }
                else
                {
                    string choose = @"update Feedback set Evaluate = @Evaluate WHERE (FeedbackID=1)";
                    using (SqlConnection conn1 = new SqlConnection(strcon))
                    {
                        SqlCommand cmd1 = new SqlCommand(choose, conn1);
                        cmd1.Parameters.Add("@Evaluate", SqlDbType.NVarChar).Value = "Cry";
                        conn1.Open();
                        cmd1.ExecuteNonQuery();
                        MessageBox.Show("亲，感谢您的参与！");
                    }
                }
            }
        }

        private void 建议ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Suggest jy = new Suggest(list2);
            jy.ShowDialog();
        }

        private void 关于AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Concerning gy = new Concerning();
            gy.ShowDialog();
        }

        private void 修改密码toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Changepwd gg = new Changepwd(list2);
            gg.ShowDialog();
        }

        private void 购票ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel2.Location = new Point(-2000, 20);
            panel1.Location = new Point(5, 5);
        }

        private void 影片管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel2.Location = new Point(5, 5);
            panel1.Location = new Point(-2000, 20);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count <= 0)		//用于判断是否选中了DataGridView中的一行
                {
                    MessageBox.Show("请选中一行进行操作");
                    return;
                }
                txtID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                txtPM.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                txtZY.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                txtDY.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                txtLX.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                txtPJ.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                txtSJ.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                txtYH.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                pictureBox4.Load(dataGridView1.SelectedRows[0].Cells[8].Value.ToString());
            }catch
            {
                MessageBox.Show("请选中一行进行操作");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtPM.Text.Trim().Equals("") || txtDY.Text.Trim().Equals("") || txtZY.Text.Trim().Equals("") ||
                txtLX.Text.Trim().Equals("") || txtSJ.Text.Trim().Equals("") || txtPJ.Text.Trim().Equals("") || txtYH.Text.Trim().Equals(""))
            {
                MessageBox.Show("完整信息！");
                return;
            }

            string str = "insert into MovieInfo(MovieName,MovieActor,MovieDirector,MovieType,MoviePrice,MovieTime,MovieFavourable,MoviePicturePath) values(@MovieName,@MovieActor,@MovieDirector,@MovieType,@MoviePrice,@MovieTime,@MovieFavourable,@MoviePicturePath) ";
            SqlConnection conn = new SqlConnection(strcon);
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.Parameters.Add(new SqlParameter("@MovieName", txtPM.Text));
            cmd.Parameters.Add(new SqlParameter("@MovieActor", txtZY.Text));
            cmd.Parameters.Add(new SqlParameter("@MovieDirector", txtDY.Text));
            cmd.Parameters.Add(new SqlParameter("@MovieType", txtLX.Text));
            cmd.Parameters.Add(new SqlParameter("@MoviePrice", txtPJ.Text));
            cmd.Parameters.Add(new SqlParameter("@MovieTime", txtSJ.Text));
            cmd.Parameters.Add(new SqlParameter("@MovieFavourable", txtYH.Text));
            cmd.Parameters.Add(new SqlParameter("@MoviePicturePath", pictureBox4.ImageLocation));
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

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)		//用于判断是否选中了DataGridView中的一行
            {
                MessageBox.Show("请选中一行进行操作！");
                return;
            }
            SqlConnection conn = new SqlConnection(strcon);
            try
            {
                string str = "delete from MovieInfo where MovieName=@MovieName";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.Add(new SqlParameter("@MovieName", txtPM.Text));
                conn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("数据删除成功");
                    dataGridView1.DataSource = getData();
                }
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("该电影正在上映，删除失败");
            }
            finally
            {
                conn.Close();
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPM.Text != "")
                {
                    string str = string.Format("select * from MovieInfo where MovieName='{0}'", txtPM.Text);
                    //MessageBox.Show(str);
                    DataTable dt = DbHelper.GetDataTable(str);
                    MovieInfo mf = new MovieInfo();
                    DataRow r = dt.Rows[0];
                    txtID.Text = r["Id"].ToString();
                    txtZY.Text = r["MovieActor"].ToString();
                    txtDY.Text = r["MovieDirector"].ToString();
                    //枚举处理电影类型
                    MovieType a = (MovieType)(r["MovieType"]);
                    txtLX.Text = a.ToString();
                    txtPJ.Text = r["MoviePrice"].ToString();
                    txtSJ.Text = r["MovieTime"].ToString();
                    txtYH.Text = r["MovieFavourable"].ToString();
                    pictureBox4.Load(r["MoviePicturePath"].ToString());
                }
                else
                {
                    MessageBox.Show("请输入片名！");
                }
            }catch
            {
                MessageBox.Show("不存在该片名，请重新输入！");
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
               
                string str = "update MovieInfo set MovieName=@MovieName,MovieActor=@MovieActor,MovieDirector=@MovieDirector,MovieType=@MovieType,MoviePrice=@MoviePrice,MovieTime=@MovieTime,MovieFavourable=@MovieFavourable,MoviePicturePath=@MoviePicturePath where Id=@id";
               
                SqlConnection conn = new SqlConnection(strcon);
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.Add(new SqlParameter("@id", txtID.Text));
                cmd.Parameters.Add(new SqlParameter("@MovieName", txtPM.Text));
                cmd.Parameters.Add(new SqlParameter("@MovieActor", txtZY.Text));
                cmd.Parameters.Add(new SqlParameter("@MovieDirector", txtDY.Text));
                cmd.Parameters.Add(new SqlParameter("@MovieType", txtLX.Text));
                cmd.Parameters.Add(new SqlParameter("@MoviePrice", txtPJ.Text));
                cmd.Parameters.Add(new SqlParameter("@MovieTime", txtSJ.Text));
                cmd.Parameters.Add(new SqlParameter("@MovieFavourable", txtYH.Text));
                cmd.Parameters.Add(new SqlParameter("@MoviePicturePath", pictureBox4.ImageLocation));
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
                MessageBox.Show("不存在该影片类型，请重新输入！");
            }
        }

        private void clearbtu_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void MovieType_Click(object sender, EventArgs e)
        {
            movieTP mTP = new movieTP();
            mTP.ShowDialog();
        }

        private void btnUpLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            if (openfile.ShowDialog() == DialogResult.OK && (openFileDialog1.FileName != ""))
            {
                pictureBox4.ImageLocation = openfile.FileName;
                //textbox.Text = openfile.FileName;
            }
            openfile.Dispose();
        }

        private void 电影设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            moviePD mPD = new moviePD();
            mPD.ShowDialog();
        }

    }

      

}

       

       

      

      

      

       
        
    
