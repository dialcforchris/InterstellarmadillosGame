using UnityEngine;
using System.Collections;

namespace Astrodillos{
	public class Controller_Keyboard : Controller {

		public Controller_Keyboard() : base(){
			trigger = new ControlInputKey (KeyCode.Space);
			bumper = new ControlInputKey (KeyCode.E);
			upButton = new ControlInputKey (KeyCode.W);
			downButton = new ControlInputKey (KeyCode.S);
			rightButton = new ControlInputKey (KeyCode.D);
			leftButton = new ControlInputKey (KeyCode.A);
		}
	}


	//Keyboard controller input
	public class ControlInputKey : ControlInput{

		KeyCode keyCode;

		public ControlInputKey(KeyCode inputKey):base(){
			keyCode = inputKey;
		}

		public override bool IsDown(){
			return Input.GetKey (keyCode);
		}

		public override bool JustPressed(){
			return Input.GetKeyDown (keyCode);
		}

		public override bool JustReleased(){
			return Input.GetKeyUp (keyCode);
		}
	}

}
