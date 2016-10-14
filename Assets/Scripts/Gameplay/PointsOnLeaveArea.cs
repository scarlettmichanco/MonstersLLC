using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PointsOnLeaveArea : MonoBehaviour {
	[Tooltip("Number of points to award when leaving")]
	public int NumberOfPoints;

	[Tooltip("Trigger Collider which must be left")]
	public Collider LeaveArea;

	private bool hasLeftArea = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit(Collider other) {
        if (other == LeaveArea && !hasLeftArea)
		{
			GameManager.Instance.AddPoints(NumberOfPoints);
			hasLeftArea = true;
		}
    }
}
