using UnityEngine;
using System.Collections;

public class WhirlwindTrees : MonoBehaviour {

	public Transform[] trees = new Transform[3];

	float[] a = new float[3];
	float[] b = new float[3];
	
	float[] x = new float[3];
	float[] z = new float[3];

	float[] speed = new float[3];

	void Start () {
		Time.timeScale = 0;
		Random.seed = (int)System.DateTime.Now.Ticks;
		for (int i = 0; i < 3; i++) {
			a[i] = Random.Range(0, 180);
			b[i] = Random.Range(0, 180);
			x[i] = trees[i].position.x;
			z[i] = trees[i].position.z;

			trees[i].position = 
				new Vector3(x[i]*Mathf.Cos(a[i]), trees[i].position.y, z[i]*Mathf.Sin(a[i]));

			speed[i] = Random.Range(0.1F, 0.5F);
		}
		Time.timeScale = 1;
	}

	void Update () {
		for (int i = 0; i < 3; i++) {
			a[i] += speed[i]*Time.deltaTime;
			b[i] += speed[i]*Time.deltaTime;

			trees[i].position = 
				new Vector3(x[i]*Mathf.Cos(a[i]), trees[i].position.y, z[i]*Mathf.Sin(b[i]));

			trees[i].Rotate(new Vector3(Random.value, Random.value, Random.value)*Time.deltaTime*10);
		}
	}
}
