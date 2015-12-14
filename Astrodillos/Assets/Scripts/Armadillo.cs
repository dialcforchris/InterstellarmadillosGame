using UnityEngine;
using System.Collections;

namespace Astrodillos {
	public class Armadillo : MonoBehaviour {

		public GameObject aimer;
		
		float jetpackPower = 1.1f;
		float rotateSpeed = 60f;
		float aimTurnSpeed = 40;
		
		Rigidbody2D body;

		Controller controller;
		// Use this for initialization
		void Awake () {
			body = GetComponent<Rigidbody2D>();
		}

		void Start(){
			//Debug default to keyboard
			if (controller == null) {
				controller = new ControllerKeyboard();
			}
		}
		
		// Update is called once per frame
		void Update () {
			if (controller != null) {
				
				if (controller.thrustKey.isDown()){
					Thrust();
				}

				UpdateRotation ();
				UpdateAiming ();
			}
		}
		
		void Thrust(){
			body.AddForce(transform.up * jetpackPower);
		}


		void UpdateRotation(){
			if (controller.leftKey.isDown()) {
				Rotate(-1);
				return;
			}
			if (controller.rightKey.isDown()) {
				Rotate(1);
				return;
			}

			//Stop rotating
			Rotate (0);
		}

		void UpdateAiming(){
			if (controller.downKey.isDown()) {
				RotateAimer(-1);
			}
			if (controller.upKey.isDown()) {
				RotateAimer(1);
			}

			if (controller.shootKey.justPressed ()) {
				ShootMissile();
			}
		}

		void ShootMissile(){

		}

		void Rotate(float rotDir){
			body.angularVelocity = rotDir * rotateSpeed;
		}

		void RotateAimer(float rotDir){
			aimer.transform.localEulerAngles += new Vector3 (0, 0, aimTurnSpeed) * Time.deltaTime * rotDir;
		}

		public void SetController(Controller _controller){
			controller = _controller;
		}
	}
}


