using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : GenericSingletonClass<GameManager> {

	[Header("Gameplay Settings")]
	[Tooltip("Round time in seconds")]
	public int RoundTimeInSeconds = 60;

	[Header("UI/Round Bindings")]
	[Tooltip("UI GameObject for RoundOver Card")]
	public GameObject UIRoundOver;
	[Tooltip("UI Text element for Timer Countdown display")]
	public Text CountdownText;
	[Tooltip("Audio source for alarm going off")]
	public AudioSource AlarmAudio;
	[Header("Round Over UI Bindings")]
	public Text TitleLabel;
	public Text ScarePointsLabel;
	public Text TimeRemainingLabel;
	public Text RoarPowerLabel;

	public Text GradeLabel;

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

	public void EndRound(bool success)
	{
		if (!RoundStarted)
			return;

		
			
		//display gameover card,
		UIRoundOver.SetActive(true);
		//
		RoundStarted = false;
	}

	void SetScarePoints(int points)
	{
		ScarePointsLabel.text = "+" + points;
	}

	void SetTimeRemainingPoints(int points)
	{
		TimeRemainingLabel.text = "+" + points;
	}

	void SetRoarPower(float multi)
	{
		RoarPowerLabel.text = multi.ToString() + "x";
	}

	void SetGrade(int grandTotalPoints)
	{
		string grade = "F";
		if (grandTotalPoints > 20)
		{
			grade = "D";
		}
		if (grandTotalPoints > 40)
		{
			grade = "C";
		}
		if (grandTotalPoints > 50)
		{
			grade = "B";
		}
		if (grandTotalPoints > 60)
		{
			grade = "A";
		}
		if (grandTotalPoints > 80)
		{
			grade = "A+";
		}
	}

	public void NoiseEventTriggered()
	{
		Debug.Log("End Round from noise!");
		EndRound(true);
	}
	
	// Update is called once per frame
	void Update () {
		if (RoundStarted)
		{
			if (Mathf.FloorToInt(timeRemaining) <= 0)
			{
				//trigger alarm code
				AlarmAudio.Play();
				EndRound(false);
				CountdownText.text = "00:00";
				return;
			}
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
