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

    // FIXME: Does not work!
    public void move(Coordinates moveTo) {
        gm.RemovePieceAt(currentPos);
        updatePosition(moveTo);
        gm.AddPieceAt(this, moveTo);
    }

    private void updatePosition(Coordinates moveTo) {
        transform.position = new Vector3(moveTo.x, 0f, moveTo.z);
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
        ChessPiece[,] tempLocations = new ChessPiece[8, 8];
        for(int z = 0; z <= 7; z++)
        {
            for (int x = 0; x <=7; x++)
            {
                tempLocations[x, z] = GameManager.pieceLocations[x, z];
            }
        }
        Coordinates kingLoc;
        string ownTeam;
        string opponentTeam;

        if(gameObject.tag == "Team1")
        {
            if (this is King)
            {
                kingLoc = new Coordinates(pos.x, pos.z);
                Debug.Log("KING: " + kingLoc);
            } else
            {
                kingLoc = new Coordinates(gm.team1_king.currentPos.x, gm.team1_king.currentPos.z);
            }
            ownTeam = "Team1";
            opponentTeam = "Team2";
        }
        else
        {
            if (this is King)
            {
                kingLoc = new Coordinates(pos.x, pos.z);
            }
            else
            {
                kingLoc = new Coordinates(gm.team1_king.currentPos.x, gm.team1_king.currentPos.z);
            }
            ownTeam = "Team2";
            opponentTeam = "Team1";
        }

        tempLocations[currentPos.x, currentPos.z] = null;
        tempLocations[pos.x, pos.z] = this;
        
        for(int i = kingLoc.x + 1; i <= 7; i++)
        {
            ChessPiece tempPiece = tempLocations[i, kingLoc.z];
            if (tempPiece != null)
            {
                if (tempPiece.gameObject.tag == opponentTeam && (tempPiece is Queen || tempPiece is Rook || (tempPiece is King && (i-kingLoc.x == 1))))
                {
                    return true;
                }
                break;
            }
        }
        for (int i = kingLoc.x - 1; i >= 0; i--)
        {
            ChessPiece tempPiece = tempLocations[i, kingLoc.z];
            if (tempPiece != null)
            {
                if (tempPiece.gameObject.tag == opponentTeam && (tempPiece is Queen || tempPiece is Rook || (tempPiece is King && (kingLoc.x - i == 1))))
                {
                    return true;
                }
                break;
            }
        }
        for (int i = kingLoc.z + 1; i <= 7; i++)
        {
            ChessPiece tempPiece = tempLocations[kingLoc.x, i];
            if (tempPiece != null)
            {
                if (tempPiece.gameObject.tag == opponentTeam && (tempPiece is Queen || tempPiece is Rook || (tempPiece is King && (i - kingLoc.z == 1))))
                {
                    return true;
                }
                break;
            }
        }
        for (int i = kingLoc.z - 1; i >= 0; i--)
        {
            ChessPiece tempPiece = tempLocations[kingLoc.x, i];
            if (tempPiece != null)
            {
                if (tempPiece.gameObject.tag == opponentTeam && (tempPiece is Queen || tempPiece is Rook || (tempPiece is King && (kingLoc.z - i == 1))))
                {
                    return true;
                }
                break;
            }
        }

        int j = kingLoc.z + 1;
        for (int i = kingLoc.x + 1; i <=7; i++, j++)
        {
            ChessPiece tempPiece = tempLocations[i, j];
            if (tempPiece != null)
            {
                if (tempPiece.gameObject.tag == opponentTeam && (tempPiece is Bishop || tempPiece is Queen || ((tempPiece is King || tempPiece is Pawn) && (i - kingLoc.x == 1))))
                {
                    return true;
                }
                break;
            }
            if (j >= 7)
            {
                break;
            }
        }
        j = kingLoc.z - 1;
        for (int i = kingLoc.x - 1; i >= 0; i--, j--)
        {
            ChessPiece tempPiece = tempLocations[i, j];
            if (tempPiece != null)
            {
                if (tempPiece.gameObject.tag == opponentTeam && (tempPiece is Bishop || tempPiece is Queen || ((tempPiece is King || tempPiece is Pawn) && (kingLoc.x - i == 1))))
                {
                    return true;
                }
                break;
            }
            if (j <= 0)
            {
                break;
            }
        }
        j = kingLoc.z - 1;
        for (int i = kingLoc.x + 1; i <= 7; i++, j--)
        {
            ChessPiece tempPiece = tempLocations[i, j];
            if (tempPiece != null)
            {
                if (tempPiece.gameObject.tag == opponentTeam && (tempPiece is Bishop || tempPiece is Queen || ((tempPiece is King || tempPiece is Pawn) && (i - kingLoc.x == 1))))
                {
                    return true;
                }
                break;
            }
            if (j <= 0)
            {
                break;
            }
        }
        j = kingLoc.z + 1;
        for (int i = kingLoc.x - 1; i >= 0; i--, j++)
        {
            ChessPiece tempPiece = tempLocations[i, j];
            Debug.Log(tempPiece + " at (" + i + "," + kingLoc.z + ")");
            if (tempPiece != null)
            {
                Debug.Log("Here");
                if (tempPiece.gameObject.tag == opponentTeam && (tempPiece is Bishop || tempPiece is Queen || ((tempPiece is King || tempPiece is Pawn) && (kingLoc.x - i == 1))))
                {
                    return true;
                }
                break;
            }
            if (j >= 7)
            {
                break;
            }
        }

        return false;
    }

    public abstract List<Coordinates> GetMoves();

}
