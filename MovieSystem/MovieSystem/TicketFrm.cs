using MovieSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieSystem
{
    public partial class TicketFrm : Form
    {
        bool formMove = false;//窗体是否移动
        Point formPoint;//记录窗体的位置
        public TicketFrm()
        {
            InitializeComponent();
        }
        public TicketFrm(List<MovieTicket> list ,string list1)
        {
            InitializeComponent();
            foreach (MovieTicket a in list)
            {
              
                lblId.Text = a.MovieId;
                lblMovieName.Text = a.MovieName;
                lblMovieRoom.Text = a.MovieRoom; 
                lblMoviePrice.Text = a.MoviePrice.ToString();
                
            }

            lblMovieSit.Text = list1;
            
               
        }

        private void TicketFrm_MouseDown(object sender, MouseEventArgs e)
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

        private void TicketFrm_MouseMove(object sender, MouseEventArgs e)
        {
            if (formMove == true)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(formPoint.X, formPoint.Y);
                Location = mousePos;
            }
        }

        private void TicketFrm_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)//按下的是鼠标左键
            {
                formMove = false;//停止移动
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblMovieSit_Click(object sender, EventArgs e)
        {

        }

        private void TicketFrm_Load(object sender, EventArgs e)
        {

        }

       
    }
}
