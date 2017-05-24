using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Transformator : MonoBehaviour {

	protected TransformatorRadius radius;

	void Start(){
		radius=GetComponentInChildren<TransformatorRadius>();
	}

	protected void Activate(GameObject player){
		if (radius.GetAmountOfEnemies()>0 && IsDifferent (player)) {
			Debug.Log("Switch player and enemey");
			Switch(player);
		}
	}

	protected abstract bool IsDifferent(GameObject player);

	protected abstract void Switch(GameObject player);

	public void OnTriggerEnter2D(Collider2D coll){
		if(coll.gameObject.tag=="Player"){
			this.Activate(coll.gameObject);
		}
	}


}
