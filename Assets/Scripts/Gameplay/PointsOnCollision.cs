using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PointsOnCollision : MonoBehaviour {
	[Tooltip("Number of points to award during collision")]
	public int NumberOfPoints;

	[Tooltip("Multiplier for force of impact (set to 0 for no difference)")]
	public float ForceMultiplier = 0.0f;

	[Tooltip("Minimum relative velocity to assign points")]
	public float MinimumForceRequired = 0.25f;

	private bool hasCollided = false;

	// Use this for initialization
	void Start () {
		
	}

	void OnCollisionEnter (Collision col)
    {
		if (col.relativeVelocity.magnitude < MinimumForceRequired)
		{
			return;
		}

		int extraForcePoint = Mathf.FloorToInt(ForceMultiplier * col.relativeVelocity.magnitude);

		if (!hasCollided)
		{
			GameManager.Instance.AddPoints(NumberOfPoints + extraForcePoint);
		}

        hasCollided = true;
    }
}
