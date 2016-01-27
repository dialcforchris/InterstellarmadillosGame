using UnityEngine;
using System.Collections;

public class screenWrap : MonoBehaviour {

    Vector2 position;
    Vector2 screenToWorldMax;
    Vector2 screenToWorldMin;
	// Use this for initialization
	void Start () 
    {
        screenToWorldMax = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        screenToWorldMin = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
	}
	
	// Update is called once per frame
	void Update ()
    {
        position = gameObject.transform.position;

        if (position.x>screenToWorldMax.x)
        {
            gameObject.transform.position = new Vector2(screenToWorldMin.x,position.y);
        }
        if (position.x<screenToWorldMin.x)
        {
            gameObject.transform.position = new Vector2(screenToWorldMax.x, position.y);
        }
        if (position.y>screenToWorldMax.y)
            {
            gameObject.transform.position = new Vector2(position.x,screenToWorldMin.y);
        }
        if (position.y < screenToWorldMin.y)
            {
            gameObject.transform.position = new Vector2(position.x,screenToWorldMax.y);
        }
	}
}
