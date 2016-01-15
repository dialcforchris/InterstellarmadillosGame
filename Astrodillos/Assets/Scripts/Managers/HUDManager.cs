using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Astrodillos{
	public class HUDManager : MonoBehaviour {

		public static HUDManager instance;

		public GameObject hudPrefab;

		List<ArmadilloHUD> huds = new List<ArmadilloHUD>();


		// Use this for initialization
		void Awake () {
			instance = this;
		}
		
		// Update is called once per frame
		void Update () {
		
		}

		public void CreateHUD(Actor_AstrodilloPlayer player){
			GameObject go = Instantiate (hudPrefab);
			go.transform.SetParent (gameObject.transform);
			go.transform.localScale = new Vector3 (1, 1, 1);
			go.transform.localPosition = new Vector3 (-300 + (huds.Count*100), -200, 0);
			ArmadilloHUD hud = go.GetComponent<ArmadilloHUD> ();
			huds.Add (hud);
			player.AssignHUD (hud);
		}
	}
}