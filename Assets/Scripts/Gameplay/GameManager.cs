using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : GenericSingletonClass<GameManager> {

	[Tooltip("Round time in seconds")]
	public int RoundTimeInSeconds = 60;
	[Tooltip("UI GameObject for RoundOver Card")]
	public GameObject UIRoundOver;
	[Tooltip("UI Text element for Timer Countdown display")]
	public Text CountdownText;

	private bool RoundStarted = false;

	private int totalPoints = 0;

	private float timeRemaining = 0f;

	// Use this for initialization
	void Start()
	{
		//for debug.
		StartRound();
	}

	public void StartRound()
	{
		UIRoundOver.SetActive(false);
		RoundStarted = true;
		totalPoints = 0;
		timeRemaining = RoundTimeInSeconds;
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
		if (RoundStarted)
		{
			timeRemaining -= Time.deltaTime;
			string minutes = Mathf.Floor(timeRemaining / 60).ToString("00");
 			string seconds = (timeRemaining % 60).ToString("00");
			CountdownText.text = minutes + ":" + seconds;
		}
		
	}

	public void AddPoints(int points)
	{
		Debug.Log("Added points: " + points);
		totalPoints += points;
	}
}
