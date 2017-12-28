using System;
namespace Checkers
{
    public class Testing
    {
        public static String[,] testBoard;
        private String[,] state;
		private String[,] newState;

       
        public Testing()
        {
            testBoard = new String[Checkerboard.SIZEN, Checkerboard.SIZEN];

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

            testBoard[0, 0] = Piece.SPACE;
            testBoard[0, 1] = Piece.SPACE;
            testBoard[0, 2] = Piece.SPACE;
            testBoard[0, 3] = Piece.SPACE;
            testBoard[0, 4] = Piece.SPACE;
            testBoard[0, 5] = "R3";

            testBoard[1, 0] = Piece.SPACE;
            testBoard[1, 1] = Piece.SPACE;
            testBoard[1, 2] = Piece.SPACE;
            testBoard[1, 3] = Piece.SPACE;
            testBoard[1, 4] = Piece.SPACE;
            testBoard[1, 5] = Piece.SPACE;

            testBoard[2, 0] = Piece.SPACE;
            testBoard[2, 1] = Piece.SPACE;
            testBoard[2, 2] = Piece.SPACE;
            testBoard[2, 3] = Piece.SPACE;
            testBoard[2, 4] = Piece.SPACE;
            testBoard[2, 5] = Piece.SPACE;

            testBoard[3, 0] = Piece.SPACE;
            testBoard[3, 1] = Piece.SPACE;
            testBoard[3, 2] = "B2";
            testBoard[3, 3] = Piece.SPACE;
            testBoard[3, 4] = "B6";
            testBoard[3, 5] = Piece.SPACE;


            testBoard[4, 0] = Piece.SPACE;
            testBoard[4, 1] = "B1";
            testBoard[4, 2] = Piece.SPACE;
            testBoard[4, 3] = "B4";
            testBoard[4, 4] = Piece.SPACE;
            testBoard[4, 5] = "B6";

			testBoard[5, 0] = Piece.SPACE;
			testBoard[5, 1] = Piece.SPACE;
			testBoard[5, 2] = "B1";
			testBoard[5, 3] = Piece.SPACE;
			testBoard[5, 4] = Piece.SPACE;
			testBoard[5, 5] = Piece.SPACE;

            return testBoard;
        }




    }
}
