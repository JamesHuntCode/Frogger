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
        private List<Car> cars = new List<Car>();

        public Form1()
        {
            InitializeComponent();

            this.Height = 940;
            this.Width = 1515;

            this.picGame.Height = 900;
            this.picGame.Width = 1500;
            this.picGame.Location = new Point(0, 0);

            this.KeyDown += this.Form1_KeyDown;
        }

        #endregion

        #region initiate game and start timer

        private void Form1_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();

            #region add cars to game

            int carVel;
            int randomCarX1;
            int randomCarX2;
            int randomCarX3;
            int randomCarD;
            int tempCarVel = -1;
            int carOffset = 500;

            for (int i = 0; i < 7; i++)
            {
                // Create random velocity and direction
                carVel = rnd.Next(2, 4);
                randomCarD = rnd.Next(0, 2);
                randomCarX1 = rnd.Next(0, this.picGame.Width);
                randomCarX2 = rnd.Next(0, this.picGame.Width);
                randomCarX3 = rnd.Next(0, this.picGame.Width);

                // Set new velocity if car above has same velocity value
                while (carVel == tempCarVel)
                {
                    carVel = rnd.Next(2, 5);
                }

                // Make sure each car is spaced apart fairly
                while (randomCarX3 < (randomCarX2 + 250) || randomCarX2 < (randomCarX1 + 250))
                {
                    randomCarX1 = rnd.Next(0, this.picGame.Width);
                    randomCarX2 = rnd.Next(0, this.picGame.Width);
                    randomCarX3 = rnd.Next(0, this.picGame.Width);
                }

                this.cars.Add(new Car(50, 50, randomCarX1, carOffset, randomCarD, carVel));
                this.cars.Add(new Car(50, 50, randomCarX2, carOffset, randomCarD, carVel));
                this.cars.Add(new Car(50, 50, randomCarX3, carOffset, randomCarD, carVel));

                // Increment offset
                carOffset += 50;
                tempCarVel = carVel;
            }

            #endregion

            #region add logs to game

            int randomV;
            int randomX1;
            int randomX2;
            int randomD;
            int tempV = -1;
            int offsetY = 50;

            for (int i = 0; i < 8; i++)
            {
                // Create random velocity and direction
                randomV = rnd.Next(1, 3);
                randomD = rnd.Next(0, 2);
                randomX1 = rnd.Next(0, this.Width - 200);
                randomX2 = rnd.Next(0, this.Width - 200);

                // Set new velocity if row above has same velocity value
                while (randomV == tempV)
                {
                    randomV = rnd.Next(1, 3);
                }

                // Make sure each log is spaced apart fairly
                while (randomX2 < (randomX1 + 250))
                {
                    randomX1 = rnd.Next(0, this.Width - 200);
                    randomX2 = rnd.Next(0, this.Width - 200);
                }
 
                this.logs.Add(new Log(50, 200, randomX1, offsetY, randomD, randomV));
                this.logs.Add(new Log(50, 200, randomX2, offsetY, randomD, randomV));
               
                // Increment offset
                offsetY += 50;
                tempV = randomV;
            }

            #endregion

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

            // Draw safe zone at top of map
            SolidBrush safeZone = new SolidBrush(Color.Gray);
            Frogger.FillRectangle(safeZone, 0, 0, 1500, 50);

            // Draw safe zone in middle of map
            Frogger.FillRectangle(safeZone, 0, 450, 1500, 50);

            // Draw cars
            SolidBrush carBrush = new SolidBrush(Color.Orange);
            for (int i = 0; i < this.cars.Count; i++)
            {
                // Make cars appear
                Frogger.FillRectangle(carBrush, this.cars[i].GetX(), this.cars[i].GetY(), Convert.ToInt32(this.cars[i].GetW()), Convert.ToInt32(this.cars[i].GetH()));

                // Give cars their behaviours
                this.cars[i].move();
                this.cars[i].offScreen(0, this.picGame.Width);
            }

            // Check if player has been hit by car
            if (this.playerIcon.GetY() > 49 && !this.playerIcon.reachTop(this.playerIcon.GetY()))
            {
                for (int i = 0; i < this.cars.Count; i++)
                {
                    // Player has been hit by car
                    if (this.cars[i].hitsFrog(this.playerIcon))
                    {
                        this.playerIcon.resetPosition((this.picGame.Width / 2), (this.picGame.Height - 50));
                    }
                }
            }

            // Draw logs
            SolidBrush drawLog = new SolidBrush(Color.White);
            for (int i = 0; i < this.logs.Count; i++)
            {
                // Make logs appear
                Frogger.FillRectangle(drawLog, this.logs[i].GetX(), this.logs[i].GetY(), Convert.ToInt32(this.logs[i].GetW()), Convert.ToInt32(this.logs[i].GetH()));

                // Give logs their behaviours
                this.logs[i].move();
                this.logs[i].offScreen(0, this.picGame.Width);
            }

            // Check if player is on log
            if (this.playerIcon.GetY() < 450 && !this.playerIcon.reachTop(this.playerIcon.GetY()))
            {
                bool frogOnLog = false;
            
                for (int i = 0; i < this.logs.Count; i++)
                {
                    // Player is on the log
                    if (this.logs[i].frogIsRiding(this.playerIcon))
                    {
                        this.playerIcon.moveWithLog(this.logs[i]);
                        frogOnLog = true;
                    }
                }

                // Player missed the log
                if (!frogOnLog)
                {
                    this.playerIcon.resetPosition((this.picGame.Width / 2), (this.picGame.Height - 50));
                }
            }

            // Draw player icon
            SolidBrush drawPlayer = new SolidBrush(Color.Green);
            Frogger.FillRectangle(drawPlayer, this.playerIcon.GetX(), this.playerIcon.GetY(), Convert.ToInt32(this.playerIcon.GetH()), Convert.ToInt32(this.playerIcon.GetW()));

            // Player has reached the top
            if (this.playerIcon.reachTop(this.playerIcon.GetY()))
            {
                // ADD SOMETHING HERE
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
