using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChessPiece : MonoBehaviour {

    public TeamInfo teamInfo;

    public int locationX;
    public int locationZ;

    private Renderer rend;

	// Use this for initialization
	public void Setup () {
        locationX = (int)Mathf.Round(transform.position.x);
        locationZ = (int)Mathf.Round(transform.position.z);

        rend = GetComponentInChildren<Renderer>();
        SetColor();
    }

    public void SetColor()
    {
        rend.material.color = teamInfo.teamColor;
    }

    public void HighlightPiece()
    {
        if (MouseManager.selectedObject == gameObject)
        {
            //currentShader = selectedShader;
        }
        else if (false/*currentShader != defaultShader*/)
        {
            //currentShader = defaultShader;
        }
    }

    public abstract void OnMouseUp();

}
