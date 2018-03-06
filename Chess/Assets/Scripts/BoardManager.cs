using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {

    public Material whiteTile;
    public Material blackTile;
    public Material highlight;

    private const int BOARD_SIZE = 8;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void HighlightTiles (List<Coordinates> moves)
    {
        foreach (Coordinates move in moves)
        {
            transform.GetChild((move.z * BOARD_SIZE) + move.x).GetComponent<Renderer>().material = highlight;
            transform.GetChild((move.z * BOARD_SIZE) + move.x).GetComponent<Tile>().isHighlighted = true;
        }
    }

    public void ResetBoard()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (transform.GetChild(i).position.z % 2 == 0) {
                if (i % 2 == 0)
                    transform.GetChild(i).GetComponent<Renderer>().material = blackTile;
                else
                    transform.GetChild(i).GetComponent<Renderer>().material = whiteTile;
            }
            else {
                if (i % 2 == 0)
                    transform.GetChild(i).GetComponent<Renderer>().material = whiteTile;
                else
                    transform.GetChild(i).GetComponent<Renderer>().material = blackTile;
            }
            transform.GetChild(i).GetComponent<Tile>().isHighlighted = false;
        }
    }
}
