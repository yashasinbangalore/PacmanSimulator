using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanSimulator.Models
{
    public static class Pacman
    {
        static int xPos;
        static int yPos;
        static Direction direction;
        static bool IsPlaced = false;


        public static void Place(int x, int y, string direct)
        {
            if (x < 0 || x > 4 || y < 0 || y > 4 || (!direct.ToUpper().Trim().Equals(Direction.NORTH.ToString()) &&
                !direct.ToUpper().Trim().Equals(Direction.EAST.ToString()) &&
                !direct.ToUpper().Trim().Equals(Direction.SOUTH.ToString()) &&
                !direct.ToUpper().Trim().Equals(Direction.WEST.ToString())))
            {
                Console.WriteLine("Pacman cannot be placed at desired position OR Invalid command format. Expected format : PLACE x,y,'NORTH/SOUTH/EAST/WEST'");
            }
            else
            {
                xPos = x;
                yPos = y;
                direction = (Direction)Enum.Parse(typeof(Direction), direct, true);
                IsPlaced = true;
            }
        }
        public static void Move()
        {
            if (!IsPlaced)
            {
                Console.WriteLine("You need to PLACE the pacman before anything!");
            }
            else
            {
                if (direction == Direction.NORTH && (yPos + 1) <= 4) yPos++;
                else if (direction == Direction.SOUTH && (yPos - 1) >= 0) yPos--;
                else if (direction == Direction.EAST && (xPos + 1) <= 4) xPos++;
                else if (direction == Direction.WEST && (xPos - 1) >= 0) xPos--;
                else
                {
                    Console.WriteLine("Pacamn should not fall off the grid.");
                }
            }
        }
        public static void Left()
        {
            if (!IsPlaced)
            {
                Console.WriteLine("You need to PLACE the pacman before anything!");
            }
            else
            {

                int facing = (int)direction;
                facing--;
                if (facing < 0)
                    direction = Direction.WEST;
                else
                    direction = (Direction)facing;
            }
        }
        public static void Right()
        {
            if (!IsPlaced)
            {
                Console.WriteLine("You need to PLACE the pacman before anything!");
            }
            else
            {

                int facing = (int)direction;
                facing++;
                if (facing > 3)
                    direction = Direction.NORTH;
                else
                    direction = (Direction)facing;
            }
        }
        public static void Report()
        {
            if (!IsPlaced)
            {
                Console.WriteLine("You need to PLACE the pacman before anything!");
            }
            else
            {
                Console.WriteLine("{0},{1},{2}", xPos, yPos, direction.ToString());
            }
        }

        enum Direction
        {
            NORTH = 0,
            EAST = 1,
            SOUTH = 2,
            WEST = 3
        }
    }
}
