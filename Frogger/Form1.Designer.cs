namespace Frogger
{
    partial class Form1
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
            this.picGame = new System.Windows.Forms.PictureBox();
            this.picTopSafeZone = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTopSafeZone)).BeginInit();
            this.SuspendLayout();
            // 
            // picGame
            // 
            this.picGame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picGame.Location = new System.Drawing.Point(12, 12);
            this.picGame.Name = "picGame";
            this.picGame.Size = new System.Drawing.Size(1373, 772);
            this.picGame.TabIndex = 0;
            this.picGame.TabStop = false;
            // 
            // picTopSafeZone
            // 
            this.picTopSafeZone.Location = new System.Drawing.Point(11, 12);
            this.picTopSafeZone.Name = "picTopSafeZone";
            this.picTopSafeZone.Size = new System.Drawing.Size(1373, 73);
            this.picTopSafeZone.TabIndex = 1;
            this.picTopSafeZone.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1396, 809);
            this.Controls.Add(this.picTopSafeZone);
            this.Controls.Add(this.picGame);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Frogger - James Hunt";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picGame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTopSafeZone)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picGame;
        private System.Windows.Forms.PictureBox picTopSafeZone;
    }
}

