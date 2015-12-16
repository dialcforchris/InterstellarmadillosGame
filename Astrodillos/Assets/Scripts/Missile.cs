using UnityEngine;
using System.Collections;

namespace Astrodillos{
	public class Missile : MonoBehaviour {
		
		Rigidbody2D body;
		SpriteRenderer sprite;
		
		bool active = false;
		// Use this for initialization
		void Awake () {
			body = GetComponent<Rigidbody2D> ();
			sprite = GetComponentInChildren<SpriteRenderer> ();
			
			Spawn ();
		}
		
		void Spawn(){
			active = true;
			body.AddForce (new Vector2 (100, 0));
		}

		// Update is called once per frame
		void Update () {
			
		}
		
		void LateUpdate(){
			//Update rotation to face force direction
			float rocketAngle = Mathf.Rad2Deg * Mathf.Atan2 (body.velocity.x, -body.velocity.y);
			sprite.gameObject.transform.localEulerAngles = new Vector3 (0, 0, rocketAngle - 90);
		}
		
		void OnCollisionEnter2D(Collision2D col){
			if (active) {
				Explode();
			}
		}
		
		void Explode(){
			active = false;
			gameObject.SetActive (false);
			Game.game.Explosion (transform.position);
		}
	}
}


