using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class OnCollideLoadScene : MonoBehaviour {

	public string SceneName;

	void OnCollisionEnter (Collision col)
    {
		SceneManager.LoadScene (SceneName);
	}
}
