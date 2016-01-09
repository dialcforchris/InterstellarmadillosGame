using UnityEngine;
using System.Collections;

namespace Astrodillos{

	public class Controller {

		public ControlInput bumper = new ControlInput();
		public ControlInput trigger = new ControlInput();
		public ControlInput rightButton = new ControlInput();
		public ControlInput upButton = new ControlInput();
		public ControlInput splitButton = new ControlInput();
		//Rewired player index
		public int playerIndex;
		public int controllerIndex;
		public bool isSplit { 
			get 
			{ return splitSide != SplitSide.none; } 
			private set{}
		}

		public enum SplitSide
		{
			none,
			left,
			right
		}

		public SplitSide splitSide;

		public Controller(int player = 0, int _controllerIndex = 0){
			playerIndex = player;
			splitSide = SplitSide.none;
			controllerIndex = _controllerIndex;
		}
	}

	//Base class for control input
	public class ControlInput{
		protected bool isDown = false;
		protected bool justPressed = false;
		protected bool justReleased = false;

		public ControlInput(){

		}

		public virtual bool IsDown(){
			return false;
		}

		public virtual bool JustPressed(){
			return false;
		}

		public virtual bool JustReleased(){
			return false;
		}

		public virtual float GetValue(){
			return 0;
		}
	}

}



