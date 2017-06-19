using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Maze
{
    class Program
    {
        static void Main(string[] args)
        {
            //create variables to use with square
            int count = 0;
            int boardCount = 0;
            string startX, startY, endX, endY, coor, boardX, boardY, temp, temp2, wallX, wallY;
            object test;

            //get input from file
            string[] input = System.IO.File.ReadAllLines(@"C:\Users\xdark\Documents\Visual Studio 2015\Projects\Maze\sqcoordinates.txt");
            string[] coord;
            object[,] squares = new object[10, 11];
            LLCreate linked = new LLCreate();

            for (int i = 0; i < input.Length; i++)
            {
                //if input does not have parenthesis, contains sentinel, count is < 1,
                //get board size and create the array for the board
                if (!input[i].Contains('(') && !input[i].Contains(')') && count < 1 && input[i].Contains('.'))
                {
                    coord = input[i].Split(',');
                    coor = coord[i];
                    boardX = coor;
                    coor = coord[i + 1];
                    boardY = coor.Substring(1, 2);
                    count++;
                }
                //if count >= 1 < 2 and contains sentinel this is the starting coordinate, get it
                else if (count >= 1 && count < 2 && input[i].Contains('.'))
                {
                    coord = input[i].Split(',');
                    coor = coord[0];
                    startX = (coor.Remove(0, 1));
                    coor = coord[1];
                    temp = (coor.Replace(')', ' '));
                    temp2 = (temp.Replace('.', ' '));
                    startY = temp2.Trim();
                    Square square = new Square(int.Parse(startX), int.Parse(startY), "start");
                    squares[int.Parse(startX), int.Parse(startY)] = square;
                    count++;
                }
                //if count >= 2 < 3 and contains sentinel, get final square
                else if (count >= 2 && count < 3 && input[i].Contains('.'))
                {
                    coord = input[i].Split(',');
                    coor = coord[0];
                    endX = (coor.Remove(0, 1));
                    coor = coord[1];
                    temp = (coor.Replace(')', ' '));
                    temp2 = (temp.Replace('.', ' '));
                    endY = temp2.Trim();
                    Square square = new Square(int.Parse(endX), int.Parse(endY), "end");
                    squares[int.Parse(endX), int.Parse(endY)] = square;
                    linked.addToTail(square);
                    count++;
                }
                //else if count >= 3 and does not contain sentinel
                else if (count >= 3 && count < 42)
                {
                    coord = input[i].Split(',');
                    coor = coord[0];
                    wallX = (coor.Remove(0, 1));
                    coor = coord[1];
                    temp = (coor.Replace(')', ' '));
                    temp2 = (temp.Replace('.', ' '));
                    wallY = temp2.Trim();
                    Square square = new Square(int.Parse(wallX), int.Parse(wallY), "wall");
                    squares[int.Parse(wallX), int.Parse(wallY)] = square;
                    count++;
                }
                //add open cells to the array
                else
                {
                    int rowLength = squares.GetLength(0);
                    int colLength = squares.GetLength(1);

                    for (int h = 0; h < rowLength; h++)
                    {
                        for (int j = 0; j < colLength; j++)
                        {
                            if (squares[h, j] == null)
                            {
                                Square square = new Square(h, j, "open");
                                squares[h, j] = square;
                            }
                        }
                    }
                }

            }

            //print to file, I had some issues formatting the printing of the maze here, but I added a
            //console print to show what the values are for the array.
            //you can see it prints to mazePrint in the bin folder, but it is not formatted correctly.
            //edited 6/18/17 to add items from the array to the linked list and print those items

            foreach (Square square in squares)
            {
                if (square.getType() == "start")
                {
                    linked.addToTail(square.start());
                }
                else if (square.getType() == "end")
                {
                    linked.addToTail(square.fin());
                }
                else if (square.getType() == "open")
                {
                    linked.addToTail(square.opSq());
                }
                else if (square.getType() == "wall")
                {
                    linked.addToTail(square.wall());
                }

            }

            linked.printList();
        }
    }
}
