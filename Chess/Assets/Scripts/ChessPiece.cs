using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChessPiece : MonoBehaviour {

    public Shader selectedShader;

    public int locationX;
    public int locationZ;

	// Use this for initialization
	public void Setup () {
        locationX = (int)Mathf.Round(transform.position.x);
        locationZ = (int)Mathf.Round(transform.position.z);
    }

    public void HightlightPiece()
    {

    }

    public abstract void OnMouseUp();

}
