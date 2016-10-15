using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class RestartOnCollide : MonoBehaviour {

	void Start() {
		
	}

	void OnTriggerEnter(Collider col)
	{
	  SceneManager.LoadScene ("Bedroom");
	}
}
