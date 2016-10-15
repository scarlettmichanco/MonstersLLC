using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RoundManager : MonoBehaviour {

	
	[Header("Gameplay Settings")]
	[Tooltip("Round time in seconds")]
	public int RoundTimeInSeconds = 60;

	[Header("UI/Round Bindings")]
	public GameObject kid;
	public GameObject UIToastPrefab;
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

	[Header("Audio Sources")]
	public AudioSource BuildUp;
	public float BuildUpLength;

	private bool animatescare = false;



	public bool RoundStarted = false;

	private int totalPoints = 0;

	private float timeRemaining = 0f;

	private Vector3 startRot;

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

	public void EndRound(bool success){
		EndRound(success, 1f);
	}

	public void EndRound(bool success, float roarPower)
	{
		if (!RoundStarted)
			return;

		if (success)
		{
			TitleLabel.text = "SUCCESSFUL SCARE";

			SetScarePoints(totalPoints);
			SetTimeRemainingPoints(Mathf.FloorToInt(RoundTimeInSeconds-timeRemaining));
			SetRoarPower(roarPower);
			SetGrade(Mathf.FloorToInt((totalPoints + Mathf.FloorToInt(RoundTimeInSeconds-timeRemaining)) * roarPower));
		}else{
			TitleLabel.text = "FAILED SCARE";
			TitleLabel.color = Color.red;

			SetScarePoints(0);
			SetTimeRemainingPoints(0);
			SetRoarPower(0);
			SetGrade(0);
		}

		startRot = kid.transform.localEulerAngles;
		animatescare = true;
			
		//display gameover card,
		UIRoundOver.SetActive(true);
		//
		RoundStarted = false;
	}

	void SetScarePoints(int points)
	{
		ScarePointsLabel.text = "+" + points;
		if (points == 0)
		{
			ScarePointsLabel.color = Color.red;
		}
	}

	void SetTimeRemainingPoints(int points)
	{
		TimeRemainingLabel.text = "+" + points;
		if (points == 0)
		{
			TimeRemainingLabel.color = Color.red;
		}
	}

	void SetRoarPower(float multi)
	{
		RoarPowerLabel.text = multi.ToString("0.00") + "x";
		if (multi == 0f)
		{
			RoarPowerLabel.color = Color.red;
		}
	}

	void SetGrade(int grandTotalPoints)
	{
		string grade = "F";

		if (grandTotalPoints == 0)
		{
			GradeLabel.color = Color.red;
		}

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

		GradeLabel.text = grade;
	}

	public void NoiseEventTriggered(float roarPower)
	{
		Debug.Log("End Round from noise!");
		EndRound(true, roarPower);
	}
	
	private float animateTimer = 0;
	// Update is called once per frame
	void Update () {

		if (animatescare)
		{
			animateTimer += Time.deltaTime;
			kid.transform.localEulerAngles = Vector3.Lerp(startRot, new Vector3(0, 120f, 90f), Mathf.Clamp01(animateTimer/0.25f));
		}

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

			if (timeRemaining - BuildUpLength <= 0 && !BuildUp.isPlaying)
			{
				BuildUp.Play();
			}

			timeRemaining -= Time.deltaTime;
			string minutes = Mathf.Floor(timeRemaining / 60).ToString("00");
 			string seconds = (timeRemaining % 60).ToString("00");
			CountdownText.text = minutes + ":" + seconds;
		}
	}

	public void AddPoints(int points)
	{
		if (!RoundStarted)
			return;

		Debug.Log("Added points: " + points);
		totalPoints += points;
	}
}
