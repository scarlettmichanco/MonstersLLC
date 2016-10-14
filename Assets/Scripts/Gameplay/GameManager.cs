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
		if (!RoundStarted)
			return;

			
		//display gameover card,
		UIRoundOver.SetActive(true);
		//
		RoundStarted = false;
	}

	public void NoiseEventTriggered()
	{
		Debug.Log("End Round from noise!");
		EndRound();
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
