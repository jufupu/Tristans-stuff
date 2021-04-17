using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TankWar
{
    public partial class Form1 : Form
    {
        int P1Tank_traj = 1;
        int P2Tank_traj = 1;
        int p1Shelltraj;
        int p2Shelltraj;
        bool p1shelllive;
        bool p2shelllive;
        
       
        string path = "C:/Users/Tristan/Documents/Uni/3rd year/Programming for mobile devices/Game Prototype/images/";
        public Form1()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(OnKeyDown);
            initialisep2firing(); 


        }
        public void OnKeyDown(object sender, KeyEventArgs e)
        {
            // player 1 fires using 'F' key 
            if (e.KeyCode.ToString() == "F")
            {
                p1firing();
            }

            //player 2 fires using '5' key

            if (e.KeyCode.ToString() == "T")
            {
                p2firing();
            }
            //player 1 movement

            if (e.KeyCode.ToString() == "A")
            {
                pictureBox1.Image = Image.FromFile(path +"tank1.bmp");
                pictureBox1.Left = pictureBox1.Left - 5;
                pictureBox1.Refresh();
                P1Tank_traj = 1;

            }
            if (e.KeyCode.ToString()=="D")
            {
                pictureBox1.Image = Image.FromFile(path +"tank2.bmp");
                pictureBox1.Left = pictureBox1.Left + 5;
                pictureBox1.Refresh();
                P1Tank_traj = 2;

            }
            if (e.KeyCode.ToString() == "S")
            {
                pictureBox1.Image = Image.FromFile(path +"tank3.bmp");
                pictureBox1.Top = pictureBox1.Top + 5;
                pictureBox1.Refresh();
                P1Tank_traj = 3;
            }
            if (e.KeyCode.ToString() == "W")
            {
                pictureBox1.Image = Image.FromFile(path +"tank4.bmp");
                pictureBox1.Top = pictureBox1.Top - 5;
                pictureBox1.Refresh();
                P1Tank_traj = 4;
            }

            //Player 2 controls
            if (e.KeyCode.ToString() == "J")
            {
                pictureBox2.Image = Image.FromFile(path +"tank1.bmp");
                pictureBox2.Left = pictureBox2.Left - 5;
                pictureBox2.Refresh();
                P2Tank_traj = 1;
            }
            if (e.KeyCode.ToString() == "L")
            {
                pictureBox2.Image = Image.FromFile(path + "tank2.bmp");
                pictureBox2.Left = pictureBox2.Left + 5;
                pictureBox2.Refresh();
                P2Tank_traj = 2;
            }
            if (e.KeyCode.ToString() == "K")
            {
                pictureBox2.Image = Image.FromFile(path + "tank3.bmp");
                pictureBox2.Top = pictureBox2.Top + 5;
                pictureBox2.Refresh();
                P2Tank_traj = 3;
            }
            if (e.KeyCode.ToString() == "I")
            {
                pictureBox2.Image = Image.FromFile(path + "tank4.bmp");
                pictureBox2.Top = pictureBox2.Top - 5;
                pictureBox2.Refresh();
                P2Tank_traj = 4;
            }
                //DetectWall();
                OffscreenOnscreen();
        }
        private void initialisep2firing()
        {
            pictureBox4.Left = -100;
            pictureBox4.Top = -100;

            p1Shelltraj = 0;
            p1shelllive = false;

            pictureBox3.Left = -100;
            pictureBox3.Top = -100;

            p2Shelltraj = 0;
            p2shelllive = false;
        }
        //Timers for shell movement 
        Timer timer1 = new Timer
        {
            Interval = 10
        };
        Timer timer2 = new Timer
        {
            Interval = 10
        };
        //Functions for firing
        private void p1firing()
        {
            p1shelllive = true;
            SET_TRAJECTORY();
            timer1.Enabled = true;
        }
        private void p2firing()
        {
            p2shelllive = true;
            SET_TRAJECTORY();
            timer2.Enabled = true;
        }

        //Shell movement
        private void timer1_Tick()
        {
            MoveShell();
        }
        private void timer2_Tick()
        {
            MoveShell();
        }
        private void MoveShell()
        {
            //player 1
            if (p1shelllive == true)
            {
                if (p1Shelltraj == 1)
                { pictureBox4.Left = pictureBox4.Left - 5; }
                if (p1Shelltraj == 2)
                { pictureBox4.Left = pictureBox4.Left + 5; }
                if (p1Shelltraj == 3)
                { pictureBox4.Top = pictureBox4.Top + 5; }
                if (p1Shelltraj == 4)
                { pictureBox4.Top = pictureBox4.Top - 5; }

                if ((pictureBox4.Left < 0) || (pictureBox4.Left > this.Width) || (pictureBox4.Top > this.Height) || (pictureBox4.Top < 0))
                {
                    p1shelllive = false;
                    timer1.Enabled = false;
                    pictureBox4.Left = -100;
                    pictureBox4.Top = -100;

                }
            }
            //player 2 
            if (p2shelllive == true)
            {
                if (p2Shelltraj == 1)
                { pictureBox3.Left = pictureBox3.Left - 5; }
                if (p2Shelltraj == 2)
                { pictureBox3.Left = pictureBox3.Left + 5; }
                if (p2Shelltraj == 3)
                { pictureBox3.Top = pictureBox3.Top + 5; }
                if (p2Shelltraj == 4)
                { pictureBox3.Top = pictureBox3.Top - 5; }

                if ((pictureBox3.Left < 0) || (pictureBox3.Left > this.Width) || (pictureBox3.Top > this.Height) || (pictureBox3.Top < 0))
                {
                    p2shelllive = false;
                    timer2.Enabled = false;
                    pictureBox3.Left = -100;
                    pictureBox3.Top = -100;

                }
            }
        }

            private void SET_TRAJECTORY()
        {   
            
            //player 1
            if (P1Tank_traj == 1)
            {
                pictureBox4.Left = pictureBox1.Left;
                pictureBox4.Top = pictureBox1.Top + (pictureBox1.Height / 2);
                p1Shelltraj = 1;
            }
            if (P1Tank_traj == 2)
            {
                pictureBox4.Left = pictureBox1.Left + pictureBox1.Width;
                pictureBox4.Top = pictureBox1.Top + (pictureBox1.Height / 2);
                p1Shelltraj = 2;
            }
            if (P1Tank_traj == 3)
            {
                pictureBox4.Left = pictureBox1.Left + (pictureBox1.Width / 2);
                pictureBox4.Top = pictureBox1.Top + pictureBox1.Height;
                p1Shelltraj = 3;
            }
            if (P1Tank_traj == 4)
            {

                pictureBox4.Left = pictureBox1.Left + (pictureBox1.Width / 2);
                pictureBox4.Top = pictureBox1.Top;
                p1Shelltraj = 4;
            }
            //player 2 
            if (P2Tank_traj == 1)
            {
                pictureBox3.Left = pictureBox2.Left;
                pictureBox3.Top = pictureBox2.Top + (pictureBox2.Height / 2);
                p2Shelltraj = 1;
            }
            if (P2Tank_traj == 2)
            {
                pictureBox3.Left = pictureBox2.Left + pictureBox2.Width;
                pictureBox3.Top = pictureBox2.Top + (pictureBox2.Height / 2);
                p2Shelltraj = 2;
            }
            if (P2Tank_traj == 3)
            {
                pictureBox3.Left = pictureBox2.Left + (pictureBox2.Width / 2);
                pictureBox3.Top = pictureBox2.Top + pictureBox2.Height;
                p2Shelltraj = 3;
            }
            if (P2Tank_traj == 4)
            {

                pictureBox3.Left = pictureBox2.Left + (pictureBox2.Width / 2);
                pictureBox3.Top = pictureBox2.Top;
                p2Shelltraj = 4;
            }
        }

        public void DetectWall()
        {
            if (pictureBox1.Left <= 0)
                pictureBox1.Left = pictureBox1.Left + 20;
                pictureBox1.Refresh();

            if (pictureBox1.Left >= (this.Width - pictureBox1.Width))
                pictureBox1.Left = pictureBox1.Left - 50;
                pictureBox1.Refresh();

            if (pictureBox1.Top <= 0)
                pictureBox1.Top = pictureBox1.Top + 20;
                pictureBox1.Refresh();

            if (pictureBox1.Top >= this.Height - pictureBox1.Height)
                pictureBox1.Top = pictureBox1.Top - 50;
                pictureBox1.Refresh();

            if (pictureBox2.Left <= 0)
                pictureBox2.Left = pictureBox2.Left + 20;
                pictureBox2.Refresh();

            if (pictureBox2.Left >= (this.Width - pictureBox1.Width))
                pictureBox2.Left = pictureBox2.Left - 50;
                pictureBox2.Refresh();

            if (pictureBox2.Top <= 0)
                pictureBox2.Top = pictureBox2.Top + 20;
                pictureBox2.Refresh();

            if (pictureBox2.Top >= this.Height - pictureBox1.Height)
                pictureBox2.Top = pictureBox2.Top - 50;
                pictureBox2.Refresh();
        }

        public void OffscreenOnscreen()
        {
            //player 1
            if (pictureBox1.Left + pictureBox1.Width <= 0)
            {
                pictureBox1.Left = this.Width - 1;
                pictureBox1.Refresh();
            }

            if (pictureBox1.Left >= this.Width)
            {
                pictureBox1.Left = 0 - pictureBox1.Width;
                pictureBox1.Refresh();
            }

            if (pictureBox1.Top <= 0 - pictureBox1.Height)
            {
                pictureBox1.Top = this.Height - 1;
                pictureBox1.Refresh();
            }

            if (pictureBox1.Top >= this.Height)
            {
                pictureBox1.Top = 0 - pictureBox1.Height;
            }
            // player 2 
            if (pictureBox2.Left + pictureBox2.Width <= 0)
            {
                pictureBox2.Left = this.Width - 1;
                pictureBox2.Refresh();
            }

            if (pictureBox2.Left >= this.Width)
            {
                pictureBox2.Left = 0 - pictureBox2.Width;
                pictureBox2.Refresh();
            }

            if (pictureBox2.Top <= 0 - pictureBox2.Height)
            {
                pictureBox2.Top = this.Height - 1;
                pictureBox2.Refresh();
            }

            if (pictureBox2.Top >= this.Height)
            {
                pictureBox2.Top = 0 - pictureBox2.Height;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
                    }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click_2(object sender, EventArgs e)
        {

        }
    }
}
