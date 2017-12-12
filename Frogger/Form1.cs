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


        public Form1()
        {
            InitializeComponent();
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
            Frogger = this.picGame.CreateGraphics();
            Frogger.Clear(ColorTranslator.FromHtml("#333"));
        }

        #endregion
    }
}
