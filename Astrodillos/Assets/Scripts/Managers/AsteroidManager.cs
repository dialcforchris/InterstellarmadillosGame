using UnityEngine;
using System.Collections;


public class AsteroidManager : MonoBehaviour 
{

    float timer = 0;
    public GameObject asteroid;
    int maxAst;
    float randTime = 0;
    int currentAsteroids = 0;
	// Use this for initialization
	void Start () 
    {
        randTime = Random.Range(1.2f, 3.0f);
        maxAst = Random.Range(5, 10);
        currentAsteroids = maxAst;
	}
	
	// Update is called once per frame
	void Update () 
    {
        Vector2 spawnLoc = Vector2.zero; 
       if (currentAsteroids>0)
       {
           float randomY = Random.Range(0.2f, 1.0f);
           timer += Time.deltaTime;
           if (randomBool())
           {
               spawnLoc.x = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x - 2.0f;
           }
           else
           {

               spawnLoc.x = Camera.main.ViewportToWorldPoint(new Vector2(1,0)).x + 2.0f;
           }
           
           spawnLoc.y = Camera.main.ViewportToWorldPoint(new Vector2(0,randomY)).y;
           if (timer >= randTime)
           {
               Instantiate(asteroid, spawnLoc, new Quaternion(0, 0, 0, 0));
               
               timer = 0;
           }

       }
       else
       {
           currentAsteroids = maxAst;
       }

	}

    bool randomBool()
    {
        return (Random.value > 0.5f);
    }
}
