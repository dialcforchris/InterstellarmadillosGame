using UnityEngine;
using System.Collections;


public class Projectile : MonoBehaviour {
	
	protected Rigidbody2D body;
	public Collider2D ignoreCollider;
	
    
	protected float projectileSpeed = 5.0f;
	// Use this for initialization
	protected virtual void Awake () {
		body = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		
	}
	
	public void Fire(Collider2D _ignoreCollider, Vector3 parentVel)
    {
		ignoreCollider = _ignoreCollider;
        body.velocity = (transform.right * projectileSpeed) + parentVel;
       
	}
	
	protected virtual void HitObject(GameObject hitObject){
		if(gameObject.GetComponent<Actor>()){
			gameObject.GetComponent<Actor>().TakeDamage();
		}
		
		Destroy(gameObject);
	}
	
	void OnTriggerEnter2D(Collider2D col){
		
		//Ignore gravity
		if(!col.usedByEffector){
			//If not ignore collider (player)
			if(col != ignoreCollider){
				HitObject(col.gameObject);
			}
		}
	}
	
	void OnTriggerExit2D(Collider2D col){
		//No longer ignore player
		if (ignoreCollider != null) {
			ignoreCollider = null;
		}
	}
	
}
