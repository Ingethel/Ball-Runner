using UnityEngine;
using System.Collections;

public class BadStarCollect : ICollect {
	
	DisablePanel UI;

	protected override void Behave(){
		UI = FindObjectOfType<DisablePanel> ();
		UI.disable ();
	}
	
}
