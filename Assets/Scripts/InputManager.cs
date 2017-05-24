using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	public static InputManager instance;

	public float horizontalInput;
	public float verticalInput;
	public float horizontalXBox;
	public float verticalXBox;

	// Use this for initialization
	void Start () {
		if (instance ==null ) {
			instance = this;
		} else if(instance!=this){
			Destroy (instance);
		}
	}
	
	// Update is called once per frame
	void Update () {
		ReadInput ();
	}
	private void ReadInput(){
		this.horizontalInput = Input.GetAxis ("Horizontal");
		this.verticalInput = Input.GetAxis ("Vertical");
		this.horizontalXBox=Input.GetAxis("Horizontal_XBOX");
		this.verticalXBox=Input.GetAxis("Vertical_XBOX");
	}

}
