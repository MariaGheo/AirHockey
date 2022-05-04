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

namespace AirHockey
{
    public partial class Form1 : Form
    {
        //players
        Rectangle player1 = new Rectangle(10, 185, 30, 30);
        Rectangle player2 = new Rectangle(710, 185, 30, 30);

        //ball
        Rectangle ball = new Rectangle(370, 200, 10, 10);

        //walls
        Rectangle upperLeftWall = new Rectangle(0, 0, 2, 140);
        Rectangle lowerLeftWall = new Rectangle(0, 260, 2, 140);
        Rectangle topWall = new Rectangle(0, 0, 750, 2);
        Rectangle bottomWall = new Rectangle(0, 398, 750, 2);
        Rectangle upperRightWall = new Rectangle(748, 0, 2, 140);
        Rectangle lowerRightWall = new Rectangle(748, 260, 2, 140);

        //constant values
        const int maxBallXSpeed = 8;
        const int maxBallYSpeed = 7;
        const int playerSpeed = 4;
        const int wallWidth = 2;

        //variables for player scores
        int player1Score = 0;
        int player2Score = 0;

        //variables for ball movement
        int ballXSpeed = 0;
        int ballYSpeed = 0;
        int counter = 0; //this is to make sure the ball doesn't slow down too fast

        //variables for user input
        bool wDown = false;
        bool aDown = false;
        bool sDown = false;
        bool dDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;
        bool leftArrowDown = false;
        bool rightArrowDown = false;

        //brushes to make things appear on screen
        SolidBrush blueBrush = new SolidBrush(Color.DodgerBlue);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush greenBrush = new SolidBrush(Color.Green);

        public Form1()
        {
            InitializeComponent();

            //setting score labels
            p1ScoreLabel.Text = "0";
            p2ScoreLabel.Text = "0";
        }

        //for user input when a key is pressed
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
            }
        }

        //for user input when a key is released
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
            }
        }

        //game engine
        private void gameEngine_Tick(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.pongBlip);

            //move ball 
            if ((ball.X + ballXSpeed <= this.Width - ball.Width - wallWidth && ball.X + ballXSpeed >= wallWidth) || (ball.Y > 140 && ball.Y < 260))
            {
                ball.X += ballXSpeed;
            }
            else if (ball.X + ballXSpeed <= this.Width - ball.Width - wallWidth)
            {
                ball.X = wallWidth;
            }
            else
            {
                ball.X = this.Width - ball.Width - wallWidth;
            }

            if (ball.Y + ballYSpeed >= wallWidth && ball.Y + ballYSpeed <= this.Height - wallWidth - ball.Height)
            {
                ball.Y += ballYSpeed;
            }
            else if (ball.Y + ballYSpeed >= wallWidth)
            {
                ball.Y = this.Height - wallWidth - ball.Height;
            }
            else
            {
                ball.Y = wallWidth;
            }


            //move player 1 
            if (wDown == true && player1.Y > wallWidth)
            {
                if (player1.Y - playerSpeed >= wallWidth)
                {
                    player1.Y -= playerSpeed;
                }
                else
                {
                    player1.Y = wallWidth;
                }
            }

            if (sDown == true && player1.Y < this.Height - player1.Height - wallWidth)
            {
                if (player1.Y + playerSpeed <= this.Height - player1.Height - wallWidth)
                {
                    player1.Y += playerSpeed;
                }
                else
                {
                    player1.Y = this.Height - player1.Height - wallWidth;
                }
            }

            if (aDown == true && player1.X > wallWidth)
            {
                if (player1.X - playerSpeed >= wallWidth)
                {
                    player1.X -= playerSpeed;
                }
                else
                {
                    player1.X = wallWidth;
                }
            }

            if (dDown == true && player1.X < (this.Width / 2) - player1.Width)
            {
                if (player1.X + playerSpeed <= (this.Width / 2) - player1.Width)
                {
                    player1.X += playerSpeed;
                }
                else
                {
                    player1.X = (this.Width / 2) - player1.Width;
                }
            }


            //move player 2 
            if (upArrowDown == true && player2.Y > wallWidth)
            {
                if (player2.Y - playerSpeed >= wallWidth)
                {
                    player2.Y -= playerSpeed;
                }
                else
                {
                    player2.Y = wallWidth;
                }
            }

            if (downArrowDown == true && player2.Y < this.Height - player2.Height - wallWidth)
            {
                if (player2.Y + playerSpeed <= this.Height - player2.Height - wallWidth)
                {
                    player2.Y += playerSpeed;
                }
                else
                {
                    player2.Y = this.Height - player2.Height - wallWidth;
                }
            }

            if (leftArrowDown == true && player2.X > this.Width / 2)
            {
                if (player2.X - playerSpeed >= this.Width / 2)
                {
                    player2.X -= playerSpeed;
                }
                else
                {
                    player2.X = this.Width / 2;
                }
            }

            if (rightArrowDown == true && player2.X < this.Width - player2.Width - wallWidth)
            {
                if (player2.X + playerSpeed <= this.Width - player2.Width - wallWidth)
                {
                    player2.X += playerSpeed;
                }
                else
                {
                    player2.X = this.Width - player2.Width - wallWidth;
                }
            }


            //check if ball hit top or bottom wall and change direction if it does 
            if (ball.Y == this.Height - wallWidth - ball.Height || ball.Y == wallWidth)
            {
                ballYSpeed *= -1;  // or: ballYSpeed = -ballYSpeed;
                player.Play();
            }


            //check if ball hit right or left wall and change direction if it does
            if ((ball.X == wallWidth || ball.X == this.Width - ball.Width - wallWidth) && (ball.Y < 140 || ball.Y > 260))
            {
                ballXSpeed *= -1;
                player.Play();
            }


            //check if ball hits either player. If it does change the direction 
            //and place the ball in front of the player hit 
            if (player1.IntersectsWith(ball))
            {
                player.Play();

                if (aDown == true && dDown == false) //base the ball movement on player movement
                {
                    ball.X -= ball.Width + playerSpeed;
                    ballXSpeed = -maxBallXSpeed;
                }
                else if (dDown == true && aDown == false) //base the ball movement on player movement
                {
                    ball.X += ball.Width + playerSpeed;
                    ballXSpeed = maxBallXSpeed;
                }
                else if (ballXSpeed > 0)
                {
                    ball.X -= ball.Width + playerSpeed;
                    ballXSpeed = -maxBallXSpeed;
                }
                else if (ballXSpeed < 0)
                {
                    ball.X += ball.Width + playerSpeed;
                    ballXSpeed = maxBallXSpeed;
                }

                if (wDown == true && sDown == false)
                {
                    ball.Y -= ball.Height + playerSpeed;
                    ballYSpeed = -maxBallYSpeed;
                }
                else if (sDown == true && wDown == false)
                {
                    ball.Y += ball.Height + playerSpeed;
                    ballYSpeed = maxBallYSpeed;
                }
                else if (ballYSpeed > 0)
                {
                    ball.Y -= ball.Height + playerSpeed;
                    ballYSpeed = -maxBallYSpeed;
                }
                else if (ballYSpeed < 0)
                {
                    ball.Y += ball.Height + playerSpeed;
                    ballYSpeed = maxBallYSpeed;
                }
            }
            else if (player2.IntersectsWith(ball))
            {
                player.Play();

                if (leftArrowDown == true && rightArrowDown == false)
                {
                    ball.X -= ball.Width + playerSpeed;
                    ballXSpeed = -maxBallXSpeed;
                }
                else if (rightArrowDown == true && leftArrowDown == false)
                {
                    ball.X += ball.Width + playerSpeed;
                    ballXSpeed = maxBallXSpeed;
                }
                else if (ballXSpeed > 0)
                {
                    ball.X -= ball.Width + playerSpeed;
                    ballXSpeed = -maxBallXSpeed;
                }
                else if (ballXSpeed < 0)
                {
                    ball.X += ball.Width + playerSpeed;
                    ballXSpeed = maxBallXSpeed;
                }

                if (upArrowDown == true && downArrowDown == false)
                {
                    ball.Y -= ball.Height + playerSpeed;
                    ballYSpeed = -maxBallYSpeed;
                }
                else if (downArrowDown == true && upArrowDown == false)
                {
                    ball.Y += ball.Height + playerSpeed;
                    ballYSpeed = maxBallYSpeed;
                }
                else if (ballYSpeed > 0)
                {
                    ball.Y -= ball.Height + playerSpeed;
                    ballYSpeed = maxBallYSpeed;
                }
                else if (ballYSpeed < 0)
                {
                    ball.Y += ball.Height + playerSpeed;
                    ballYSpeed = -maxBallYSpeed;
                }
            }


            //slow down the ball
            if (counter % 15 == 0)
            {
                if (ballXSpeed > 0)
                {
                    ballXSpeed--;
                }
                else if (ballXSpeed < 0)
                {
                    ballXSpeed++;
                }

                if (ballYSpeed > 0)
                {
                    ballYSpeed--;
                }
                else if (ballYSpeed < 0)
                {
                    ballYSpeed++;
                }
            }
            
            counter++; //for the previous if statement, so the ball doesn't slow down too fast


            //check if the ball was scored
            if ((ball.X < -ball.Width || ball.X > this.Width) && ball.Y > 140 && ball.Y < 260)
            {
                if (ball.X > this.Width)
                {
                    player1Score++;
                    p1ScoreLabel.Text = $"{player1Score}";
                }
                else
                {
                    player2Score++;
                    p2ScoreLabel.Text = $"{player2Score}";
                }

                //reset positions of objects
                player1.Location = new Point (10, 185);
                player2.Location = new Point(710, 185);
                ball.Location = new Point(370, 200);

                //stop ball from moving
                ballXSpeed = 0;
                ballYSpeed = 0;

                if (player1Score == 3 || player2Score == 3)
                {
                    if (player1Score == 3)
                    {
                        winLabel.Text = "Player 1 Wins!!";
                    }
                    else
                    {
                        winLabel.Text = "Player 2 Wins!!";
                    }
                    
                    gameEngine.Enabled = false;
                    winLabel.Visible = true;
                }
            }


            Refresh(); //update the screen to show movement
        }

        //show the screen
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(greenBrush, ball);
            e.Graphics.FillRectangle(whiteBrush, upperLeftWall);
            e.Graphics.FillRectangle(whiteBrush, lowerLeftWall);
            e.Graphics.FillRectangle(whiteBrush, topWall);
            e.Graphics.FillRectangle(whiteBrush, bottomWall);
            e.Graphics.FillRectangle(whiteBrush, upperRightWall);
            e.Graphics.FillRectangle(whiteBrush, lowerRightWall);
            e.Graphics.FillRectangle(blueBrush, player1);
            e.Graphics.FillRectangle(redBrush, player2);
        }
    }
}
