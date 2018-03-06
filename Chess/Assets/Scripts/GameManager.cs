using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private MouseManager mm;

	// Use this for initialization
	void Start () {
        mm = FindObjectOfType<MouseManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0))
        {
            //mm.selectedObject;
        }
	}
}
