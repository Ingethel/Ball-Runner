using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActivateSnow : MonoBehaviour {

	public Camera _camera;
	public ParticleSystem[] snow;

	public Color clearSky;
	public Color notSoClearSky;

	public Color clearCloud;
	public Color snowCloud;

	public ObjectGeneration cloudManager;

	Color background;

	public bool snowing;

	public Material nearLeaf;
	public Material farLeaf;
	public Material cloud;

	void Start () {
		InstaClear ();
	}

	public void InstaClear(){
		snowing = false;
		for (int i = 0; i < snow.Length; i++) {
			snow[i].enableEmission = false;
		}
		_camera.backgroundColor = clearSky;
		cloud.color = clearCloud;
		nearLeaf.SetFloat ("_Snow", 1f);
		farLeaf.SetFloat ("_Snow", 1f);
		nearLeaf.SetFloat ("_ActiveSnow", 0f);
		farLeaf.SetFloat ("_ActiveSnow", 0f);
	}

	IEnumerator SkyColorTo(bool snowFlag){
		snowing = snowFlag;

		cloudManager.objSpawnProb = snowFlag ? 0.7f : 0.2f;

		Color skyColor = snowFlag ? notSoClearSky : clearSky;
		Color cloudColor = snowFlag ? snowCloud : clearCloud;

		if (!snowing) {
			for (int i = 0; i < snow.Length; i++) {
				snow [i].enableEmission = snowFlag;
			}
			GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().wind = false;
		}

		while (_camera.backgroundColor != skyColor) {
			yield return null;
			_camera.backgroundColor = Color.Lerp (_camera.backgroundColor, skyColor, 0.1f);
			cloud.color = Color.Lerp (cloud.color, cloudColor, 0.1f);
		}

		if (snowing) {
			for (int i = 0; i < snow.Length; i++) {
				snow [i].enableEmission = snowFlag;
			}
			GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerMovement> ().wind = true;
		}
		if (snowFlag) {
			nearLeaf.SetFloat ("_ActiveSnow", 1f);
			farLeaf.SetFloat ("_ActiveSnow", 1f);
			yield return new WaitForSeconds (1);
			nearLeaf.SetFloat ("_Snow", 0.5f);
			farLeaf.SetFloat ("_Snow", 0.5f);
			yield return new WaitForSeconds (3);
			nearLeaf.SetFloat ("_Snow", 0f);
			yield return new WaitForSeconds (3);
			farLeaf.SetFloat ("_Snow", 0f);
		} else {
			yield return new WaitForSeconds (1);
			nearLeaf.SetFloat ("_Snow", 0.5f);
			farLeaf.SetFloat ("_Snow", 0.5f);
			yield return new WaitForSeconds (3);
			farLeaf.SetFloat ("_Snow", 1f);
			yield return new WaitForSeconds (3);
			nearLeaf.SetFloat ("_Snow", 1f);
			nearLeaf.SetFloat ("_ActiveSnow", 0f);
			farLeaf.SetFloat ("_ActiveSnow", 0f);
		}

		yield break;
	}

	public void startSnow(){
		StartCoroutine (SkyColorTo(true));
	}

	public void stopSnow(){
		StartCoroutine (SkyColorTo(false));
	}
	
}
