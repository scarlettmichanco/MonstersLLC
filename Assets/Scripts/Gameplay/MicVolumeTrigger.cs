using UnityEngine;
using System.Collections;

public class MicVolumeTrigger : MonoBehaviour {

	public float Threshold = 100f;

	private AudioSource audioSource;
	private int _sampleWindow = 128;

	private string chosenDevice;

	// Use this for initialization
	void Start () {

		foreach (string device in Microphone.devices) {
            Debug.Log("Name: " + device);
        }

		//deviceName = "Built-in Microphone";

		audioSource = GetComponent<AudioSource>();
		chosenDevice = "Built-in Microphone";
		StartMicrophone(chosenDevice);
        
	}
	
	// Update is called once per frame
	void Update () {
		float level = LevelMax();
		if (level >= Threshold)
		{
			Debug.Log("Threshold met!");
			float multi = (level-Threshold)/100;
			multi += 1;

			GameObject.FindWithTag("RoundManager").GetComponent<RoundManager>().NoiseEventTriggered(multi);
			StopMicrophone(chosenDevice);
		}		
	}

	private float LevelMax()
    {
        float levelMax = 0;
        float[] waveData = new float[_sampleWindow];
        int micPosition = Microphone.GetPosition (null) - (_sampleWindow + 1);
        if (micPosition < 0) {
            return 0;
        }
        audioSource.clip.GetData (waveData, micPosition);
        for (int i = 0; i < _sampleWindow; ++i) {
            float wavePeak = waveData [i] * waveData [i];
            if (levelMax < wavePeak) {
                levelMax = wavePeak;
            }
        }
        return levelMax * 1000;
    }

	public void StartMicrophone(string deviceName)
	{
		audioSource.clip = Microphone.Start(deviceName, true, 5, 44100);
	}

	public void StopMicrophone(string deviceName)
	{
		Microphone.End(deviceName);
	}

	void OnDestroy()
	{
		StopMicrophone(chosenDevice);
	}
}
