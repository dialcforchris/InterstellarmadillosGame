using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Rewired;
using System.Text;

namespace Astrodillos{
	public class ControllerManager : MonoBehaviour {

		public static ControllerManager instance;
		InputManager rewiredInput;
		
		//Controllers
		List<Controller> controllers = new List<Controller>();

		public int controllerCount {
			get{ return controllers.Count; }
			private set{}
		}
		int gamepadCount = 0;
		
		void Awake() {

			instance = this;

			CheckForNewControllers ();
		}
		
		void Update(){
			CheckForNewControllers ();
		}
		
		void CheckForNewControllers(){
			if (gamepadCount < ReInput.controllers.joystickCount) {
				
				//Add a new controller
				for (int i = gamepadCount; i < ReInput.controllers.joystickCount; i++) {
					AddController(new Controller_PS4_Full (i, controllers.Count));
					gamepadCount++;
				}
			}
		}
		
		//Get a controller from it's id
		public Controller GetController(int id){
			if (id >= controllers.Count) {
				return new Controller();
			}
			
			return controllers [id];
		}
		
		public void AddController(Controller newController){
			controllers.Add (newController);
		}

		public void SplitController(Controller controller){
			int index = controller.controllerIndex;
			Controller rightSide = new Controller_PS4_Right (controllers [index].playerIndex, controllers.Count);
			controllers [index] = new Controller_PS4_Left (controllers [index].playerIndex, controllers [index].controllerIndex);
			controllers.Add (rightSide);
		}
		
	}

}

