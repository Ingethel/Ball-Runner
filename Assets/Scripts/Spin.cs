using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {

	public float speed;
	
	void Update () {
		GetComponent<Transform> ().Rotate(0, speed, 0, Space.World);
	}
}
