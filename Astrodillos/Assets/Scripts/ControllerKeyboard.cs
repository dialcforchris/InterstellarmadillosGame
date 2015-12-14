using UnityEngine;
using System.Collections;

namespace Astrodillos{
	public class ControllerKeyboard : Controller {

		public ControllerKeyboard(){
			thrustKey = new ControllerKey ("keyboard_thrust");
			leftKey = new ControllerKey ("keyboard_left");
			rightKey = new ControllerKey ("keyboard_right");
			upKey = new ControllerKey ("keyboard_up");
			downKey = new ControllerKey ("keyboard_down");
			shootKey = new ControllerKey ("keyboard_shoot");
		}


	}
}
