using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

namespace Tests
{
    public class PieceColorTest {

        // A UnityTest behaves like a coroutine in PlayMode
        // and allows you to yield null to skip a frame in EditMode
        [UnityTest]
        public IEnumerator TestIfPieceColorMatchesTeamColor() {
            // Use the Assert class to test conditions.
            // yield to skip a frame
    
            TeamInfo team1Info = (TeamInfo)Resources.Load("ScriptableObjects/Team1Info");
            TeamInfo team2Info = (TeamInfo)Resources.Load("ScriptableObjects/Team2Info");

            GameObject[] team1Pieces = GameObject.FindGameObjectsWithTag("Team1");
            GameObject[] team2Pieces = GameObject.FindGameObjectsWithTag("Team2");

            Color[] team1PieceColor = new Color[team1Pieces.Length];
            Color[] team2PieceColor = new Color[team2Pieces.Length];

            for (int i = 0; i < team1Pieces.Length; i++)
            {
                team1PieceColor[i] = team1Pieces[i].GetComponent<Renderer>().material.color;
            }
            for (int i = 0; i < team1Pieces.Length; i++)
            {
                team2PieceColor[i] = team2Pieces[i].GetComponent<Renderer>().material.color;
            }

            Color teamColor = team1Info.teamColor;
            foreach (Color pieceColor in team1PieceColor)
            {
                Assert.AreEqual(pieceColor, teamColor);
            }

            teamColor = team2Info.teamColor;
            foreach (Color pieceColor in team2PieceColor)
            {
                Assert.AreEqual(pieceColor, teamColor);
            }

            yield return null;
        }

    }
}
