using UnityEngine;
using System.Collections;

public class groundenemy : MonoBehaviour {
	public Transform center, right, left, topleft, topright, toplefte, toprighte;
	public bool rightray = false;
	public bool leftray = false;
	public bool toprayl = false;
	public bool toprayr = false;
	public float speed = 10f;
	public float pouncespeed = 10f;
	public float jump = 10f;
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		Detection ();
		Movement ();
	}
	void Detection ()
	{
		Debug.DrawLine (center.position, right.position, Color.blue);
		rightray = Physics2D.Linecast (center.position, right.position);
		Debug.DrawLine (center.position, left.position, Color.blue);
		leftray = Physics2D.Linecast (center.position, left.position);
		Debug.DrawLine (toplefte.position, topleft.position, Color.blue);
		toprayl = Physics2D.Linecast (toplefte.position, topleft.position);
		Debug.DrawLine (toprighte.position, topright.position, Color.blue);
		toprayr = Physics2D.Linecast (toprighte.position, topright.position);

	}
	void Movement ()
	{
		if (rightray == true) 
		{
			rigidbody2D.transform.Translate(Vector2.right * speed * Time.deltaTime);
		}
		if (leftray == true) 
		{
			rigidbody2D.transform.Translate(Vector2.right * -speed * Time.deltaTime);
		}
		if (toprayl == true) 
		{
			rigidbody2D.AddForce(Vector2.up * jump);
			rigidbody2D.AddForce(Vector2.right * -pouncespeed);
		}
		if (toprayr == true) 
		{
			rigidbody2D.AddForce(Vector2.up * jump);
			rigidbody2D.AddForce(Vector2.right * pouncespeed);
		}
	}
}
