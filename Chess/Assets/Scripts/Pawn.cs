using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : ChessPiece {

    public List<Coordinates> knownMoves;
    private bool firstMove;

    void Start() {
        base.Setup();
        firstMove = false;
    }

    // Update is called once per frame
    void Update () {
	    
	}

    public override List<Coordinates> GetMoves()
    {
        return new List<Coordinates>();
    }
}
