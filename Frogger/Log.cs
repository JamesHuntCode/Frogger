using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger
{
    class Log
    {
        // Attributes:
        private double height;
        private double width;

        private int posX;
        private int posY;

        private double velocity;

        // Direction of log:

        private int direction;

        // Constructor:

        public Log(double h, double w, int x, int y, double v)
        {
            this.height = h;
            this.width = w;
            this.posX = x;
            this.posY = y;
            this.velocity = v;

            // Set movement direction:

            Random rnd = new Random();

            if (rnd.Next(0, 2) == 1)
            {
                this.direction = 1; // Sweep left accross screen
            }
            else
            {
                this.direction = 2; // Sweep right accross screen
            }
        }

        // Getter Methods:

        public double GetHeight()
        {
            return this.height;
        }

        public double GetWidth()
        {
            return this.width;
        }

        public int GetX()
        {
            return this.posX;
        }

        public int GetY()
        {
            return this.posY;
        }

        public double GetV()
        {
            return this.velocity;
        }

        // Setter Methods:

        public void SetH(double h)
        {
            this.height = h;
        }

        public void SetW(double w)
        {
            this.width = w;
        }

        public void SetX(int x)
        {
            this.posX = x;
        }

        public void SetY(int y)
        {
            this.posY = y;
        }

        public void SetV (double v)
        {
            this.velocity = v;
        }

        // Custom Methods:

        public void move ()
        {

        }

        // Method tracking log position:

        public bool offScreen (int leftSide, int rightSide)
        {
            if (this.posX + this.width < 0) // Too far left
            {
                return true;
            }

            if (this.posX > rightSide) // Too far right
            {
                return true;
            }
            return false;
        }
    }
}
