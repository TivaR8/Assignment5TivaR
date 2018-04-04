using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

/*
 * Created by: Tiva Rait
 * Created on: 02-04-2018
 * Created for: ICS3U Programming
 * Assignment #5b - Simplified 21
 * This program let's you play a simplified version of 21
*/

namespace Assignment5TivaR
{
    public partial class frmAssignment5 : Form
    {
        // Defining Constants and variables
        const int BLACKJACK = 21;
        const int MAX_VALUE = 10;
        const int MIN_VALUE = 1;
        string playerName;
        bool threeComCards;
        int playTotal, firstPlayCard, secondPlayCard, thirdPlayCard;
        int comTotal, firstComCard, secondComCard, thirdComCard;
        Random randomNumberGenerator = new Random();

        // Sounds
        SoundPlayer win = new SoundPlayer(Assignment5TivaR.Properties.Resources.HappyDing);
        SoundPlayer lose = new SoundPlayer(Assignment5TivaR.Properties.Resources.Marbles);
        SoundPlayer tie = new SoundPlayer(Assignment5TivaR.Properties.Resources.Ting);

        public frmAssignment5()
        {
            InitializeComponent();
            // To Hide the Instructions until needed
            grbInstructions.Hide();
            // To Define constants and variables
             playTotal = 0;
             comTotal = 0;
             firstPlayCard = 0;
             secondPlayCard = 0;
             thirdPlayCard = 0;
             firstComCard = 0;
             secondComCard = 0;
             thirdComCard = 0;

            threeComCards = false;

            //To Disable all of the group boxes and buttons until name is submitted
            grbCom.Enabled = false;
            grbPlayer.Enabled = false;
            grbNameQuest.Show();
            grbHit.Hide();
            grbPass.Hide();
            btnPlay.Enabled = false;

            // To stop the labels from displaying a number
            lbl1ComCard.Text = ("?");
            lbl2ComCard.Text = ("?");
            lbl3ComCard.Text = ("?");

            lbl1PlayCard.Text = ("?");
            lbl2PlayCard.Text = ("?");
            lbl3PlayCard.Text = ("?");

            lblComTotal.Text = ("Total = ");
            lblPlayTotal.Text = ("Total = ");

            // To hide the third card until one is needed
            grbComCard3.Hide();
            grbPlayCard3.Hide();

            // To set the status bar
            lblStatus.Text = ("Enter your name");

            // To Set up Hit, Pass, continue and play buttons
            this.btnPlay.Location = new Point(383, 321);
            this.grbHit.Location = new Point(334, 397);
            this.grbPass.Location = new Point(453, 397);
            this.btnContinue.Location = new Point(383, 350);
            btnContinue.Hide();

            // Test to see if  cards off screen will look like they are "Off the table"
            this.grbComCard1.Location = new Point(6, 19);
            grbComCard1.Text = ("Deck");

            // Hide the other cards
            grbComCard2.Hide();

        }

        private void mniNewGame_Click(object sender, EventArgs e)
        {
            // To Define constants and variables
            playTotal = 0;
            comTotal = 0;
            firstPlayCard = 0;
            secondPlayCard = 0;
            thirdPlayCard = 0;
            firstComCard = 0;
            secondComCard = 0;
            thirdComCard = 0;

            threeComCards = false;

            //To Disable all of the group boxes and buttons until name is submitted
            grbCom.Enabled = false;
            grbPlayer.Enabled = false;
            grbNameQuest.Show();
            grbHit.Hide();
            grbPass.Hide();
            btnPlay.Enabled = false;

            // To stop the labels from displaying a number
            lbl1ComCard.Text = ("?");
            lbl2ComCard.Text = ("?");
            lbl3ComCard.Text = ("?");

            lbl1PlayCard.Text = ("?");
            lbl2PlayCard.Text = ("?");
            lbl3PlayCard.Text = ("?");

            lblComTotal.Text = ("Total = ");
            lblPlayTotal.Text = ("Total = ");

            // To hide the third card until one is needed
            grbComCard3.Hide();
            grbPlayCard3.Hide();

            // To set the status bar
            lblStatus.Text = ("Enter your name");

            // To Set up Hit, Pass, continue and play buttons
            this.btnPlay.Location = new Point(383, 321);
            this.grbHit.Location = new Point(334, 397);
            this.grbPass.Location = new Point(453, 397);
            this.btnContinue.Location = new Point(383, 350);
            btnContinue.Hide();

            // Move cards to be in deck
            this.grbComCard1.Location = new Point(6, 19);
            grbComCard1.Text = ("Deck");

            // Hide the other cards
            grbComCard2.Hide();
        }

        private void btnCloseInstructions_Click(object sender, EventArgs e)
        {
            grbInstructions.Hide();
        }

        private void mniInstructions_Click(object sender, EventArgs e)
        {
            grbInstructions.Show();
        }

        private void btnSubmitName_Click(object sender, EventArgs e)
        {
            // To Name the Player
            playerName = Convert.ToString(txtNameBox.Text);
            grbPlayer.Text = (playerName);

            //To start the rest of the game
            grbNameQuest.Hide();
            grbPlayer.Enabled = true;
            btnPlay.Enabled = true;
            btnPlay.Show();

            //To get player to hit Play button
            lblStatus.Text = ("Are you ready? Hit the play button to start");
        }

        private void mniExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            // To set up what happens to play button after is it clicked
            this.btnPlay.Location = new Point(383, 321);
            btnPlay.Hide();

            //To set the random numbers
            firstComCard = randomNumberGenerator.Next(MIN_VALUE, MAX_VALUE + 1);
            secondComCard = randomNumberGenerator.Next(MIN_VALUE, MAX_VALUE + 1);

            // To Calculate and see if Computer should get a third card
            comTotal = firstComCard + secondComCard;
            Console.WriteLine("ComTotal =" + comTotal);
            if (comTotal <= 14)
            {
                thirdComCard = randomNumberGenerator.Next(MIN_VALUE, MAX_VALUE + 1);
                Console.WriteLine("New Third Card");
                threeComCards = true;

                // Change the third card text to show the number
                lbl3ComCard.Text = Convert.ToString(thirdComCard);
            }
            else
            {
                thirdComCard = 0;
                Console.WriteLine("No third Card");
                threeComCards = false;
                grbComCard3.Hide();
            }
            comTotal = firstComCard + secondComCard + thirdComCard;

            // Time to deal with the player side of things!!!!!!!!!
            firstPlayCard = randomNumberGenerator.Next(MIN_VALUE, MAX_VALUE + 1);
            secondPlayCard = randomNumberGenerator.Next(MIN_VALUE, MAX_VALUE + 1);
            // Calculate player total 
            playTotal = firstPlayCard + secondPlayCard;

            //Display everything 
            lbl1PlayCard.Text = Convert.ToString(firstPlayCard);
            lbl2PlayCard.Text = Convert.ToString(secondPlayCard);
            lblPlayTotal.Text = Convert.ToString("Total = " + playTotal);

            // Change status to ask is player wants a third card
            lblStatus.Text = ("Do you want to get a third card?");

            //Enable the Hit and Pass features
            grbHit.Show();
            grbPass.Show();
        }
        private void btnHit_Click(object sender, EventArgs e)
        {
            // To Hide the Buttons and group boxes
            grbHit.Show();
            grbPass.Show();
            this.btnContinue.Location = new Point(383, 321);
            btnContinue.Show();

            thirdPlayCard = randomNumberGenerator.Next(MIN_VALUE, MAX_VALUE + 1);
            grbPlayCard3.Show();
            lbl3PlayCard.Text = Convert.ToString(thirdPlayCard);

            //Calculate Total 
            playTotal = firstPlayCard + secondPlayCard + thirdPlayCard;

            // Show change
            lblPlayTotal.Text = Convert.ToString("Total = " + playTotal);

            // Change status to tell user to press continue
            lblStatus.Text = ("Press continue for dealers turn");
        }
        private void btnPass_Click(object sender, EventArgs e)
        {
            // To Hide buttons 
            grbPass.Hide();
            grbHit.Hide();
            this.btnContinue.Location = new Point(383, 321);
            btnContinue.Show();
           

            // Change status to tell user to press continue
            lblStatus.Text = ("Press continue for dealers turn");
        }
        private void btnContinue_Click(object sender, EventArgs e)
        {
            // To hide the continue Button
            btnContinue.Hide();
            //To Display the Computer's cards
            this.grbComCard1.Location = new Point(6, 86);
            grbComCard1.Text = ("Card 1");
            grbComCard2.Show();
            if (threeComCards == true)
            {
                grbComCard3.Show();
            }

            //Display computers numbers
            lbl1ComCard.Text = Convert.ToString(firstComCard);
            lbl2ComCard.Text = Convert.ToString(secondComCard);
            lblComTotal.Text = Convert.ToString("Total = " + comTotal);

            // Finally Just to find winner
            if (comTotal == playTotal)
            {
                lblStatus.Text = ("It's a tie.");
                tie.Play();
            }
            else if (comTotal == BLACKJACK)
            {
                lblStatus.Text = ("Computer wins with a blackjack");
                lose.Play();
            }
            else if (playTotal == BLACKJACK)
            {
                lblStatus.Text = (playerName + " wins with a blackjack!");
                win.Play();
            }
            else if (playTotal >21 && comTotal >21)
            {
                lblStatus.Text = ("It's a tie.");
                tie.Play();
            }
            else if (playTotal >21)
            {
                lblStatus.Text = ("Computer wins");
                lose.Play();
            }
            else if (comTotal > 21 && playTotal <= 21)
            {
                lblStatus.Text = (playerName + " wins!");
                win.Play();
            }
            else if (playTotal > comTotal)
            {
                lblStatus.Text = (playerName + " wins!");
                win.Play();
            }
            else
            {
                lblStatus.Text = ("Computer wins");
                lose.Play();
            }

        }
    }
}
