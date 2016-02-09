using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {

	public Slider fuelSlider;
	public GameObject armadJetpack;
	Actor_Jetpack actorJetpack;

	// Use this for initialization
	void Start () {
		actorJetpack = armadJetpack.GetComponent<Actor_Jetpack> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		fuelSlider.value = actorJetpack.jetpackFuel;

	
	}
}
