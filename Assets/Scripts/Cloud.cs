using UnityEngine;
using System.Collections;

public class Cloud : IPoolObject {
	
	void FixedUpdate(){
		if(!ready)
			if (transform.position.x < Camera.main.transform.position.x - 15)
				Destroy ();
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
}
