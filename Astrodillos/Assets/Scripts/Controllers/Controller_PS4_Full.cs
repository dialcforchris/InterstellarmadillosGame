using UnityEngine;
using System.Collections;
using Rewired;

namespace Astrodillos{
	public class Controller_PS4_Full : Controller {

		public Controller_PS4_Full(int player) : base(){
			trigger = new ControlInputButton (player, "trigger");
			bumper = new ControlInputButton (player, "bumper");
			upButton = new ControlInputButton (player, "up");
			downButton = new ControlInputButton (player, "down");
			rightButton = new ControlInputButton (player, "right");
			leftButton = new ControlInputButton (player, "left");
		}
	}


	//Gamepad controller input
	public class ControlInputButton : ControlInput{

		int playerIndex;
		string buttonName;

		public ControlInputButton(int player, string button):base(){
			playerIndex = player;
			buttonName = button;
		}

		public override bool IsDown(){

			return ReInput.players.GetPlayer(playerIndex).GetButton (buttonName);
		}

		public override bool JustPressed(){
			return ReInput.players.GetPlayer(playerIndex).GetButtonDown (buttonName);
		}

		public override bool JustReleased(){
			return ReInput.players.GetPlayer(playerIndex).GetButtonUp (buttonName);
		}
	}
}


