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
        int P2Tank_traj = 1;
        int p2Shelltraj;
        Boolean p2shelllive;
        
        string path = "C:/Users/Tristan/Documents/Uni/3rd year/Programming for mobile devices/Game Prototype/images/";
        public Form1()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(OnKeyDown);
        }
        private void initialisep2firing()
        {

            pictureBox3.Left = -100;
            pictureBox3.Top = -100;

            p2Shelltraj = 0;
            p2shelllive = false;
        }
        private void p2firing()
        {
            p2shelllive = true;
            SET_TRAJECTORY();
        }

        private void SET_TRAJECTORY()
        {
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

        public void OnKeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode.ToString() == "A")
            {
                pictureBox1.Image = Image.FromFile(path +"tank1.bmp");
                pictureBox1.Left = pictureBox1.Left - 5;
                pictureBox1.Refresh();
                
            }
            if (e.KeyCode.ToString()=="D")
            {
                pictureBox1.Image = Image.FromFile(path +"tank2.bmp");
                pictureBox1.Left = pictureBox1.Left + 5;
                pictureBox1.Refresh();
           
            }
            if (e.KeyCode.ToString() == "S")
            {
                pictureBox1.Image = Image.FromFile(path +"tank3.bmp");
                pictureBox1.Top = pictureBox1.Top + 5;
                pictureBox1.Refresh();
            }
            if (e.KeyCode.ToString() == "W")
            {
                pictureBox1.Image = Image.FromFile(path +"tank4.bmp");
                pictureBox1.Top = pictureBox1.Top - 5;
                pictureBox1.Refresh();
            }
            if (e.KeyCode.ToString() == "E")
            {
                pictureBox1.Image = Image.FromFile(path +"tank5.bmp");
                pictureBox1.Top = pictureBox1.Top - 5;
                pictureBox1.Left = pictureBox1.Left + 5;
                pictureBox1.Refresh();
            }
            if (e.KeyCode.ToString() == "Q")
            {
                pictureBox1.Image = Image.FromFile(path +"tank8.bmp");
                pictureBox1.Top = pictureBox1.Top - 5;
                pictureBox1.Left = pictureBox1.Left - 5;
                pictureBox1.Refresh();
            }
            if (e.KeyCode.ToString() == "Z")
            {
                pictureBox1.Image = Image.FromFile(path +"tank7.bmp");
                pictureBox1.Left = pictureBox1.Left - 5;
                pictureBox1.Top = pictureBox1.Top + 5;
                pictureBox1.Refresh();
            }
            if (e.KeyCode.ToString() == "C")
            {
                pictureBox1.Image = Image.FromFile(path +"tank6.bmp");
                pictureBox1.Top = pictureBox1.Top + 5;
                pictureBox1.Left = pictureBox1.Left + 5;
                pictureBox1.Refresh();
            }

            // player 1 fires using 'F' key 
            if (e.KeyCode.ToString() == "F")
            {
               
            }
                
            //Player 2 controls
            if (e.KeyCode.ToString() == "J")
            {
                pictureBox2.Image = Image.FromFile(path +"tank1.bmp");
                pictureBox2.Left = pictureBox2.Left - 5;
                pictureBox2.Refresh();
            }
            if (e.KeyCode.ToString() == "L")
            {
                pictureBox2.Image = Image.FromFile(path + "tank2.bmp");
                pictureBox2.Left = pictureBox2.Left + 5;
                pictureBox2.Refresh();
            }
            if (e.KeyCode.ToString() == "K")
            {
                pictureBox2.Image = Image.FromFile(path + "tank3.bmp");
                pictureBox2.Top = pictureBox2.Top + 5;
                pictureBox2.Refresh();
            }
            if (e.KeyCode.ToString() == "I")
            {
                pictureBox2.Image = Image.FromFile(path + "tank4.bmp");
                pictureBox2.Top = pictureBox2.Top - 5;
                pictureBox2.Refresh();
            }

            //SHELL TRAJ
            switch (p2Shelltraj)
            {
                case 1:
                    pictureBox3.Image = Image.FromFile(path + "shell.bmp");
                    pictureBox3.Left = pictureBox3.Left - 5;
                    pictureBox3.Refresh();
                    P2Tank_traj = 1;
                    break;
            }







            //player 2 fires using '5' key

            if (e.KeyCode.ToString() == "5")
            {
                p2firing();
            }
                //detects walls 
                //DetectWall();
                OffscreenOnscreen();
                initialisep2firing();
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
    }
}
