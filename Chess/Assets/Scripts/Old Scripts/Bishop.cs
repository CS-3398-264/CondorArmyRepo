using System.Collections;
using System.Collections.Generic;
using Chess;

namespace Chess
{
    public class Bishop : ChessPiece
    {
        /*
        int currentX;
        int currentY;
        int currentZ;

        string color;
        bool taken = false;
        */

        public Bishop(int startingX, int startingZ, int team) :
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

            int i = currentX + 1;
            int j = currentZ + 1;
            bool blocked = false;

            while (i <= 7 && j <= 7 && blocked == false)
            {
                if (pieces[i, j].team == 0)
                    moves[i, j] = true;
                else if (pieces[i, j].team == team)
                    blocked = true;
                else
                {
                    moves[i, j] = true;
                    blocked = true;
                }

                i += 1;
                j += 1;
            }

            i = currentX - 1;
            j = currentZ + 1;
            blocked = false;

            while (i >= 0 && j <= 7 && blocked == false)
            {
                if (pieces[i, j].team == 0)
                    moves[i, j] = true;
                else if (pieces[i, j].team == team)
                    blocked = true;
                else
                {
                    moves[i, j] = true;
                    blocked = true;
                }

                i -= 1;
                j += 1;
            }

            i = currentX - 1;
            j = currentZ - 1;
            blocked = false;

            while (i >= 0 && j >= 0 && blocked == false)
            {
                if (pieces[i, j].team == 0)
                    moves[i, j] = true;
                else if (pieces[i, j].team == team)
                    blocked = true;
                else
                {
                    moves[i, j] = true;
                    blocked = true;
                }

                i -= 1;
                j -= 1;
            }

            i = currentX + 1;
            j = currentZ - 1;
            blocked = false;

            while (i <= 7 && j >= 0 && blocked == false)
            {
                if (pieces[i, j].team == 0)
                    moves[i, j] = true;
                else if (pieces[i, j].team == team)
                    blocked = true;
                else
                {
                    moves[i, j] = true;
                    blocked = true;
                }

                i += 1;
                j -= 1;
            }


            return moves;
        }
    }
}