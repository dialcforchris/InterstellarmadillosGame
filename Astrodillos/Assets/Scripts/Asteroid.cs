using UnityEngine;
using System.Collections;

namespace Astrodillos{

	public class Asteroid : MonoBehaviour {

		public ParticleSystem flameParticles;
		SpriteRenderer spriteRenderer;

		Rigidbody2D body;

		//When the asteroid comes on screen. Destroys when this is true but not on screen anymore
		bool beenVisible = false;
		

		//Spawn ranges for each edge of the screen - top, right
		Vector2[] spawnRanges = new Vector2[2] {new Vector2(-10,10),new Vector2(-17,17)};

	   
		// Use this for initialization
		void Awake () 
	    {
			body = GetComponent<Rigidbody2D> ();
			spriteRenderer = GetComponent<SpriteRenderer> ();

			Vector2 spawnPosition = new Vector2 ();

			//Top or right of screen
			switch (RandomBoolean()) {
			case true:
				spawnPosition = new Vector2(Random.Range(-12, 12), 14);
				break;
			case false:
				spawnPosition = new Vector2(20,Random.Range(-17, 17));
				break;
			}

			//Do we flip spawn pos from right/top to left/down?
			if (RandomBoolean ()) {
				spawnPosition *= -1;
			}

			//Set the position of the asteroid
			gameObject.transform.position = new Vector3 (spawnPosition.x, spawnPosition.y, 0);

			//Use the offset from the centre to work out angle and speed
			float angle = Mathf.Atan2 (spawnPosition.x, -spawnPosition.y) * Mathf.Rad2Deg;


			//Modify angle for randomness
			angle += 90 + Random.Range (-40, 40);

			//Back to radians
			angle *= Mathf.Deg2Rad;

			//Random speed
			float speed = Random.Range (20.0f, 50.0f);

			//Speed vector from angle
			Vector2 force = new Vector2 (Mathf.Cos (angle), Mathf.Sin (angle))*speed;

			//Add the force

			body.AddForce (force);
			body.angularVelocity = speed*2;

			//Rotate other direction
			if (RandomBoolean ()) {
				body.angularVelocity *= -1;
			}
		    
		}

		void Start(){
			flameParticles.Play ();
		}
		
		// Update is called once per frame
		void Update () 
	    {
			if (!beenVisible) {
				beenVisible = spriteRenderer.isVisible;
			} 
			else {
				//No longer visible
				if(!spriteRenderer.isVisible){
					Destroy(gameObject);
				}
			}


	         //
	            
	        
		}
	    void OnCollisionEnter2D(Collision2D other)
	    {
			Vector3 direction = other.transform.position - transform.position;
			direction.Normalize ();
			Vector3 explosionPos = transform.position + (direction*0.4f);
			GameType_Astrodillos.instance.Explosion (explosionPos, other.collider,0.75f);

	        Destroy(gameObject);

			if(other.gameObject.GetComponent<Actor_AstrodilloPlayer>()){
				other.gameObject.GetComponent<Actor_AstrodilloPlayer>().TakeDamage();
			}
	        
	    }

		bool RandomBoolean ()
		{
			if (Random.value >= 0.5f)
			{
				return true;
			}
			return false;
		}
	}

}
