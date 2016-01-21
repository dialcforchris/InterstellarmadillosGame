using UnityEngine;
using System.Collections;

public class machineGun : MonoBehaviour 
{

    Rigidbody2D body;
    float aliveTime=0;
    bool active;
    float bulletSpeed = 80;
    float maxAliveTime = 3;
    public Vector2 direction;
    SpriteRenderer sprite;
    Collider2D ignoreCollider;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }
   
    // Update is called once per frame
    void Update()
    {
     
            aliveTime += Time.deltaTime;
            if (aliveTime > maxAliveTime)
            {
                Destroy(gameObject);

            }
           // body.velocity =  direction*10;

    }

   void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
    }
}
