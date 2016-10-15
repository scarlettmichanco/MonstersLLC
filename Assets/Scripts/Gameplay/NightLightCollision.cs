using UnityEngine;
using System.Collections;

public class NightLightCollision : MonoBehaviour {

	public Light light;

	void OnCollisionEnter(Collision col)
	{
		Rigidbody rb = GetComponent<Rigidbody>();
		rb.isKinematic = false;
		rb.useGravity = true;
		light.enabled = false;
	}
}
