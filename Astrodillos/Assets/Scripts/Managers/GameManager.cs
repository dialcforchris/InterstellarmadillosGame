using UnityEngine;
using System.Collections;

namespace Astrodillos{
	public class GameManager : MonoBehaviour {

		public ControllerManager controllerManager;
		public ActorManager actorManager;
		[HideInInspector]
		public GameType gameType;

		public static GameManager instance;
		// Use this for initialization
		void Awake () {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
		
		// Update is called once per frame
		void Update () {
		
		}
	}
}
