using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DinuchG
{
    public partial class Apka : Form
    {
        bool jumping = false;
        int jumpSpeed = 14;
        int force = 14;
        int score = 0;
        int obstacleSpeed = 10;
        int decorationSpeed = 10;
        Random rand = new Random();
        int position;
        int position2;
        int position3;
        bool isGamerOver = false;

        public Apka()
        {
            InitializeComponent();

            GameReset();
        }

        private void MaingameTimer(object sender, EventArgs e)
        {
            Dinuch.Top += jumpSpeed;

            txtScore.Text = "Wynik: " + score;

            if (jumping == true && force < 0)
            {
                jumping= false;
            }
            if (jumping == true)
            {
                jumpSpeed = -14;
                force -= 1;
            }
            else
            {
                jumpSpeed = 14;
            }

            if (Dinuch.Top > 582 && jumping == false)
            {
                force = 14;
                Dinuch.Top = 583;
                jumpSpeed = 0;
            }


            foreach(Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "Obstacle")
                {
                    x.Left -= obstacleSpeed;

                    if (x.Left < -100)
                    {
                        x.Left = this.ClientSize.Width + rand.Next(200, 500) + (x.Width * 15);
                        score++;
                    }  
                    

                    if (Dinuch.Bounds.IntersectsWith(x.Bounds))
                    {
                        gameTimer.Stop();
                        Dinuch.Image = Properties.Resources.Death;
                        txtScore.Text += " Naciśnij R żeby zresetować";
                        isGamerOver = true;
                    }
                }
                if (x is PictureBox && (string)x.Tag == "Decoration")
                {
                    x.Left -= decorationSpeed;

                    if (x.Left < -100)
                    {
                        x.Left = this.ClientSize.Width + rand.Next(200, 500) + (x.Width * 15);
                    }
                }
                if (x is PictureBox && (string)x.Tag == "SkyDec")
                {
                    x.Left -= decorationSpeed;

                    if (x.Left < -100)
                    {
                        x.Left = this.ClientSize.Width + rand.Next(0,1000) + (x.Width * 5);
                    }
                }

            }
            switch(score)
            {
                case 5:
                    
                    obstacleSpeed = 12;
                    decorationSpeed= 12;
                break;
                case 10:
                    
                    obstacleSpeed = 14;
                    decorationSpeed= 14;
                break;
                    
                case 20:
                    
                    obstacleSpeed = 16;
                    decorationSpeed = 16;
                break;
            }

        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (jumping == true)
            {
                jumping = false;
            }

            if (e.KeyCode == Keys.R && isGamerOver == true)
            {
                GameReset();
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && jumping == false)
            {
                    jumping = true;
                }
        }
        

        private void GameReset()
        {
            force = 14;
            jumpSpeed = 0;
            jumping= false;
            score = 0;
            obstacleSpeed= 10;
            decorationSpeed= 10;
            txtScore.Text = "Wynik: " + score;
            Dinuch.Image = Properties.Resources.DinR;
            isGamerOver = false;
            Dinuch.Top = 583;

            foreach (Control x in this.Controls) 
            {
                if (x is PictureBox && (string)x.Tag == "Obstacle")
                {
                    position = this.ClientSize.Width + rand.Next(500, 800) + (x.Width * 10);

                    x.Left = position;
                }
            }
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "Decoration")
                {
                    position2 = this.ClientSize.Width + rand.Next(0,1000) + (x.Width * 10);

                    x.Left = position2;
                }
            }
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "SkyDec")
                {
                    position3 = this.ClientSize.Width + rand.Next(0,1000) + (x.Width * 5);

                    x.Left = position3;
                }
            }

            gameTimer.Start();



        }

        private void Exit(object sender, KeyPressEventArgs e)
        {   
                if (e.KeyChar == (char)Keys.Escape)
                {
                Menu gameWindow = new Menu();

                gameWindow.Show();
                this.Hide();
            }
        }
    } 

}
