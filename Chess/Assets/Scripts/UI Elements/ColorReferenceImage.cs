using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorReferenceImage : MonoBehaviour {

    public Slider red;
    public Slider green;
    public Slider blue;

    public TeamInfo teamInfo;

    private Color teamColor;

    private void Start()
    {
        teamColor = new Color(red.value, green.value, blue.value, 1.0f);
    }

    // Update is called once per frame
    void Update () {
        teamColor.r = red.value;
        teamColor.g = green.value;
        teamColor.b = blue.value;
        gameObject.GetComponent<Image>().color = teamColor;
        teamInfo.teamColor = teamColor;
	}
}
