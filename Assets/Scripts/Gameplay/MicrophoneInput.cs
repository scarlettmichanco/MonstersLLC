using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MicrophoneInput : MonoBehaviour {

public float sensitivity = 100;
public float pitch = 0;

	// Use this for initialization
	void Start () {
		AudioSource audio = GetComponent<AudioSource>();
		GetComponent<AudioSource>().clip = Microphone.Start(null, true, 10, 44100);
		GetComponent<AudioSource>().loop = true;
		GetComponent<AudioSource>().mute = true;
		while (!(Microphone.GetPosition(null) > 0)){} // wait for recording
		audio.Play();
		audio.Play(44100);
		
	}

	float GetVolumeLevel() {
		float[] data = new float[256];
		GetComponent<AudioSource>().GetOutputData(data, 0);
		float avg = 0;
		foreach(float vSet in data) {
			avg += Mathf.Abs(vSet);
		}
		return avg/256;
	}
	
	// Update is called once per frame
	void Update () {
		// set pitch equal to average volume level * sensitivity;
		pitch = GetVolumeLevel() * sensitivity;
		Debug.Log("pitch");
		Debug.Log(pitch);
	}
}
