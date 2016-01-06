using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Astrodillos{
	public class JoinMenu : MonoBehaviour {

		public ControllerManager controllerManager;
		public Text countdownText;
		public GameObject joinedPlayersParent;
		public GameObject joinedPlayerPrefab;

		List<JoinedPlayer> joinedPlayers = new List<JoinedPlayer>();
		List<int> joinedControllers = new List<int>();
		List<int> notJoinedControllers = new List<int>();

		float countdown = 5f;
		bool countdownActive = false;
		// Use this for initialization
		void Awake () {

		}
		
		// Update is called once per frame
		void Update () {

			GetJoinInput ();


			//Add new controllers to not joined
			for (int i = joinedControllers.Count + notJoinedControllers.Count; i<controllerManager.controllerCount; i++) {
				notJoinedControllers.Add(i);
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

		//Check controllers to see if they join
		void GetJoinInput(){
			//Did joined controller ready up or split?
			for (int i = 0; i<joinedControllers.Count; i++) {
				Controller controller = controllerManager.GetController(joinedControllers[i]);
				if(controller.bumper.JustPressed()){
					joinedPlayers[i].ToggleReady();
					//Start countdown if all players are nor ready
					if(AllPlayersReady()){
						if (!countdownActive) {
							StartCountdown();
						}
					}
				}
				if(!controller.isSplit){
					if(controller.splitButton.JustPressed()){
						SplitController(joinedControllers[i], i);
					}
				}
			}

			//Did controller press join?
			for (int i = 0; i<notJoinedControllers.Count; i++) {
				Controller controller = controllerManager.GetController(notJoinedControllers[i]);
				if(controller.bumper.JustPressed()){
					AddPlayer(controller);
					joinedControllers.Add(notJoinedControllers[i]);
					notJoinedControllers.RemoveAt(i);
				}
			}

		}

		void AddPlayer(Controller controller){
			GameObject newJoinedPlayer = Instantiate (joinedPlayerPrefab);
			newJoinedPlayer.transform.SetParent (joinedPlayersParent.transform);
			newJoinedPlayer.transform.localPosition = new Vector3 (0+(joinedPlayers.Count*150), -400, 0);
			newJoinedPlayer.transform.localScale = new Vector3 (1, 1, 1);
			JoinedPlayer joinedPlayer = newJoinedPlayer.GetComponent<JoinedPlayer> ();
			joinedPlayer.Initialise (controller);
			joinedPlayers.Add (joinedPlayer);


		}

		void SplitController(int controllerIndex, int joinedPlayer){
			controllerManager.SplitController(controllerIndex);
			//Add right side to joined players
			joinedPlayers [joinedPlayer].Initialise (controllerManager.GetController (controllerIndex));
			joinedControllers.Add(controllerManager.controllerCount-1);
			AddPlayer(controllerManager.GetController(controllerManager.controllerCount-1));
		}

		bool AllPlayersReady(){
			for (int i = 0; i<joinedPlayers.Count; i++) {
				if(!joinedPlayers[i].GetReady()){
					return false;
				}
			}
			return true;
		}

		void StartCountdown(){
			countdownActive = true;
		}

		void StartGame(){
			Application.LoadLevel ("Astrodillos");
		}


	}
}

