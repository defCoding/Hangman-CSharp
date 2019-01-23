namespace Hangman
{
    partial class frmRecords
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
            this.lblEasy = new System.Windows.Forms.Label();
            this.lblMedium = new System.Windows.Forms.Label();
            this.lblHard = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.lblEasyRecord = new System.Windows.Forms.Label();
            this.lblMediumRecord = new System.Windows.Forms.Label();
            this.lblHardRecord = new System.Windows.Forms.Label();
            this.lblTotalScore = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblEasy
            // 
            this.lblEasy.AutoSize = true;
            this.lblEasy.Font = new System.Drawing.Font("Times New Roman", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEasy.Location = new System.Drawing.Point(16, 8);
            this.lblEasy.Name = "lblEasy";
            this.lblEasy.Size = new System.Drawing.Size(50, 22);
            this.lblEasy.TabIndex = 0;
            this.lblEasy.Text = "Easy";
            // 
            // lblMedium
            // 
            this.lblMedium.AutoSize = true;
            this.lblMedium.Font = new System.Drawing.Font("Times New Roman", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMedium.Location = new System.Drawing.Point(16, 96);
            this.lblMedium.Name = "lblMedium";
            this.lblMedium.Size = new System.Drawing.Size(77, 22);
            this.lblMedium.TabIndex = 1;
            this.lblMedium.Text = "Medium";
            // 
            // lblHard
            // 
            this.lblHard.AutoSize = true;
            this.lblHard.Font = new System.Drawing.Font("Times New Roman", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHard.Location = new System.Drawing.Point(16, 184);
            this.lblHard.Name = "lblHard";
            this.lblHard.Size = new System.Drawing.Size(52, 22);
            this.lblHard.TabIndex = 2;
            this.lblHard.Text = "Hard";
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(200, 200);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(136, 31);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "Reset Records";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMainMenu.Location = new System.Drawing.Point(200, 240);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(136, 31);
            this.btnMainMenu.TabIndex = 7;
            this.btnMainMenu.Text = "Return to Menu";
            this.btnMainMenu.UseVisualStyleBackColor = true;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // lblEasyRecord
            // 
            this.lblEasyRecord.AutoSize = true;
            this.lblEasyRecord.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lblEasyRecord.Location = new System.Drawing.Point(24, 32);
            this.lblEasyRecord.Name = "lblEasyRecord";
            this.lblEasyRecord.Size = new System.Drawing.Size(45, 17);
            this.lblEasyRecord.TabIndex = 8;
            this.lblEasyRecord.Text = "Temp";
            // 
            // lblMediumRecord
            // 
            this.lblMediumRecord.AutoSize = true;
            this.lblMediumRecord.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lblMediumRecord.Location = new System.Drawing.Point(24, 120);
            this.lblMediumRecord.Name = "lblMediumRecord";
            this.lblMediumRecord.Size = new System.Drawing.Size(45, 17);
            this.lblMediumRecord.TabIndex = 9;
            this.lblMediumRecord.Text = "Temp";
            // 
            // lblHardRecord
            // 
            this.lblHardRecord.AutoSize = true;
            this.lblHardRecord.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lblHardRecord.Location = new System.Drawing.Point(24, 208);
            this.lblHardRecord.Name = "lblHardRecord";
            this.lblHardRecord.Size = new System.Drawing.Size(45, 17);
            this.lblHardRecord.TabIndex = 10;
            this.lblHardRecord.Text = "Temp";
            // 
            // lblTotalScore
            // 
            this.lblTotalScore.AutoSize = true;
            this.lblTotalScore.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalScore.Location = new System.Drawing.Point(192, 32);
            this.lblTotalScore.Name = "lblTotalScore";
            this.lblTotalScore.Size = new System.Drawing.Size(45, 17);
            this.lblTotalScore.TabIndex = 11;
            this.lblTotalScore.Text = "Temp";
            // 
            // frmRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 276);
            this.Controls.Add(this.lblTotalScore);
            this.Controls.Add(this.lblHardRecord);
            this.Controls.Add(this.lblMediumRecord);
            this.Controls.Add(this.lblEasyRecord);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblHard);
            this.Controls.Add(this.lblMedium);
            this.Controls.Add(this.lblEasy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRecords";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "v";
            this.Load += new System.EventHandler(this.frmRecords_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEasy;
        private System.Windows.Forms.Label lblMedium;
        private System.Windows.Forms.Label lblHard;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.Label lblEasyRecord;
        private System.Windows.Forms.Label lblMediumRecord;
        private System.Windows.Forms.Label lblHardRecord;
        private System.Windows.Forms.Label lblTotalScore;
    }
}