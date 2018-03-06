﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChessPiece : MonoBehaviour {

    public TeamInfo teamInfo;

    public Coordinates currentPos;

    private Renderer rend;

	// Use this for initialization
	public void Setup () {
        currentPos.x = (int)Mathf.Round(transform.position.x);
        currentPos.z = (int)Mathf.Round(transform.position.z);

        rend = GetComponentInChildren<Renderer>();
        SetColor();
    }

    public void SetColor()
    {
        rend.material.color = teamInfo.teamColor;
    }

    public void HighlightPiece()
    {
        
    }

    public abstract List<Coordinates> GetMoves();

}
