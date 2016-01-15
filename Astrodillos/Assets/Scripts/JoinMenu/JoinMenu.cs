using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Astrodillos{
	public class JoinMenu : MonoBehaviour {


		public Text countdownText;
		public GameObject joinedPlayersParent;
		public GameObject joinedPlayerPrefab;
		public List<PlayerSelectionBox> selectionBoxes;

		ControllerManager controllerManager { 
			get{ return ControllerManager.instance;}
			set{}
		}

		ActorManager actorManager{
			get{ return ActorManager.instance;}
			set{}
		}

		List<Actor_JoinPlayer> joinedPlayers = new List<Actor_JoinPlayer>();
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

				//Check all players are still ready
				for(int i = 0; i<joinedPlayers.Count; i++){
					if(!joinedPlayers[i].GetReady()){
						countdownActive = false;
						break;
					}
				}
				if(countdown<=0){
					countdownActive = false;
					StartGame();
				}
			}
		}

		//Check controllers to see if they join
		void GetJoinInput(){


			//Did joined player ready up?
			for (int i = 0; i<joinedPlayers.Count; i++) {
				if(joinedPlayers[i].PressedReady()){
					joinedPlayers[i].ToggleReady();
					//Start countdown if all players are nor ready
					if(AllPlayersReady()){
						if (!countdownActive) {
							StartCountdown();
						}
					}
				}
			}
			//Did joined controller ready up or split?
			for (int i = 0; i<joinedControllers.Count; i++) {
				Controller controller = controllerManager.GetController(joinedControllers[i]);

				if(!controller.isSplit){
					if(controller.splitButton.JustPressed()){
						SplitController(controller, i);
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
			newJoinedPlayer.transform.SetParent (selectionBoxes[joinedPlayers.Count].gameObject.transform);
			newJoinedPlayer.transform.localPosition = new Vector3 (0, 0, 0);
			newJoinedPlayer.transform.localScale = new Vector3 (1, 1, 1);
			Actor_JoinPlayer joinedPlayer = newJoinedPlayer.GetComponent<Actor_JoinPlayer> ();

			joinedPlayer.SetController (controller.controllerIndex);
			joinedPlayer.SetSelectionBox(selectionBoxes[joinedPlayers.Count]);
			actorManager.AddActor (joinedPlayer);
			joinedPlayers.Add (joinedPlayer);


		}

		void SplitController(Controller controller, int joinedPlayer){
			int index = controller.controllerIndex;
			controllerManager.SplitController(controller);

			//Update controller for left side
			joinedPlayers [joinedPlayer].SetController (index);
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
			countdown = 5;
			countdownActive = true;
		}

		void StartGame(){
			actorManager.ParentActors ();
			Application.LoadLevel ("Astrodillos");
		}


	}
}

