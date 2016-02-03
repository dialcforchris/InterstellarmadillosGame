using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
	
	public GameObject weaponProjectile;
	
	void Awake(){
		
	}
	
	public void Fire(float angle,Vector3 parentVel){
		GameObject projectile = Instantiate (weaponProjectile);
		projectile.transform.position = gameObject.transform.position;
		projectile.transform.localEulerAngles = new Vector3 (0, 0, angle);
		
		Projectile component= projectile.GetComponent<Projectile> ();
		component.Fire (gameObject.GetComponent<Collider2D>(), parentVel);
	}
}
