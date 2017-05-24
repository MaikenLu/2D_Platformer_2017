using UnityEngine;
using System.Collections;

public class RadiusEnemy : MonoBehaviour {
	protected bool playerIsInRadius;
	public bool IsPlayerInRadius(){
		return this.playerIsInRadius;
	}
	public void OnTriggerStay2D(Collider2D coll){
		Debug.Log(coll.transform.tag);
		if(coll.gameObject.tag=="Player"){
			playerIsInRadius=true;
		}
	}
	public void OnTriggerExit2D(Collider2D coll){
		if(coll.gameObject.tag=="Player"){
			playerIsInRadius=false;
		}
	}
}
