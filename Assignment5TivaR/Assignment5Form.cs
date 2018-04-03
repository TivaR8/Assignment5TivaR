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
        int playTotal, firstPlayCard, secondPlayCard, thirdPlayCard;
        int comTotal, firstComCard, secondComCard, thirdComCard;
        bool thirdCardForCom;
        Random randomNumberGenerator = new Random();

        public frmAssignment5()
        {
            InitializeComponent();
            // To Define constants and variables
             playTotal = 0;
             comTotal = 0;
             firstPlayCard = 0;
             secondPlayCard = 0;
             thirdPlayCard = 0;
             firstComCard = 0;
             secondComCard = 0;
             thirdComCard = 0;

            thirdCardForCom = false;

            //To Disable all of the group boxes and buttons until name is submitted
            grbCom.Enabled = false;
            grbPlayer.Enabled = false;
            grbNameQuest.Show();
            btnHit.Enabled = false;
            btnPlay.Enabled = false;
            btnPass.Enabled = false;

            // To stop the labels from displaying a number
            lbl1ComCard.Text = ("?");
            lbl2ComCard.Text = ("?");
            lbl3ComCard.Text = ("?");

            lbl1PlayCard.Text = ("?");
            lbl2PlayCard.Text = ("?");
            lbl3PlayCard.Text = ("?");

            // To hide the third card until one is needed
            grbComCard3.Hide();
            grbPlayCard3.Hide();

            // To set the status bar
            lblStatus.Text = ("Enter your name");

            // To Set up Hit, Pass, and play buttons
            this.btnPlay.Location = new Point(383, 321);
            this.btnHit.Location = new Point(383, 379);
            this.btnContinue.Location = new Point(383, 409);

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
            this.btnHit.Location = new Point (383, 321);
            this.btnPlay.Location = new Point(383, 379);
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
                thirdCardForCom = true;
                grbComCard3.Show();
            }
            else
            {
                thirdComCard = 0;
                Console.WriteLine("No third Card");
            }
            comTotal = firstComCard + secondComCard + thirdComCard;

            //Time to deal with the player side of things!!!!!!!!!
            firstPlayCard = randomNumberGenerator.Next(MIN_VALUE, MAX_VALUE + 1);
            secondPlayCard = randomNumberGenerator.Next(MIN_VALUE, MAX_VALUE + 1);
            // Calculate player total 
            playTotal = firstPlayCard + secondPlayCard;

            //Display everything 
            lbl1PlayCard.Text = Convert.ToString(firstPlayCard);
            lbl2PlayCard.Text = Convert.ToString(secondPlayCard);
            lblPlayTotal.Text = Convert.ToString(playTotal);

            // Change status to ask is player wants a third card
            lblStatus.Text = ("Do you want to get a third card?");

            //Enable the Hit and Pass features
            btnHit.Enabled = true;
            btnPass.Enabled = true;
        }
        private void btnHit_Click(object sender, EventArgs e)
        {
            // To Hide the buttons
            btnPass.Hide();
            btnHit.Hide();
            this.btnContinue.Location = new Point(383, 321);

            thirdPlayCard = randomNumberGenerator.Next(MIN_VALUE, MAX_VALUE + 1);
            grbPlayCard3.Show();

            //Calculate Total 
            playTotal = firstPlayCard + secondPlayCard + thirdPlayCard;

            // Change status to tell user to press continue
            lblStatus.Text = ("Press continue for dealers turn");
        }
        private void btnPass_Click(object sender, EventArgs e)
        {
            // To Hide buttons 
            btnPass.Hide();
            btnHit.Hide();
            this.btnContinue.Location = new Point(383, 321);

            // Change status to tell user to press continue
            lblStatus.Text = ("Press continue for dealers turn");
        }
        private void btnContinue_Click(object sender, EventArgs e)
        {
            // Define variables
            int finalLocation = 0;
            int currentLocation = 0;

            //To Display the Computer's cards
           // while (currentLocation< finalLocation)

        }
    }
}
