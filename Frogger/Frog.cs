using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger
{
    class Frog
    {
        // Attributes:
        private double height;
        private double width;

        private int posX;
        private int posY;

        // Constructor:

        public Frog(double h, double w, int x, int y)
        {
            this.height = h;
            this.width = w;
            this.posX = x;
            this.posY = y;
        }

        // Getter Methods:

        public double GetH ()
        {
            return this.height;
        }

        public double GetW ()
        {
            return this.width;
        }

        public int GetX ()
        {
            return this.posX;
        }

        public int GetY ()
        {
            return this.posY;
        }

        // Setter Methods:

        public void SetH (double h)
        {
            this.height = h;
        }

        public void SetW (double w)
        {
            this.width = w;
        }

        public void SetX (int x)
        {
            this.posX = x;
        }

        public void SetY (int y)
        {
            this.posY = y;
        }
    }
}
