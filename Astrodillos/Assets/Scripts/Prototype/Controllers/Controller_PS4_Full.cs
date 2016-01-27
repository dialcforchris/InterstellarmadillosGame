using UnityEngine;
using System.Collections;
using Rewired;


public class Controller_PS4_Full : Controller {

	public Controller_PS4_Full(int player, int _controllerIndex) : base(player,_controllerIndex){
		trigger = new ControlInputAxis (player, "trigger");
		bumper = new ControlInputButton (player, "bumper");
		upButton = new ControlInputAxis (player, "up");
		rightButton = new ControlInputAxis (player, "right");
		splitButton = new ControlInputButton(player, "splitpad");
	}
}

//Split sides of the controller
public class Controller_PS4_Left : Controller {
	
	public Controller_PS4_Left(int player, int _controllerIndex) : base(player,_controllerIndex){
		splitSide = SplitSide.left;
		trigger = new ControlInputAxis (player, "trigger_left");
		bumper = new ControlInputButton (player, "bumper_left");
		upButton = new ControlInputAxis (player, "up_left");
		rightButton = new ControlInputAxis (player, "right_left");
		splitButton = new ControlInputButton(player, "splitpad");
	}
}

public class Controller_PS4_Right : Controller {
	
	public Controller_PS4_Right(int player, int _controllerIndex) : base(player,_controllerIndex){
		splitSide = SplitSide.right;
		trigger = new ControlInputAxis (player, "trigger_right");
		bumper = new ControlInputButton (player, "bumper_right");
		upButton = new ControlInputAxis (player, "up_right");
		rightButton = new ControlInputAxis (player, "right_right");
		splitButton = new ControlInputButton(player, "splitpad");
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

public class ControlInputAxis : ControlInput{
	int playerIndex;
	string axisName;
	
	public ControlInputAxis(int player, string axis):base(){
		playerIndex = player;
		axisName = axis;
	}
	
	public override float GetValue(){
		return ReInput.players.GetPlayer(playerIndex).GetAxis (axisName);
	}

}



