﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Rewired;
using System.Text;

namespace Astrodillos{
	public class ControllerManager : MonoBehaviour {
		
		//Controllers
		List<Controller> controllers = new List<Controller>();
		
		int gamepadCount = 0;
		
		void Awake() {
			DontDestroyOnLoad (gameObject);
			CheckForNewControllers ();
			
			AddController (new Controller_Keyboard ());
		}
		
		void Update(){
			CheckForNewControllers ();
		}
		
		void CheckForNewControllers(){
			if (gamepadCount < ReInput.controllers.joystickCount) {
				
				//Add a new controller
				for (int i = gamepadCount; i < ReInput.controllers.joystickCount; i++) {
					AddController(new Controller_PS4_Full (i));
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
		
	}

}

