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

    // Returns true if there is an object in the way.
    public bool ObstacleChecker(Coordinates to, Coordinates from) {
        Coordinates diff = to - from;
        Debug.Log("[" + diff.x + ", " + diff.z + "]");
        if (diff.x > 0)
        {
            if (diff.z > 0)
            {
                while (to != from)
                {
                    Debug.Log("In the way: " + GameManager.pieceLocations[to.x, to.z]);
                    if (GameManager.pieceLocations[to.x, to.z] != null)
                    {
                        return true;
                    }
                    to.x -= 1;
                    to.z -= 1;
                }
                return false;
            }
            if (diff.z == 0)
            {
                while (to != from)
                {
                    if (GameManager.pieceLocations[to.x, to.z] != null)
                    {
                        return true;
                    }
                    to.x -= 1;
                }
                return false;
            }
            if (diff.z < 0)
            {
                while (to != from)
                {
                    if (GameManager.pieceLocations[to.x, to.z] != null)
                    {
                        return true;
                    }
                    to.x -= 1;
                    to.z += 1;
                }
                return false;
            }
        }
        else if (diff.x == 0)
        {
            if (diff.z > 0)
            {
                while (to != from)
                {
                    if (GameManager.pieceLocations[to.x, to.z] != null)
                    {
                        return true;
                    }
                    to.z -= 1;
                }
                return false;
            }
            if (diff.z < 0)
            {
                while (to != from)
                {
                    if (GameManager.pieceLocations[to.x, to.z] != null)
                    {
                        return true;
                    }
                    to.z += 1;
                }
                return false;
            }
        }
        else
        {
            if (diff.z > 0)
            {
                while (to != from)
                {
                    if (GameManager.pieceLocations[to.x, to.z] != null)
                    {
                        return true;
                    }
                    to.x += 1;
                    to.z -= 1;
                }
                return false;
            }
            if (diff.z == 0)
            {
                while (to != from)
                {
                    if (GameManager.pieceLocations[to.x, to.z] != null)
                    {
                        return true;
                    }
                    to.x += 1;
                }
                return false;
            }
            if (diff.z < 0)
            {
                while (to != from)
                {
                    if (GameManager.pieceLocations[to.x, to.z] != null)
                    {
                        return true;
                    }
                    to.x += 1;
                    to.z += 1;
                }
                return false;
            }
        }
        Debug.Log("Why am I ending up here?");
        return false;
    }

    public abstract List<Coordinates> GetMoves();

}
