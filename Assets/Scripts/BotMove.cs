using UnityEngine;
using System.Collections;

public class BotMove : MonoBehaviour {

	// {moveLeft, Jump, Fall}
	int[] action = {1, 2, 3};
	// total = 1
	public float[] prob = {0.6F, 0.3F, 0.1F};

	public Transform target;

	int newMove = 0;
	float offset = 8.0F;

	Manager manager;

	void Start(){
		manager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<Manager> ();
		Random.seed = (int)System.DateTime.Now.Ticks;
	}

	void Update () {
		if (manager.getState () == 0) {
			transform.position = new Vector3 (target.position.x + offset, transform.position.y, 0.0F);
		}
	}

	public int generateChoice(){
		float randomMove = Random.value;
		for (int i = 0; i < 3; i++) {
			if (randomMove <= prob[i]) {
				newMove = action[i];
				break;
			} else {
				randomMove -= prob[i];
			}
		}

		return newMove;
	}

}
