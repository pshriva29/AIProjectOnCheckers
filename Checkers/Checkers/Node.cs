/* Class to represent a Node (States). Contains method SelectBestMove() to to implement Minimax Algortihm and get best computer method. */

using System;
using System.Collections.Generic;

namespace Checkers
{
    public class Node
    {
        public String[,] checkerboard;

        public List<Node> children = new List<Node>();
        public Node parent;
        public Move makeMove;
        private double value = 0;
        //int x = 0;


        public Node()
        {
        }

        public Node(String[,] checkerboard)
        {
            this.checkerboard = checkerboard;
        }

        public String[,] getBoard()
        {
            return this.checkerboard;
        }

        public List<Node> getChildren()
        {
            return this.children;
        }


        public double GetValue()
        {
             return value;
        }
    
        public void SetValue(double value)
        {
             this.value = value;
        }
    

      
        public bool HaveChildren()
        {
            bool haveChild;

            if(this.getChildren().Count == 0){
                haveChild = false;
            }
            else{
                haveChild = true;
            }

            return haveChild;
        }


		/**
     * Returns the best move given the state of the game
     */
		public Node SelectBestMove()
		{
            double highestScore = Int32.MinValue;
			Node bestMove = null;
            double score = 0;
			Checkerboard display = new Checkerboard();

            for (int i = 0; i < children.Count; i++)    // Iterate through child nodes
            {
                Node currentChild = (Node)children[i];
				score = Min(currentChild);
				if (score > highestScore)
				{
					highestScore = score;
					bestMove = currentChild;
				}

            }
			return bestMove;
		}


		/* Returns the lowest score received by the min player */

		private double Min(Node childNode)
		{
            double score = 0;
            if (childNode.getChildren().Count == 0)   // No children so Terminal Node
                return childNode.GetValue();

            double minimumScore = Int32.MaxValue;

            for (int i = 0; i < childNode.getChildren().Count; i++)    // Iterate through child nodes
            {
                Node currentChild = childNode.getChildren()[i];
				score = Max(currentChild);
				if (score < minimumScore)
                {
                    minimumScore = score;
                }
					

            }
			return minimumScore;
		}


		/* Returns the highest score received by the max player */


		private double Max(Node childNode)
		{
			double score = 0;
			if (childNode.getChildren().Count == 0)   // No children so Terminal Node
				return childNode.GetValue();


			double maximumScore = Int32.MinValue;

			for (int i = 0; i < childNode.getChildren().Count; i++)    // Iterate through child nodes
			{
				Node currentChild = childNode.getChildren()[i];
				score = Min(currentChild);
				if (score > maximumScore)
				{
					maximumScore = score;
				}


			}
            return maximumScore;
		}



    }
}