using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Astrodillos{
	public class MissileManager : MonoBehaviour {

		public GameObject missilePrefab;

		List<Missile> activeMissiles = new List<Missile>();
		List<Missile> inactiveMissiles = new List<Missile>();

		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		///<summary>
		///Return a Missile from the Pool of missiles
		///</summary>
		public Missile GetMissile(){
			if (inactiveMissiles.Count == 0) {
				CreateMissile();
			}

			Missile missile = inactiveMissiles [0];
		
			activeMissiles.Add (missile);
			inactiveMissiles.RemoveAt (0);
			return missile;
		}

		void CreateMissile(){
			GameObject newMissile = Instantiate (missilePrefab);
			newMissile.transform.SetParent (gameObject.transform);
			inactiveMissiles.Add (newMissile.GetComponent<Missile> ());
		}

		public void AddMissileBackToPool(Missile missile){
			activeMissiles.Remove (missile);
			inactiveMissiles.Add (missile);
			missile.gameObject.SetActive (false);
		}
	}

}
