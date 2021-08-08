using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Project
{
    public partial class crash2 : Form
    {
        public crash2()
        {
            InitializeComponent();
            //Labels used:
            crash.Visible = false;
            crash1.Visible = false;
            over.Visible = false;
            winner.Visible = false;
        }
        int carspeed = 15;  //change in cars
        double trafficspeed1, trafficspeed2; // speed of the game(difficulty)
        int score1, score2 = 0;
        // Sounds used:
        SoundPlayer crash_sound = new SoundPlayer(@"E:/crash.wav");
        SoundPlayer carstart = new SoundPlayer(@"E:/carstart.wav");
        SoundPlayer carmoving = new SoundPlayer(@"E:/carmoving.wav");



        private void Form1_Load(object sender, EventArgs e)
        { 
            this.BackgroundImage = Image.FromFile(@"E:/Background2.png");  //BackGround Tracks
            carstart.Play(); //sound of car starting when form is loaded

            button1.Text = "START";
            button1.ForeColor = Color.Yellow;
            button1.BackColor = Color.Red;

            button2.Text = "EXIT";
            button2.ForeColor = Color.Yellow;
            button2.BackColor = Color.Red;

            Image car1 = Image.FromFile(@"E:/car.png");                   //Car 1 image
            pictureBox1.Image = car1;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Location = new Point(165, 500);

            Image car2 = Image.FromFile(@"E:/car1.png");                   //Car 2 image
            pictureBox2.Image = car2;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Location = new Point(525, 500);

            Image t1 = Image.FromFile(@"E:/traffic1.png");                   //traffic 1 image
            traffic1.Image = t1;
            traffic1.SizeMode = PictureBoxSizeMode.StretchImage;
            traffic1.BackColor = Color.Transparent;

            Image t2 = Image.FromFile(@"E:/traffic2.png");                   //traffic 2 image
            traffic2.Image = t2;
            traffic2.SizeMode = PictureBoxSizeMode.StretchImage;
            traffic2.BackColor = Color.Transparent;

            Image t3 = Image.FromFile(@"E:/traffic3.png");                   //traffic 3 image
            traffic3.Image = t3;
            traffic3.SizeMode = PictureBoxSizeMode.StretchImage;
            traffic3.BackColor = Color.Transparent;

            Image t7 = Image.FromFile(@"E:/traffic6.png");                   //traffic 7 image
            traffic7.Image = t7;
            traffic7.SizeMode = PictureBoxSizeMode.StretchImage;
            traffic7.BackColor = Color.Transparent;

            Image t4 = Image.FromFile(@"E:/traffic4.png");                   //traffic 4 image
            traffic4.Image = t4;
            traffic4.SizeMode = PictureBoxSizeMode.StretchImage;
            traffic4.BackColor = Color.Transparent;

            Image t5 = Image.FromFile(@"E:/traffic5.png");                   //traffic 5 image
            traffic5.Image = t5;
            traffic5.SizeMode = PictureBoxSizeMode.StretchImage;
            traffic5.BackColor = Color.Transparent;

            Image t6 = Image.FromFile(@"E:/traffic6.png");                   //traffic 6 image
            traffic6.Image = t6;
            traffic6.SizeMode = PictureBoxSizeMode.StretchImage;
            traffic6.BackColor = Color.Transparent;

            Image t8 = Image.FromFile(@"E:/traffic1.png");                   //traffic 8 image
            traffic8.Image = t8;
            traffic8.SizeMode = PictureBoxSizeMode.StretchImage;
            traffic8.BackColor = Color.Transparent;

           
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
            //Car 2 Controls>
            if ( e.KeyCode == Keys.Left)
            {
                if ( pictureBox2.Left > 405)
                {
                    pictureBox2.Left -= carspeed;
                }               
            }
            if (e.KeyCode == Keys.Right)
            {
                if ( pictureBox2.Right < 720)
                {
                    pictureBox2.Left += carspeed;
                }                 
            }
            if (e.KeyCode == Keys.Up)
            {
                if (pictureBox2.Top > 0)
                {
                    pictureBox2.Top -= carspeed;
                }
                    
            }
            if (e.KeyCode == Keys.Down)
            {
                if (pictureBox2.Top < 500)
                {
                    pictureBox2.Top += carspeed;
                }
            }
            //Car 1 Controls(W,A,S,D):
            if (e.KeyCode == Keys.A)
            {
                if (pictureBox1.Left > 40)
                {
                    pictureBox1.Left -= carspeed;
                }
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.D)
            {
                if (pictureBox1.Right < 370)
                {
                    pictureBox1.Left += carspeed;
                }
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.W)
            {
                if (pictureBox1.Top > 0)
                {
                    pictureBox1.Top -= carspeed;
                }
                e.SuppressKeyPress = true;

            }
            if (e.KeyCode == Keys.S)
            {
                if (pictureBox1.Top < 500)
                {
                    pictureBox1.Top += carspeed;
                }
                e.SuppressKeyPress = true;
            }
        }
        void game()
        {
            if (timer1.Enabled==false && timer2.Enabled==false)
            {
                if (score1 > score2)
                { winner.Text = "Winner is Car 1"; }
                else { winner.Text = "Winner is Car 2"; }
                carmoving.Stop();        //Sound stops
                over.Show();            //Game over label
                winner.Show();         //Winner label 
                button2.Enabled = true;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            carmoving.PlayLooping();      // car moving sound
            timer1.Start();
            timer2.Start();
            name.Hide();
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            trafficspeed1 += 0.1;   //speed icreases on every tick
            score1 += 1;            //score also increases
            label1.Text = "Car 1:" + score1.ToString();

            Random r1 = new Random();
            int x = r1.Next(40, 340);  //for car1
            int y = r1.Next(0, 0);   //so traffic always start coming from top

            if (traffic1.Top >= 500)
            { traffic1.Location = new Point(x, y); }
            else { traffic1.Top += Convert.ToInt32(trafficspeed1); }
            if (traffic2.Top >= 500)
            { traffic2.Location = new Point(x, y); }
            else{ traffic2.Top += Convert.ToInt32(trafficspeed1); }
            if (traffic3.Top >= 500)
            { traffic3.Location = new Point(x, y); }
            else{ traffic3.Top += Convert.ToInt32(trafficspeed1); }
            if (traffic7.Top >= 500)
            { traffic7.Location = new Point(x, y); }
            else { traffic7.Top += Convert.ToInt32(trafficspeed1); }

            if (pictureBox1.Bounds.IntersectsWith(traffic1.Bounds))   //crash
            {
                timer1.Enabled = false;
                crash.Show();    //crash label
                
            }
            if (pictureBox1.Bounds.IntersectsWith(traffic2.Bounds))
            {
                timer1.Enabled = false;
                crash.Show();
                
            }
            if (pictureBox1.Bounds.IntersectsWith(traffic3.Bounds))
            {
                timer1.Enabled = false;
                crash.Show();
                
            }
            if (pictureBox1.Bounds.IntersectsWith(traffic7.Bounds))
            {
                timer1.Enabled = false;
                crash.Show();
                
            }
            game();   //game over function called
        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            
            trafficspeed2 += 0.1;
            score2 += 1;
            label2.Text = "Car 2:" + score2.ToString();

            Random r2 = new Random();    //car2
            int x = r2.Next(405, 690);
            int y = r2.Next(0, 0);

            if (traffic4.Top >= 500)
            { traffic4.Location = new Point(x, y); ; }
            else { traffic4.Top += Convert.ToInt32(trafficspeed2); }  //double need to be converted to string
            if (traffic5.Top >= 500)
            { traffic5.Location = new Point(x, y); }
            else { traffic5.Top += Convert.ToInt32(trafficspeed2); }
            if (traffic6.Top >= 500)
            { traffic6.Location = new Point(x, y); ; }
            else { traffic6.Top += Convert.ToInt32(trafficspeed2); }
            if (traffic8.Top >= 500)
            { traffic8.Location = new Point(x, y); ; }
            else { traffic8.Top += Convert.ToInt32(trafficspeed2); }

            if (pictureBox2.Bounds.IntersectsWith(traffic4.Bounds))     //crash
            {  
                timer2.Enabled = false;
                crash1.Show();
            }
            if (pictureBox2.Bounds.IntersectsWith(traffic5.Bounds))
            {
                timer2.Enabled = false;
                crash1.Show();
            }
            if (pictureBox2.Bounds.IntersectsWith(traffic6.Bounds))
            {
                timer2.Enabled = false;
                crash1.Show();
            }
            if (pictureBox2.Bounds.IntersectsWith(traffic8.Bounds))
            {
                timer2.Enabled = false;
                crash1.Show();
            }
            game();
        }
        
       
    }
}
