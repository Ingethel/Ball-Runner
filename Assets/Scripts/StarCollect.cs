using UnityEngine;
using System.Collections;

public class StarCollect : ICollect {

	public int value;

	protected override void Behave(){
		manager.addPoints(value);
	}
	
}
