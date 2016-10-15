using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class RestartOnCollide : MonoBehaviour {

	void OnTriggerEnter(Collider col)
	{

		SceneManager.LoadScene ("Bedroom");
		//GameManager.Instance.StartRound();

	}
}
