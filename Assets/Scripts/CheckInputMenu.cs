using UnityEngine;
using System.Collections;
#if UNITY_EDITOR 
using UnityEditor;
#endif

public class CheckInputMenu : MonoBehaviour {
	
	void Update () {
		if (clickInput ()) {
		} else if (keyInput ()) {
		}
	}

	bool clickInput(){
		bool flag = false;
		if (Input.GetMouseButtonDown (0)) {
			Collider2D _collider = Physics2D.OverlapPoint(Input.mousePosition);
			if (_collider != null) {
				flag = true;
				if(_collider.tag == GameObject.FindGameObjectWithTag("StartArea").GetComponent<Collider2D>().tag){
					Application.LoadLevel(1);
				}
				else if(_collider.tag == GameObject.FindGameObjectWithTag("ExitArea").GetComponent<Collider2D>().tag){
					Exit();
				}
			}
		}
		return flag;
	}

	bool keyInput(){
		bool flag = false;
		if (Input.GetKeyDown(KeyCode.Escape)){
			Exit();
		}
		return flag;
	}

	void Exit(){
		#if UNITY_EDITOR 
		EditorApplication.isPlaying = false;
		#else 
		Application.Quit();
		#endif
	}
}
