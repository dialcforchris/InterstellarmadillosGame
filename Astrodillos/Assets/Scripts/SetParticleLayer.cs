using UnityEngine;
using System.Collections;

public class SetParticleLayer : MonoBehaviour {
	public string sortingLayer = "Default";
	
	// Use this for initialization
	void Awake () {
		GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = sortingLayer; 
	}

}
