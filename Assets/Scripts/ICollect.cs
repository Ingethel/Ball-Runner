using UnityEngine;
using System.Collections;

public class ICollect : IPoolObject {

	GameObject player;
	protected Manager manager;

	protected virtual void Start(){
		player = GameObject.FindGameObjectWithTag ("Player");
		manager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<Manager> ();
	}

	protected void FixedUpdate(){
		if (manager.getState () == 0) {
			if(!ready)
				if (player.GetComponent<Transform> ().position.x -
				    GetComponent<Transform> ().position.x > 8)
					Destroy();
		}
	}
	
	protected void OnTriggerEnter2D(Collider2D c){
		if (c.tag == "Player") {
			Behave();
			Destroy();
		}
	}

	public override void Spawn (Vector3 position, Quaternion rotation, Vector3 scale)
	{
		base.Spawn (position, rotation, scale);
		ready = false;
	}

	public override void Destroy ()
	{
		base.Destroy ();
		ready = true;
	}

	protected virtual void Behave() {
	}
}
