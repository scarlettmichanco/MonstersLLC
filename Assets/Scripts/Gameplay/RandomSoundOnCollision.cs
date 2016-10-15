using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class RandomSoundOnCollision : MonoBehaviour {

	public float SoundDelay = 0.5f;

	public AudioClip[] SoundLibrary;

	private float lastSound = 0f;

	private AudioSource _as;

	void Start()
	{
		_as = GetComponent<AudioSource>();
	}
	
	void OnCollisionEnter(Collision col)
	{
		if (Time.time > lastSound)
		{
			AudioClip snd = SoundLibrary[Random.Range(0, SoundLibrary.Length)];
			_as.clip = snd;
			_as.Play();
			lastSound = Time.time + SoundDelay;
		}
	}
}
