using UnityEngine;
using System.Collections;

public class TerrainObject : IPoolObject {
	public GameObject grass;
	public GameObject snowPatches;

	GameObject[] grasses;
	Vector3[] pos;

	float Yoffset, Zoffset;

	protected override void Awake(){
		base.Awake ();
		grasses = new GameObject[3];
		pos = new Vector3[3];
		Zoffset = 0.436F;
		Yoffset = 0.58F;
		RandomiseGrassPosition ();
		for (int i = 0; i < 3; i++) {
			grasses[i] = (GameObject)Instantiate (grass, GetComponent<Transform>().position + pos[i], Quaternion.identity);
			grasses[i].transform.SetParent(transform);
		}
	}

	public override void Spawn (Vector3 position, Quaternion rotation, Vector3 scale)
	{
		base.Spawn (position, rotation, scale);
		if (FindObjectOfType<ActivateSnow> ().snowing)
			snowPatches.SetActive (true);
		else
			snowPatches.SetActive (false);
		changeGrassPoss ();
	}

	public void changeGrassPoss(){
		RandomiseGrassPosition ();
		for (int i = 0; i < 3; i++) {
			grasses[i].transform.position = GetComponent<Transform>().position + pos[i];
		}
	}

	void RandomiseGrassPosition(){
		pos[0] = new Vector3(Random.Range (-0.4F, 0.0F), Yoffset, Zoffset);
		pos[1] = new Vector3(Random.Range (0.0F, 0.4F), Yoffset, Zoffset);
		pos[2] = new Vector3(Random.Range (-0.4F, 0.4F), Yoffset, -Zoffset);
	}

}
