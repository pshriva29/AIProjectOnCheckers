/* Main class. Always executed first to start a new Game*/

using System;

namespace Checkers
{
    class MainClass
    {
        public static void Main(string[] args)
        {
             // Start the Game
			 GameStart();

        }


        /* Method to start the game */

        public static void GameStart()
        {
            Checkerboard board = new Checkerboard();
            Piece intialPiece = new Piece();           // Initialize the board
            String[,] currentState = intialPiece.getBoard();
            board.BoardDisplay(currentState);         // Display the board

            while (true)
            {
                currentState = PlayGame.GetUserInput(currentState);    // Get User input
                if (Piece.IsGoalState(currentState,"Human"))           // If game is over then call GameEnd method to end the game
                {
                    PlayGame.GameEnd(currentState);
                    break;
                }
                Console.WriteLine("*********** New Board after Your move ***********");
                board.BoardDisplay(currentState);
                currentState = PlayGame.ComputerMove(currentState);   // Get the best move of computer and update the board
                Console.WriteLine("*********** New Board after Computer move ***********");
                board.BoardDisplay(currentState);
                if (Piece.IsGoalState(currentState,"Computer"))      // If game is over then call GameEnd method to end the game
				{
                    PlayGame.GameEnd(currentState);
                    break;
                }
             }
         }
    }
}