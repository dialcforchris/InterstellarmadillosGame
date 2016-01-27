using UnityEngine;
using System.Collections;

namespace Astrodillos{
	public class Missile : MonoBehaviour {
		
		Rigidbody2D body;
		SpriteRenderer sprite;
		
		bool active = false;

		//Collider to ignore (usually player who fires)
		Collider2D ignoreCollider;

        //audio stuff
        public AudioClip fireRocket;
        AudioSource audioSource;

		float missileSpeed = 30f;

		float aliveTime = 0;
		float maxAliveTime = 100;
		// Use this for initialization
		void Awake () {
			body = GetComponent<Rigidbody2D> ();
			sprite = GetComponentInChildren<SpriteRenderer> ();
            audioSource = GetComponent<AudioSource>();
		}
		
		public void Spawn(Vector3 spawnPos, float angle, Collider2D playerCollider = null){
			ignoreCollider = playerCollider;
			active = true;
			transform.position = spawnPos;
			body.velocity = Vector2.zero;
			body.angularVelocity = 0;
			gameObject.SetActive (true);
			aliveTime = 0;
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(fireRocket,0.7f);
            }
			angle *= Mathf.Deg2Rad;
			Vector2 forceDirection = new Vector2 (Mathf.Cos (angle), Mathf.Sin (angle));
			body.AddForce (forceDirection * missileSpeed);
		}

		// Update is called once per frame
		void Update () {
			if (active) {
               
				aliveTime += Time.deltaTime;
				if(aliveTime>maxAliveTime){
					AddMissileBackToPool();
                   
				}
			}
		}
		
		void LateUpdate(){
			//Update rotation to face force direction
			float rocketAngle = Mathf.Rad2Deg * Mathf.Atan2 (body.velocity.x, -body.velocity.y);
			sprite.gameObject.transform.localEulerAngles = new Vector3 (0, 0, rocketAngle - 90);
		}
		
		void OnTriggerEnter2D(Collider2D col){

			if (active) {
               
				//Ignore gravity
				if(!col.usedByEffector){
                    //If not ignore collider (player)
					if(col != ignoreCollider){
                      
						Explode(col);
						if(col.gameObject.GetComponent<Actor_AstrodilloPlayer>()){
							col.gameObject.GetComponent<Actor_AstrodilloPlayer>().TakeDamage();
						}
                        if (col.gameObject.GetComponent<Asteroid>())
                        {
                         Destroy(col.gameObject);
                        
        
                        }
					}
				}


			}
		}

		void OnTriggerExit2D(Collider2D col){
			//After missile leaves player, it can hit and kill them
			if (col == ignoreCollider) {
				ignoreCollider = null;
			}
		}
		
		void Explode(Collider2D col){
          
            gameObject.SetActive (false);
			Vector3 direction = col.transform.position - transform.position;
			direction.Normalize ();
			Vector3 explosionPos = transform.position + (direction*0.25f);
			GameType_Astrodillos.instance.Explosion (explosionPos, col.gameObject);
            
            
            AddMissileBackToPool ();
		}

		void AddMissileBackToPool(){
			active = false;
			//GameType_Astrodillos.instance.missileManager.AddMissileBackToPool (this);
		}
	}
}


