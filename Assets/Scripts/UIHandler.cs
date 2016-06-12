using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour {

	GameObject menu;
	GameObject settings;
	GameObject overlayToggler;

	void Start(){
		menu = GameObject.FindGameObjectWithTag ("Menu");
		settings = GameObject.FindGameObjectWithTag ("Settings");
		overlayToggler = GameObject.FindGameObjectWithTag ("OverlayToggle");
		overlayToggler.GetComponent<Toggle> ().isOn = intToBool(PlayerPrefs.GetInt("Overlay"));
	}
	
	public void onClick(){
		menu.SetActive(true);
		settings.SetActive(false);
	}

	public void onToggleOverlay(){
		PlayerPrefs.SetInt ("Overlay", overlayToggler.GetComponent<Toggle>().isOn ? 1 : 0);
	}

	public bool intToBool(int i){
		if (i == 1)
			return true;
		return false;
	}

}