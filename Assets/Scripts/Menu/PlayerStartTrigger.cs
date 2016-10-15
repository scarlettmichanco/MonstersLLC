using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerStartTrigger : MonoBehaviour {

	public GameObject UITurnAround;
	// Use this for initialization
	void Start () {
		UITurnAround.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col)
	{
		UITurnAround.SetActive(true);
	}
	
	void OnTriggerExit(Collider col)
	{
		UITurnAround.SetActive(false);
	}

	void OnTriggerStay(Collider col)
	{
		Debug.DrawRay(col.gameObject.transform.position, col.gameObject.transform.forward, Color.red);
		//check to see if user is looking in the correct location, if they are, load level.
		if (col.gameObject.CompareTag("MainCamera"))
		{
			//its player object
			RaycastHit hit;
			if (Physics.Raycast(col.gameObject.transform.position, col.gameObject.transform.forward, out hit))
			{
				if (hit.collider.gameObject.CompareTag("UILookAt"))
				{
					StartLevel();
				}
			}
            
		}
	}

	void StartLevel()
	{
		//FindGameObjectWithTag("RoundManager").GetComponent<RoundManager>().StartRound();
		SceneManager.LoadScene ("Bedroom");
	}
}
