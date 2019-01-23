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
    public partial class frmGameEnd : Form
    {
        int gamestate;
        string answer;
        public frmGameEnd(int gamestate, string answer)
        {
            InitializeComponent();
            this.gamestate = gamestate;
            this.answer = answer;
        }

        private void frmGameEnd_Load(object sender, EventArgs e)
        {
            Color textColor;
            string text;

            if (gamestate == 0)
            {
                textColor = Color.Red;
                text = "GAME OVER.";
            } else
            {
                textColor = Color.Green;
                text = "VICTORY!";
            }

            this.lblGameStatus.Text = text;
            this.lblGameStatus.ForeColor = textColor;

            this.lblAnswer.Text = "The word was \"" + this.answer + "\".";

            this.lblGameStatus.Location = new Point((this.Width - lblGameStatus.Width) / 2, 20); // Center the label.
            this.lblAnswer.Location = new Point((this.Width - lblAnswer.Width) / 2, 70); // Center the label.

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawRectangle(new Pen(Color.Black, 5), this.DisplayRectangle);
        }

        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
