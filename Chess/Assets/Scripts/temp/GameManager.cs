using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chess;
using System.Reflection;


namespace Chess
{
    public class GameManager : MonoBehaviour
    {
        public bool checkmate = false;
        public bool stalemate = false;

        public int whiteTeam = 1;
        public int blackTeam = 2;
        public int empty = 0;

        public ChessPiece[,] pieces;

        public Pawn whitePawn1;
        public Pawn whitePawn2;
        public Pawn whitePawn3;
        public Pawn whitePawn4;
        public Pawn whitePawn5;
        public Pawn whitePawn6;
        public Pawn whitePawn7;
        public Pawn whitePawn8;

        public Pawn blackPawn1;
        public Pawn blackPawn2;
        public Pawn blackPawn3;
        public Pawn blackPawn4;
        public Pawn blackPawn5;
        public Pawn blackPawn6;
        public Pawn blackPawn7;
        public Pawn blackPawn8;

        public King whiteKing;
        public King blackKing;

        public Queen whiteQueen;
        public Queen blackQueen;

        public Rook whiteRook1;
        public Rook whiteRook2;
        public Rook blackRook1;
        public Rook blackRook2;

        public Bishop whiteBishop1;
        public Bishop whiteBishop2;
        public Bishop blackBishop1;
        public Bishop blackBishop2;

        public Knight whiteKnight1;
        public Knight whiteKnight2;
        public Knight blackKnight1;
        public Knight blackKnight2;

        public ChessPiece emptyPiece;

        public GameManager()
        {
            // Initializing all the pieces
            /*
            whitePawn1 = new Pawn(0, 1, whiteTeam);
            whitePawn2 = new Pawn(1, 1, whiteTeam);
            whitePawn3 = new Pawn(2, 1, whiteTeam);
            whitePawn4 = new Pawn(3, 1, whiteTeam);
            whitePawn5 = new Pawn(4, 1, whiteTeam);
            whitePawn6 = new Pawn(5, 1, whiteTeam);
            whitePawn7 = new Pawn(6, 1, whiteTeam);
            whitePawn8 = new Pawn(7, 1, whiteTeam);

            blackPawn1 = new Pawn(0, 6, blackTeam);
            blackPawn2 = new Pawn(1, 6, blackTeam);
            blackPawn3 = new Pawn(2, 6, blackTeam);
            blackPawn4 = new Pawn(3, 6, blackTeam);
            blackPawn5 = new Pawn(4, 6, blackTeam);
            blackPawn6 = new Pawn(5, 6, blackTeam);
            blackPawn7 = new Pawn(6, 6, blackTeam);
            blackPawn8 = new Pawn(7, 6, blackTeam);

            whiteKing = new King(3, 0, whiteTeam);
            blackKing = new King(3, 7, blackTeam);

            whiteQueen = new Queen(4, 0, whiteTeam);
            blackQueen = new Queen(4, 7, blackTeam);

            whiteRook1 = new Rook(0, 0, whiteTeam);
            whiteRook2 = new Rook(7, 0, whiteTeam);
            blackRook1 = new Rook(0, 7, blackTeam);
            blackRook2 = new Rook(7, 7, blackTeam);

            whiteBishop1 = new Bishop(2, 0, whiteTeam);
            whiteBishop2 = new Bishop(5, 0, whiteTeam);
            blackBishop1 = new Bishop(2, 7, blackTeam);
            blackBishop2 = new Bishop(5, 7, blackTeam);

            whiteKnight1 = new Knight(1, 0, whiteTeam);
            whiteKnight2 = new Knight(6, 0, whiteTeam);
            blackKnight1 = new Knight(1, 7, blackTeam);
            blackKnight2 = new Knight(6, 7, blackTeam);
            */

            emptyPiece = new ChessPiece(-1, -1, empty);

            //Initial starting positions
            pieces = new ChessPiece[,]
            {
                {whiteRook1    ,whitePawn1, emptyPiece, emptyPiece, emptyPiece, emptyPiece, blackPawn1, blackRook1  },
                {whiteKnight1  ,whitePawn2, emptyPiece, emptyPiece, emptyPiece, emptyPiece, blackPawn2, blackKnight1},
                {whiteBishop1  ,whitePawn3, emptyPiece, emptyPiece, emptyPiece, emptyPiece, blackPawn3, blackBishop1},
                {whiteKing     ,whitePawn4, emptyPiece, emptyPiece, emptyPiece, emptyPiece, blackPawn4, blackKing   },
                {whiteQueen    ,whitePawn5, emptyPiece, emptyPiece, emptyPiece, emptyPiece, blackPawn5, blackQueen  },
                {whiteBishop2  ,whitePawn6, emptyPiece, emptyPiece, emptyPiece, emptyPiece, blackPawn6, blackBishop2},
                {whiteKnight2  ,whitePawn7, emptyPiece, emptyPiece, emptyPiece, emptyPiece, blackPawn7, blackKnight2},
                {whiteRook2    ,whitePawn8, emptyPiece, emptyPiece, emptyPiece, emptyPiece, blackPawn8, blackRook2  },
            };
        }

        public void playGame()
        {
            bool check = false;
            bool checkMate = false;
            ChessPiece selectedPiece;

            while(!checkMate)
            {
                /*
                while(piece.team != 1) 
                    selectedPiece = getUserPieceSelection();
                    
                bool[,] moves = piece.getPossibleMoves(pieces);
                int[] usersMove = new int[2];

                //get the users desired move, and check to see if it is valid
                while(!move[usersMove[0], usersMove[1]])
                    usersMove = getUsersMoveSelection();

                pieces[selelectedPiece.currentX, selelectedPiece.currentZ] = empytyPiece; 
                selectedPiece.currentX = usersMove[0];
                selectedPiece.currentZ = usersMove[1];
                pieces[selelectedPiece.currentX, selelectedPiece.currentZ] = selectedPiece;

                check = check(blackKing.team, pieces);
                if (check)
                    checkmate = checkMate(blackKing);


                if (!checkmate)
                {
------------------------implement random computer move for blackTeam------------------------------
                    pieces[selelectedPiece.currentX, selelectedPiece.currentZ] = empytyPiece; 
                    selectedPiece.currentX = usersMove[0];
                    selectedPiece.currentZ = usersMove[1];
                    pieces[selelectedPiece.currentX, selelectedPiece.currentZ] = selectedPiece;

                    check = check(whiteKing);
                    if (check)
                        checkmate = checkMate(whiteKing, pieces);
                }
                */


                // This line just to prevent infinite loop until
                // playGame() is fully implemented
                checkMate = true;
            }
        }

        public bool check(int team, ChessPiece[,] pieces)
        {
            bool check = false;
            int kingX = 0;
            int kingZ = 0;

            for (int x = 0; x < 8; x++)
            {
                for (int z = 0; z < 8; z++)
                {
                    if (pieces[x,z] is King)
                    {
                        kingX = x;
                        kingZ = z;
                    }
                }
            }

            bool[,] moves = new bool[8, 8];

            for (int z = 0; z < 8; z++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if (pieces[x, z].team != team && pieces[x, z].team != 0)
                    {
                        moves = pieces[x, z].getPossibleMoves(pieces);
                        if (moves[kingX, kingZ] == true)
                        {
                            check = true;
                            System.Console.WriteLine("(" + pieces[x, z].currentX + ", " + pieces[x, z].currentZ +
                                                     ") Team: " + pieces[x, z].team + " " + pieces[x, z]);
                        }
                    }
                }
            }

            return check;
        }

        public void checkMate(King king)
        {
            checkmate = true;
            ChessPiece[,] hypoMoves = pieces; //hold hypothetical moves
            bool[,] possMoves = new bool[8, 8];

            for (int x = 0; x < 8; x++)
            {
                for (int z = 0; z < 8; z++)
                {
                    if (pieces[x,z].team == king.team)
                    {
                        possMoves = pieces[x, z].getPossibleMoves(pieces);
                        for (int i = 0; i < 8; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                if (possMoves[i, j] == true)
                                {
                                    hypoMoves[x, z] = emptyPiece;
                                    hypoMoves[i, j] = pieces[x, z];
                                    if (!check(king.team, hypoMoves))
                                    {
                                        checkmate = false;
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public void printPieces()
        {
            System.Console.WriteLine("\n--------------------------------------" +
                                     "----------------------------------------" +
                                     "----------------------------------------" +
                                     "---------");
            for (int z = 7; z >= 0; z--)
            {
                for (int x = 0; x < 8; x++)
                {
                    if (pieces[x, z].team == 0)
                        System.Console.Write("              | ");
                    else
                        System.Console.Write("{0,13} | ", pieces[x, z]);
                }
                System.Console.WriteLine();
                for (int i = 0; i < 8; i++)
                {
                    System.Console.Write("              | ");
                }

                System.Console.Write("\n--------------------------------------" +
                                     "----------------------------------------" +
                                     "----------------------------------------" +
                                     "---------\n");
            }
            System.Console.WriteLine("\n");
        }


        public void printMoves(bool[,] moves)
        {
            //Print Possible Moves
            System.Console.WriteLine("\n--------------------------------------" +
                                    "----------------------------------------" +
                                    "----------------------------------------" +
                                    "---------");
            for (int z = 7; z >= 0; z--)
            {
                for (int x = 0; x < 8; x++)
                {
                    if (moves[x, z] == false)
                        System.Console.Write("              | ");
                    else
                        System.Console.Write("{0,13} | ", moves[x, z]);
                }
                System.Console.WriteLine();
                for (int i = 0; i < 8; i++)
                {
                    System.Console.Write("              | ");
                }

                System.Console.Write("\n--------------------------------------" +
                                     "----------------------------------------" +
                                     "----------------------------------------" +
                                     "---------\n");
            }
        }

    }
}