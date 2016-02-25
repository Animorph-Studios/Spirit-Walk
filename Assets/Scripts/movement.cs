using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour 
{
	//OtherVar//
	public float energy = 100f;
	public float chargespeed = 10f;
	public float energylimit = 100f;
	public int featherscore = 0;
	// switches//
	public bool bird = false;
	public bool human = true;
	public bool wolf = false;
	public bool onground = false;
	public bool doublejump = false;
	//human variables//
	public float movementspeed = 10f;
	public float jumpspeed = 300f;
	// wolf variables//
	public float movementspeedwolf = 15f;
	public float jumpspeedwolf = 250f;
	public float wenergydrain = 30;
	// bird variables//
	public float movementspeedbird = 10f;
	public float jumpspeedbird = 200f;
	public float benergydrain = 40;
	void Start () 
	{
	}


	void Update () 
	{
		EnergyBar ();
		if (human == true) 
		{
			Humanform ();
		}	
		if (wolf == true & energy != 0) 
		{
			Wolfform ();
		}
		if (bird == true & energy != 0) 
		{
			Birdform ();
		}

		if (Input.GetKey (KeyCode.K)) // WOLF form switch//
		{
			wolf = true;
			human = false;
			bird = false;
		} 
		else if (Input.GetKey (KeyCode.L)) // Bird form switch//
		{
			wolf = false;
			human = false;
			bird = true;
		} 
		else 
		{
			bird = false;
			human = true;
			wolf = false;
		}

	}







	void Wolfform()
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
	void Humanform()
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
	void Birdform()
	{
		if ( Input.GetKeyDown (KeyCode.W))
		{
			rigidbody2D.AddForce (Vector2.up * jumpspeedbird);
		}
			if (Input.GetKey (KeyCode.D)) 
		{
			rigidbody2D.AddForce (Vector2.right * movementspeedbird);
		}
			if (Input.GetKey (KeyCode.A))
		{
			rigidbody2D.AddForce (Vector2.right * -movementspeedbird);
		}
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.name == "ground") {
			onground = true;
		}

		if (other.gameObject.name == "platform") {
			Destroy (other.gameObject, 1);
		}

		if (other.gameObject.tag == "enemy"){
			Application.LoadLevel ("Game Over");
		}
	}

	
	void OnCollisionExit2D(Collision2D other)
	{
		if (other.gameObject.name == "ground")
			onground = false;
		doublejump = true;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "water") 
		{
			Application.LoadLevel ("Game Over");
		}
		//Feather collection//
		if (other.gameObject.tag == "feather") 
		{
			Destroy (other.gameObject);
			featherscore += 1;
			ScoreSave();
		}
	}
	// Score goes to GameDataScript//
	public void ScoreSave()
	{
		GameObject gameData = GameObject.Find ("gameData");
		if (gameData != null) 
		{
			GameDataScript gameDataScript = gameData.GetComponent<GameDataScript>();
			gameDataScript.score = featherscore;
		}
	}
	// Energy bar settings //
	void EnergyBar()
	{
		if (energy < energylimit & wolf == false & bird == false) 
		{
			energy += Time.deltaTime * chargespeed;
		}
		if (wolf == true) 
		{
			energy -= Time.deltaTime * wenergydrain;
		}
		if (bird == true)
		{
			energy -= Time.deltaTime * benergydrain;
		}
		if (energy < 0) 
		{
			energy = 0;
		}
	}
}
