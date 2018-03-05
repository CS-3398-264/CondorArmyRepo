using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPiece : MonoBehaviour {

    public int locationX;
    public int locationZ;

	// Use this for initialization
	public void Setup () {
        locationX = (int)Mathf.Round(transform.position.x);
        locationZ = (int)Mathf.Round(transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseUp() {
        Debug.Log("Hi");
    }
}
