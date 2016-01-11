using UnityEngine;
using System.Collections;

public class AsteroidBehaviour : MonoBehaviour {

    float destroyBuffer = 2.0f;
    public bool L_or_R;
    public float speed = 100;
   
	// Use this for initialization
	void Start () 
    {
        if (gameObject.transform.position.x>Camera.main.ViewportToWorldPoint(new Vector2(1,0)).x)
        {
            speed = speed * -1;
            L_or_R = true;
        }
	    
	}
	
	// Update is called once per frame
	void Update () 
    {
      
        gameObject.transform.Rotate(new Vector3(0, 0, Mathf.PI * Time.deltaTime* -speed));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(Time.deltaTime * speed, 0, 0) ;
        if (L_or_R)
        {
            if (gameObject.transform.position.x+destroyBuffer<Camera.main.ViewportToWorldPoint(new Vector2(0,0)).x)
            {
                Destroy(gameObject);
            }
        }
        else if (!L_or_R)
        {
            if (gameObject.transform.position.x-destroyBuffer>Camera.main.ViewportToWorldPoint(new Vector2(1,0)).x)
            {
                Destroy(gameObject);
            }
        }
	}
    void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.transform.GetComponent<AsteroidBehaviour>())
        {
            //Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }
}
