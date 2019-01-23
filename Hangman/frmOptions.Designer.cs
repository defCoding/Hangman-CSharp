namespace Hangman
{
    partial class frmOptions
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbtnHard = new System.Windows.Forms.RadioButton();
            this.rdbtnMedium = new System.Windows.Forms.RadioButton();
            this.rdbtnEasy = new System.Windows.Forms.RadioButton();
            this.chbxMuteSound = new System.Windows.Forms.CheckBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbtnHard);
            this.groupBox1.Controls.Add(this.rdbtnMedium);
            this.groupBox1.Controls.Add(this.rdbtnEasy);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 72);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Difficulty";
            // 
            // rdbtnHard
            // 
            this.rdbtnHard.AutoSize = true;
            this.rdbtnHard.Location = new System.Drawing.Point(184, 32);
            this.rdbtnHard.Name = "rdbtnHard";
            this.rdbtnHard.Size = new System.Drawing.Size(67, 24);
            this.rdbtnHard.TabIndex = 3;
            this.rdbtnHard.Text = "Hard";
            this.rdbtnHard.UseVisualStyleBackColor = true;
            // 
            // rdbtnMedium
            // 
            this.rdbtnMedium.AutoSize = true;
            this.rdbtnMedium.Location = new System.Drawing.Point(88, 32);
            this.rdbtnMedium.Name = "rdbtnMedium";
            this.rdbtnMedium.Size = new System.Drawing.Size(89, 24);
            this.rdbtnMedium.TabIndex = 2;
            this.rdbtnMedium.TabStop = true;
            this.rdbtnMedium.Text = "Medium";
            this.rdbtnMedium.UseVisualStyleBackColor = true;
            // 
            // rdbtnEasy
            // 
            this.rdbtnEasy.AutoSize = true;
            this.rdbtnEasy.Location = new System.Drawing.Point(16, 32);
            this.rdbtnEasy.Name = "rdbtnEasy";
            this.rdbtnEasy.Size = new System.Drawing.Size(67, 24);
            this.rdbtnEasy.TabIndex = 1;
            this.rdbtnEasy.TabStop = true;
            this.rdbtnEasy.Text = "Easy";
            this.rdbtnEasy.UseVisualStyleBackColor = true;
            // 
            // chbxMuteSound
            // 
            this.chbxMuteSound.AutoSize = true;
            this.chbxMuteSound.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbxMuteSound.Location = new System.Drawing.Point(16, 96);
            this.chbxMuteSound.Name = "chbxMuteSound";
            this.chbxMuteSound.Size = new System.Drawing.Size(120, 24);
            this.chbxMuteSound.TabIndex = 1;
            this.chbxMuteSound.Text = "Mute Sound";
            this.chbxMuteSound.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(296, 16);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(107, 32);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(296, 56);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(107, 32);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(410, 148);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.chbxMuteSound);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.frmOptions_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbtnEasy;
        private System.Windows.Forms.RadioButton rdbtnHard;
        private System.Windows.Forms.RadioButton rdbtnMedium;
        private System.Windows.Forms.CheckBox chbxMuteSound;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}