using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    public class Move
    {

        public Move()
        {

        }

       /* Method to check if a Left Move is valid */

        public static bool IsValidLeftMove(String playerType, String[,] board, int row, int col)
        {
            bool validLeftMove = true;
            int rowChangeC = row + 1;  // Row updation for Computer
            int colChangeC = col + 1;  // Column updation for Computer
            int rowChangeH = row - 1;  // Row updation for Human
            int colChangeH = col - 1;  // Column updation for Human

            // Check Valid moves for Computer

            if (playerType.Equals("Computer"))
            {
                if (col == 5 || row == 5)
                {
                    return false;
                }
                else
                {
                    if (!(board[rowChangeC, colChangeC].Equals(Piece.SPACE)))
                    {
                        return false;
                    }
                }

            }

            // Check Valid moves for Human

            if (playerType.Equals("Human"))
            {
                if (col == 0 || row == 0)
                {
                    return false;
                }
                else
                {
                  if (!(board[rowChangeH, colChangeH].Equals(Piece.SPACE)))
                    {
                        return false;
                    }
                }

            }

            return validLeftMove;
        }

		/* Method to check if a Right Move is valid */

		public static bool IsValidRightMove(String playerType, String[,] board, int row, int col)
        {
            
            bool validRightMove = true;
            int rowChangeC = row + 1;  // Row updation for Computer
            int colChangeC = col - 1;  // Column updation for Computer
            int rowChangeH = row - 1;  // Row updation for Human
            int colChangeH = col + 1;  // Column updation for Human

            // Check Valid moves for Computer

            if (playerType.Equals("Computer"))
            {
                if (col == 0 || row == 5)
                {
                    return false;
                }

                else
                {
                    if (!(board[rowChangeC, colChangeC].Equals(Piece.SPACE)))
                    {
                      return false;
                    }
                }

            }

            // Check Valid moves for Human

            if (playerType.Equals("Human"))
            {
                if (col == 5 || row == 0)
                {
                   return false;
                }
                else
                {
                    if (!(board[rowChangeH, colChangeH].Equals(Piece.SPACE)))
                    {
                        return false;
                    }
                }

            }

            return validRightMove;
        }

		/* Method to check if a Left Capture is valid */

		public static bool IsValidLeftCapture(String playerType, String[,] board, int row, int col)
        {
            
            bool validLeftCapture = false;
            int rowChangeC = row + 1;  // Row updation for Computer
            int colChangeC = col + 1;  // Column updation for Computer
            int rowChangeH = row - 1;  // Row updation for Human
            int colChangeH = col - 1;  // Column updation for Human

            if (!(IsValidLeftMove(playerType, board, row, col)))
            {

                // Check if capture is valid for Computer

                if (playerType.Equals("Computer"))
                {
                    if (col == 4 || col == 5 || row == 4 || row == 5)
                    {
                        validLeftCapture = false; // Cannot capture as there is no Left spot after capture
                    }

                    else if (board[rowChangeC, colChangeC][0] == 'B')
                    {

                        validLeftCapture = false; // Cannot capture as there is Computer piece (B) in the Left spot

                    }
                    else if (board[rowChangeC + 1, colChangeC + 1].Equals(Piece.SPACE))
                    {
                        validLeftCapture = true;
                    }
                }

                // Check if capture is valid for Human

                if (playerType.Equals("Human"))
                {
                    if (col == 1 || col == 0 || row == 0 || row == 1)
                    {
                        validLeftCapture = false; // Cannot capture as there is no Left spot after capture
                    }

                    else if (board[rowChangeH, colChangeH][0] == 'R')
                    {
                        validLeftCapture = false; // Cannot capture as there is Human piece (R) in the Left spot
                    }
                    else if (board[rowChangeH - 1, colChangeH - 1].Equals(Piece.SPACE))
                    {
                        validLeftCapture = true;
                    }
                }
            }

            return validLeftCapture;
        }

		/* Method to check if a Right Capture is valid */

		public static bool IsValidRightCapture(String playerType, String[,] board, int row, int col)
        {
            bool validRightCapture = false;
            int rowChangeC = row + 1;  // Row updation for Computer
            int colChangeC = col - 1;  // Column updation for Computer
            int rowChangeH = row - 1;  // Row updation for Human
            int colChangeH = col + 1;  // Column updation for Human

            if (!(IsValidRightMove(playerType, board, row, col)))
            {
                // Check if capture is valid for Computer

                if (playerType.Equals("Computer"))
                {
                    if (col == 0 || col == 1 || row == 4 || row == 5)
                    {
                        validRightCapture = false; // Cannot capture as there is no Right spot after capture
                    }

                    else if (board[rowChangeC, colChangeC][0] == 'B')
                    {

                        validRightCapture = false; // Cannot capture as there is Computer piece (B) in the Right spot

                    }
                    else if (board[rowChangeC + 1, colChangeC - 1].Equals(Piece.SPACE))
                    {
                        validRightCapture = true;
                    }
                }

                // Check if capture is valid for Human

                if (playerType.Equals("Human"))
                {
                   
                    if (col == 4 || col == 5 || row == 0 || row == 1)
                    {
                        validRightCapture = false; // Cannot capture as there is no left spot after capture
                    }

                    else if (board[rowChangeH, colChangeH][0] == 'R')
                    {
                        validRightCapture = false; // Cannot capture as there is Human piece (R) in the left spot

                    }

                    else if (board[rowChangeH - 1, colChangeH + 1].Equals(Piece.SPACE))
                    {
                        validRightCapture = true;
                    }
                }
            }

            return validRightCapture;
        }

		/* Method to make Left Move */

		public static String[,] MoveLeft(String playerType, String[,] board, int row, int col)
        {

            int rowChangeC = row + 1;  // Row updation for Computer
            int colChangeC = col + 1;  // Column updation for Computer
            int rowChangeH = row - 1;  // Row updation for Human
            int colChangeH = col - 1;  // Column updation for Human

            if (playerType.Equals("Computer"))
            {
                board[rowChangeC, colChangeC] = board[row, col];
                board[row, col] = Piece.SPACE;
            }
            if (playerType.Equals("Human"))
            {
                board[rowChangeH, colChangeH] = board[row, col];
                board[row, col] = Piece.SPACE;
            }


            return board;
        }

		/* Method to make Right Move */

		public static String[,] MoveRight(String playerType, String[,] board, int row, int col)
        {
            int rowChangeC = row + 1;  // Row updation for Computer
            int colChangeC = col - 1;  // Column updation for Computer
            int rowChangeH = row - 1;  // Row updation for Human
            int colChangeH = col + 1;  // Column updation for Human

            if (playerType.Equals("Computer"))
            {
                board[rowChangeC, colChangeC] = board[row, col];
                board[row, col] = Piece.SPACE;
            }
            if (playerType.Equals("Human"))
            {
                board[rowChangeH, colChangeH] = board[row, col];
                board[row, col] = Piece.SPACE;
            }


            return board;
        }

		/* Method to make Left Capture */

		public static String[,] CaptureLeft(String playerType, String[,] board, int row, int col)
        {
            int rowChangeC = row + 1;  // Row updation for Computer
            int colChangeC = col + 1;  // Column updation for Computer
            int rowChangeH = row - 1;  // Row updation for Human
            int colChangeH = col - 1;  // Column updation for Human

            if (playerType.Equals("Computer"))
            {
                board[rowChangeC + 1, colChangeC + 1] = board[row, col];
                board[rowChangeC, colChangeC] = Piece.SPACE;
                board[row, col] = Piece.SPACE;
            }
            if (playerType.Equals("Human"))
            {
                board[rowChangeH - 1, colChangeH - 1] = board[row, col];
                board[rowChangeH, colChangeH] = Piece.SPACE;
                board[row, col] = Piece.SPACE;
            }


            return board;
        }

		/* Method to make Right Capture */

		public static String[,] CaptureRight(String playerType, String[,] board, int row, int col)
        {
            int rowChangeC = row + 1;  // Row updation for Computer
            int colChangeC = col - 1;  // Column updation for Computer
            int rowChangeH = row - 1;  // Row updation for Human
            int colChangeH = col + 1;  // Column updation for Human

            if (playerType.Equals("Computer"))
            {
                board[rowChangeC + 1, colChangeC - 1] = board[row, col];
                board[rowChangeC, colChangeC] = Piece.SPACE;
                board[row, col] = Piece.SPACE;
            }
            if (playerType.Equals("Human"))
            {
                board[rowChangeH - 1, colChangeH + 1] = board[row, col];
                board[rowChangeH, colChangeH] = Piece.SPACE;
                board[row, col] = Piece.SPACE;
            }


            return board;
        }


        /* Method to check if any valid move is available */

        public static bool IsValidMoveAvail(String playerType, String[,] board, int row, int col)
        {
            if (IsValidLeftMove(playerType, board, row, col))
            {
                return true;
            }
            if (IsValidRightMove(playerType, board, row, col))
            {
                return true;
            }
            if (IsValidLeftCapture(playerType, board, row, col))
            {
                return true;
            }
            if (IsValidRightCapture(playerType, board, row, col))
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        /* Method to check if Move requested by Human Player is valid */

        public static bool IsValidMove(String command, String[,] board, String playerType, int row, int col)
        {
            if (command.Equals("moveLeft"))
            {
                return IsValidLeftMove(playerType, board, row, col);
            }

            if (command.Equals("moveRight"))
            {
                return IsValidRightMove(playerType, board, row, col);
            }
			if (command.Equals("captureLeft"))
			{
				return IsValidLeftCapture(playerType, board, row, col);
			}

			if (command.Equals("captureRight"))
			{
				return IsValidRightCapture(playerType, board, row, col);
			}
            else
            {
                return false;
            }
        }

        /* Method to move piece of Human Player*/
         
        public static String[,] MoveHumanPiece(String command, String[,] board, String playerType, int row, int col)
        {
            if (command.Equals("moveLeft"))
            {
                return MoveLeft(playerType, board, row, col);
            }

            if (command.Equals("moveRight"))
            {
                return MoveRight(playerType, board, row, col);
            }
			if (command.Equals("captureLeft"))
			{
				return CaptureLeft(playerType, board, row, col);
			}

			else
			{
				return CaptureRight(playerType, board, row, col);
			}


        }

	}
}
