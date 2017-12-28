/* Class for Calculating Evaluation Function */
using System;
namespace Checkers
{
    public class EvaluationFunction
    {
        
        public EvaluationFunction()
        {
        }

        /* Methid to calculate Evaluation function */

        public static double GetEvaluationValue(String[,] board,String playerType, String moveType)
        {
            double boardValue = 0;
            double pieceCount = 0;  // First variable that gives difference between number of pieces
			double captureScore = 0;  // Second variable to give capture score
            double positionScore = 0; // Third variable to give score based on position


			/* Difference between number of pieces */
			int[] numPieces = Piece.GetPieces(board);
            pieceCount = numPieces[0] - numPieces[1];  

            /* Calculate Score for Capture */
            if(moveType.Equals("capture"))
            {
                if(playerType.Equals("Computer"))
                {
                    captureScore = captureScore + 50;
                }
                else{
                    captureScore = captureScore - 50;
                }
            }


            /* Calculate board positions for the pieces */

            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 6; col++)
                {
                    if(row <=2)  // First half of the board
                    {
                        if((!(board[row,col].Equals(Piece.SPACE))) && (board[row,col][0] == 'R'))  // If Human reaches near opposite side
                        {
                            positionScore = positionScore - 10;
                        }
                    }
                    if(row>2)
                    {
						if ((!(board[row, col].Equals(Piece.SPACE))) && (board[row, col][0] == 'B'))  // If Computer reaches near opposite side
						{
							positionScore = positionScore + 10;
						}

					}
                }
            }
           boardValue = pieceCount + captureScore + positionScore;
           return boardValue;
        }
    }
}