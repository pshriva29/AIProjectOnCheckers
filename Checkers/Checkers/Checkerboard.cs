/* Class to display the checkerbaord*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
	class Checkerboard
	{

		public const int SIZEN = 6; // 6X6 board

        // creates board with empty spaces 
		public Checkerboard()
		{

			CheckerBoardHorizontalSymbol = "-----";
			CheckerBoardVerticalSymbol = "| ";

		}

		public string CheckerBoardHorizontalSymbol { get; set; }
		public string CheckerBoardVerticalSymbol { get; set; }


		public void BoardDisplay(String[,] board)
		{
			Console.Write("     ");// space from index
			for (int i = 0; i < SIZEN; i++)
			{
				Console.Write(i + "    ");
			}
			Console.Write("\n");
			for (int row = 0; row < SIZEN; row++)
			{
				Console.Write("  ");//  left space
				for (int column = 0; column < SIZEN; column++)
				{
					Console.Write(CheckerBoardHorizontalSymbol);

				}
				Console.Write("-\n");

				for (int column = 0; column < SIZEN; column++)
				{

					if (column == 0)
					{
						Console.Write(row + " ");
					}
					Console.Write(CheckerBoardVerticalSymbol + board[row, column] + " ");

				}
				Console.Write("|\n");
			}
			// displays last horizontal ---
			Console.Write("  ");
			for (int i = 0; i < SIZEN; i++)
			{
				Console.Write(CheckerBoardHorizontalSymbol);
			}
			Console.Write("-\n\n");
			//} // once while ends game ends. 
		}//end of display


	}
}
