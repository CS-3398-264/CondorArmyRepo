using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : ChessPiece {

    void Start() {
        base.Setup();
    }

    // Update is called once per frame
    void Update () {
        
    }

    public override void OnMouseUp()
    {
        Debug.Log("Queen was clicked!");
    }
}
