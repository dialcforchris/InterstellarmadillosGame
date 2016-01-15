using UnityEngine;
using System.Collections;

namespace Astrodillos {
	public class Actor_AstrodilloPlayer : Actor {

		enum PlayerState{
			Alive,
			Dead
		}

		public ParticleSystem jetpackParticles;
		PlayerState playerState = PlayerState.Alive;

		ArmadilloHUD armadilloHUD;
		
		float jetpackPower = 1.5f;
		float rotateSpeed = 60f;
		float aimTurnSpeed = 75;

		float jetpackFuel = 1.0f;
		float fuelBurnRate = 0.2f;
		float fuelRefillRate = 0.5f;
		float fuelRefillTime = 1f; //Used to start refill after player stops thrusting
		float fuelRefillCounter;

		int ammo = 1;
		float ammoRefillTime = 1f;
		float ammoRefillCounter;

		
		Rigidbody2D body;
		Collider2D collider;



		// Use this for initialization
		protected override void Awake () {
			base.Awake ();
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

			switch (playerState) {
			case PlayerState.Alive:{
				if (controller.trigger.GetValue()!=0){
					if (jetpackFuel > 0) {
						Thrust();
						thrusting = true;
					}
				}
				
				if(controller.bumper.JustPressed()){
					FireMissile();
				}
				
				UpdateRotation ();

				if (ammoRefillCounter < ammoRefillTime) {
					ammoRefillCounter += Time.deltaTime;
					if(ammoRefillCounter >= ammoRefillTime){
						armadilloHUD.RefillAmmo();
						ammo++;
					}
				}

				break;
			}
			}


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
				Missile missile = GameType_Astrodillos.instance.missileManager.GetMissile ();
				missile.Spawn (gameObject.transform.position, gameObject.transform.localEulerAngles.z-180, collider);
				ammo--;
				ammoRefillCounter = 0;
				armadilloHUD.RemoveAmmo();
			}

		}


		void UpdateRotation(){
			//Direction the analog stick is facing
			Vector2 stickAim = new Vector2 (controller.rightButton.GetValue (), controller.upButton.GetValue ());
			if (stickAim.x != 0 || stickAim.y != 0) {
				float stickAngle = Mathf.Atan2 (stickAim.y, stickAim.x) * Mathf.Rad2Deg;

				transform.localEulerAngles = new Vector3 (0, 0, stickAngle-180);
				body.angularVelocity = 0;
			}


		}



		void Rotate(float rotDir){
			body.angularVelocity = rotDir * rotateSpeed;
		}

		//Assigns a hud to this player
		public void AssignHUD(ArmadilloHUD hud){
			armadilloHUD = hud;
		}

		public void TakeDamage(){
			playerState = PlayerState.Dead;
			animator.SetTrigger ("Kill");
		}

		public override void Spawn(Vector2 spawnPos, float spawnAngle){
			base.Spawn (spawnPos, spawnAngle);

			playerState = PlayerState.Alive;
		}

	}
}


