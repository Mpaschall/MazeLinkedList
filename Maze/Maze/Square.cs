using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    class Square
    {
        //no changes in this class on 6/18/16
        //variables for position
        int xPos, yPos, startX, startY, endX, endY;
        string sqstring, type;

        //default constructor
        public Square()
        {
        }

        //overloaded constructor
        public Square(int xPos, int yPos, string type)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.type = type;
        }

        public string start()
        {
            sqstring = "...\n.S.\n...";
            return sqstring;
        }

        public string fin()
        {
            sqstring = "...\n.F.\n...";
            return sqstring;
        }

        public string opSq()
        {
            sqstring = "...\n...\n...";
            return sqstring;
        }

        public string wall()
        {
            sqstring = "xxx\nxxx\nxxx";
            return sqstring;
        }

        public void moveRight()
        {
            xPos++;
        }

        public void moveLeft()
        {
            xPos--;
        }

        public void moveDown()
        {
            yPos++;
        }

        public void moveUp()
        {
            yPos--;
        }

        public void setX(int xPos)
        {
            this.xPos = xPos;
        }

        public int getX()
        {
            return xPos;
        }

        public void setY(int yPos)
        {
            this.yPos = yPos;
        }

        public int getY()
        {
            return yPos;
        }

        public void setType(string type)
        {
            this.type = type;
        }

        public string getType()
        {
            return type;
        }
    }
}
