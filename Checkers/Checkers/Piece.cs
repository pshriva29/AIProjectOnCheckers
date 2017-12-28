/* Class to intiate the board. Cotains method IsGoalState() to check the goal state. Contains method GetPieces() to get the number of pieces of each player */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
	public class Piece
	{
		public const String COMP_PIECE = "B";
		public const String PLAYER_PIECE = "R";
		public const String SPACE = "  ";
		public static String[,] pieces;
        private String[,] state;
        private String[,] newState;


		public Piece()
		{
			pieces = new String[Checkerboard.SIZEN, Checkerboard.SIZEN];
			state = InitPieces();
            setBoard(state);

         }

		public void setBoard(String[,] state)
		{
            this.newState = state;
		}

		public String[,] getBoard()
		{
			return this.newState;
		}


		public String[,] InitPieces()
		{
			int compPieceStarted = Checkerboard.SIZEN - 1;
			int compPiecesCount = 0;
			int initPosition = 1;
			int initPLayerPiece = Checkerboard.SIZEN - 1;
			int initPlayerCount = 0;
			int initPosition2 = 1;

			for (int row = 0; row <= Checkerboard.SIZEN - 1; row++)
			{
				for (int column = 0; column <= Checkerboard.SIZEN - 1; column++)
				{

					if (compPiecesCount <= compPieceStarted)
					{
						if (row % 2 == 0 && compPiecesCount <= compPieceStarted)
						{
							if (column % 2 != 0)
							{
								pieces[row, column] = COMP_PIECE + initPosition;
								compPiecesCount++;
								initPosition++;
							}//end of column if
							else
								pieces[row, column] = SPACE;
						}// end of row iff
						else if (row % 2 != 0 && compPiecesCount <= compPieceStarted)
						{
							if (column % 2 == 0)
							{
								pieces[row, column] = COMP_PIECE + initPosition;
								compPiecesCount++;
								initPosition++;
							}
							else
								pieces[row, column] = SPACE;
						}//end of if

					}//end of if 

					else if (row >= Checkerboard.SIZEN - 2)
					{
						if (row % 2 == 0 && initPlayerCount <= initPLayerPiece)
						{
							if (column % 2 != 0)
							{
                                pieces[row, column] = PLAYER_PIECE + initPosition2;
								initPlayerCount++;
								initPosition2++;
							}
							else
								pieces[row, column] = SPACE;

						}
						else if (row % 2 != 0 && initPlayerCount <= initPLayerPiece)
						{
                         if (column % 2 == 0)
							{

								pieces[row, column] = PLAYER_PIECE + initPosition2;
								initPlayerCount++;
								initPosition2++;

							}
						 else
								pieces[row, column] = SPACE;
                          }
                         else
							pieces[row, column] = SPACE;
                    }// end of adding PLAYEr_PIEce

                    else
						pieces[row, column] = SPACE;

               }// end of inner loop
			}// end of outer loop

            return pieces;
          } //end of initCompiece


		/* Method to get number of pieces of both players */

		public static int[] GetPieces(String[,] board)
		{
			int[] NumPieces = new int[2] { 0, 0 };
			int computerPiece = 1;
			int humanPiece = 1;

			for (int i = 0; i < 6; i++)
			{
				for (int j = 0; j < 6; j++)
				{
					if (board[i, j][0] == 'B')
					{
						NumPieces[0] = computerPiece++;   // Holds number of pieces for Computer
					}
					if (board[i, j][0] == 'R')
					{
						NumPieces[1] = humanPiece++;     // Holds number of pieces for Human
					}
				}
			}

			return NumPieces;
		}

        /* Method to check if Goal State is reached
           // Either 0 pieces left for any player
           // If Valid Move is not available for any of the player
        */

        public static bool IsGoalState(String[,] board, String playerType)
        {
            bool isGoalState = true;
            int[] numberOfPieces = GetPieces(board); // Get # of pieces for each player 

            if((numberOfPieces[0] == 0) || (numberOfPieces[1] == 0))  // If any player have 0 pieces Game end
            {
                   return isGoalState;
            }

            else {
                for (int row = 0; row < 6;row++)
                {
                    for (int col = 0; col < 6; col++)
                    {
                        if(playerType.Equals("Human"))
                        {
							if (!(board[row, col].Equals(Piece.SPACE)) && board[row, col][0] == 'B')
							{
								if ((Move.IsValidMoveAvail("Computer", board, row, col))) // Valid move is avilable for Computer for this row and col
								{
									isGoalState = false;  // Valid move is there so it is not Goal State
														  //  return isGoalState;
								}

							}

						}

                        else{
                            if (!(board[row, col].Equals(Piece.SPACE)) && board[row, col][0] == 'R')
							{
								if (Move.IsValidMoveAvail("Human", board, row, col)) // No Valid move avilable for Human
								{
                                    isGoalState = false;  // Valid move is there so this is not a Goal state
														  //  return isGoalState;
								}

							}

						}
                    }
                }
                
            }

            return isGoalState;
        }

    }//end of class
}// end of namespace 


