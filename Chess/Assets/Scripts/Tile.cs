using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    public bool isHighlighted;
    public Coordinates tilePosition;

	// Use this for initialization
	void Start () {
        isHighlighted = false;

        tilePosition.x = (int)Mathf.Round(transform.position.x);
        tilePosition.z = (int)Mathf.Round(transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
