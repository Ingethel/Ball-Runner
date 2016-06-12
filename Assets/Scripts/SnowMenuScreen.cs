using UnityEngine;
using System.Collections;

public class SnowMenuScreen : MonoBehaviour {
	public Material mat;
	public Color col;
	public ParticleSystem[] snow;

	void Awake () {
		bool emit = 0.1 > mat.color.r - col.r;

		for (int i = 0; i < snow.Length; i++)
			snow[i].enableEmission = emit;
	}

}
