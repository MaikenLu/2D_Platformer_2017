using UnityEngine;
using System.Collections;

public class SizeTransformator :Transformator {

	protected override bool IsDifferent(GameObject player){
		return !(this.radius.GetNearestEnemy().GetComponent<Character>().GetSize()==player.GetComponent<Character>().GetSize());
	}

	protected override void Switch(GameObject player){
		player.GetComponent<Character>().SwitchSize();
		this.radius.GetNearestEnemy().GetComponent<Character>().SwitchSize();
	}
}
