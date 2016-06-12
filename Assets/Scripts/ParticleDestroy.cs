using UnityEngine;
using System.Collections;

public class ParticleDestroy : MonoBehaviour 
{
	ParticleSystem system;

	public void Start() {
		system = GetComponent<ParticleSystem>();
	}
	
	public void Update() {
		if(system)
			if(!system.IsAlive())
				Destroy(gameObject);
	}

}