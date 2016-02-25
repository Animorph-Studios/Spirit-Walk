using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {

	// switches//
	public bool bird = false;
	public bool human = true;
	public bool wolf = false;
	public bool bear = false;
	public bool onground = false;
	public bool doublejump = false;

	//human variables//
	public float movementspeed = 7.5f;
	public float jumpspeed = 150f;

	// wolf variables//
	public float movementspeedwolf = 15f;
	public float jumpspeedwolf = 250f;

	// bird variables//
	public float movementspeedbird = 10f;
	public float jumpspeedbird = 100f;

	// Bear Variables
	public float movementSpeedBear = 7.5f;
	public float jumpSpeedBear = 150f;

	public string form = "human";
	public bool formChoice = true;
	public bool 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		switch (formChoice) 
		{
		case Input.GetKey (KeyCode.J):
			form = "wolf";
			WolfForm ();
			break;
		case Input.GetKey (KeyCode.K):
			form = "bear";
			BearForm ();
			break;
		case Input.GetKey (KeyCode.L):
			form = "bird";
			BirdForm();
			break;
		default: 
			form = "human";
			HumanForm ();
			break;
		}
	}

	void WolfForm()
	{
		if ((onground | doublejump) & Input.GetKeyDown (KeyCode.W))
		{
			rigidbody2D.AddForce (Vector2.up * jumpspeedwolf);
			doublejump = false;
		}
		if (onground == true)
			if (Input.GetKey (KeyCode.D)) 
		{
			rigidbody2D.AddForce (Vector2.right * movementspeedwolf);
		}
		if (onground == true)
			if (Input.GetKey (KeyCode.A))
		{
			rigidbody2D.AddForce (Vector2.right * -movementspeedwolf);
		}
	}

	void HumanForm()
	{
		if ((onground | doublejump) & Input.GetKeyDown (KeyCode.W))
		{
			rigidbody2D.AddForce (Vector2.up * jumpspeed);
			doublejump = false;
		}
		if (onground == true)
			if (Input.GetKey (KeyCode.D)) 
		{
			rigidbody2D.AddForce (Vector2.right * movementspeed);
		}
		if (onground == true)
			if (Input.GetKey (KeyCode.A))
		{
			rigidbody2D.AddForce (Vector2.right * -movementspeed);
		}
	}

	void BirdForm()
	{
		if ( Input.GetKey (KeyCode.W)){
			rigidbody2D.AddForce (Vector2.up * jumpspeedbird);
		}
			if (Input.GetKey (KeyCode.D)) {
			rigidbody2D.AddForce (Vector2.right * movementspeedbird);
		}
			if (Input.GetKey (KeyCode.A)){
			rigidbody2D.AddForce (Vector2.right * -movementspeedbird);
		}
	}

	void BearForm()
	{
		if (Input.GetKey (KeyCode.W)) {
			rigidbody2D.AddForce (Vector2.up * jumpSpeedBear);
		}
		if (Input.GetKey (KeyCode.D)) {
			rigidbody2D.AddForce (Vector2.right * movementSpeedBear);
		}
		if (Input.GetKey (KeyCode.A)) {
			rigidbody2D.AddForce (Vector2.left * movementSpeedBear);
		}
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "ground") 
		{
			onground = true;
		}
	}
	
	void OnCollisionExit2D(Collision2D other)
	{
		if (other.gameObject.tag == "ground") 
		{
			onground = false;
			doublejump = true;
		}
	}







}
