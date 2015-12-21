using UnityEngine;
using System.Collections;

namespace Astrodillos{
	public class Missile : MonoBehaviour {
		
		Rigidbody2D body;
		SpriteRenderer sprite;
		
		bool active = false;

		//Collider to ignore (usually player who fires)
		Collider2D ignoreCollider;


		float missileSpeed = 200f;

		float aliveTime = 0;
		float maxAliveTime = 10;
		// Use this for initialization
		void Awake () {
			body = GetComponent<Rigidbody2D> ();
			sprite = GetComponentInChildren<SpriteRenderer> ();
		}
		
		public void Spawn(Vector3 spawnPos, float angle, Collider2D playerCollider = null){
			ignoreCollider = playerCollider;
			active = true;
			transform.position = spawnPos;
			body.velocity = Vector2.zero;
			body.angularVelocity = 0;
			gameObject.SetActive (true);
			aliveTime = 0;

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
						Explode();
					}
				}


			}
		}
		
		void Explode(){

			gameObject.SetActive (false);
			Game.game.Explosion (transform.position);
			AddMissileBackToPool ();
		}

		void AddMissileBackToPool(){
			active = false;
			Game.game.missileManager.AddMissileBackToPool (this);
		}
	}
}


