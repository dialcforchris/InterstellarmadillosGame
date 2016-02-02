using UnityEngine;
using System.Collections;

public class desertPlayer : Actor {

    Rigidbody2D body;
    public GameObject bullets;
    float speed = 7;
    float coolDown = 0.1f;
	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        Move();
        coolDown += Time.deltaTime;
        if (controller.bumper.IsDown())
        {
            if (coolDown >= 0.1f)
            {
              //  bullets.GetComponent<machineGun>().direction = transform.forward;
                GameObject bullet = Instantiate(bullets, new Vector2(transform.position.x + 1, transform.position.y), new Quaternion(0, 0, 0, 0)) as GameObject;
                bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * 500);
                coolDown = 0;
            }
            
        }
	}
    void Move()
    {
      
        Vector2 movement = new Vector2(controller.rightButton.GetValue(), controller.upButton.GetValue());
        
        {
            body.velocity = movement*speed;// *Time.deltaTime;
        }


    }
  
}
