using UnityEngine;
using System.Collections;

public class CollectibleGeneration : MonoBehaviour {

	[Header("Object Details")]
	public float[] probs;
	public GameObject[] collectibles;
	public int[] maxNumber;
	
	public GameObject weather;

	[Header("Random Range")]
	public float Ymin;
	public float Ymax;

	PoolManager pool;

	void Start(){
		pool = PoolManager.instance;
		for(int i = 0; i < collectibles.Length; i++){
			pool.CreatePool(collectibles[i], maxNumber[i]);
			pool.CreatePool(weather, 1);
			if(i > 0)
				probs[i] += probs[i-1];
		}

	}

	public void Generate(Vector3 pos){
		float value = Random.value;
		for(int i = 0; i < collectibles.Length; i++){
			if (value <= probs[i]) {
				pos.y += Random.Range(Ymin, Ymax);
				pool.SpawnObject(collectibles[i], pos);
				break;
			}
		}

	}

	public void GenerateWeatherCube(Vector3 pos){
		pos.y += Random.Range(Ymin, Ymax);
		pool.SpawnObject(weather, pos);
	}
}
