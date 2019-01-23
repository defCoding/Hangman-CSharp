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
    public partial class frmPopupMenu : Form
    {
        public frmPopupMenu()
        {
            InitializeComponent();
        }

        // The event handler for the return to menu button.
        private void btnReturnToMenu_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure you want to return to the main menu? This will count as a loss.",
                "Return to Main Menu",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                this.DialogResult = DialogResult.Abort; // If the user wishes to return to the main menu, send the dialog result and close the pop-up.
                Close();
            }

            // Otherwise do nothing.
        }

        // The event handler for the surrender button.
        private void btnSurrender_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure you would like to surrender?", "Surrender",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                this.DialogResult = DialogResult.Retry; // If the user wishes to surrender, send the dialog result and close the popup.
                Close();
            }

            // Otherwise do nothing.
        }

        // Event handler for the cancel button.
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close(); // Close the pop-up window.
        }

        // Override paint method to draw a border.
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawRectangle(new Pen(Color.Black, 3), this.DisplayRectangle);
        }

        private void frmPopupMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
