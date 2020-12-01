using System;

namespace MorpionConsole
{

    class Game
    {
        public char[,] grid = new char[,] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
        public char currentPlayer = 'O';
        public void displayGrid()
        {
            for (int i = 0; i < this.grid.GetLength(0); i++)
            {
                Console.BackgroundColor = ConsoleColor.White;
                for (int j = 0; j < this.grid.GetLength(1); j++)
                {
                    if (this.grid[i, j].Equals('X'))
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write(this.grid[i, j]);
                    if (j != 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("|");
                    }
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("\n");
            }
        }
        public void changeCurrentPlayer()
        {
            if (this.currentPlayer.Equals('O'))
                currentPlayer = 'X';
            else
                currentPlayer = 'O';
        }
        private int getPlayerValue(String text)
        {
            Console.Write(text);
            String value = Console.ReadLine();
            try
            {
                int i = System.Convert.ToInt32(value);
                if (i > 3 || i < 0)
                {
                    return getPlayerValue(text);
                }
                return i;
            }
            catch (FormatException)
            {
                return getPlayerValue(text);
            }
        }
        public int getPlayerValueX()
        {
            return this.getPlayerValue("Entrez la ligne de la case à jouer: ");
        }

        public int getPlayerValueY()
        {
            return this.getPlayerValue("Entrez la colonne de la case à jouer: ");
        }

        public bool isWin()
        {
            for (int i = 0; i <= 2; i++)
            {
                if (grid[i, 0].Equals(grid[i, 1]) && grid[i, 2].Equals(grid[i, 1]) && !grid[i, 1].Equals(' '))
                {
                    return true;
                }
                if (grid[0, i].Equals(grid[1, i]) && grid[2, i].Equals(grid[1, i]) && !grid[1, i].Equals(' '))
                {
                    return true;
                }
            }
            if (grid[0, 0].Equals(grid[1, 1]) && grid[2, 2].Equals(grid[1, 1]) && !grid[1, 1].Equals(' '))
            {
                return true;
            }
            if (grid[0, 2].Equals(grid[1, 1]) && grid[2, 0].Equals(grid[1, 1]) && !grid[1, 1].Equals(' '))
            {
                return true;
            }
            return false;
        }
        public bool isNull()
        {
            for (int i = 0; i < this.grid.GetLength(0); i++)
            {
                for (int j = 0; j < this.grid.GetLength(1); j++)
                {
                    if (this.grid[i, j].Equals(' '))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
            Game mygame = new Game();
            do
            {
                mygame.changeCurrentPlayer();
                Console.WriteLine($"au tour du joueur {mygame.currentPlayer} de jouer");
                mygame.displayGrid();
                int x = mygame.getPlayerValueX();
                int y = mygame.getPlayerValueY();
                if (mygame.grid[x - 1, y - 1].Equals(' '))
                {
                    mygame.grid[x - 1, y - 1] = mygame.currentPlayer;
                }
                else
                {
                    Console.WriteLine("Vous ne pouvez pas jouer sur une case déjà remplie !");
                    mygame.changeCurrentPlayer();
                }
            } while (!mygame.isNull() && !mygame.isWin());

            mygame.displayGrid();

            if (mygame.isWin())
            {
                Console.WriteLine($"{mygame.currentPlayer} a gagné!!!");
            }
            else
            {
                Console.WriteLine("Match null!!!");
            }
            Console.ReadKey(true);
        }
    }
}

