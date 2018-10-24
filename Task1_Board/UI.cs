// <copyright file="UI.cs" company="My Company">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace Task1_Board
{
    using System;
    using System.IO;
    using ShowMenuLib;

    /// <summary>
    /// Present visualization for user
    /// </summary>
    public class UI : GetMenu
    {
        /// <summary>
        /// Show menu for board task
        /// </summary>
        /// <param name="type">The header-line of menu</param>
        /// <returns>user choice</returns>
        public override char ShowMenu(string type)
        {
            Console.ResetColor();
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(type);
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("           1.Help                 ");
            Console.WriteLine("           2.Do it                ");
            Console.WriteLine("           3.Quit                 ");
            Console.WriteLine();
            Console.WriteLine(" What is your choice? [tap number]");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            return Console.ReadKey().KeyChar;
        }

        /// <summary>
        /// Show logic depending on the choice
        /// </summary>
        public override void UserChoice()
        {
            Console.Title = " My Board [Kropyvna Yuliia]";
            UsersAction action;
            Console.ResetColor();
            do
            {
                Console.SetCursorPosition(0, 0);
                Enum.TryParse(this.ShowMenu("    Welcome to the board task!    ").ToString(), out action);
                Console.WriteLine();
                Console.ResetColor();

                switch (action)
                {
                    case UsersAction.Help:
                        Help helper = new Help();
                        try
                        {
                            Console.ResetColor();
                            Console.WriteLine(helper.References(@"..\..\Files\BoardRef.txt"));
                        }
                        catch (FileNotFoundException ex)
                        {
                            Console.WriteLine("Some problem with file" + ex.Message);
                        }

                        Console.ReadKey();
                        break;
                    case UsersAction.Program:
                        Console.ResetColor();
                        this.TaskWithBoard();
                        break;
                    case UsersAction.Quit:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }

                Console.ResetColor();
                Console.Clear();
            }
            while (action != UsersAction.Quit);
        }

        /// <summary>
        /// Current menu for task
        /// </summary>
        public void TaskWithBoard()
        {
            int height = 1;
            int width = 1;
            int size = 1;
            bool isOk = true;

            try
            {
                Console.WriteLine("Please, write the height: ");
                height = int.Parse(Console.ReadLine());
                Console.WriteLine("Please, write the width: ");
                width = int.Parse(Console.ReadLine());
                Console.WriteLine("Please, write the size of the cell: |recommend size [1,6]|");
                size = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                isOk = false;
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Beep();
                Console.WriteLine("Just positive natural digit.");
            }

            if (isOk)
            {
               this.InitializeBoard(height, width, size);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Set the board
        /// </summary>
        /// <param name="height">height of board</param>
        /// <param name="width">width of board</param>
        /// <returns>the instance of board</returns>
        public Board GetBoard(int height, int width)
        {
            Board currentBoard = new Board();
            try
            {
                currentBoard = new Board(height, width);
            }
            catch (OverflowException)
            {
                Console.Beep();
                Console.WriteLine("Just positive natural digit.");
            }

            return currentBoard;
        }

        /// <summary>
        /// Initialize board and cells
        /// </summary>
        /// <param name="height">height of board</param>
        /// <param name="width">width of board</param>
        /// <param name="size">cell size</param>
        private void InitializeBoard(int height, int width, int size)
        {
            Console.WriteLine("Do you want to play on standart board?");
            string key = Console.ReadLine();
            Board currentBoard = new Board();
            try
            {
               currentBoard = this.GetBoard(height, width);
            }
            catch (ArgumentException ex)
            {
                Console.Beep();
                Console.WriteLine(ex.Message);
            }
            Color color = new Color();
            Cell currentCell = new Cell();
            currentCell = new Cell(color, size);

                if (key == "yes")
                {
                    this.GenerateBoard(height, width, currentBoard, currentCell, (Color)1, 0);
                }
                else
                {
                    this.GenerateBoard(height, width, currentBoard, currentCell, 0, (Color)1);
                }
        }

        /// <summary>
        /// Set console color of cell
        /// </summary>
        /// <param name="color"> enum color</param>
        private void SetColor(Color color)
        {
            switch (color)
            {
                case Color.Grey:
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    break;
                case Color.White:
                    Console.BackgroundColor = ConsoleColor.White;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Sets the color of current cell
        /// </summary>
        /// <param name="width">width of board</param>
        /// <param name="height">height of board</param>
        /// <param name="currentBoard">instance of board</param>
        /// <param name="currentCell">instance of cell</param>
        /// <param name="start">color depending on board position</param>
        /// <param name="end"> next color depending on board position</param>
        private void GenerateBoard(int width, int height, Board currentBoard, Cell currentCell, Color start, Color end)
        {
            int z = 0;
            int w = 0;
            Color color = new Color();
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (i % 2 == 0)
                    {
                        if (j % 2 == 0)
                        {
                            color = start;
                        }

                        if (j % 2 != 0)
                        {
                            color = end;
                        }
                    }
                    else
                    {
                        if (j % 2 == 0)
                        {
                            color = end;
                        }

                        if (j % 2 != 0)
                        {
                            color = start;
                        }
                    }

                    this.SetColor(color);

                    this.Draw(currentBoard, currentCell, ref z, ref w, i, j);
                }

                for (int m = 0; m < currentCell.Size; m++)
                {
                    Console.WriteLine();
                }

                z = 0;
                w = 0;
            }
        }

        /// <summary>
        /// Draw board
        /// </summary>
        /// <param name="currentBoard">instance of board</param>
        /// <param name="currentCell">instance of cell</param>
        /// <param name="z">indent for even lines</param>
        /// <param name="w">indent for odd lines</param>
        /// <param name="i">width of board</param>
        /// <param name="j">height of board</param>
        private void Draw(Board currentBoard, Cell currentCell, ref int z, ref int w, int i, int j)
        {
            try
            {
                int x;
                int y;
                currentBoard[i, j] = currentCell;

                for (x = 0; x < currentCell.Size; x++)
                {
                    for (y = 0; y < currentCell.Size * 2; y++)
                    {
                        Console.Write(" ");
                    }

                    Console.Write("\n");

                    if (x % 2 == 0)
                    {
                        if (currentCell.Size % 2 != 0)
                        {
                            if (x == currentCell.Size - 1 || currentCell.Size == 1)
                            {
                                z += currentCell.Size * 2;
                            }
                        }

                        if (y % 2 == 0 && y == currentCell.Size * 2)
                        {
                            if (currentCell.Size % 2 != 0)
                            {
                                if (currentCell.Size == 1)
                                {
                                    Console.SetCursorPosition(Console.CursorLeft + z, Console.CursorTop - 1);
                                }
                                else if (x == currentCell.Size - 1)
                                {
                                    Console.SetCursorPosition(Console.CursorLeft + z, Console.CursorTop - currentCell.Size);
                                }
                                else
                                {
                                    Console.SetCursorPosition(Console.CursorLeft + z, Console.CursorTop);
                                }
                            }
                            else
                            {
                                Console.SetCursorPosition(Console.CursorLeft + z, Console.CursorTop);
                            }
                        }

                        if (currentCell.Size % 2 == 0)
                        {
                            if (x == currentCell.Size - 2)
                            {
                                z += currentCell.Size * 2;
                            }
                        }

                        if (currentCell.Size != 2)
                        {
                            if (x == currentCell.Size - (currentCell.Size / 2) || x == (currentCell.Size - 1))
                            {
                                w += currentCell.Size * 2;
                            }
                        }

                        if (currentCell.Size == 2)
                        {
                            w += currentCell.Size * 2;
                        }
                    }

                    if (x % 2 != 0)
                    {
                        if (y % 2 == 0)
                        {
                            if (x == currentCell.Size - 1)
                            {
                                if (currentCell.Size % 2 != 0 || currentCell.Size == 6)
                                {
                                    w += currentCell.Size * 2;
                                }

                                Console.SetCursorPosition(Console.CursorLeft + w, Console.CursorTop - currentCell.Size);
                            }

                            if (currentCell.Size != 2)
                            {
                                if (x == currentCell.Size - (currentCell.Size - 1))
                                {
                                    Console.SetCursorPosition(Console.CursorLeft + w, Console.CursorTop);
                                }

                                if (x == currentCell.Size - (currentCell.Size / 2))
                                {
                                    Console.SetCursorPosition(Console.CursorLeft + w, Console.CursorTop);
                                }
                            }
                        }
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.ResetColor();
                Console.Beep();
                Console.WriteLine("You choose too big board. You should not write so big width or try to enlarge console.");
                Console.ReadKey();
                this.UserChoice();
            }
        }
    }
}
