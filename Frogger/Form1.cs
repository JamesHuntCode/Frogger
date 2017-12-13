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
        // Classes / Objects Used:
        #region initiate classes and objects

        private Graphics Frogger;
        private Frog playerIcon;
        private List<Log> logs = new List<Log>();

        public Form1()
        {
            InitializeComponent();
            this.KeyDown += this.Form1_KeyDown;
        }

        #endregion

        // Initiate Game:

        #region initiate game and start timer

        private void Form1_Load(object sender, EventArgs e)
        {
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

        // Play Game:
        private void draw()
        {
            // Set up canvas:
            Frogger = this.picGame.CreateGraphics();
            Frogger.Clear(ColorTranslator.FromHtml("#333"));

            // Draw player icon:
            playerIcon = new Frog(40, 40, 0, 0);
            SolidBrush drawPlayer = new SolidBrush(Color.Green);

            // Put player in starting position:
            this.playerIcon.SetX((this.picGame.Width / 2) - (Convert.ToInt32(this.playerIcon.GetW() / 2)));
            this.playerIcon.SetY(this.picGame.Height - (Convert.ToInt32(this.playerIcon.GetH())));
            this.Frogger.FillRectangle(drawPlayer, this.playerIcon.GetX(), this.playerIcon.GetY(), Convert.ToInt32(this.playerIcon.GetH()), Convert.ToInt32(this.playerIcon.GetW()));

        }

        #endregion

        // Frogger Movement:

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:



                    break;
                case Keys.Down:



                    break;
                case Keys.Left:



                    break;
                case Keys.Right:



                    break;
            }
        }
    }
}
