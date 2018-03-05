using System.Collections;
using System.Collections.Generic;
using Chess;

namespace Chess
{
    public class King : ChessPiece
    {
        /*
        int currentX;
        int currentY;
        int currentZ;

        string color;
        bool taken = false;
        */

        public King(int startingX, int startingZ, int team) :
            base(startingX, startingZ, team)
        {
        }

        public override bool[,] getPossibleMoves(ChessPiece[,] pieces)
        {
            bool[,] moves = new bool[8, 8];

            for (int x = 0; x < 8; x++)
            {
                for (int z = 0; z < 0; z++)
                    moves[x, z] = false;
            }


            /* Checks to make sure the King is not on the border of the board
             * then checks the surrounding squares for empty spaces or oppos-
             * ing pieces
             */
            if (currentX != 0)
            {
                if (pieces[currentX - 1, currentZ].team != team)
                    moves[currentX - 1, currentZ] = true;
            }
            if (currentX != 0 && currentZ != 0)
            {
                if (pieces[currentX - 1, currentZ - 1].team != team)
                    moves[currentX - 1, currentZ - 1] = true;
            }
            if (currentX != 0 && currentZ != 7)
            {
                if (pieces[currentX - 1, currentZ + 1].team != team)
                    moves[currentX - 1, currentZ + 1] = true;
            }
            if (currentX != 7)
            {
                if (pieces[currentX + 1, currentZ].team != team)
                    moves[currentX + 1, currentZ] = true;
            }
            if (currentX != 7 && currentZ != 0)
            {
                if (pieces[currentX + 1, currentZ - 1].team != team)
                    moves[currentX + 1, currentZ - 1] = true;
            }
            if (currentX != 7 && currentZ != 7)
            {
                if (pieces[currentX + 1, currentZ + 1].team != team)
                    moves[currentX + 1, currentZ + 1] = true;
            }
            if (currentZ != 0)
            {
                if (pieces[currentX, currentZ - 1].team != team)
                    moves[currentX, currentZ - 1] = true;
            }
            if (currentZ != 7)
            {
                if (pieces[currentX, currentZ + 1].team != team)
                    moves[currentX, currentZ + 1] = true;
            }

            return moves;
        }
    }
}