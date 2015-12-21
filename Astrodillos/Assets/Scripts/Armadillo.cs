using UnityEngine;
using System.Collections;

namespace Astrodillos {
	public class Armadillo : MonoBehaviour {

		public GameObject aimer;
		public ParticleSystem jetpackParticles;
		
		float jetpackPower = 1.5f;
		float rotateSpeed = 60f;
		float aimTurnSpeed = 75;
		
		Rigidbody2D body;
		Collider2D collider;
		Controller controller;


		// Use this for initialization
		void Awake () {
			body = GetComponent<Rigidbody2D>();
			collider = GetComponent<Collider2D> ();
		}

		void Start(){
			//Debug default to keyboard
			if (controller == null) {
				controller = new ControllerKeyboard();
			}
		}
		
		// Update is called once per frame
		void Update () {
			bool thrusting = false;
			if (controller != null) {
				
				if (controller.thrustKey.isDown()){
					Thrust();
					thrusting = true;
				}

				if(controller.shootKey.justPressed()){
					FireMissile();
				}

				UpdateRotation ();
				UpdateAiming ();
			}

			if (!thrusting) {
				jetpackParticles.Stop();
			}
		}
		
		void Thrust(){
			body.AddForce(-transform.right * jetpackPower);
			if (!jetpackParticles.isPlaying) {
				jetpackParticles.Play();
			}
		}

		void FireMissile(){
			Missile missile = Game.game.missileManager.GetMissile ();
			missile.Spawn (aimer.transform.position, aimer.transform.eulerAngles.z + 90, collider);
		}


		void UpdateRotation(){
			if (controller.leftKey.isDown()) {
				Rotate(1);
				return;
			}
			if (controller.rightKey.isDown()) {
				Rotate(-1);
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


