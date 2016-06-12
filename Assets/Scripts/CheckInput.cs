using UnityEngine;
using System.Collections;

public class CheckInput : MonoBehaviour {

	PlayerMovement player;
	Manager manager;
	string jumpArea, slowArea, menu;

	void Start () {
		player = FindObjectOfType<PlayerMovement> ();
		manager = FindObjectOfType<Manager> ();
		jumpArea = GameObject.FindGameObjectWithTag ("JumpArea").GetComponent<Collider2D> ().tag;
		slowArea = GameObject.FindGameObjectWithTag ("SlowArea").GetComponent<Collider2D> ().tag;
		menu = GameObject.FindGameObjectWithTag ("Menu").GetComponent<Collider2D> ().tag;
	}
	
	void Update () {
		if (touchInput ()) {
		} else if (clickInput ()) {
		} else if (keyInput ()) {
		}
	}

	bool keyInput(){
		bool flag = false;
		#if UNITY_EDITOR 
		if (Input.GetKeyDown (KeyCode.Space) || 
		    Input.GetKeyDown (KeyCode.W) || 
		    Input.GetKeyDown (KeyCode.UpArrow)) {
			player.Jump();
			flag = true;
		}
		if (Input.GetKey (KeyCode.A) || 
		    Input.GetKey (KeyCode.LeftArrow)) {
			player.Slow();
			flag = true;
		}
		#endif
		if (Input.GetKeyDown(KeyCode.Escape)){
			manager.LaunchMenuScreen();
		}
		return flag;
	}
	
	bool touchInput(){
		bool flag = false;
		for (int i = 0; i < Input.touchCount; i++) {
			flag = colliderBehaviour(Physics2D.OverlapPoint(Input.GetTouch(i).position));
		}
		return flag;
	}
	
	bool clickInput(){
		if (Input.GetMouseButton (0)) {
			return colliderBehaviour(Physics2D.OverlapPoint(Input.mousePosition));
		}
		return false;
	}

	bool colliderBehaviour(Collider2D col){
		if(col != null){
			if(col.CompareTag(jumpArea)){
				player.Jump();
			} else if(col.CompareTag(slowArea)){
				player.Slow();
			} else if(col.CompareTag(menu)){
				manager.LaunchMenuScreen();
			}
			return true;
		}
		return false;
	}

	public void onClickExit(){
		Application.LoadLevel(0);
	}

	public void onClickRestart(){
		Application.LoadLevel(Application.loadedLevel);
	}

	public void onClickResume(){
		manager.Resume ();
	}
}
