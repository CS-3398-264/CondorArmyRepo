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

        foreach (Coordinates move in knownMoves) {
            Coordinates coord = move;

            if (gameObject.tag == "Team2")
            {
                coord = coord.flip();
            }
            coord = coord + currentPos;
            if (coord.x <= 7 && coord.x >= 0 && coord.z <= 7 && coord.z >= 0)
            {
                finalMoves.Add(coord);
            }
        }

        return finalMoves;
    }
}
