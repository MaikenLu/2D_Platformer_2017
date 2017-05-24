using UnityEngine;
using System.Collections;

public abstract class Character : MonoBehaviour {
	public bool red;
	public bool big;

	protected Vector3 size;
	protected Color color;
	protected float velocity;
	protected float jumpForce;

	private bool isJump;

	protected Rigidbody2D rigid;

	//----------------------------------------

	void Start(){
		Init ();
	}
	public void Init(){
		this.rigid = GetComponent<Rigidbody2D> ();

		this.velocity = CharacterValues.LOW_VELOCITY;


		this.jumpForce = CharacterValues.JUMP_FORCE;
		if(red){
			SetColor(CharacterValues.RED_COLOR);
		}else{
			SetColor(CharacterValues.BLUE_COLOR);
		}
		if(big){
			SetSize(CharacterValues.BIG_SIZE);
		}else{
			SetSize(CharacterValues.SMALL_SIZE);
		}
	}
	public void Update(){
		this.Control ();
	}
	//---------------------------------------
	public Vector3 GetSize(){
		return this.size;
	}
	protected void SetSize(Vector3 size){
		this.size = size;
		this.transform.localScale=size;
	}
	public Color GetColor(){
		return this.color;
	}
	protected void SetColor(Color color){
		this.color = color;
		this.GetComponent<SpriteRenderer> ().color = color;
	}
	public float GetVelocity(){
		return this.velocity;
	}
	protected void SetVelocity(float velocity){
		this.velocity = velocity;
	}
	//----------------------------------------
	protected abstract void Control();
	protected abstract void Walk ();

	protected void Jump(){
		if (!isJump) {
			this.rigid.AddForce (new Vector2 (0, this.jumpForce));
			isJump = true;
		}
	}
	public void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "ground") {
			isJump = false;
		}
	}

	public void CollideWithOtherCharacter(GameObject character){
		if (this.tag != character.tag) {
			if (this.GetSize ().x >= character.GetComponent<Character> ().GetSize ().x) {
				Destroy (character);
			}
		}
	}
	public void Climb(){
		Debug.LogError ("Not yet implemented");
	}
	public void SwitchColor(){
		if (this.color == CharacterValues.RED_COLOR) {
			this.SetColor(CharacterValues.BLUE_COLOR);
		}else if (this.color == CharacterValues.BLUE_COLOR) {
			this.SetColor (CharacterValues.RED_COLOR);
		}
	}
	public void SwitchSize(){
		if (this.size == CharacterValues.BIG_SIZE) {
			this.SetSize( CharacterValues.SMALL_SIZE);
			this.SetVelocity (CharacterValues.FAST_VELOCITY);
		}else if (this.size == CharacterValues.SMALL_SIZE) {
			this.SetSize (CharacterValues.BIG_SIZE);
			this.SetVelocity (CharacterValues.LOW_VELOCITY);
		}
	}



}
