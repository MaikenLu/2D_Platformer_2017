using UnityEngine;
using System.Collections;

public class Barriere : MonoBehaviour {
	public bool red;
	private Color color;
	// Use this for initialization
	void Start () {
		if (red) {
			SetColor(CharacterValues.RED_COLOR);
		} else {
			SetColor(CharacterValues.BLUE_COLOR);
		}
	}

	public Color GetColor(){
		return this.color;
	}
	protected void SetColor(Color color){
		this.color = color;
		GetComponent<SpriteRenderer>().color =color;

	}

//	public void OnCollisionEnter2D(Collision2D coll){
//		Character character = coll.gameObject.GetComponent<Character> ();
//		if (character != null) {
//			if (character.GetColor () == this.color) {
//				Debug.Log("Character with "+character.GetColor());
//				this.GetComponent<BoxCollider2D> ().enabled = false;
//			}
//		}
//	}
	public void OnTriggerEnter2D(Collider2D coll){
		Character character = coll.gameObject.GetComponent<Character> ();
		if (character != null) {
			if (character.GetColor () == this.color) {
				this.GetComponent<BoxCollider2D> ().enabled = false;
			}
		}
	}
	public void OnTriggerExit2D(Collider2D coll){	
		Character character = coll.gameObject.GetComponent<Character> ();
		if (character != null) {
			if (character.GetColor () == this.color) {
				this.GetComponent<BoxCollider2D> ().enabled = true;
			}
		}
	}
}
