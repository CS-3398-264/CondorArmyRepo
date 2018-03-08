using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    
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
	}
	
	// Update is called once per frame
	void Update () {
        ArrayVisualizer.VisualizeArray2D(pieceLocations);
        if (mm.selectedObject != null)
        {
            if (currentObject != null)
            {
                if (currentObject.tag == "Team1")
                {
                    if (mm.selectedObject.tag == "Tile")
                    {
                        if (mm.selectedObject.GetComponent<Tile>().isHighlighted)
                        {
                            if (pieceLocations[mm.selectedObject.GetComponent<Tile>().tilePosition.x, mm.selectedObject.GetComponent<Tile>().tilePosition.z] != null)
                            {
                                DeactivateChildren(pieceLocations[mm.selectedObject.GetComponent<Tile>().tilePosition.x, mm.selectedObject.GetComponent<Tile>().tilePosition.z].gameObject, false);
                            }
                            currentObject.GetComponent<ChessPiece>().move(mm.selectedObject.GetComponent<Tile>().tilePosition);
                            bm.ResetBoard();
                        }
                    }
                    if (mm.selectedObject.tag == "Team2" && bm.transform.GetChild((mm.selectedObject.GetComponent<ChessPiece>().currentPos.z * 8) + mm.selectedObject.GetComponent<ChessPiece>().currentPos.x).GetComponent<Tile>().isHighlighted == true)
                    {
                        Coordinates tempPos = mm.selectedObject.GetComponent<ChessPiece>().currentPos;
                        DeactivateChildren(pieceLocations[mm.selectedObject.GetComponent<ChessPiece>().currentPos.x, mm.selectedObject.GetComponent<ChessPiece>().currentPos.z].gameObject, false);
                        currentObject.GetComponent<ChessPiece>().move(tempPos);
                        bm.ResetBoard();
                    }
                }
            }
            if (currentObject != mm.selectedObject)
            {
                bm.ResetBoard();
                if (mm.selectedObject.tag == "Team1")
                {
                    Debug.Log("Here");
                    List<Coordinates> moves = mm.selectedObject.GetComponent<ChessPiece>().GetMoves();
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

    public void AddPieceAt(ChessPiece piece, Coordinates pos) {
        pieceLocations[pos.x, pos.z] = piece;
    }

    public void RemovePieceAt(Coordinates pos) {
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

    public void DeactivateChildren(GameObject g, bool a)
    {
        g.SetActive(a);

        foreach (Transform child in g.transform)
        {
            DeactivateChildren(child.gameObject, a);
        }
    }

    public void QuitGame() {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
