using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateDistanceText : MonoBehaviour {

	Transform player;
	Text distText;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
		distText = GetComponent<Text> ();
	}

	void Update () {
		distText.text = ((int)player.position.x).ToString ();
	}
}