using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class TicTacToe
    {
        public Dictionary<int, string> Board { get; set; }

        public IList<string> player1Choics = new List<string>();
        public IList<string> player2Choics = new List<string>();

        public TicTacToe()
        {
            Board = new Dictionary<int, string>();
            for (var index =0;index<9;index++)
            {
                Board.Add(index, " ");
            }
        }

        public void PrintBoard()
        {
            for (var row = 0; row < 9; row++)
            {
                Console.Write("|{0}|", Board[row]);
                if ((row + 1) % 3 == 0)
                {
                    Console.Write("\n---------\n");
                }
            }
        }

        public bool BoardCheck(int player, string position)
        {
            string choice = player == 1 ? "x" : "o";
            string playerChoices = "W";

            var inputRow = Convert.ToInt32(position.Split(',')[0]);
            var inputCol = Convert.ToInt32(position.Split(',')[1]);

            if (Board[(inputRow*3) + inputCol] == " ")
            {
                Board[(inputRow * 3) + inputCol] = choice;
            }
            else
            {
                Console.WriteLine("Try next position");
                return false;
            }

            var index = 0;
            for (var row = 0; row < 3; row++)
            {
                for (var col = 0; col < 3; col++)
                {
                    if (Board[index] == choice)
                    {
                        if (player == 1)
                        {
                            player1Choics.Add(index.ToString());
                        }
                        else
                        {
                            player2Choics.Add(index.ToString());
                        }
                        playerChoices += (index).ToString();
                    }
                    index++;
                }
            }

            var isWin = Enum.GetNames(typeof(WinMoves)).Contains(playerChoices);
            if (!isWin)
            {
                isWin = !Board.ContainsValue(" ");
            }
            return isWin;
        }
    }

    public enum WinMoves
    {
        W012,
        W036,
        W048,
        W147,
        W258,
        W246,
        W345,
        W678
    }
}
