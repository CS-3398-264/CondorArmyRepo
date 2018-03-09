using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skynet : MonoBehaviour {

    public GameObject parentPiecesObject;
    public GameManager gm;
    private List<GameObject> pieces;
    private float thinkingTime;
    private bool piecesUpToDate;

	// Use this for initialization
	void Start () {
        pieces = new List<GameObject>();
        UpdatePieces();
        gm = FindObjectOfType<GameManager>();

        thinkingTime = Random.Range(1f, 3f);
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.turn == 1 && !gm.gameOver.gameObject.activeInHierarchy)
        {
            if (!piecesUpToDate)
            {
                UpdatePieces();
                piecesUpToDate = true;
            }
            List<Coordinates> moves = new List<Coordinates>();
            GameObject selectedPiece;
            if (thinkingTime <= 0f) {
                selectedPiece = pieces[Random.Range(0, pieces.Count)];
                Debug.Log("sPiece: " + selectedPiece);
                moves = selectedPiece.GetComponent<ChessPiece>().GetMoves(true);
                if (moves.Count != 0)
                {
                    Coordinates move = moves[Random.Range(0, moves.Count)];
                    Debug.Log("Moving: " + move);
                    selectedPiece.GetComponent<ChessPiece>().move(move);
                    thinkingTime = Random.Range(1f, 3f);
                }
            }
            else
            {
                thinkingTime -= Time.deltaTime;
            }
        }
        else
        {
            piecesUpToDate = false;
        }
	}

    private void UpdatePieces() {
        pieces.Clear();
        for (int i = 0; i < parentPiecesObject.transform.childCount; i++)
        {
            if (parentPiecesObject.transform.GetChild(i).gameObject.activeInHierarchy)
                pieces.Add(parentPiecesObject.transform.GetChild(i).gameObject);
        }
    }
}
