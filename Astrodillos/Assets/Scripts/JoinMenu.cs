using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Astrodillos{
	public class JoinMenu : MonoBehaviour {

		public ControllerManager controllerManager;
		public Text countdownText;

		float countdown = 5f;
		bool countdownActive = false;
		// Use this for initialization
		void Awake () {

		}
		
		// Update is called once per frame
		void Update () {

			if (controllerManager.GetController (0).bumper.JustPressed ()) {
				Debug.Log(1);
			}

			//Update countdown
			if (countdownActive) {
				countdown-=Time.deltaTime;
				countdownText.text = Mathf.RoundToInt(countdown).ToString();
				if(countdown<=0){
					countdownActive = false;
					StartGame();
				}
			}
		}

		void AddController(){
			if (!countdownActive) {
				StartCountdown();
			}
		}

		void StartCountdown(){
			countdownActive = true;
		}

		void StartGame(){
			Application.LoadLevel ("Astrodillos");
		}


	}
}

