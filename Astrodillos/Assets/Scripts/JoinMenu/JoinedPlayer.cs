using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Astrodillos{
		
	public class JoinedPlayer : MonoBehaviour {

		public Text controllerNumber;
		public Image controllerTypeImg;
		public Image readyImg;
		public Sprite readyTick, readyCross;
		public Sprite pad, pad_left, pad_right;

		bool ready = false;

		Controller controller;

		// Use this for initialization
		void Awake () {
			readyImg.sprite = readyCross;
		}

		public void Initialise(Controller _controller){
			controller = _controller;
			controllerNumber.text = controller.controllerIndex.ToString ();

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
		
		}

		public void ToggleReady(){
			ready = !ready;

			if (ready) {
				readyImg.sprite = readyTick;
			} 
			else {
				readyImg.sprite = readyCross;
			}
		}

		public bool GetReady(){
			return ready;
		}
	}
}
