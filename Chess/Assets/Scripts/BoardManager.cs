using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {

    public Material whiteTile;
    public Material blackTile;

    private Renderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponentInChildren<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ResetBoard()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (i % 2 == 0)
                rend.material = blackTile;
            else
                rend.material = whiteTile;
        }
    }
}
