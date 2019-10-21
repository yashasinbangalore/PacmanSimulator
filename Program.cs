using System;
using PacmanSimulator.Models;

namespace PacmanSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Place the Pacman please.");
            string command;
            do
            {
                command = Console.ReadLine();
                if (command.ToUpper().Contains("PLACE"))
                {
                    PlacePacman(command);
                }
                else if(command.ToUpper().Contains("MOVE") || command.ToUpper().Contains("LEFT") || command.ToUpper().Contains("RIGHT") ||
                    command.ToUpper().Contains("REPORT"))
                {
                    Command(command);
                }
                else
                {
                    Console.WriteLine("Invalid command.");
                }
                Console.WriteLine("Enter a command or ENTER to exit.");
            } while (!string.IsNullOrWhiteSpace(command));
        }
        static void PlacePacman(string command)
        {
            string[] splitCmd = command.Split(new char[] { ',', ' ' });
            int xVal;
            int yVal;
            if (splitCmd.Length == 4 && splitCmd[0].ToUpper().Trim().Equals("PLACE") && int.TryParse(splitCmd[1], out xVal) && int.TryParse(splitCmd[2], out yVal))
            {
                //[0] - PLACE
                //[1] - x
                //[2] - y
                //[3] - NORTH/SOUTH/EAST/WEST

                Pacman.Place(xVal, yVal, splitCmd[3]);
                return;
            }
            Console.WriteLine("Invalid command format. Expected format : PLACE x,y,'NORTH/SOUTH/EAST/WEST'");

        }
        static void Command(string command)
        {
            if (command.Trim().ToUpper().Equals("MOVE")) { Pacman.Move(); }
            else if (command.Trim().ToUpper().Equals("LEFT")) { Pacman.Left(); }
            else if (command.Trim().ToUpper().Equals("RIGHT")) { Pacman.Right(); }
            else if (command.Trim().ToUpper().Equals("REPORT")) { Pacman.Report(); }
            else Console.WriteLine("Invalid command");
        }
    }
}
