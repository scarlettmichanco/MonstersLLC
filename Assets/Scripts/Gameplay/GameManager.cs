using UnityEngine;
using System.Collections;

public class GameManager : GenericSingletonClass<GameManager> {

	public GameObject UIRoundOver;

	private bool RoundStarted = false;

	private int totalPoints = 0;

	// Use this for initialization
	void Start()
	{

	}

	public void StartRound()
	{
		UIRoundOver.SetActive(false);
		RoundStarted = true;
		totalPoints = 0;
	}

	public void EndRound()
	{
		//display gameover card,
		UIRoundOver.SetActive(true);
		//
		RoundStarted = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddPoints(int points)
	{
		Debug.Log("Added points: " + points);
		totalPoints += points;
	}
}
