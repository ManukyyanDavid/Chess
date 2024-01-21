using ChessLibrary;
namespace ChessProject;

public static class BoardIllustrator
{
    /// <summary>
    /// Prints the chess board represente by two-dimensional array of string values.
    /// </summary>
    /// <param name="board">String type 2D array representing the chess board.</param>


    public static void PrintBoard(string[,] board)
    {
        int count = 1;
        Console.WriteLine("    A    B    C    D    E    F    G    H ");  
        for (int i = 0; i < 8; i++)
        {
            Console.Write($" {count} ");
            count++;
            for (int j = 0; j < 8; j++)
            {
                if ((i + j) % 2 == 0)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                if (board[i, j] == null)
                {
                    Console.Write("     ");
                }
                else if (board[i, j].Length == 1)  //e5
                {
                    if (board[i, j] != "e" && board[i, j] != "5")
                    {
                        if ((i + j) % 2 == 0)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Gray;
                        }
                    }
                    if (board[i, j].Contains("e"))
                    {
                        Console.Write($" BK  ");

                    }
                    else if (board[i, j].Contains("a"))
                    {
                        Console.Write($" WK  ");
                    }
                    else if (board[i, j].Contains("b"))
                    {
                        Console.Write($" WQ  ");
                    }
                    else if (board[i, j].Contains("c"))
                    {
                        Console.Write($" R1  ");
                    }
                    else if (board[i, j].Contains("d"))
                    {
                        Console.Write($" R2  ");
                    }
                    else
                    {
                        Console.Write("     ");
                    }
                }
                else if (board[i, j].Length == 3 || board[i, j].Length == 2)
                {
                    if (board[i, j] != "e" && board[i, j] != "5")
                    {
                        if ((i + j) % 2 == 0)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Gray;
                        }
                    }
                    if (board[i, j].Length == 2)
                    {
                        if (board[i, j].Contains("e"))
                        {
                            Console.Write(" ");
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.Write($"BK");
                            Console.BackgroundColor = ConsoleColor.White;

                        }
                        else if (board[i, j].Contains("a"))
                        {
                            Console.Write($" WK");
                        }
                        else if (board[i, j].Contains("b"))
                        {
                            Console.Write($" WQ");
                        }
                        else if (board[i, j].Contains("c"))
                        {
                            Console.Write($" R1");
                        }
                        else if (board[i, j].Contains("d"))
                        {
                            Console.Write($" R2");
                        }
                        else
                        {
                            Console.Write($"   ");
                        }
                        Console.Write("  ");
                    }
                    else
                    {
                        if (board[i, j].Contains("e"))
                        {
                            Console.Write($" BK");

                        }
                        else if (board[i, j].Contains("a"))
                        {
                            Console.Write($" WK");
                        }
                        else if (board[i, j].Contains("b"))
                        {
                            Console.Write($" WQ");
                        }
                        else if (board[i, j].Contains("c"))
                        {
                            Console.Write($" R1");
                        }
                        else if (board[i, j].Contains("d"))
                        {
                            Console.Write($" R2");
                        }
                        else
                        {
                            Console.Write($"   ");
                        }
                        Console.Write("  ");
                    }
                }
            }
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}