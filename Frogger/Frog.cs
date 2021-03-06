﻿using System;
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

        // Custom Methods:

        // Method controlling Frog movement
        public void UpdatePos(int direction, int leftSide, int rightSide, int bottom, int top)
        {
            if (direction == 1 && (this.posX - this.width / 2) > leftSide) // Move left
            {
                this.posX -= 50;
            }
            else if (direction == 2 && (this.posX + this.width) < rightSide) // Move right
            {
                this.posX += 50;
            }
            else if (direction == 3 && (this.posY - this.width / 2) > top) // Move up
            {
                this.posY -= 50;
            }
            else if (direction == 4 && (this.posY + this.width) < bottom) // Move down
            {
                this.posY += 50;
            }
        }

        // Method to allow frog to move with log it is currently riding
        public void MoveWithLog(Log log)
        {
            if (log.GetD() == 1) // Move frog left
            {
                this.posX -= log.GetV();
            }
            else // Move frog right
            {
                this.posX += log.GetV();
            }
        }

        // Method to check if player reaches safe zone
        public bool ReachTop(int currentY)
        {
            return (currentY < 50);
        }

        // Method to send player back to starting position
        public void ResetPosition(int x, int y)
        {
            this.posX = x;
            this.posY = y;
        }
    }

}
