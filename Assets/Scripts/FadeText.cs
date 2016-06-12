using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeText : MonoBehaviour {

	float minFade;
	Text textField;
	bool update;
	public float fadeSpeed;

	void Start () {
		update = true;
		minFade = 0.0F;
		textField = GetComponent<Text> ();
	}

	void Update () {
		if (update) {
			fade ();
		}
	}

	void fade(){
		if (textField.color.a > minFade) {
			Color new_colour = textField.color;
			new_colour.a -= fadeSpeed * Time.deltaTime;
			textField.color = new_colour;
		} else {
			update = false;
		}
	}

}
