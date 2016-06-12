using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisablePanel : MonoBehaviour {

	Image imageOverlay;
	BoxCollider2D _collider;

	bool disabled;
	float lastTrigger;
	Color old;
	public float seconds;

	void Start () {
		imageOverlay = GetComponent<Image> ();
		_collider = GetComponent<BoxCollider2D> ();
	}

	void Update(){
		if (disabled) {
			if(Time.time - lastTrigger > seconds){
				imageOverlay.color = old;
				_collider.enabled = true;
				disabled = false;
			}
		}
	}

	public void disable(){
		lastTrigger = Time.time;
		if (!disabled) {
			old = imageOverlay.color;
			imageOverlay.color = Color.red;
			_collider.enabled = false;
			disabled = true;
		}
	}

}
