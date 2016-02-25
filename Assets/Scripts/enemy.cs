
using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {

	public Transform target;
	public float moveSpeed =2f;
	public float moveSpeed2 =3f;
	public float fov =20;
	public float ffov =7;
	public bool trig = false;

	private Transform myTransform;
	
	void Awake() {
		myTransform = transform;
	}
	// Use this for initialization
	void Start () {
		GameObject go = GameObject.FindGameObjectWithTag("Player");
		
		target = go.transform;
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawLine(target.position, myTransform.position, Color.yellow);


		if(Vector2.Distance(target.position, myTransform.position) < fov) 
		{
			if(Vector2.Distance(target.position, myTransform.position) > ffov)
			{
			transform.position = Vector2.MoveTowards(myTransform.position, target.position, moveSpeed * Time.deltaTime);
			}
			else if(Vector2.Distance(target.position, myTransform.position) < ffov) 
			{
			transform.position = Vector2.MoveTowards(myTransform.position, target.position, moveSpeed2 * Time.deltaTime);
			}
		}
	}
}

