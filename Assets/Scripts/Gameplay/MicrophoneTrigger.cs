using UnityEngine;
using System.Collections;

public class MicrophoneTrigger : MonoBehaviour {

	public GameObject audioInputObject;
	public float threshold = 1.0f;
	public GameObject scareSoundLevel;
	MicrophoneInput micIn;
	// Use this for initialization
	void Start () {
		if (audioInputObject == null)
			audioInputObject = GameObject.Find("AudioInputObject");
		micIn = (MicrophoneInput) audioInputObject.GetComponent("MicrophoneInput");
	}
	
	// Update is called once per frame
	void Update () {
		float L = micIn.pitch;
		if (L > threshold) {
			Debug.Log("inputLevel");
			Debug.Log(threshold);
		}
	}
}
