using UnityEngine;
using System.Collections;

public class ColorTransformator : Transformator {

	protected override bool IsDifferent(GameObject player){
		return !(this.radius.GetNearestEnemy().GetComponent<Character>().GetColor()==player.GetComponent<Character>().GetColor());
	}

	protected override void Switch(GameObject player){
		player.GetComponent<Character>().SwitchColor();
		this.radius.GetNearestEnemy().GetComponent<Character>().SwitchColor();
	}
}
