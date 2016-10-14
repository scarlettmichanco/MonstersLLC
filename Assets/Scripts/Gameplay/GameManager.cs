using UnityEngine;
using System.Collections;

public class GameManager : GenericSingletonClass<GameManager> {

	private bool RoundStarted = false;

	private int totalPoints = 0;

	// Use this for initialization
	void Start()
	{

	}

	public void StartRound()
	{
		RoundStarted = true;
	}

	public void EndRound()
	{
		//display gameover card,

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
