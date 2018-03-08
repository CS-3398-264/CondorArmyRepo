using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : ChessPiece {

    public List<Coordinates> knownMoves;

    void Awake() {
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
            Coordinates opt1 = new Coordinates(0, 1); //normal move
            Coordinates opt2 = new Coordinates(0, 2); //first move option

            if (gameObject.tag == "Team2")
            {
                coord = coord.flip();
            }
            coord = coord + currentPos;

            if (coord.x <= 7 && coord.x >= 0 && coord.z <= 7 && coord.z >= 0)
            {
                if (move == opt1)
                {
                    Debug.Log("her");
                    if (!isBlocked(coord, currentPos) && (GameManager.pieceLocations[coord.x, coord.z] == null/* && (isCheck(coord).Count == 0)*/))
                    {
                        finalMoves.Add(coord);
                    }
                }
                else if (move == opt2)
                {
                    if (firstMove)
                    {
                        if (!isBlocked(coord, currentPos) && (isCheck(coord).Count == 0))
                        {
                            finalMoves.Add(coord);
                        }
                    }
                }
                else
                {
                    if (GameManager.pieceLocations[coord.x, coord.z] != null && GameManager.pieceLocations[coord.x, coord.z].gameObject.tag != gameObject.tag)
                    {
                        if (!isBlocked(coord, currentPos) && (isCheck(coord).Count == 0))
                        {
                            finalMoves.Add(coord);
                        }
                    }
                }
            }
        }


        return finalMoves;
        }
}
