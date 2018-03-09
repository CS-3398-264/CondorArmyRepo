using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static int turn;
    public static bool isCheckmate;
    public GameObject gameOver;
    public Text winText;
    public Text loseText;

    // =================
    // Team one pieces
    // =================
    public ChessPiece team1_pawn1;
    public ChessPiece team1_pawn2;
    public ChessPiece team1_pawn3;
    public ChessPiece team1_pawn4;
    public ChessPiece team1_pawn5;
    public ChessPiece team1_pawn6;
    public ChessPiece team1_pawn7;
    public ChessPiece team1_pawn8;

    public ChessPiece team1_rook1;
    public ChessPiece team1_rook2;

    public ChessPiece team1_knight1;
    public ChessPiece team1_knight2;

    public ChessPiece team1_bishop1;
    public ChessPiece team1_bishop2;

    public ChessPiece team1_queen;
    public ChessPiece team1_king;

    // =================
    // Team two pieces
    // =================
    public ChessPiece team2_pawn1;
    public ChessPiece team2_pawn2;
    public ChessPiece team2_pawn3;
    public ChessPiece team2_pawn4;
    public ChessPiece team2_pawn5;
    public ChessPiece team2_pawn6;
    public ChessPiece team2_pawn7;
    public ChessPiece team2_pawn8;

    public ChessPiece team2_rook1;
    public ChessPiece team2_rook2;

    public ChessPiece team2_knight1;
    public ChessPiece team2_knight2;

    public ChessPiece team2_bishop1;
    public ChessPiece team2_bishop2;

    public ChessPiece team2_queen;
    public ChessPiece team2_king;

    public static ChessPiece[,] pieceLocations;

    public BoardManager bm;
    private MouseManager mm;
    private GameObject currentObject;

	// Use this for initialization
	void Start () {
        // This is actually disgusting and the Unity inspector doesn't support polymorphic arrays

        pieceLocations = new ChessPiece[8, 8];

        updatePieceLocations();

        mm = FindObjectOfType<MouseManager>();
        bm = FindObjectOfType<BoardManager>();

        turn = 0;
	}
	
    public static void ChangeTurns() {
        if (turn == 0)
        {
            turn = 1;
        }
        else
        {
            turn = 0;
        }
    }

	// Update is called once per frame
	void Update () {
        if (isCheckmate)
            return;
        if (turn == 0)
        {
            if (mm.selectedObject != null)
            {
                if (currentObject != null)
                {
                    if (currentObject.tag == "Team1")
                    {
                        if (mm.selectedObject.tag == "Tile" && mm.selectedObject.GetComponent<Tile>().isHighlighted)
                        {
                            currentObject.GetComponent<ChessPiece>().move(mm.selectedObject.GetComponent<Tile>().tilePosition);
                            bm.ResetBoard();
                        }
                        if (mm.selectedObject.tag == "Team2" && bm.transform.GetChild((mm.selectedObject.GetComponent<ChessPiece>().currentPos.z * 8) + mm.selectedObject.GetComponent<ChessPiece>().currentPos.x).GetComponent<Tile>().isHighlighted == true)
                        {
                            currentObject.GetComponent<ChessPiece>().move(mm.selectedObject.GetComponent<ChessPiece>().currentPos);
                            bm.ResetBoard();
                        }
                    }
                }
                if (currentObject != mm.selectedObject)
                {
                    bm.ResetBoard();
                    if (mm.selectedObject.tag == "Team1")
                    {
                        List<Coordinates> moves = mm.selectedObject.GetComponent<ChessPiece>().GetMoves(true);
                        bm.HighlightTiles(moves);
                    }
                }
                else
                {
                    //nothing so far
                }
                currentObject = mm.selectedObject;
            }
        }
    }

    public static void AddPieceAt(ChessPiece piece, Coordinates pos) {
        pieceLocations[pos.x, pos.z] = piece;
    }

    public static void RemovePieceAt(Coordinates pos) {
        pieceLocations[pos.x, pos.z] = null;
    }

    public  void updatePieceLocations() {
        // ***************************************
        // Team 1 array setup
        // ***************************************
        pieceLocations[team1_pawn1.currentPos.x, team1_pawn1.currentPos.z] = team1_pawn1;
        pieceLocations[team1_pawn2.currentPos.x, team1_pawn2.currentPos.z] = team1_pawn2;
        pieceLocations[team1_pawn3.currentPos.x, team1_pawn3.currentPos.z] = team1_pawn3;
        pieceLocations[team1_pawn4.currentPos.x, team1_pawn4.currentPos.z] = team1_pawn4;
        pieceLocations[team1_pawn5.currentPos.x, team1_pawn5.currentPos.z] = team1_pawn5;
        pieceLocations[team1_pawn6.currentPos.x, team1_pawn6.currentPos.z] = team1_pawn6;
        pieceLocations[team1_pawn7.currentPos.x, team1_pawn7.currentPos.z] = team1_pawn7;
        pieceLocations[team1_pawn8.currentPos.x, team1_pawn8.currentPos.z] = team1_pawn8;

        pieceLocations[team1_rook1.currentPos.x, team1_rook1.currentPos.z] = team1_rook1;
        pieceLocations[team1_rook2.currentPos.x, team1_rook2.currentPos.z] = team1_rook2;

        pieceLocations[team1_knight1.currentPos.x, team1_knight1.currentPos.z] = team1_knight1;
        pieceLocations[team1_knight2.currentPos.x, team1_knight2.currentPos.z] = team1_knight2;

        pieceLocations[team1_bishop1.currentPos.x, team1_bishop1.currentPos.z] = team1_bishop1;
        pieceLocations[team1_bishop2.currentPos.x, team1_bishop2.currentPos.z] = team1_bishop2;

        pieceLocations[team1_queen.currentPos.x, team1_queen.currentPos.z] = team1_queen;
        pieceLocations[team1_king.currentPos.x, team1_king.currentPos.z] = team1_king;
        // ***************************************

        // ***************************************
        // Team 2 array setup
        // ***************************************
        pieceLocations[team2_pawn1.currentPos.x, team2_pawn1.currentPos.z] = team2_pawn1;
        pieceLocations[team2_pawn2.currentPos.x, team2_pawn2.currentPos.z] = team2_pawn2;
        pieceLocations[team2_pawn3.currentPos.x, team2_pawn3.currentPos.z] = team2_pawn3;
        pieceLocations[team2_pawn4.currentPos.x, team2_pawn4.currentPos.z] = team2_pawn4;
        pieceLocations[team2_pawn5.currentPos.x, team2_pawn5.currentPos.z] = team2_pawn5;
        pieceLocations[team2_pawn6.currentPos.x, team2_pawn6.currentPos.z] = team2_pawn6;
        pieceLocations[team2_pawn7.currentPos.x, team2_pawn7.currentPos.z] = team2_pawn7;
        pieceLocations[team2_pawn8.currentPos.x, team2_pawn8.currentPos.z] = team2_pawn8;

        pieceLocations[team2_rook1.currentPos.x, team2_rook1.currentPos.z] = team2_rook1;
        pieceLocations[team2_rook2.currentPos.x, team2_rook2.currentPos.z] = team2_rook2;

        pieceLocations[team2_knight1.currentPos.x, team2_knight1.currentPos.z] = team2_knight1;
        pieceLocations[team2_knight2.currentPos.x, team2_knight2.currentPos.z] = team2_knight2;

        pieceLocations[team2_bishop1.currentPos.x, team2_bishop1.currentPos.z] = team2_bishop1;
        pieceLocations[team2_bishop2.currentPos.x, team2_bishop2.currentPos.z] = team2_bishop2;

        pieceLocations[team2_queen.currentPos.x, team2_queen.currentPos.z] = team2_queen;
        pieceLocations[team2_king.currentPos.x, team2_king.currentPos.z] = team2_king;
        // ***************************************
    }

    public void win() {
        gameOver.SetActive(true);
        winText.gameObject.SetActive(true);
        loseText.gameObject.SetActive(false);
    }

    public void lose() {
        gameOver.SetActive(true);
        winText.gameObject.SetActive(false);
        loseText.gameObject.SetActive(true);
    }

    public void QuitGame() {
        Debug.Log("Quitting Game");
        Application.Quit();
    }

    public bool IsCheckmate(ChessPiece king)
    {
        List<ChessPiece> dangers = new List<ChessPiece>();
        List<Coordinates> allMoves = new List<Coordinates>();
        ChessPiece ownKing;
        Coordinates kingLoc;

        foreach (ChessPiece piece in pieceLocations)
        {
            if ((piece != null) && (piece.gameObject.tag == king.gameObject.tag))
            {
                allMoves.AddRange(piece.GetMoves(false));
            }
        }

        if (king.gameObject.tag == "Team1")
        {
            ownKing = team1_king;
        }
        else
        {
            ownKing = team2_king;
        }

        kingLoc = new Coordinates(ownKing.currentPos.x, ownKing.currentPos.z);
        dangers = ownKing.isCheck(ownKing.currentPos);

        if (dangers.Count != 0)
        {
            List<ChessPiece> tempDangers = new List<ChessPiece>(dangers);

            foreach (ChessPiece badPiece in tempDangers)
            {
                foreach (Coordinates move in allMoves)
                {
                    if(move == badPiece.currentPos)
                    {
                        dangers.Remove(badPiece);
                        continue;
                    }
                }

                if (badPiece is Rook || badPiece is Queen)
                {
                    if (kingLoc.x == badPiece.currentPos.x)
                    {
                        if (kingLoc.z > badPiece.currentPos.z)
                        {
                            for (int i = kingLoc.z - 1; i > badPiece.currentPos.z; i--)
                            {
                                foreach (Coordinates move in allMoves)
                                {
                                    if (move == badPiece.currentPos)
                                    {
                                        dangers.Remove(badPiece);
                                        continue;
                                    }
                                }
                            }
                        }
                        else
                        {
                            for (int i = kingLoc.z + 1; i < badPiece.currentPos.z; i++)
                            {
                                foreach (Coordinates move in allMoves)
                                {
                                    if (move == badPiece.currentPos)
                                    {
                                        dangers.Remove(badPiece);
                                        continue;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (kingLoc.x > badPiece.currentPos.x)
                        {
                            for (int i = kingLoc.x - 1; i > badPiece.currentPos.x; i--)
                            {
                                foreach (Coordinates move in allMoves)
                                {
                                    if (move == badPiece.currentPos)
                                    {
                                        dangers.Remove(badPiece);
                                        continue;
                                    }
                                }
                            }
                        }
                        else
                        {
                            for (int i = kingLoc.x + 1; i < badPiece.currentPos.x; i++)
                            {
                                foreach (Coordinates move in allMoves)
                                {
                                    if (move == badPiece.currentPos)
                                    {
                                        dangers.Remove(badPiece);
                                        continue;
                                    }
                                }
                            }
                        }
                    }
                }
                if (badPiece is Bishop || badPiece is Queen)
                {
                    if (kingLoc.x - badPiece.currentPos.x > 0)
                    {
                        if (kingLoc.z - badPiece.currentPos.z > 0)
                        {
                            int j = kingLoc.z - 1;
                            for (int i = kingLoc.x - 1; i < badPiece.currentPos.x; i++, j++)
                            {
                                foreach (Coordinates move in allMoves)
                                {
                                    if (move == badPiece.currentPos)
                                    {
                                        dangers.Remove(badPiece);
                                        continue;
                                    }
                                }
                            }
                        }
                        else
                        {
                            int j = kingLoc.z + 1;
                            for (int i = kingLoc.x - 1; i < badPiece.currentPos.x; i++, j--)
                            {
                                foreach (Coordinates move in allMoves)
                                {
                                    if (move == badPiece.currentPos)
                                    {
                                        dangers.Remove(badPiece);
                                        continue;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (kingLoc.z - badPiece.currentPos.z > 0)
                        {
                            int j = kingLoc.z - 1;
                            for (int i = kingLoc.x + 1; i > badPiece.currentPos.x; i--, j++)
                            {
                                foreach (Coordinates move in allMoves)
                                {
                                    if (move == badPiece.currentPos)
                                    {
                                        dangers.Remove(badPiece);
                                        continue;
                                    }
                                }
                            }
                        }
                        else
                        {
                            int j = kingLoc.z + 1;
                            for (int i = kingLoc.x + 1; i > badPiece.currentPos.x; i--, j--)
                            {
                                foreach (Coordinates move in allMoves)
                                {
                                    if (move == badPiece.currentPos)
                                    {
                                        dangers.Remove(badPiece);
                                        continue;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        bool saveFlag = false;
        if (dangers.Count != 0)
        {
            for (int x = -1; x <= 1; x++)
            {
                for (int z = -1; z <=1; z++)
                {
                    Coordinates tempCoord = new Coordinates(x,z);
                    if (ownKing.isCheck(kingLoc + tempCoord).Count == 0)
                    {
                        saveFlag = true;
                    }
                }
            }
        }

        return (dangers.Count != 0 && !saveFlag);
    }

    public static void DeactivateChildren(GameObject g, bool a)
    {
        if (g != null)
        {
            RemovePieceAt(g.GetComponent<ChessPiece>().currentPos);
            g.SetActive(a);
        }
    }
}
