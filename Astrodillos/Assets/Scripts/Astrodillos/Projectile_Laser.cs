using UnityEngine;
using System.Collections;

public class Projectile_Laser : Projectile 
{
   
   public LineRenderer line;
    protected virtual void Awake()
    {
        
        base.Awake();
      
        projectileSpeed = 100;
        line = GetComponent<LineRenderer>();
        


    }

    protected virtual void Update()
    {
        base.Update();

        //Update rotation to face force direction
        float rocketAngle = (Mathf.Rad2Deg * Mathf.Atan2(body.velocity.x, -body.velocity.y)) - 90;
        transform.localEulerAngles = new Vector3(0, 0, rocketAngle);
    }
    protected virtual void Fire(Collider2D _ignoreCollider, Vector3 parentVel)
    {

    }
    protected override void HitObject(GameObject hitObject)
    {
        base.HitObject(hitObject);

        Vector3 direction = hitObject.transform.position - transform.position;
        direction.Normalize();
        Vector3 explosionPos = transform.position + (direction * 0.25f);
        GameType_Astrodillos.instance.Explosion(explosionPos, hitObject, 0.5f);

        /*if (col.gameObject.GetComponent<Asteroid>())
        {
            Destroy(col.gameObject);
        }*/

    }
	
}
