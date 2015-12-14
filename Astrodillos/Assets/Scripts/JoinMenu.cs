using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Astrodillos{
	public class JoinMenu : MonoBehaviour {

		public Text playerCount;
		public Text countdownText;

		List<Controller> controllers = new List<Controller>();

		bool keyboardController = false;

		float countdown = 5f;
		bool countdownActive = false;
		// Use this for initialization
		void Start () {
			UpdatePlayerCountText ();
		}
		
		// Update is called once per frame
		void Update () {
			if (controllers.Count < 8) {
				//Keyboard
				if(!keyboardController){
					if(Input.GetKeyDown(KeyCode.Space)){
						keyboardController = true;
						AddController(new ControllerKeyboard());
					}
				}
			}

			if (countdownActive) {
				countdown-=Time.deltaTime;
				countdownText.text = Mathf.RoundToInt(countdown).ToString();
				if(countdown<=0){
					countdownActive = false;
					StartGame();
				}
			}
		}


		void AddController(Controller type){

			controllers.Add(type);
			UpdatePlayerCountText ();
			if (!countdownActive) {
				StartCountdown();
			}
		}

		void UpdatePlayerCountText(){
			playerCount.text = controllers.Count.ToString ();
		}

		void StartCountdown(){
			countdownActive = true;
		}

		void StartGame(){
			Application.LoadLevel ("Astrodillos");
		}


	}
}

