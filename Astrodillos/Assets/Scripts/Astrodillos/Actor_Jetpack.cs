using UnityEngine;
using System.Collections;

public class Actor_Jetpack : Actor {
	
	public SpriteRenderer jetpackSprite;
	public ParticleSystem jetpackParticles;
	
	private float jetpackPower = 1.5f;
	
	private float jetpackFuel = 1.0f;
	private float fuelBurnRate = 0.2f;
	private float fuelRefillRate = 0.5f;
	private float fuelRefillTime = 1f; //Used to start refill after player stops thrusting
	private float fuelRefillCounter;
	
	private bool isThrusting = false;
	
	private float currentAngle = 0;
	
	// Use this for initialization
	protected override void Awake () {
		base.Awake ();
	}
	
	protected override void Start () {
		base.Start ();
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update ();
		
		//Jetpack sprite ordering
		int actorSpriteOrder = spriteRenderer.sortingOrder;
		int jetpackSpriteOrder = (Mathf.Abs(currentAngle)<=112.1f) ? actorSpriteOrder-1 : actorSpriteOrder+1;
		jetpackSprite.sortingOrder = jetpackSpriteOrder;
		UpdateRotation ();
		UpdateThrusting ();
		UpdateShooting ();
	}
	
	void UpdateShooting(){
		if (controller.bumper.JustPressed ()) {
			weapon.Fire(currentAngle-90);
		}
	}
	
	void UpdateThrusting(){
		if (controller.trigger.GetValue () > 0) {
			Thrust ();
		} 
		else {
			RechargeFuel();
			isThrusting = false;
		}
		
		if (!isThrusting) {
			
			jetpackParticles.Stop();
		}
	}
	
	
	
	void UpdateRotation(){
		//Update the rotation of the sprite based on the direction of the analog stick
		//Direction the analog stick is facing
		Vector2 stickAim = new Vector2 (controller.rightButton.GetValue (), controller.upButton.GetValue ());
		if (stickAim.x != 0 || stickAim.y != 0) {
			currentAngle = (Mathf.Atan2(stickAim.x, -stickAim.y) * Mathf.Rad2Deg);
			
			//Flip x scale if less than 0 angle - temp untill left side sprites?
			int xScale = (currentAngle>=0) ? 1 : -1;
			gameObject.transform.localScale = new Vector3(xScale,1,1);
			
			
			animator.SetFloat("angle", Mathf.Abs(currentAngle));
			
		}
	}
	
	
	//Apply thrust to the jetpack
	void Thrust(){
		
		//If jetpack fuel is depleted
		if (jetpackFuel <= 0) {
			isThrusting = false;
			return;
		}
		
		isThrusting = true;
		
		//Rotation to direction vector
		float radAngle = (currentAngle+90) * Mathf.Deg2Rad;
		Vector2 direction = -new Vector2 (Mathf.Cos (radAngle), Mathf.Sin (radAngle));
		//Add the thrust force to the rigidbody
		body.AddForce(direction * jetpackPower);
		
		//Play particles if not already
		if (!jetpackParticles.isPlaying) {
			jetpackParticles.Play();
		}
		
		//Remove jetpack fuel
		jetpackFuel -= fuelBurnRate * Time.deltaTime;
	}
	
	//Refills jetpack fuel
	void RechargeFuel(){
		
		//Refill jetpack fuel
		if (jetpackFuel < 1) {
			if(fuelRefillCounter<fuelRefillTime){
				fuelRefillCounter += Time.deltaTime;
			}
			else{
				jetpackFuel += fuelRefillRate * Time.deltaTime;
			}
		}
		
	}
}
