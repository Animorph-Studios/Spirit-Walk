using UnityEngine;
using System.Collections;

public class optionscript : MonoBehaviour {
	float volume = 1.0f;
	public void LoadToMenu() // Load my level//
	{
		Application.LoadLevel("Mainmenu");
		
	}
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI()
	{
		GUI.color = Color.blue;
		GUI.Label (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 130, 200, 30), "Master Volume");
		volume = GUI.HorizontalSlider (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 30), volume, 0, 1.0f);
		AudioListener.volume = volume;
	}
}
