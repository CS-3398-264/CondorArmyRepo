﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : ChessPiece {

    void Start() {
        base.Setup();
    }

    // Update is called once per frame
    void Update () {
	    
	}

    public override void OnMouseUp()
    {
        Debug.Log("Knight was clicked!");
    }
}
