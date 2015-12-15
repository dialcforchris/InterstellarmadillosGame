using UnityEngine;
using System.Collections;

public class LevelGenerator : MonoBehaviour {

	public GameObject planet;

	int numOfPlanets;
	int xRand;
	int yRand;
	int size;

	// Use this for initialization
	void Start () {
	
		numOfPlanets = Random.Range (10, 20);
		Debug.Log (numOfPlanets);

		for (int i = 0; i < numOfPlanets; i++) {

			xRand = Random.Range(-20, 20);
			yRand = Random.Range(-10, 10);
			
			Instantiate(planet, new Vector2(xRand, yRand), Quaternion.identity);

		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
