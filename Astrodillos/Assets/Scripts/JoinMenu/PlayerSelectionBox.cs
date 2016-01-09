using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerSelectionBox : MonoBehaviour {

	public Image readyLight;
	public Sprite greenLight;
	public Sprite redLight;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetReady(bool ready){
		if (ready) {
			readyLight.sprite = greenLight;
		} else {
			readyLight.sprite = redLight;
		}
	}
}
