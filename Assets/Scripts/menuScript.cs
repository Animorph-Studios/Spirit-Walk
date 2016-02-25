using UnityEngine;
using System.Collections;

public class menuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadMainLevel()
	{
		Application.LoadLevel ("prototype");
	}

	public void QuitGame() 
	{
		Application.Quit ();
	}
	public void Options()
	{
		Application.LoadLevel ("Options");
	}
}
