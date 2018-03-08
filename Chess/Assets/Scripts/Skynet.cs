﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skynet : MonoBehaviour {

    public GameObject parentPiecesObject;
    private GameObject[] pieces;
    private float thinkingTime;

	// Use this for initialization
	void Start () {
        pieces = new GameObject[parentPiecesObject.transform.childCount];
        UpdatePieces();

        thinkingTime = Random.Range(2f, 5f);
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.turn == 1)
        {
            List<Coordinates> moves;
            GameObject selectedPiece;
            if (thinkingTime <= 0f) {
                selectedPiece = pieces[Random.Range(0, pieces.Length)];
                moves = selectedPiece.GetComponent<ChessPiece>().GetMoves(true);
                if (moves.Count != 0)
                {
                    Coordinates move = moves[Random.Range(0, moves.Count)];
                    selectedPiece.GetComponent<ChessPiece>().move(move);
                    thinkingTime = Random.Range(2f, 5f);
                }
            }
            else
            {
                thinkingTime -= Time.deltaTime;
            }
        }
	}

    private void UpdatePieces() {
        for (int i = 0; i < parentPiecesObject.transform.childCount; i++)
        {
            if (parentPiecesObject.transform.GetChild(i).gameObject.activeInHierarchy)
                pieces[i] = parentPiecesObject.transform.GetChild(i).gameObject;
        }
    }
}
