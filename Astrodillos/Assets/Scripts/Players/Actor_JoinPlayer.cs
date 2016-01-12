using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Astrodillos{
		
	public class Actor_JoinPlayer : Actor {

		public Image controllerTypeImg;
		public Sprite pad, pad_left, pad_right;


		bool ready = false;

		PlayerSelectionBox selectionBox;

		// Use this for initialization
		void Awake () {

		}


		public void SetSelectionBox(PlayerSelectionBox _selectionBox){
			selectionBox = _selectionBox;
		}

		public override void SetController(int id){
			base.SetController (id);

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
