using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Astrodillos{
		
	public class JoinedPlayer : MonoBehaviour {

		public Image controllerTypeImg;
		public Sprite pad, pad_left, pad_right;


		bool ready = false;


		Controller controller;
		PlayerSelectionBox selectionBox;

		// Use this for initialization
		void Awake () {
		}

		public void Initialise(Controller _controller, PlayerSelectionBox _selectionBox){
			SetController (_controller);
			selectionBox = _selectionBox;



		}

		public void SetController(Controller _controller){
			controller = _controller;
			//Debug.Log (controller.controllerIndex);
			//Set pad sprite
			switch (controller.splitSide) {
			case Controller.SplitSide.none:
				controllerTypeImg.sprite = pad;
				break;
			case Controller.SplitSide.left:
				controllerTypeImg.sprite = pad_left;
				break;
			case Controller.SplitSide.right:
				controllerTypeImg.sprite = pad_right;
				break;
			}
		}


		
		// Update is called once per frame
		void Update () {
			float controllerX = controller.rightButton.GetValue ();
			if (controllerX > 0) {
				//Move character selection right
			} 
			else if (controllerX < 0) {
				//left
			}
		}

		public bool PressedReady(){
			if (controller.bumper.JustPressed ()) {
				Debug.Log(controller.controllerIndex);
			}
			return controller.bumper.JustPressed ();
		}

		public void ToggleReady(){
			ready = !ready;

			selectionBox.SetReady (ready);
		}

		public bool GetReady(){
			return ready;
		}
	}
}
