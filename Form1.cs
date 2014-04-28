using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Threading;

namespace Game_HitBall
{
    public partial class Form1 : Form
    {
        Thread t;
        int x, y,cw, ch;
        static int hit, miss;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            hit = 0;
            miss = 0;
            //lblHit.Text = "Hits=0";
           // lblMiss.Text = "Misses=0";
            t = new Thread(new ThreadStart(this.Run));
            t.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            t.Abort();
            double hit_percent = (hit / (double)(hit + miss)) * 100;
            MessageBox.Show("hit percentage=" + hit_percent.ToString());
            lblHit.Text = "Hits=0";
            lblMiss.Text = "Misses=0";
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            cw = this.ClientSize.Width;
            ch = this.ClientSize.Height;
            Graphics g = e.Graphics;
            Brush br = new SolidBrush(Color.RoyalBlue);
            g.FillEllipse(br, x, y, 50, 50);
        }
        public void Run()
        {
            while (true)
            {
                //MessageBox.Show(cw.ToString());
                Random rand = new Random();
                x = rand.Next(10, cw - 20);
                y = rand.Next(10, ch - 20);
                //w = 50;
                //h = 50;
                Invalidate();
                Thread.Sleep(100);
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Point p1 = e.Location;
            if ((x < p1.X) && (p1.X < x + 50) && (y < p1.Y) && (p1.Y < y + 50))
            {
                hit++;
                lblHit.Text = "Hits=" + hit.ToString();
            }
            else
            {
                miss++;
                lblMiss.Text = "Misses=" + miss.ToString();
            }
        }

    }
}
