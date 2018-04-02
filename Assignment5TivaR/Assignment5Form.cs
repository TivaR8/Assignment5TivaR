using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        const int MAX_VALUE = 10;
        const int MIN_VALUE = 1;
        string playerName;

        public frmAssignment5()
        {
            InitializeComponent();

            //To Disable all of the group boxes until name is submitted
            grbCom.Enabled = false;
            grbPlayer.Enabled = false;
            grbNameQuest.Show();

            // To hide the third card until one is needed
            grbComCard3.Hide();
            grbPlayCard3.Hide();

            // To set the status bar
            lblStatus.Text = ("Enter your name");

            // To Set up Hit, Pass, and play buttons
            this.btnPlay.Location = new Point(355, 321);
            this.btnHit.Location = new Point(366, 379);

        }

        private void btnSubmitName_Click(object sender, EventArgs e)
        {
            // To Name the Player
            playerName = Convert.ToString(txtNameBox.Text);
            grbPlayer.Text = (playerName);

            //To start the rest of the game
            grbNameQuest.Hide();
            grbPlayer.Enabled = true;

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
            this.btnHit.Location = new Point (355, 321);
            this.btnPlay.Location = new Point(366, 379);
        }
    }
}
