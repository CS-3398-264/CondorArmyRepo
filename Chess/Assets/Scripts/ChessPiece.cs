using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChessPiece : MonoBehaviour {

    public TeamInfo teamInfo;
    public GameManager gm;
    public Coordinates currentPos;

    private Renderer rend;

	// Use this for initialization
	public void Setup () {
        currentPos.x = (int)Mathf.Round(transform.position.x);
        currentPos.z = (int)Mathf.Round(transform.position.z);

        rend = GetComponentInChildren<Renderer>();
        SetColor();
    }

    public void SetColor()
    {
        rend.material.color = teamInfo.teamColor;
    }

    public void HighlightPiece()
    {
        
    }

    public bool ObstacleChecker(Coordinates to, Coordinates from) {
        Coordinates diff = to - from;
        if (diff.x > 0)
        {
            if (diff.z > 0)
            {
                for (int i = diff.x - 1; i >= 0; i--)
                {
                    if (GameManager.pieceLocations[to.x - i, to.z - i] != null)
                    {
                        return true;
                    }
                }
            }
            if (diff.z == 0)
            {
                for (int i = diff.x - 1; i >= 0; i--)
                {
                    if (GameManager.pieceLocations[to.x - i, to.z] != null)
                    {
                        return true;
                    }
                }
            }
            if (diff.z < 0)
            {
                for (int i = diff.z - 1; i < 0; i--)
                {
                    if (GameManager.pieceLocations[to.x - i, to.z + i] != null)
                    {
                        return true;
                    }
                }
            }
        }
    }

    public abstract List<Coordinates> GetMoves();

}
