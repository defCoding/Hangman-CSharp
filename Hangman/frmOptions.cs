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
    public partial class frmOptions : Form
    {
        private frmHangman parent; // The parent that the options window is a child of.

        public frmOptions(frmHangman parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        // Paints a border.
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawRectangle(new Pen(Color.Black, 3), this.DisplayRectangle);
        }

        // Sets checkmarks to appropriate areas.
        private void frmOptions_Load(object sender, EventArgs e)
        {
            int difficulty = this.parent.getHangman().getDifficulty();

            // Check the proper radio button to reflect what the current difficulty is.
            switch (difficulty)
            {
                case 0:
                    this.rdbtnEasy.Checked = true;
                    break;
                case 1:
                    this.rdbtnMedium.Checked = true;
                    break;
                case 2:
                    this.rdbtnHard.Checked = true;
                    break;
                default: // Should never get here.
                    break;
            }

            if (parent.isMuted())
            {
                this.chbxMuteSound.Checked = true;
            }
        }

        // Event handler for if btnOk is hit.
        private void btnOk_Click(object sender, EventArgs e)
        {
            int chosenDifficulty;

            // Find chosen difficulty to see what the difficulty is.
            if (rdbtnEasy.Checked)
            {
                chosenDifficulty = 0;
            } else if (rdbtnMedium.Checked)
            {
                chosenDifficulty = 1;
            } else
            {
                chosenDifficulty = 2;
            }

            this.parent.getHangman().setDifficulty(chosenDifficulty);

            if (chbxMuteSound.Checked)
            {
                this.parent.setSound(false);
            } else
            {
                this.parent.setSound(true);
            }

            Close();
        }
    }
}
