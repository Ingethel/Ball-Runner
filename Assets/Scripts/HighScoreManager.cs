using UnityEngine;
using System.Collections;

public class HighScoreManager : MonoBehaviour {
	
	static int version = 3;

	void Start () {
		if (PlayerPrefs.GetInt ("Version") != version) {
			PlayerPrefs.SetInt ("Version", version);
			PlayerPrefs.SetInt ("HighScore", 0);
		}
	}

}
