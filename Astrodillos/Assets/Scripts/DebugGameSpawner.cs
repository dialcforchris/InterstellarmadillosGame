using UnityEngine;
using System.Collections;

namespace Astrodillos{
	public class DebugGameSpawner : MonoBehaviour {

		public GameObject gameManagerPrefab;
		// Use this for initialization
		void Awake () {
			if (GameManager.instance == null) {
				Instantiate(gameManagerPrefab);
			}
		}
		
		// Update is called once per frame
		void Update () {
		
		}
	}
}
