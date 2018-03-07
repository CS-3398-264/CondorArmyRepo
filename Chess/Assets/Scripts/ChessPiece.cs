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
        updatePosition();

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

    // FIXME: Does not work!
    public void move(Coordinates moveTo) {
        transform.position = new Vector3(moveTo.x, 0f, moveTo.z);
        gm.RemovePieceAt(currentPos);
        updatePosition();
        gm.AddPieceAt(this, moveTo);
    }

    private void updatePosition() {
        currentPos.x = (int)Mathf.Round(transform.position.x);
        currentPos.z = (int)Mathf.Round(transform.position.z);
    }

    public bool isBlocked(Coordinates to, Coordinates from) {
        Vector3 origin = new Vector3(from.x, 0.1f, from.z);
        Vector3 destination = new Vector3(to.x, 0.1f, to.z);
        Vector3 diff = destination - origin;
        float distance = diff.magnitude;

        RaycastHit hitInfo;

        Debug.DrawLine(origin, destination, Color.blue);
        bool isHit = Physics.Raycast(origin, diff.normalized, out hitInfo, distance);

        if (isHit)
        {
            if (hitInfo.transform.tag == "Team1")
            {
                return true;
            }
            else if (hitInfo.transform.tag == "Team2")
            {
                if (hitInfo.transform.GetComponent<ChessPiece>().currentPos != to)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    public bool isCheck(Coordinates pos)
    {
        ChessPiece[,] tempLocations = GameManager.pieceLocations;
        Coordinates kingLoc;
        string ownTeam;
        string opponentTeam;

        if(gameObject.tag == "Team1")
        {
            kingLoc = new Coordinates(gm.team1_king.currentPos.x, gm.team1_king.currentPos.z);
            ownTeam = "Team1";
            opponentTeam = "Team2";
        }
        else
        {
            kingLoc = new Coordinates(gm.team2_king.currentPos.x, gm.team2_king.currentPos.z);
            ownTeam = "Team2";
            opponentTeam = "Team1";
        }

        tempLocations[currentPos.x, currentPos.z] = null;
        tempLocations[pos.x, pos.z] = this;

        for(int i = kingLoc.x; i <= 7; i++)
        {
            if (tempLocations[i, kingLoc.z] != null && tempLocations[i, kingLoc.z].gameObject.tag == opponentTeam)
            {
                if (tempLocations[i,kingLoc.z] == null)
                {

                }
            }
        }
        for (int i = kingLoc.x; i >= 0; i--)
        {
            if (tempLocations[i, kingLoc.z] != null && tempLocations[i, kingLoc.z].gameObject.tag == opponentTeam)
            {

            }
        }

        return false;
    }

    public abstract List<Coordinates> GetMoves();

}
