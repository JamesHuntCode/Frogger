using System;
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
            playerIcon = new Frog(50, 50, (this.picGame.Width / 2), (this.picGame.Height - 40));

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
            // Set up canvas:
            Graphics Frogger = this.picGame.CreateGraphics();
            Frogger.Clear(ColorTranslator.FromHtml("#333"));

            // Draw player icon:
            SolidBrush drawPlayer = new SolidBrush(Color.Green);
            Frogger.FillRectangle(drawPlayer, this.playerIcon.GetX(), this.playerIcon.GetY(), Convert.ToInt32(this.playerIcon.GetH()), Convert.ToInt32(this.playerIcon.GetW()));

            // Draw logs:
            
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
