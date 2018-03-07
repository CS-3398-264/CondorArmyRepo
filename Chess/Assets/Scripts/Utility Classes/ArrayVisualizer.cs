using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrayVisualizer : MonoBehaviour {

    private static ChessPiece[,] currentArray;

    void OnGUI() {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (currentArray[i, j] != null)
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

    public static void VisualizeArray2D(ChessPiece[,] array) {
        currentArray = array;
    }
}
