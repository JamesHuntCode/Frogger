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

        private int velocity;

        // Direction of log:

        private int direction;

        // Constructor: 

        public Log(double h, double w, int x, int y, int d, int v)
        {
            this.height = h;
            this.width = w;
            this.posX = x;
            this.posY = y;
            this.direction = d;
            this.velocity = v;
        }

        // Getter Methods:

        public double GetH()
        {
            return this.height;
        }

        public double GetW()
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

        public int GetV()
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

        public void SetV (int v)
        {
            this.velocity = v;
        }

        // Custom Methods:

        public void move ()
        {
            if (direction == 1) // Move log left
            {
                this.posX -= this.velocity;
            }
            else // Move log right
            {
                this.posX += this.velocity;
            }
        }

        // Method tracking log position:
        public void offScreen (int leftSide, int rightSide)
        {
            if (this.posX + this.width < 0) // Too far left
            {
                this.posX = rightSide;
            }

            if (this.posX > rightSide) // Too far right
            {
                this.posX = leftSide - Convert.ToInt32(this.width);
            }
            
        }

        // Method to check if frog is riding log:
        public bool frogIsRiding(Frog frog)
        {
            return !(this.posX > (frog.GetX() + frog.GetW()) ||
                (this.posX + this.width) < frog.GetX() ||
                this.posY > (frog.GetY() + frog.GetH()) ||
                (this.posY + this.height) < frog.GetY());
        }
    }
}
