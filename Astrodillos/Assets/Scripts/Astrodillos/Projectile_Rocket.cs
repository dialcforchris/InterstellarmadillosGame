using UnityEngine;
using System.Collections;

public class Projectile_Rocket : Projectile {
	
	protected virtual void Update(){
		base.Update ();
		
		//Update rotation to face force direction
		float rocketAngle = (Mathf.Rad2Deg * Mathf.Atan2 (body.velocity.x, -body.velocity.y))-90;
		transform.localEulerAngles = new Vector3 (0, 0, rocketAngle);
	}
	
	protected override void HitObject(GameObject hitObject){
		base.HitObject(hitObject);
		
		Vector3 direction = hitObject.transform.position - transform.position;
		direction.Normalize ();
		Vector3 explosionPos = transform.position + (direction*0.25f);
		GameType_Astrodillos.instance.Explosion (explosionPos, hitObject);
		
		/*if (col.gameObject.GetComponent<Asteroid>())
		{
			Destroy(col.gameObject);
		}*/
		
	}
}
