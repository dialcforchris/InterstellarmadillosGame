using UnityEngine;
using System.Collections;

namespace Astrodillos {
	public class Armadillo : MonoBehaviour {

		public GameObject aimer;
		public ArmadilloHUD armadilloHUD;
		public ParticleSystem jetpackParticles;
		
		float jetpackPower = 1.5f;
		float rotateSpeed = 60f;
		float aimTurnSpeed = 75;

		float jetpackFuel = 1.0f;
		float fuelBurnRate = 0.4f;
		float fuelRefillRate = 0.5f;
		float fuelRefillTime = 1f; //Used to start refill after player stops thrusting
		float fuelRefillCounter;

		int ammo = 1;
		float ammoRefillTime = 1f;
		float ammoRefillCounter;

		
		Rigidbody2D body;
		Collider2D collider;
		Controller controller;

		int controllerID;
		ControllerManager controllerManager;


		// Use this for initialization
		void Awake () {
			ammoRefillCounter = ammoRefillTime;
			fuelRefillCounter = fuelRefillTime;
			body = GetComponent<Rigidbody2D>();
			collider = GetComponent<Collider2D> ();
		}

		void Start(){
			//Debug default to keyboard
			if (controllerManager == null) {
				controllerManager = GameObject.Find("ControllerManager").GetComponent<ControllerManager>();
				controllerID = 0;
			}
		}
		
		// Update is called once per frame
		void Update () {
			bool thrusting = false;

				
			if (controllerManager.GetController(controllerID).trigger.GetValue()!=0){
				if (jetpackFuel > 0) {
					Thrust();
					thrusting = true;
				}
			}

			if(controllerManager.GetController(controllerID).bumper.JustPressed()){
				FireMissile();
			}

			UpdateRotation ();
			UpdateAiming ();


			if (!thrusting) {
				if(fuelRefillCounter<fuelRefillTime){
					fuelRefillCounter += Time.deltaTime;
				}
				else{
					jetpackFuel += fuelRefillRate * Time.deltaTime;
				}

				jetpackParticles.Stop();
			}

			//Clamp and update fuel hud
			jetpackFuel = Mathf.Clamp (jetpackFuel, 0, 1);
			armadilloHUD.UpdateFuelFill (jetpackFuel);

			if (ammoRefillCounter < ammoRefillTime) {
				ammoRefillCounter += Time.deltaTime;
				if(ammoRefillCounter >= ammoRefillTime){
					armadilloHUD.RefillAmmo();
					ammo++;
				}
			}
		}
		
		void Thrust(){
			jetpackFuel -= fuelBurnRate * Time.deltaTime;

			body.AddForce(-transform.right * jetpackPower);
			if (!jetpackParticles.isPlaying) {
				jetpackParticles.Play();
			}


			fuelRefillCounter = 0;

		}

		void FireMissile(){
			if (ammo > 0) {
				Missile missile = Game.game.missileManager.GetMissile ();
				missile.Spawn (aimer.transform.position, aimer.transform.eulerAngles.z + 90, collider);
				ammo--;
				ammoRefillCounter = 0;
				armadilloHUD.RemoveAmmo();
			}

		}


		void UpdateRotation(){
			if (controllerManager.GetController(controllerID).rightButton.GetValue()<0) {
				Rotate(1);
				return;
			}
			if (controllerManager.GetController(controllerID).rightButton.GetValue()>0) {
				Rotate(-1);
				return;
			}

			//Stop rotating
			Rotate (0);
		}

		void UpdateAiming(){
			if (controllerManager.GetController(controllerID).upButton.GetValue()<0) {
				RotateAimer(-1);
			}
			if (controllerManager.GetController(controllerID).upButton.GetValue()>0) {
				RotateAimer(1);
			}

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


