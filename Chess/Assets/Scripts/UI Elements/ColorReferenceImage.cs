using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorReferenceImage : MonoBehaviour {

    public Slider red;
    public Slider green;
    public Slider blue;
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Image>().color = new Color(red.value, green.value, blue.value, 1.0f);
	}
}
