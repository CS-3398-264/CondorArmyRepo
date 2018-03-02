using System.Collections;
using System.Collections.Generic;
using Chess;

namespace Chess
{
    public class Knight : ChessPiece
    {
        /*
        int currentX;
        int currentY;
        int currentZ;

        string color;
        bool taken = false;
        */

        public Knight(int startingX, int startingZ, int team) :
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

            if (currentX > 1)
            {
                if (currentZ > 0)
                {
                    if (pieces[currentX - 2, currentZ - 1].team != team)
                        moves[currentX - 2, currentZ - 1] = true;
                }
                if (currentZ < 7)
                {
                    if (pieces[currentX - 2, currentZ + 1].team != team)
                        moves[currentX - 2, currentZ + 1] = true;
                }
            }
            if (currentX < 6)
            {
                if (currentZ > 0)
                {
                    if (pieces[currentX + 2, currentZ - 1].team != team)
                        moves[currentX + 2, currentZ - 1] = true;
                }
                if (currentZ < 7)
                {
                    if (pieces[currentX + 2, currentZ + 1].team != team)
                        moves[currentX + 2, currentZ + 1] = true;
                }
            }

            if (currentZ < 6)
            {
                if (currentX < 7)
                {
                    if (pieces[currentX + 1, currentZ + 2].team != team)
                        moves[currentX + 1, currentZ + 2] = true;
                }
                if (currentX > 0)
                {
                    if (pieces[currentX - 1, currentZ + 2].team != team)
                        moves[currentX - 1, currentZ + 2] = true;
                }
            }

            if (currentZ > 1)
            {
                if (currentX < 7)
                {
                    if (pieces[currentX + 1, currentZ - 2].team != team)
                        moves[currentX + 1, currentZ - 2] = true;
                }
                if (currentX > 0)
                {
                    if (pieces[currentX - 1, currentZ - 2].team != team)
                        moves[currentX - 1, currentZ - 2] = true;
                }
            }

            return moves;
        }
    }
}