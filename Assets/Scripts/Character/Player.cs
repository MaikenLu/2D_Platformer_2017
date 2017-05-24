using UnityEngine;
using System.Collections;

public class Player : Character {

	private bool isClimbing;

	protected override void Walk (){
		float x=InputManager.instance.horizontalInput;
		x*=velocity;
		this.rigid.velocity=new Vector2(x,this.rigid.velocity.y);
	}
	protected override void Control(){

			this.Walk ();
	
		if ( InputManager.instance.verticalInput > 0 ) {
			this.Jump ();
		}
		if (isClimbing) {
			Climb ();
		}
	}
	public void OnCollisionEnter2D(Collision2D coll){
		base.OnCollisionEnter2D (coll);
		if (coll.gameObject.tag == "wall" && this.GetColor()==CharacterValues.RED_COLOR) {
			
			isClimbing = true;
		}
	}
	public void OnCollisionExit2D(Collision2D coll){
		base.OnCollisionEnter2D (coll);
		if (coll.gameObject.tag == "wall") {
			isClimbing = false;
		}
	}
	protected void Climb(){
		this.rigid.velocity = new Vector2 (rigid.velocity.x, InputManager.instance.verticalInput);


	}
}
