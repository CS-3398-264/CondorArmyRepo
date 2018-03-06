﻿/*
 * Arthur Cousseau, 2017
 * https://www.linkedin.com/in/arthurcousseau/
 * Please share this if you enjoy it! :)
 * 
 * Modified by Cullen Sturdivant, 2018
*/

using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "NewPieceArray", menuName = "Chess/Piece Array")]
public class BoardData : ScriptableObject
{
    private const int defaultGridSize = 8;

    public int gridSize = defaultGridSize;

    public CellRow[] cells = new CellRow[defaultGridSize];


    public ChessPiece[,] GetCells()
    {
        ChessPiece[,] ret = new ChessPiece[gridSize, gridSize];

        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                ret[i, j] = cells[i].row[j];
            }
        }

        return ret;
    }

    /// <summary>
    /// Just an example, you can remove this.
    /// </summary>
    public int GetCountActiveCells()
    {
        int count = 0;

        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                if (cells[i].row[j] != null) count++;
            }
        }

        return count;
    }


    [System.Serializable]
    public class CellRow
    {
        public ChessPiece[] row = new ChessPiece[defaultGridSize];
    }
}