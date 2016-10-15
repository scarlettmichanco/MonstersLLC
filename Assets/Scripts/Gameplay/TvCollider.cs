using UnityEngine;
using System.Collections;

public class TvCollider : MonoBehaviour {

	public GameObject tvStatic;
	public GameObject tvLight;
	public Material screenMaterial;
	public AudioSource staticSound;

	private bool turnedOn = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!turnedOn) {
			return;
		}
		screenMaterial.mainTextureOffset = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
	}
	void OnTriggerEnter(Collider col)
	{
		tvStatic.SetActive (true);
		tvLight.SetActive (true);

		if (!staticSound.isPlaying)
		{
			staticSound.Play();
		}
		turnedOn = true;
	}

}
