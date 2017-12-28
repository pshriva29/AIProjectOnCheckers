/* Class to implement methods to play the game. Contains :
 * method GetUserInput() to get the user input validate it.
 * method ComputerMove() for Computer's move which in turn calls methods for states tree generation and Minimax Algorithm.
 * method GameEnd() to End the game if game is over and decide the winner based on the state of the baord.
*/
using System;
namespace Checkers
{
    public class PlayGame
    {
        public PlayGame()
        {
        }

		/* Method to get the user input validate it */
		public static String[,] GetUserInput(String[,] board)
		{
            
			Console.WriteLine("Please enter the command to move your piece. Command Format : R1 moveRight");
            Console.WriteLine("Available commands are : moveLeft, moveRight, captureLeft, captureRight");
			String userInput = Console.ReadLine();
			String[] inputWords = userInput.Split(' ');
            String piece = null;
            String command = null;

            if(inputWords.Length == 2)
            {
				piece = inputWords[0];
				command = inputWords[1];
            }

            String[,] newBoard;

			if (inputWords.Length != 2)
			{
				Console.WriteLine("Please enter correct format");
                GetUserInput(board);
			}

			else if (piece[0] == 'B')
			{
				Console.WriteLine("You can not move computer piece");
                GetUserInput(board);
			}
            else if(piece[0]!='R')
            {
                Console.WriteLine("Please enter the piece in correct format");
                GetUserInput(board);
            }

			else if (!(command.Equals("moveLeft") || command.Equals("moveRight") || command.Equals("captureLeft") || command.Equals("captureRight")))
			{
				Console.WriteLine("Please enter correct command");
                GetUserInput(board);
			}
			else
			{
                for (int row = 0; row < 6; row++)
                {
                    for (int col = 0; col < 6;col++)
                    {
                        if (!(board[row, col].Equals(Piece.SPACE)) && board[row,col].Equals(piece))
                        {
                            if(Move.IsValidMove(command,board,"Human",row,col))
                            {
                                newBoard = Move.MoveHumanPiece(command, board, "Human", row, col);
                                return newBoard;
                            }

                            else{
                                Console.WriteLine("Not a valid move.");
                                GetUserInput(board);
                            }

                        }
                    }
                }


			}

            return board;

		}

		/* Method for Computer's move which in turn calls methods for states tree generation and Minimax Algorithm */
		public static String[,] ComputerMove(String[,] currentBoard)
        {
            Console.WriteLine("******* Computer's Move *******");
            Node currentNode = new Node(currentBoard);

            GenerateMoves.MovePiece("Computer", currentBoard, currentNode, 0);  // Generate tree of valid moves (states)
			Node bestNode = currentNode.SelectBestMove();  // Select best move using MiniMax Algorithm
			String[,] bestBoard = bestNode.getBoard();
            return bestBoard;
		
        }


        /* Method to end the game if game is over and decide the winner based on board state*/
		public static void GameEnd(String[,] currentState)
		{
			
            int[] numPieces = Piece.GetPieces(currentState);  // Get Number of pieces

            double pointsHuman = 0;
            double pointsComputer = 0;



            if(numPieces[0]!=numPieces[1])         // If number of pieces of both players are not equal
            {
				if (numPieces[0] > numPieces[1])           // If Computer has more pieces 
				{
                    Console.WriteLine("You have less pieces left. Computer Win :(");
                    Environment.Exit(0);
				}

				else
				{
                    Console.WriteLine("Computer have less pieces left. You Win :)");
                    Environment.Exit(0);
				}

			}

            else{
                // Check which player has reached closer to other side

                for (int row = 0; row < 6;row++)
                {
                    for (int col = 0; col < 6; col++)
                    {
                        if(!(currentState[row, col].Equals(Piece.SPACE)) && currentState[row,col][0] == 'B')  // Computer's Piece
                        {
                            if(row==5)
                            {
                                pointsComputer = pointsComputer + 50;   // 50 points if piece is in last row
                            }
                            else if(row==4)
                            {
                                pointsComputer = pointsComputer + 30;
                            }
                            else if(row==3)
                            {
                                pointsComputer = pointsComputer + 10;
                            }
                            else{
                                pointsComputer = pointsComputer + 5;
                            }
                        }

						if (!(currentState[row, col].Equals(Piece.SPACE)) && currentState[row, col][0] == 'R')  // Human's Piece
						{
							if (row == 0)
							{
                                pointsHuman = pointsHuman + 50;   // 50 points if piece is in first row
							}
							else if (row == 1)
							{
								pointsHuman = pointsHuman + 30;
							}
							else if (row == 2)
							{
								pointsHuman = pointsHuman + 10;
							}
							else
							{
								pointsHuman = pointsHuman + 5;
							}

						}

                    }
                }
                /* Check who has more points*/
                Console.WriteLine("Human points are : " + pointsHuman);
                Console.WriteLine("Computer points are : " + pointsComputer);
                if(pointsComputer > pointsHuman)
                {
					Console.WriteLine("You have less points. Computer Win :(");
					Environment.Exit(0);
                }

                else if (pointsHuman > pointsComputer)
                {
                    Console.WriteLine("Computer have less points. You win :)");
					Environment.Exit(0);
                }

                else{
                    Console.WriteLine("It's a tie :)");
                    Environment.Exit(0);
                }


            }

         }
     }
}
