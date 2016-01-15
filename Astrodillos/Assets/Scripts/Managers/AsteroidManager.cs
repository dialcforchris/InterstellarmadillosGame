using UnityEngine;
using System.Collections;


public class AsteroidManager : MonoBehaviour 
{

    float timer = 0;
    public GameObject asteroid;
    const int MAX_ASTEROIDS = 3;
    float randTime = 0;

	// Use this for initialization
	void Start () 
    {
		SetRandomTime ();
	}
	
	// Update is called once per frame
	void Update () 
    {

       timer += Time.deltaTime;
      
       if (timer >= randTime)
       {
			//Spawn an asteroid
           	GameObject newAsteroid = Instantiate(asteroid);

			float randomY = Random.Range(0.2f, 1.0f);
			Vector2 spawnLoc = Vector2.zero; 

			if (randomBool())
			{
				spawnLoc.x = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x - 2.0f;
			}
			else
			{
				
				spawnLoc.x = Camera.main.ViewportToWorldPoint(new Vector2(1,0)).x + 2.0f;
			}
			
			spawnLoc.y = Camera.main.ViewportToWorldPoint(new Vector2(0,randomY)).y;

			newAsteroid.transform.SetParent(gameObject.transform);
			newAsteroid.transform.localPosition = spawnLoc;
			SetRandomTime();
           	
       }
       


	}

    bool randomBool()
    {
        return (Random.value > 0.5f);
    }

	void SetRandomTime(){
		randTime = Random.Range(5.0f, 15.0f);
		timer = 0;
	}
}
