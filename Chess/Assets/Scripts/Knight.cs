using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : ChessPiece {

    public List<Coordinates> knownMoves;

    void Awake() {
        base.Setup();
    }

    // Update is called once per frame
    void Update () {
	    
	}

    public override List<Coordinates> GetMoves(bool runCheckCheck)
    {
        List<Coordinates> finalMoves = new List<Coordinates>();

        foreach (Coordinates move in knownMoves)
        {
            Coordinates coord = move + currentPos;
            if (coord.x <= 7 && coord.x >= 0 && coord.z <= 7 && coord.z >= 0)
            {
                if ((GameManager.pieceLocations[coord.x, coord.z] == null || GameManager.pieceLocations[coord.x, coord.z].gameObject.tag == "Team2"))
                {
                    if (runCheckCheck)
                    {
                        if (isCheck(coord).Count == 0)
                        {
                            finalMoves.Add(coord);
                        }
                    }
                    else
                    {
                        finalMoves.Add(coord);
                    }
                }
            }
        }
        return finalMoves;
    }
}
