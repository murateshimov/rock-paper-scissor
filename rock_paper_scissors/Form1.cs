using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rock_paper_scissors
{
    public partial class Form1 : Form
    {

        int rounds = 3;
        int timerPerRound = 6;
        bool gameOver = false;

        string[] botChoiceList = { "rock", "paper", "scissor", "rock", "scissor", "paper" };

        int randomNumber = 0;

        Random rnd = new Random();

        string botChoice;

        string playerChoice;

        int playerScore;
        int botScore;

        public Form1()
        {
            InitializeComponent();

            countDownTimer.Enabled = true;

            playerChoice = "none";

            txtCountDown.Text = "5";
        }

        private void btnRock_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.rock;
            playerChoice = "rock";
        }

        private void btnPaper_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.paper;
            playerChoice = "paper";
        }

        private void btnScissors_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.scissors;
            playerChoice = "scissor";
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            playerScore = 0;
            botScore = 0;
            rounds = 3;
            txtScore.Text = "Player: " + playerScore + " - " + "Bot: " + botScore;
            playerChoice = "none";
            countDownTimer.Enabled = true;

            pictureBox1.Image = Properties.Resources.qq;
            pictureBox2.Image = Properties.Resources.qq;

            gameOver = false;
        }

        private void countDownTimerEvent(object sender, EventArgs e)
        {
            timerPerRound -= 1;

            txtCountDown.Text = timerPerRound.ToString();

            txtRounds.Text = "Rounds: " + rounds;

            if(timerPerRound < 1)
            {
                countDownTimer.Enabled = false;
                timerPerRound = 6;
                randomNumber = rnd.Next(0, botChoiceList.Length);
                botChoice = botChoiceList[randomNumber];

                switch (botChoice)
                {
                    case "rock":
                        pictureBox2.Image = Properties.Resources.rock;
                        break;

                    case "paper":
                        pictureBox2.Image = Properties.Resources.paper;
                        break;

                    case "scissor":
                        pictureBox2.Image = Properties.Resources.scissors;
                        break;
                }

                if (rounds > 0)
                {00
                    checkGame();
                }
                else
                {
                    if (playerScore > botScore)
                    {
                        MessageBox.Show("Player wins the Game!");
                    }
                    else
                    {
                        MessageBox.Show("Bot wins the Game!");
                    }

                    gameOver = true;
                }
            }
        }

        private void checkGame()
        {
            if (playerChoice == "rock" && botChoice == "paper")
            {
                botScore += 1;
                rounds -= 1;
                MessageBox.Show("Bot wins");
            }
            else if (playerChoice == "scissor" && botChoice == "rock")
            {
                botScore += 1;
                rounds -= 1;
                MessageBox.Show("Bot wins");
            }
            else if (playerChoice == "paper" && botChoice == "scissor")
            {
                botScore += 1;
                rounds -= 1;
                MessageBox.Show("Bot wins");
            }
            else if (playerChoice == "rock" && botChoice == "scissor")
            {
                playerScore += 1;
                rounds -= 1;
                MessageBox.Show("Player wins");
            }
            else if (playerChoice == "paper" && botChoice == "rock")
            {
                playerScore += 1;
                rounds -= 1;
                MessageBox.Show("Player wins");
            }
            else if (playerChoice == "scissor" && botChoice == "paper")
            {
                playerScore += 1;
                rounds -= 1;
                MessageBox.Show("Player wins");
            }

            else if (playerChoice == "none")
            {
                MessageBox.Show("Make a choice");
            }
            else
            {
                MessageBox.Show("Draw");
            }

            startNextRound();
        }

        private void startNextRound()
        {
            if(gameOver == true)
            {
                return;
            }

            txtScore.Text = "Player: " + playerScore + " - " + "Bot: " + botScore;
            playerChoice = "none";
            countDownTimer.Enabled = true;

            pictureBox1.Image = Properties.Resources.qq;
            pictureBox2.Image = Properties.Resources.qq;
        }
    }
}
