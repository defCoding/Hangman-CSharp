using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hangman
{
    public partial class frmRecords : Form
    {
        public frmRecords()
        {
            InitializeComponent();
        }

        private void frmRecords_Load(object sender, EventArgs e)
        {
            displaySave();
        }

        // Displays the save information in the labels.
        private void displaySave()
        {
            int[] save = SaveController.getSave(); // Get the save.

            // Display the save information.
            this.lblEasyRecord.Text = "Wins: " + save[0] + "\nLosses: " + save[1];
            this.lblMediumRecord.Text = "Wins: " + save[2] + "\nLosses: " + save[3];
            this.lblHardRecord.Text = "Wins: " + save[4] + "\nLosses: " + save[5];
            this.lblTotalScore.Text = "Total Wins: " + (save[0] + save[2] + save[4]) + "\nTotal Losses: " + (save[1] + save[3] + save[5]);
        }

        // Draws a border.
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawRectangle(new Pen(Color.Black, 3), this.DisplayRectangle);
        }

        // Event handler for btnReset.
        private void btnReset_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure you would like to permanently erase all records?", 
                "Erase", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                SaveController.resetSave();
                SaveController.save();
            }
            displaySave(); // Display the updated save.
        }

        // Event handler for return to menu. Closes the form.
        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
