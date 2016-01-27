using UnityEngine;
using System.Collections;

namespace Astrodillos{
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

				newAsteroid.transform.SetParent(gameObject.transform);
				SetRandomTime();
	           	
	       }
	       


		}


		void SetRandomTime(){
			randTime = Random.Range(5.0f, 15.0f);
			timer = 0;
		}
	}
}
