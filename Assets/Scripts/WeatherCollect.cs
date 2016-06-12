using UnityEngine;
using System.Collections;

public class WeatherCollect : ICollect {

	ActivateSnow snowManager;

	protected override void Start(){
		base.Start ();
		snowManager = FindObjectOfType<ActivateSnow>();
	}

	protected override void Behave(){
		if (snowManager.snowing)
			snowManager.stopSnow ();
		else
			snowManager.startSnow();
	}

}
