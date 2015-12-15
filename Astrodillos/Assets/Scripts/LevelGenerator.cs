using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class LevelGenerator : MonoBehaviour {

	public GameObject planetPrefab;

	List<GameObject> planetList;

	int numOfPlanets;
	int xRand;
	int yRand;
	int sizeRand;

	// Use this for initialization
	void Start () {
	
		List<GameObject> planetList = new List<GameObject> ();

		numOfPlanets = Random.Range (10, 20);
		Debug.Log (numOfPlanets);

		for (int i = 0; i < numOfPlanets; i++) {

			xRand = Random.Range(-20, 20);
			yRand = Random.Range(-10, 10);
			
			GameObject planet = (GameObject) Instantiate(planetPrefab, new Vector2(xRand, yRand), Quaternion.identity);
			//planet.transform.localScale = new Vector2(sizeRand, sizeRand);
			planetList.Add(planet);

		}

		for (int i = 0; i < planetList.Count; i++) {

			sizeRand = Random.Range (1, 5);

			planetList[i].transform.localScale = new Vector2(sizeRand, sizeRand);

		}


	}
}
