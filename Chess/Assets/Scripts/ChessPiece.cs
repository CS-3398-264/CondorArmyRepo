using System.Collections;
using System.Collections.Generic;
using Chess;

namespace Chess
{
    public class ChessPiece
    {
        public int currentX;
        public int currentY;
        public int currentZ;

        public int team;
        public bool taken = false;

        public ChessPiece(int startingX, int startingZ, int team)
        {
            currentX = startingX;
            currentY = 0;
            currentZ = startingZ;
            this.team = team;
        }

        public int[] getCurrentPosition()
        {
            int[] currentPos = new int[3];
            currentPos[0] = currentX;
            currentPos[1] = currentY;
            currentPos[2] = currentZ;

            return currentPos;
        }

        public void move(bool[,] moves)
        {

        }

        public virtual bool[,] getPossibleMoves(ChessPiece[,] pieces)
        {
            return null;
        }
    }
}