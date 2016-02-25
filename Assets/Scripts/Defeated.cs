using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Defeated : MonoBehaviour {
	public Text finalscore;
	// Use this for initialization
	void Start () 
	{
		GameObject gameData = GameObject.Find("gameData"); //Refresh the gamedatascript on start//
		if (gameData != null) 
		{
			GameDataScript gameDataScript
				= gameData.GetComponent<GameDataScript> ();
			finalscore.text =  " score: " + gameDataScript.score;
		}
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
