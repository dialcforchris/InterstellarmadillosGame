using UnityEngine;
using System.Collections;
using Rewired;

namespace Astrodillos{
	public class GameManager : MonoBehaviour {

		public static GameManager instance;
		// Use this for initialization
		void Awake () {
			//Debug disable if we come from another scene
			if (instance!=null) {
				gameObject.SetActive(false);
				return;
			}
			instance = this;
			DontDestroyOnLoad (gameObject);
		}

		//Debug
		void Start(){

		}
		
		// Update is called once per frame
		void Update () {
		
		}
	}
}
