using UnityEngine;
using System.Collections;

public class Enemy : Character {
	protected Vector2 detectionRadius=new Vector2(8,3.25f);
	//protected bool playerIsInRadius=false;
	protected float reachValue=CharacterValues.ReachSizeEnemy;
	protected  override void Control(){
	//	if(playerIsInRadius){
		Debug.Log(IsPlayerVisible());
		if(IsPlayerVisible()){
			this.Walk();
		}
			
	//	}
	}
	protected  override void Walk (){
		this.rigid.velocity=new Vector2(GetDirectionToPlayer().normalized.x*this.velocity,rigid.velocity.y);
	}


	protected bool IsPlayerVisible(){
		bool visible=true;
		bool playerVisible=false;
		RaycastHit2D[] hits=Physics2D.RaycastAll(this.transform.position,GetDirectionToPlayer(),reachValue);
		foreach(RaycastHit2D hit in hits){
			if(visible && hit.transform.tag=="Player"){
				playerVisible=true;
			}
			if(hit.transform.tag=="wall" || hit.transform.tag=="barriere" || hit.transform.tag=="ground"){
				visible=false;
			}
		}
		return playerVisible;
	}
	private Vector2 GetDirectionToPlayer(){
		GameObject player=GameObject.Find("Player");
		return player.transform.position-this.transform.position;
	}
//	public void OnTriggerStay2D(Collider2D coll){
//		Debug.Log(coll.transform.tag);
//		if(coll.gameObject.tag=="Player"){
//			playerIsInRadius=true;
//		}
//	}
//	public void OnTriggerExit2D(Collider2D coll){
//		if(coll.gameObject.tag=="Player"){
//			playerIsInRadius=false;
//		}
//	}



}
