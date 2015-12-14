using UnityEngine;
using System.Collections;

namespace Astrodillos{
	public class Controller {

		public ControllerKey thrustKey { get; protected set; }
		public ControllerKey upKey { get; protected set; }
		public ControllerKey downKey { get; protected set; }
		public ControllerKey leftKey { get; protected set; }
		public ControllerKey rightKey { get; protected set; }
		public ControllerKey shootKey { get; protected set; }

		public Controller(){

		}


	}

	public class ControllerKey{



		string inputName;

		public ControllerKey(string _inputName){
			inputName = _inputName;
		}

		public bool justPressed(){
			return Input.GetButtonDown (inputName);
		}

		public bool justReleased(){
			return Input.GetButtonUp (inputName);
		}

		public bool isDown(){
			return Input.GetButton (inputName);
		}
	}

}
