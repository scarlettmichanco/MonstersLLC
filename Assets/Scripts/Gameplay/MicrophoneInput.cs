using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MicrophoneInput : MonoBehaviour {

public float sensitivity = 100;
public float pitch = 0;

	// Use this for initialization
	void Start () {
		audio.clip = Microphone.Start(null, true, 10, 44100);
		audio.loop = true;
		audio.mute = true;
		while (!(Microphone.GetPosition(AudioInputDevice) > 0)){} // wait for recording
		audio.Play();
		
	}

	float GetVolumeLevel() {
		float[] data = new float[256];
		audio.GetOutputData(data, 0);
		float average = 0;
		foreach(float vSet in data) {
			average += Mathf.abs(vSet);
		}
		return average/256;
	}
	
	// Update is called once per frame
	void Update () {
		// set pitch equal to average volume level * sensitivity;
		pitch = GetVolumeLevel() * sensitivity;
	}
}
