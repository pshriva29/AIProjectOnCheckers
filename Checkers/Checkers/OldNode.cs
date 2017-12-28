using System;
using System.Collections.Generic;

namespace Checkers
{
	public class OldNode
	{
		public String[,] checkerboard = new String[Checkerboard.SIZEN, Checkerboard.SIZEN];

		public List<Node> children = new List<Node>();
		public Node parent;
		//int x = 0;


		public OldNode()
		{
		}

		public OldNode(String[,] b)
		{
			for (int i = 0; i < 6; i++)
			{
				for (int j = 0; j < 6; j++)
				{
					checkerboard[i, j] = b[i, j];
				}
			}
		}

		public String[,] getBoard()
		{
			return this.checkerboard;
		}

		public List<Node> getChildren()
		{
			return this.children;
		}

		public void PrintCheckerboard()
		{
			for (int i = 0; i < 6; i++)
			{
				for (int j = 0; j < 6; j++)
				{
					Console.Write(checkerboard[i, j] + " ");
				}
				Console.WriteLine();
			}
		}

		public void PrintCheckerboard(int[,] board)
		{
			for (int i = 0; i < 6; i++)
			{
				for (int j = 0; j < 6; j++)
				{
					Console.Write(board[i, j] + " ");
				}
				Console.WriteLine();
			}
		}

		/* Method to check if the move is valid */
		public bool IsValidMove(int val, int i, int j)
		{
			bool IsValid = true;
			int r1 = i + 1;
			int r2 = i - 1;
			int c1 = j - 1;
			int c2 = j + 1;
			if (val == 3) // Player 1 -- so check only Lower Diagonal
			{
				if (j > 0 && j < 5)
				{
					Console.WriteLine("inside j<5");
					if ((checkerboard[r1, c1] == 2) || (checkerboard[r1, c2] == 2))
					{
						Console.WriteLine("checkerboard[r1] is " + r1);
						Console.WriteLine("checkerboard[c2] is " + c2);
						Console.WriteLine("checkerboard[r1, c1] is " + checkerboard[r1, c1]);
						Console.WriteLine("checkerboard[r1, c2] is " + checkerboard[r1, c2]);
						IsValid = false;
					}

				}

				if (j == 0)  // Column 1
				{
					if (checkerboard[r1, c2] == 2)
					{
						IsValid = false;
					}

				}

				if (j == 5)  // Column 6
				{
					if (checkerboard[r1, c1] == 2)
					{
						IsValid = false;
					}

				}
			}

			if (val == 2) // Player 2 -- so check only Upper Diagonal
			{
				if (j > 0 && j < 5)
				{
					if ((checkerboard[r2, c2] == 3) || (checkerboard[r2, c1] == 3))
					{
						IsValid = false;
					}

				}

				if (j == 0)  // Column 1
				{
					if (checkerboard[r2, c2] == 3)
					{
						IsValid = false;
					}

				}

				if (j == 5)  // Column 6
				{
					if (checkerboard[r2, c1] == 3)
					{
						IsValid = false;
					}

				}

			}

			return IsValid;

		}

		public void MoveLeft(int val, int i, int j)
		{

			if (IsValidMove(val, i, j)) //will return true if the move is valid
			{
				Console.WriteLine("Inside Valid");
				if (val == 3) //Player 1 moves by increasing col and row by 1
				{
					Console.WriteLine("Inside 3");
					checkerboard[i + 1, j + 1] = 3; //player 1 will move forward by one
					checkerboard[i, j] = 1; //original spot will become 1 to indicate that its empty 
											//j = j + 1;
											//i = i + 1;
				}


				else if (val == 2)//Player 2 moves by decreasing col and row by 1
				{
					Console.WriteLine("Inside 2");
					checkerboard[i - 1, j - 1] = 2;
					checkerboard[i, j] = 1;
					// i = i - 1;
					// j = j - 1;
				}
			}
		}

		public void MoveRight(int val, int i, int j)
		{
			if (IsValidMove(val, i, j))
			{
				Console.WriteLine("Inside Valid");
				if (val == 3)
				{
					Console.WriteLine("Inside 3");
					checkerboard[i - 1, j - 1] = 3;
					checkerboard[i, j] = 1;
				}
				else if (val == 2)
				{
					Console.WriteLine("Inside 2");
					checkerboard[i - 1, j + 1] = 2;
					checkerboard[i, j] = 1;
				}
			}
		}

		public void copyboard(int[,] a, int[,] b)
		{

			for (int i = 0; i < 6; i++)
			{
				for (int j = 0; j < 6; j++)
				{
					b[i, j] = a[i, j];
				}
			}

		}

		public void ExpandMove(int val, int i, int j)
		{
			tree(val, i, j);
		}

		//I need a method which would make a tree of all of the nodes moving 1 step forward and creating a tree as What would happen if this move is to be made. 
		public void tree(int val, int i, int j)
		{
			int[,] boardcopy = new int[8, 8];

			copyboard(checkerboard, boardcopy);
			if (val == 2)
			{
				Node child = new Node(boardcopy);
				child.PrintCheckerboard();
				children.Add(child);
				child.parent = this;
				Console.WriteLine("The 2 at " + i + ", " + j + " can move at following location(s)");

				if (IsValidMove(val, i, j)) //if moving right is valid, as an if the val is 1, then assign it to 2 for now and print the board, so we can explore our options.
				{
					boardcopy[i - 1, j + 1] = 2;
					boardcopy[i - 1, j + 1] = 1; //once the board is printed, change the value at i j to 2 so we can check for the left side.
					PrintCheckerboard(boardcopy);
				}
				Console.WriteLine("Next");
				if (IsValidMove(val, i, j))
				{
					boardcopy[i - 1, j - 1] = 2;
					boardcopy[i - 1, j - 1] = 1;
					PrintCheckerboard(boardcopy);
				}
			}
			if (val == 3)
			{
				Node child = new Node(boardcopy);
				children.Add(child);
				child.parent = this;
				Console.WriteLine("The 3 at " + i + ", " + j + " can move at following location(s)");

				if (IsValidMove(val, i, j)) //if moving right is valid, as an if the val is 1, then assign it to 2 for now and print the board, so we can explore our options.
				{
					boardcopy[i + 1, j - 1] = 3;

					boardcopy[i + 1, j - 1] = 1; //once the board is printed, change the value at i j to 2 so we can check for the left side.
					PrintCheckerboard(boardcopy);
				}
				Console.WriteLine("Next");
				if (IsValidMove(val, i, j))
				{
					boardcopy[i + 1, j + 1] = 3;

					boardcopy[i + 1, j + 1] = 1;
					PrintCheckerboard(boardcopy);
				}
			}
		}

		public void generateTree(String player, int[,] board, int depth)
		{
			int maxDepth = 2;
			int[,] boardCopy = new int[6, 6];
			copyboard(board, boardCopy);

			if (depth <= maxDepth)
			{
				for (int row = 0; row < 6; row++)
				{
					for (int col = 0; col < 6; col++)
					{
						if (player.Equals("Computer"))
						{
							int val = 2;
							Node child = new Node(boardCopy);
							child.PrintCheckerboard();
							children.Add(child);
							child.parent = this;
							Console.WriteLine("The 2 at " + row + ", " + col + " can move at following location(s)");

							if (IsValidMove(val, row, col)) //if moving right is valid, as an if the val is 1, then assign it to 2 for now and print the board, so we can explore our options.
							{
								MoveLeft(val, row, col);
								MoveRight(val, row, col);
								//boardcopy[i - 1, j + 1] = 2;
								//boardcopy[i - 1, j + 1] = 1; //once the board is printed, change the value at i j to 2 so we can check for the left side.
								PrintCheckerboard(boardCopy);
							}
							Console.WriteLine("Next");

						}

					}
				}

			}

		}


		public int[] GetPieces()
		{
			int[] NumPieces = new int[2] { 0, 0 };
			int count3 = 1;
			int count2 = 1;

			for (int i = 0; i < 6; i++)
			{
				for (int j = 0; j < 6; j++)
				{
					if (checkerboard[i, j] == 3)
					{
						NumPieces[0] = count3++;
					}
					if (checkerboard[i, j] == 2)
					{
						NumPieces[1] = count2++;
					}
				}
			}

			return NumPieces;
		}


	}
}
