using System.Collections;
using System.Collections.Generic;
using Chess;

namespace Chess
{
    public class Pawn : ChessPiece
    {
        /*
        int currentX;
        int currentY;
        int currentZ;

        string color;
        bool taken = false;
        */ 
        bool hasMoved = false;

        public Pawn(int startingX, int startingZ, int team) :
            base(startingX, startingZ, team){}

        public override bool[,] getPossibleMoves(ChessPiece[,] pieces)
        {
            bool[,] moves = new bool[8, 8];

            for (int x = 0; x < 8; x++)
            {
                for (int z = 0; z < 0; z++)
                    moves[x, z] = false;
            }


            if (team == 1)
            {
                if (currentX < 7 && currentZ < 7)
                {
                    if (pieces[currentX + 1, currentZ + 1].team == 2)
                        moves[currentX + 1, currentZ + 1] = true;
                }
                if (currentX > 0 && currentZ < 7)
                {
                    if (pieces[currentX - 1, currentZ + 1].team == 2)
                        moves[currentX - 1, currentZ + 1] = true;
                }
                if (currentZ < 7 && pieces[currentX, currentZ + 1].team == 0)
                {
                    moves[currentX, currentZ + 1] = true;
                    if (!hasMoved)
                    {
                        if (pieces[currentX, currentZ + 2].team != team)
                            moves[currentX, currentZ + 2] = true;
                    }
                }
            }
            else
            {
                if (currentX < 7 && currentZ > 0)
                {
                    if (pieces[currentX + 1, currentZ - 1].team == 1)
                        moves[currentX + 1, currentZ - 1] = true;
                }
                if (currentX > 0 && currentZ < 7)
                {
                    if (pieces[currentX - 1, currentZ - 1].team == 1)
                        moves[currentX - 1, currentZ - 1] = true;
                }

                if (currentZ > 0 && pieces[currentX, currentZ - 1].team == 0)
                {
                    moves[currentX, currentZ - 1] = true;
                    if (!hasMoved)
                    {
                        if (pieces[currentX, currentZ - 2].team != team)
                            moves[currentX, currentZ - 2] = true;
                    }
                }
            }

            return moves;
        }
    }
}