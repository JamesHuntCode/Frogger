﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frogger
{
    public partial class Form1 : Form
    {
        #region initiate classes and objects

        private Frog playerIcon;
        private List<Log> logs = new List<Log>();

        public Form1()
        {
            InitializeComponent();

            this.Height = 940;
            this.Width = 1520;

            this.picGame.Height = 900;
            this.picGame.Width = 1500;
            this.picGame.Location = new Point(0, 0);

            this.picTopSafeZone.BackColor = Color.Green;
            this.picTopSafeZone.Height = 62;
            this.picTopSafeZone.Width = 1500;
            this.picTopSafeZone.Location = new Point(0, 0);

            this.KeyDown += this.Form1_KeyDown;
        }

        #endregion

        #region initiate game and start timer

        private void Form1_Load(object sender, EventArgs e)
        {
            // Add logs to map
            Random rnd = new Random();
            int offsetY = 50;
            for (int i = 0; i < 16; i++)
            {
                // Make algorithm to check if row has same velocity setting as row above it & *MAYBE* allow for multiple logs on one row - implement later
                this.logs.Add(new Log(50, 200, rnd.Next(0, this.Width - 200), offsetY, rnd.Next(0, 2), rnd.Next(1, 3)));
                offsetY += 50;
            }

            // Make player icon
            playerIcon = new Frog(50, 50, (this.picGame.Width / 2), (this.picGame.Height - 50));

            // Timer used to call draw method (60FPS)
            Timer play = new Timer();
            play.Interval = 10;
            play.Tick += new EventHandler(refresh);
            play.Start();
        }

        #endregion

        #region timer_Tick method

        private void refresh(object sender, EventArgs e)
        {
            this.draw();
        }

        #endregion

        #region draw method (play game)

        private void draw()
        {
            // Set up canvas
            Graphics Frogger = this.picGame.CreateGraphics();
            Frogger.Clear(ColorTranslator.FromHtml("#333"));

            // Draw 'logs'
            SolidBrush drawLog = new SolidBrush(Color.White);
            for (int i = 0; i < this.logs.Count; i++)
            {
                // Make logs appear
                Frogger.FillRectangle(drawLog, this.logs[i].GetX(), this.logs[i].GetY(), Convert.ToInt32(this.logs[i].GetW()), Convert.ToInt32(this.logs[i].GetH()));

                // Give logs their behaviours
                this.logs[i].move();
                this.logs[i].offScreen(0, this.picGame.Width);

                // Check if player is on log
                if (((this.playerIcon.GetX() > this.logs[i].GetX()) && (this.playerIcon.GetX() < (this.logs[i].GetX() + this.logs[i].GetW()))) /* && check player is not where they started */)
                {
                    // Player is not on a log and has died
                    MessageBox.Show("YOU DIED!");
                }
            }

            // Draw player icon
            SolidBrush drawPlayer = new SolidBrush(Color.Green);
            Frogger.FillRectangle(drawPlayer, this.playerIcon.GetX(), this.playerIcon.GetY(), Convert.ToInt32(this.playerIcon.GetH()), Convert.ToInt32(this.playerIcon.GetW()));

            // Enable player behaviours:

            if (this.playerIcon.reachTop(this.playerIcon.GetY() ,0))
            {
                // Player has successfully reached the safe zone
            }
        }

        #endregion

        #region movement control

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:

                    this.playerIcon.updatePos(3, 0, this.picGame.Width, this.picGame.Height, 0);
                   
                    break;
                case Keys.Down:

                    this.playerIcon.updatePos(4, 0, this.picGame.Width, this.picGame.Height, 0);

                    break;
                case Keys.Left:

                    this.playerIcon.updatePos(1, 0, this.picGame.Width, this.picGame.Height, 0);

                    break;
                case Keys.Right:

                    this.playerIcon.updatePos(2, 0, this.picGame.Width, this.picGame.Height, 0);

                    break;
            }
        }

        #endregion
    }
}
