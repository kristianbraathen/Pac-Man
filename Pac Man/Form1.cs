using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pac_Man
{

    public partial class Form1 : Form
    {
        bool goup;
        bool godown;
        bool goleft;
        bool goright;
        int speed = 8;

        int ghost1 = 5;
        int ghost2 = 5;

        int ghost3x = 5;
        int ghost3y = 5;


        int score = 0;
        bool isGameOver = false;


        public Form1()
        {
            InitializeComponent();
            label2.Visible = false;
            //GameTimer.Start();
            ResetGame();
           
        }


        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = true;
                pacman.Image = Properties.Resources.left;
            }

            if (e.KeyCode == Keys.Up)
            {
                goup = true;
                pacman.Image = Properties.Resources.Up;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = true;
                pacman.Image = Properties.Resources.right;
            }

            if (e.KeyCode == Keys.Down)
            {
                godown = true;
                pacman.Image = Properties.Resources.down;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = false;

            }

            if (e.KeyCode == Keys.Up)
            {
                goup = false;

            }
            if (e.KeyCode == Keys.Right)
            {
                goright = false;

            }

            if (e.KeyCode == Keys.Down)
            {
                godown = false;

            }
            if (e.KeyCode == Keys.Enter && isGameOver == true)
            {
               ResetGame();
               
            }



        }
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            txtScore.Text = "Score: " + score; 

           
            if (goleft)
            {
                pacman.Left -= speed;
                 
            }
            if (goright)
            {
                pacman.Left += speed;
               
            }
            if (goup)
            {
                pacman.Top -= speed;
               
            }

            if (godown)
            {
                pacman.Top += speed;
              
            }
            if (pacman.Left < -10)
            {
                pacman.Left = 744;
            }
            if (pacman.Left > 744)
            {
                pacman.Left = -10;
            }
            if (pacman.Top < -10)
            {
                pacman.Top = 624;

            }
            if (pacman.Top > 624)
            {
                pacman.Top = 0;
            }

           
            redGhost.Left += ghost1;
            yellowGhost.Left += ghost2;


            if (redGhost.Bounds.IntersectsWith(pictureBox2.Bounds))
            {
                ghost1 = -ghost1;
            }
          
            else if (redGhost.Bounds.IntersectsWith(pictureBox1.Bounds))
            {
                ghost1 = -ghost1;
            }
            
            if (yellowGhost.Bounds.IntersectsWith(pictureBox3.Bounds))
            {
                ghost2 = -ghost2;
            }
            
            else if (yellowGhost.Bounds.IntersectsWith(pictureBox4.Bounds))
            {
                ghost2 = -ghost2;
            }
           

            foreach (Control x in this.Controls)
            {

                if (x is PictureBox && (String)x.Tag == "wall" || (String)x.Tag == "ghost")
                {
                    
                    if (((PictureBox)x).Bounds.IntersectsWith(pacman.Bounds) || score == 7)
                    {
                        pacman.Left = 0;
                        pacman.Top = 45;
                        label2.Text = "GAME OVER";
                        label2.Visible = true;
                        
                        GameTimer.Stop();
                        if (score == 7)
                        {
                            label2.Text = "You Win!";
                            GameOver("You Win!");
                        }

                    }
                }
                if (x is PictureBox box && (String)x.Tag == "coin")
                {
                    
                    if (box.Bounds.IntersectsWith(pacman.Bounds))
                    {
                        this.Controls.Remove(x); 
                        score++; 
                    }
                }

            }

            
            pinkGhost.Left += ghost3x;
            pinkGhost.Top += ghost3y;

            if (pinkGhost.Left < 1 ||
                pinkGhost.Left + pinkGhost.Width > ClientSize.Width - 2 ||
                (pinkGhost.Bounds.IntersectsWith(pictureBox4.Bounds)) ||
                (pinkGhost.Bounds.IntersectsWith(pictureBox3.Bounds)) ||
                (pinkGhost.Bounds.IntersectsWith(pictureBox1.Bounds)) ||
                (pinkGhost.Bounds.IntersectsWith(pictureBox2.Bounds)) ||
                (pinkGhost.Bounds.IntersectsWith(pictureBox56.Bounds)) ||
                (pinkGhost.Bounds.IntersectsWith(pictureBox57.Bounds)) ||
                (pinkGhost.Bounds.IntersectsWith(pictureBox58.Bounds))
                )
            {
                ghost3x = -ghost3x;
            }
            if (pinkGhost.Top < 1 || pinkGhost.Top + pinkGhost.Height > ClientSize.Height - 2)
            {
                ghost3y = -ghost3y;
            }
            
           
        }


        private void ResetGame()
        {
            txtScore.Text = "Score: 0";
            score = 0;

            ghost1 = 5;
            ghost2 = 5;

            ghost3x = 5;
            ghost3y = 5;

            speed = 8;

            //isGameOver = false;

            pacman.Left = 64;
            pacman.Top = 47;

            redGhost.Left = 347;
            redGhost.Top = 73;

            yellowGhost.Left = 361;
            yellowGhost.Top = 480;

            pinkGhost.Left = 575;
            pinkGhost.Top = 131;
        
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (String)x.Tag == "coin")
                {
                    x.Visible = true;
                    this.Controls.Add(x);
                   
                }
            }
                label2.Visible = false;

                GameTimer.Start();
            

        }


            private void GameOver(string message)

            {
                isGameOver = true;
                GameTimer.Stop();

                txtScore.Text = "Score: " + score + Environment.NewLine + message;
            }

        
    }
}
