using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TransformatorRadius : MonoBehaviour {
	protected List<GameObject> enemies=new List<GameObject>();

	public int GetAmountOfEnemies(){
		return enemies.Count;
	}
	public GameObject GetNearestEnemy(){
		GameObject nearest = null;
		float olddistance = float.MaxValue;
		float distance=float.MaxValue;
		foreach (GameObject enemy in enemies) {
			olddistance = distance;
			distance = Mathf.Abs ((enemy.transform.position - this.transform.position).magnitude);
			if (distance <= olddistance) {
				nearest=enemy;
			}
		}
		return nearest;
	}
	public void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "enemy") {
			enemies.Add (coll.gameObject);
		}
	}
	public void OnTriggerStay2D(Collider2D coll){
		if(coll.gameObject.tag=="enemy" && !enemies.Contains(coll.gameObject)){
			enemies.Add(coll.gameObject);
		}
	}
	public void OnTriggerExit2D(Collider2D coll){
		if (coll.gameObject.tag == "enemy") {
			enemies.Remove (coll.gameObject);
		}
	}
}
