using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : ChessPiece {

    public List<Coordinates> knownMoves;

    void Awake() {
        base.Setup();
    }

    // Update is called once per frame
    void Update () {

	}

    public override List<Coordinates> GetMoves()
    {
        List<Coordinates> finalMoves = new List<Coordinates>();

        foreach (Coordinates move in knownMoves) {
            Coordinates coord = move + currentPos;
            if (coord.x <= 7 && coord.x >= 0 && coord.z <= 7 && coord.z >= 0)
            {
                finalMoves.Add(coord);
            }
        }
        return finalMoves;
    }
}
