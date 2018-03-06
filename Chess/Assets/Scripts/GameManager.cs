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

    public ChessPiece[,] pieceLocations;

    private MouseManager mm;

	// Use this for initialization
	void Start () {
        // This is actually disgusting and we should have used a Scriptable Object
        pieceLocations = new ChessPiece[8, 8] {
            { team1_rook1, team1_knight1, team1_bishop1, team1_queen, team1_king,  team1_bishop2, team1_knight2, team1_rook2 },
            { team1_pawn1, team1_pawn2,   team1_pawn3,   team1_pawn4, team1_pawn5, team1_pawn6,   team1_pawn7,   team1_pawn8 },
            { null,        null,          null,          null,        null,        null,          null,          null        },
            { null,        null,          null,          null,        null,        null,          null,          null        },
            { null,        null,          null,          null,        null,        null,          null,          null        },
            { null,        null,          null,          null,        null,        null,          null,          null        },
            { team2_pawn8, team2_pawn7,   team2_pawn6,   team2_pawn5, team2_pawn4, team2_pawn3,   team2_pawn2,   team2_pawn1 },
            { team2_rook2, team2_knight2, team2_bishop2, team2_queen, team2_king,  team2_bishop1, team2_knight1, team2_rook2 }
        };

        mm = FindObjectOfType<MouseManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0))
        {
            //mm.selectedObject;
        }
	}
}
