using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	float offset = 1.538F;
	Manager manager;

	void Start (){
		manager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<Manager> ();
	}

	void Update(){
		if (manager.getState () == 0) {

			if (target.position.x > transform.position.x)
				transform.position = new Vector3 (target.position.x, target.position.y + offset, transform.position.z);
			else
				transform.position = new Vector3 (transform.position.x, target.position.y + offset, transform.position.z);
		}
	}

}
