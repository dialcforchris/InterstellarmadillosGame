using UnityEngine;
using System.Collections;

public class Weapon_Laser : Weapon
{
    public Vector2 startPoint;
    public Vector2 endPoint;
    void Awake()
    {
        startPoint = transform.position;
        endPoint = transform.right * 10; 
    }
    protected virtual void Fire(float angle, Vector3 parentVel)
    {
        GameObject projectile = Instantiate(weaponProjectile);
        projectile.transform.position = gameObject.transform.position;
        projectile.transform.localEulerAngles = new Vector3(0, 0, angle);

        Projectile component = projectile.GetComponent<Projectile>();
        component.Fire(gameObject.GetComponent<Collider2D>(), parentVel);
        LineRenderer line = component.GetComponent<LineRenderer>();
        line.SetPosition(0, (transform.right ));
        line.SetPosition(1, transform.right * 10);
            line.sortingLayerName = "Background";
        line.sortingOrder = 1;
    }
}
