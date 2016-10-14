using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIToast : MonoBehaviour {
	
	public float LifeTime = 2f;

	public enum Scare { Small, Large };
	public GameObject SmallScare;
	public GameObject LargeScare;

	private GameObject animate;
	private Image image;

	private bool toasting = false;

	private float timer = 0f;

	private Color startColor;

	// Use this for initialization
	void Start () {
		SmallScare.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		if (toasting)
		{
			Vector3 pos = animate.transform.position;
			pos.y += (Time.deltaTime)*0.7f;
			animate.transform.position = pos;

			Color tmp = startColor;

			tmp.a = Mathf.Lerp(0, 1, 1-(timer/LifeTime));

			image.color = tmp;

			timer += Time.deltaTime;
			if (timer >= LifeTime)
			{
				Destroy(gameObject);
			}
		}
	}

	public void Toast(Scare scareType){
		if (toasting)
		{
			return;
		}
		switch (scareType)
		{
			case Scare.Small:
				animate = SmallScare;
				break;
			case Scare.Large:
				animate = LargeScare;
				break;
			
		}

		image = animate.GetComponent<Image>();
		startColor = image.color;

		timer = 0f;
		toasting = true;
		animate.SetActive(true);


	}
}
