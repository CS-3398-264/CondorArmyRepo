﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : ChessPiece {

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

    public override void OnMouseUp()
    {
        Debug.Log("King was clicked!");
    }
}
