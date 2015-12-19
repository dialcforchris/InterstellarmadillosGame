using UnityEngine;
using System.Collections;

public class playerMove : MonoBehaviour {
    Vector3 alwaysForward;
    Vector2 force;
    float power = 2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        alwaysForward = gameObject.transform.TransformDirection(Vector3.up);
        force = new Vector2 (alwaysForward.x,alwaysForward.y);
        if (Input.GetAxis("Fire")>0)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = force * power;
        }
       
        if (Input.GetAxis("Rotate")!=0)
        {
           
                gameObject.transform.Rotate(new Vector3(0, 0, Mathf.PI), ((Time.deltaTime * 80)*Input.GetAxis("Rotate")));
                force.Set(alwaysForward.x, alwaysForward.y);

        }
	}
}
