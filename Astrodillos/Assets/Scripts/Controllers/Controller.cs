using UnityEngine;
using System.Collections;

namespace Astrodillos{

	public class Controller {

		public ControlInput bumper = new ControlInput();
		public ControlInput trigger = new ControlInput();
		public ControlInput leftButton = new ControlInput();
		public ControlInput rightButton = new ControlInput();
		public ControlInput upButton = new ControlInput();
		public ControlInput downButton = new ControlInput();
		public int playerIndex;
		public int controllerIndex;
		

		public Controller(){

		}

		public virtual void Update(){
			bumper.Update ();
			trigger.Update ();
			leftButton.Update ();
			rightButton.Update ();
			upButton.Update ();
			downButton.Update ();
		}
	}

	//Base class for control input
	public class ControlInput{
		protected bool isDown = false;
		protected bool justPressed = false;
		protected bool justReleased = false;

		public ControlInput(){

		}

		public virtual void Update(){

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
	}

}



