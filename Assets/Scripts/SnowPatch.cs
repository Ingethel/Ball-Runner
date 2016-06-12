using UnityEngine;
using System.Collections;

public class SnowPatch : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D c){
		if (c.tag == "Player")
			StartCoroutine (movePatch ());
	}

	IEnumerator movePatch(){
		transform.position += new Vector3(0, -0.1f, 0);
		yield return new WaitForSeconds (2);
		transform.position -= new Vector3(0, -0.1f, 0);
	}
}
