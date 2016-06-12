using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

	GameObject gameScreen;
	GameObject endScreen;
	GameObject menuScreen;
	GameObject player;
	public GameObject deathAnim;
	int gameState;

	float time;
	int bonus = 0;
	GameObject gg;

	void Start () {
		gameState = 0;
		Time.timeScale = 0;
		player = GameObject.FindGameObjectWithTag ("Player");
		gameScreen = GameObject.FindGameObjectWithTag ("GameScreen");
		gameScreen.SetActive (true);
		endScreen = GameObject.FindGameObjectWithTag ("EndScreen");
		gg = GameObject.FindGameObjectWithTag ("GGText");
		endScreen.SetActive (false);
		menuScreen = GameObject.FindGameObjectWithTag ("MenuScreen");
		menuScreen.SetActive (false);
		Time.timeScale = 1;
		time = Time.time;
	}

	public void Deaded(){
		StartCoroutine (LaunchEndScreen());	
	}

	public IEnumerator LaunchEndScreen(){
		gameState = 2;
		gameScreen.SetActive (false);
		player.SetActive (false);
		Instantiate (deathAnim, player.GetComponent<Transform> ().position, Quaternion.identity);
		yield return new WaitForSeconds (2f);
		Pause ();
		time = Time.time - time;
		int score = CalculateScore ();
		endScreen.SetActive (true);
		GameObject.FindGameObjectWithTag ("NewScore").GetComponent<Text>().text = score.ToString();
		if (score > PlayerPrefs.GetInt ("HighScore")) {
			PlayerPrefs.SetInt ("HighScore", score);
			gg.SetActive (true);
		} else {
			gg.SetActive (false);
		}
		GameObject.FindGameObjectWithTag ("HighScore").GetComponent<Text>().text = PlayerPrefs.GetInt ("HighScore").ToString();
	}
	
	public void LaunchMenuScreen(){
		gameState = 1;
		if (!menuScreen.activeSelf) {
			gameScreen.SetActive (false);
			player.SetActive (false);
			Pause ();
			menuScreen.SetActive (true);
		}
	}

	public void Resume(){
		if (!gameScreen.activeSelf) {
			gameState = 0;
			menuScreen.SetActive (false);
			Pause ();
			gameScreen.SetActive (true);
			player.SetActive (true);
		}
	}

	void Pause()
	{
		Time.timeScale = Time.timeScale == 0 ? 1 : 0;
	}

	int CalculateScore(){
		return (int)(player.GetComponent<Transform>().position.x*100/time) + bonus;
	}

	public void addPoints(int value){
		bonus += value;
	}

	void OnApplicationPause(bool pauseStatus) {
		if (pauseStatus && !endScreen.activeSelf) {
			LaunchMenuScreen();
		}
	}

	public int getState(){
		return gameState;
	}
	
}
