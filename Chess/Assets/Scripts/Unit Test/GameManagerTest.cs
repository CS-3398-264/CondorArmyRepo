using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEditor;
using System;

public class GameManagerTest {

    GameObject newPiece;

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
	public IEnumerator Deactivate_Children_Is_Not_Null() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        
        try
        {
            GameManager.DeactivateChildren(newPiece, true);
            Assert.Fail();
        }
        catch (NullReferenceException ex)
        {

        }

		yield return null;
	}
}
