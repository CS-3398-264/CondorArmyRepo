using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : ChessPiece {

    public List<Coordinates> knownMoves;

    void Start() {
        base.Setup();
    }

    // Update is called once per frame
    void Update () {
	    
	}

    public override List<Coordinates> GetMoves()
    {
        return new List<Coordinates>();
    }
}
