/* Class to generate tree of all valid moves from a state */

using System;
namespace Checkers
    {
        public class GenerateMoves
        {

            public GenerateMoves()
            {
            }

        /* Method to generate legal moves from the state. */
    		public static void MovePiece(String playerType, String[,] board, Node node, int depth)
    		{

            String nextPlayer;
            int requiredDepth = 2;
            char pieceType;

            if(playerType.Equals("Computer"))
            {
                pieceType = 'B';
            }
            else
            {
                pieceType = 'R';
            }


            if (depth <= requiredDepth)
            {

                for (int row = 0; row < 6; row++)
                {
                    for (int col = 0; col < 6; col++)
                    {
                        Node leftMoveChild;
                        Node rightMoveChild;
                        Node leftCaptureChild;
                        Node rightCaptureChild;

                        if (!(board[row, col].Equals(Piece.SPACE)))  // if spot at row,j is not empty
                        {
                            if (board[row, col][0] == pieceType)   // if spot at row,j has Computer piece (B)
                            {
                                if (Move.IsValidLeftMove(playerType, board, row, col)) // Check Left Move. If valid then make Left Move and add children to Node
                                {
                                    String[,] boardCopyLeft = Copyboard(board);  // Copy the board
                                    boardCopyLeft = Move.MoveLeft(playerType, boardCopyLeft, row, col);

                                    leftMoveChild = new Node(boardCopyLeft);
                                    node.getChildren().Add(leftMoveChild);    // Add Left Move Child to the Node

                                    if( depth == requiredDepth) // Reached Terminal Node
                                    {
                                        leftMoveChild.SetValue(EvaluationFunction.GetEvaluationValue(leftMoveChild.getBoard(),playerType,"Move"));

                                    }
                                }

                                if (Move.IsValidRightMove(playerType, board, row, col)) // Check Right Move. If valid then make Right Move and add children to Node
                                {
                                    
                                    String[,] boardCopyRight = Copyboard(board);  // Copy the board
                                    boardCopyRight = Move.MoveRight(playerType, boardCopyRight, row, col);

                                    rightMoveChild = new Node(boardCopyRight);
                                    node.getChildren().Add(rightMoveChild);    // Add Right Move Child to the Node

									if (depth == requiredDepth) // Reached Terminal Node
									{
										rightMoveChild.SetValue(EvaluationFunction.GetEvaluationValue(rightMoveChild.getBoard(), playerType, "Move"));
										
									}
                                }

                                if (Move.IsValidLeftCapture(playerType, board, row, col)) // Check Left Capture. If valid then make Left Capture and add children to Node
                                {
                                    
                                    String[,] boardCopyLeftCapture = Copyboard(board);  // Copy the board
                                    boardCopyLeftCapture = Move.CaptureLeft(playerType, boardCopyLeftCapture, row, col);

                                    leftCaptureChild = new Node(boardCopyLeftCapture);
                                    node.getChildren().Add(leftCaptureChild);    // Add Right Capture Child to the Node

									if (depth == requiredDepth) // Reached Terminal Node
									{
										leftCaptureChild.SetValue(EvaluationFunction.GetEvaluationValue(leftCaptureChild.getBoard(), playerType, "capture"));
										
									}
                                }

                                if (Move.IsValidRightCapture(playerType, board, row, col)) // Check Right Capture. If valid then make Right Capture and add children to Node
                                {
                                    
                                    String[,] boardCopyRightCapture = Copyboard(board);  // Copy the board
                                    boardCopyRightCapture = Move.CaptureRight(playerType, boardCopyRightCapture, row, col);

                                    rightCaptureChild = new Node(boardCopyRightCapture);
                                    node.getChildren().Add(rightCaptureChild);    // Add Right Capture Child to the Node

									if (depth == requiredDepth) // Reached Terminal Node
									{
										rightCaptureChild.SetValue(EvaluationFunction.GetEvaluationValue(rightCaptureChild.getBoard(), playerType, "capture"));
										
									}
                                }

                            }
                        }

                    }
                }

                nextPlayer = (playerType.Equals("Computer")) ? "Human" : "Computer";  // Change the player type

                for (int i = 0; i < node.getChildren().Count; i++)    // Iterate through children to generate children for next depth
                {
                    
                    Node currentChild = node.children[i];
                    MovePiece(nextPlayer, currentChild.getBoard(), currentChild, depth + 1);
                }
            }

				
         }

        /* Method to copy the baord */
		public static String[,] Copyboard(String[,] board)
		{
			
            String[,] copyBoard = new String[Checkerboard.SIZEN, Checkerboard.SIZEN];

			for (int i = 0; i < 6; i++)
			{
				for (int j = 0; j < 6; j++)
				{
					copyBoard[i, j] = board[i, j];
					
				}


			}
            return copyBoard;
          }

     }
 }
