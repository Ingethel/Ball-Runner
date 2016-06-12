using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	public float acceleration;
	public float slow;
	public float jump;

	public float max_speed;
	float moveVelocity;
	bool grounded = true;
	public bool wind = false;
	Rigidbody2D body;

	bool slowed;

	void Start(){
		slowed = false;
		body = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () {
		body.velocity = new Vector2 (moveVelocity, body.velocity.y);
		if (slowed)
			slowed = false;
		else {
			SpeedUp ();
			if(wind)
				moveVelocity = Mathf.Max(3f, speed/2f);

		}
	}

	void OnTriggerEnter2D(Collider2D c){
		if (c.CompareTag("Terain")) {
			grounded = true;
		} else if (c.CompareTag("DeathBySnuSnu")) {
			GameObject.FindGameObjectWithTag("GameManager").GetComponent<Manager>().Deaded();
		}
	}

	void SpeedUp(){
		if (speed < max_speed) {
			speed += acceleration * Time.deltaTime;
		}
		moveVelocity = speed;
	}

	public void Jump(){
		if(grounded){
			body.velocity = new Vector2(body.velocity.x, jump);
			grounded = false;
		}
	}

	public void Slow(){
		slowed = true;
		if(wind)
			moveVelocity = -slow*2f;
		else
			moveVelocity = -slow;
	}

}