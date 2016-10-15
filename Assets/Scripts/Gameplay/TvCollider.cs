using UnityEngine;
using System.Collections;

public class TvCollider : MonoBehaviour {

	public GameObject tvStatic;
	public GameObject tvLight;
	public Material screenMaterial;
	public AudioSource staticSound;

	public Transform spawnToast;

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
		if (turnedOn) {
			return;
		}
		tvStatic.SetActive (true);
		tvLight.SetActive (true);

		if (!staticSound.isPlaying)
		{
			staticSound.Play();
		}
		turnedOn = true;

		GameObject UIToastPrefab = null;
		if (UIToastPrefab == null)
		{
			UIToastPrefab = GameObject.FindWithTag("RoundManager").GetComponent<RoundManager>().UIToastPrefab;
		}
		GameObject.FindWithTag("RoundManager").GetComponent<RoundManager>().AddPoints(25);
		
		GameObject t = Instantiate(UIToastPrefab, spawnToast.position, Quaternion.identity) as GameObject;
		t.GetComponent<UIToast>().Toast(UIToast.Scare.Large);

	}

}
