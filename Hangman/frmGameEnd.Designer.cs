namespace Hangman
{
    partial class frmGameEnd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblGameStatus = new System.Windows.Forms.Label();
            this.btnPlayAgain = new System.Windows.Forms.Button();
            this.btnReturnMenu = new System.Windows.Forms.Button();
            this.lblAnswer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblGameStatus
            // 
            this.lblGameStatus.AutoSize = true;
            this.lblGameStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameStatus.Location = new System.Drawing.Point(53, 20);
            this.lblGameStatus.Name = "lblGameStatus";
            this.lblGameStatus.Size = new System.Drawing.Size(315, 55);
            this.lblGameStatus.TabIndex = 0;
            this.lblGameStatus.Text = "Game Status";
            // 
            // btnPlayAgain
            // 
            this.btnPlayAgain.Location = new System.Drawing.Point(136, 129);
            this.btnPlayAgain.Name = "btnPlayAgain";
            this.btnPlayAgain.Size = new System.Drawing.Size(137, 41);
            this.btnPlayAgain.TabIndex = 1;
            this.btnPlayAgain.Text = "Play Again";
            this.btnPlayAgain.UseVisualStyleBackColor = true;
            this.btnPlayAgain.Click += new System.EventHandler(this.btnPlayAgain_Click);
            // 
            // btnReturnMenu
            // 
            this.btnReturnMenu.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnReturnMenu.Location = new System.Drawing.Point(136, 176);
            this.btnReturnMenu.Name = "btnReturnMenu";
            this.btnReturnMenu.Size = new System.Drawing.Size(137, 41);
            this.btnReturnMenu.TabIndex = 2;
            this.btnReturnMenu.Text = "Return to Menu";
            this.btnReturnMenu.UseVisualStyleBackColor = true;
            // 
            // lblAnswer
            // 
            this.lblAnswer.AutoSize = true;
            this.lblAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblAnswer.Location = new System.Drawing.Point(136, 88);
            this.lblAnswer.Name = "lblAnswer";
            this.lblAnswer.Size = new System.Drawing.Size(134, 20);
            this.lblAnswer.TabIndex = 3;
            this.lblAnswer.Text = "The word was \"\".";
            // 
            // frmGameEnd
            // 
            this.AcceptButton = this.btnPlayAgain;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnReturnMenu;
            this.ClientSize = new System.Drawing.Size(409, 249);
            this.Controls.Add(this.lblAnswer);
            this.Controls.Add(this.btnReturnMenu);
            this.Controls.Add(this.btnPlayAgain);
            this.Controls.Add(this.lblGameStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmGameEnd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Game End";
            this.Load += new System.EventHandler(this.frmGameEnd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGameStatus;
        private System.Windows.Forms.Button btnPlayAgain;
        private System.Windows.Forms.Button btnReturnMenu;
        private System.Windows.Forms.Label lblAnswer;
    }
}