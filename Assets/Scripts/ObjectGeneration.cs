﻿using UnityEngine;
using System.Collections;

public class ObjectGeneration : MonoBehaviour {

	[Header("Object details")]
	public GameObject obj;
	public int totalobjs;
	public float objSpawnProb;
	PoolManager objectList;

	[Header("Offset range spawn")]
	public float Xmin;
	public float Xmax, Ymin, Ymax, Zmin, Zmax;

	void Awake () {
		objectList = PoolManager.instance;
		objectList.CreatePool (obj, totalobjs);
	}

	public void Generate(Vector3 pos){
		float spawn = Random.value;
		if(spawn <= objSpawnProb){
			objectList.SpawnObject(obj, pos + generateRandomPos()); 
		}
	}

	private Vector3 generateRandomPos(){
		return new Vector3 (Random.Range(Xmin, Xmax), Random.Range(Ymin, Ymax), Random.Range(Zmin, Zmax));
	}
	public void CheckPooled(){
		if (!objectList.HasPooledObject (obj.GetInstanceID ())) {
			objectList.CreatePool (obj, totalobjs);
		}
	}
}
