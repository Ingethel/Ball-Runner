using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeImage : MonoBehaviour {

	Image imageOverlay;
	public float minFade;
	bool update;
	public float fadeSpeed;

	void Start () {
		imageOverlay = GetComponent<Image> ();
	}
	
	void Update () {
		fade ();
	}
	
	void fade(){
		if (imageOverlay.color.a > minFade) {
			Color new_colour = imageOverlay.color;
			new_colour.a -= fadeSpeed * Time.deltaTime;
			imageOverlay.color = new_colour;
		}
	}
}
