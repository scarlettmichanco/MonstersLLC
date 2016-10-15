using UnityEngine;
using System.Collections;

public class RandomMaterialOnStart : MonoBehaviour {
	public Material[] Materials;
	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().materials = new Material[] { Materials[Random.Range(0, Materials.Length)] };
	}
}
