using UnityEngine;
using System.Collections;

public class TvCollider : MonoBehaviour {

	public GameObject tvStatic;
	public GameObject tvLight;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider col)
	{
		tvStatic.SetActive (true);
		tvLight.SetActive (true);
	}

}
