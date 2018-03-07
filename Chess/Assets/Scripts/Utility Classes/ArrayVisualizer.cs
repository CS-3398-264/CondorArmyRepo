using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrayVisualizer : MonoBehaviour {

    private void OnGUI() {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (GameManager.pieceLocations[i, j] != null)
                {
                    GUI.TextField(new Rect(i * 25, j * 25, 25, 25), "X");
                }
                else
                {
                    GUI.TextField(new Rect(i * 25, j * 25, 25, 25), "-");
                }
            }
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
