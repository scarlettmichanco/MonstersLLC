﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PointsOnCollision : MonoBehaviour {
	[Tooltip("Number of points to award during collision")]
	public int NumberOfPoints;

	[Tooltip("Multiplier for force of impact (set to 0 for no difference)")]
	public float ForceMultiplier = 0.0f;

	[Tooltip("Minimum relative velocity to assign points")]
	public float MinimumForceRequired = 0.25f;

	[Tooltip("UI Toast Prefab to spawn on points awarded")]
	public GameObject UIToastPrefab;

	private bool hasCollided = false;

	// Use this for initialization
	void Start () {
		
	}

	void OnCollisionEnter (Collision col)
    {
		if (hasCollided)
		{
			return;
		}

		if (col.relativeVelocity.magnitude < MinimumForceRequired)
		{
			return;
		}

		int extraForcePoint = Mathf.FloorToInt(ForceMultiplier * col.relativeVelocity.magnitude);

		int pointsToAdd = NumberOfPoints + extraForcePoint;
		if (!hasCollided)
		{
			GameObject rm = GameObject.FindWithTag("RoundManager");
			if (rm != null)
			{
				if (!rm.GetComponent<RoundManager>().RoundStarted)
					return;

				rm.GetComponent<RoundManager>().AddPoints(pointsToAdd);
			}
		}

		if (UIToastPrefab == null)
		{
			UIToastPrefab = GameObject.FindWithTag("RoundManager").GetComponent<RoundManager>().UIToastPrefab;
		}
		
		GameObject t = Instantiate(UIToastPrefab, col.contacts[0].point, Quaternion.identity) as GameObject;
		if (pointsToAdd > 12)
		{
			t.GetComponent<UIToast>().Toast(UIToast.Scare.Large);
		}else{
			t.GetComponent<UIToast>().Toast(UIToast.Scare.Small);
		}
		

        hasCollided = true;
    }
}
