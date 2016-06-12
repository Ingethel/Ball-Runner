using UnityEngine;
using System.Collections;

public class ObjectSwitcher : MonoBehaviour {

	public GameObject[] obj;
	ObjectGeneration generator;
	ActivateSnow snow;
	bool snowchanged;

	void Start () {
		generator = GetComponent<ObjectGeneration> ();
		snow = FindObjectOfType<ActivateSnow> ();
		snowchanged = false;
	}

	void Update(){
		if (snowchanged != snow.snowing) {
			snowchanged = snow.snowing;
			Switch(snowchanged ? 1 : 0);
		}
	}

	public void Switch(int i){
		i = (int)Mathf.Clamp (i, 0, obj.Length-1);
		generator.obj = obj [i];
		generator.CheckPooled ();
	}
}
