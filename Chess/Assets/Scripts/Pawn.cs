using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : ChessPiece {

    public List<Coordinates> knownMoves;
    public bool firstMove;

    void Start() {
        base.Setup();
        firstMove = true;
    }

    // Update is called once per frame
    void Update () {
	    
	}

    public override List<Coordinates> GetMoves()
    {
        List<Coordinates> finalMoves = new List<Coordinates>();

        if(firstMove) {
            finalMoves.Add(new Coordinates(0,2));
        }

        return finalMoves;
    }
}
