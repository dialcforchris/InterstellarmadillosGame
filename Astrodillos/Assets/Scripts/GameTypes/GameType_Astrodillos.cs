using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Astrodillos {
	public class GameType_Astrodillos : GameType {

		//Reference to self, allows Game access anywhere
		public static GameType_Astrodillos instance;

		public MissileManager missileManager;
		public ParticleSystem explosionParticles;
		public SpriteRenderer explosionMask;

		HUDManager hudManager {
			set{}
			get{ return HUDManager.instance; }
		}

		ActorManager actorManager {
			set {}
			get { return ActorManager.instance; }
		}

		List<Controller> controllers;

		Vector2[] spawnPoints = new Vector2[8] { new Vector2(-15,-8), new Vector2(15,8), new Vector2(-15,8), new Vector2(15,-8),
												new Vector2(0,8), new Vector2(0,-8), new Vector2(-15,0), new Vector2(15,0)};

		// Use this for initialization
		void Awake () {
			instance = this;
			
			if (ActorManager.instance != null) {
				//Spawn players when we start
				SpawnPlayers ();
			}


		}

		void Start(){

		}
		
		// Update is called once per frame
		void Update () {
			
		}

		//Use the single particle emitter for all explosions
		public void Explosion(Vector3 explosionPos, Collider2D col = null, float explosionSize = 0.2f){
			explosionParticles.transform.position = explosionPos;
			explosionMask.gameObject.transform.position = explosionPos;

			//If what the explosion collided with initially is destructible
			if (col != null) {
				DestructibleObject destructObj = col.gameObject.GetComponent<DestructibleObject>();
				if(destructObj!=null){
					destructObj.DestroyPixels(explosionMask);
				}
			}

			//If size is different to what has been set
			if (explosionSize != explosionParticles.startSize) {
				//Update the necessary attributes to change size
				explosionParticles.startSize = explosionSize;
				UnityEditor.SerializedObject so = new UnityEditor.SerializedObject (explosionParticles);
				so.FindProperty ("ShapeModule.radius").floatValue = explosionSize;
				so.ApplyModifiedProperties ();
			}

			explosionParticles.Emit (100);
		}

		public void SpawnPlayers(){
			List<Actor_AstrodilloPlayer> newPlayers = new List<Actor_AstrodilloPlayer>();

			for (int i = 0; i<actorManager.actors.Count; i++) {
				//TODO make sure right character spawns
				GameObject player = Instantiate(actorPrefab);

				Actor_AstrodilloPlayer actor = player.GetComponent<Actor_AstrodilloPlayer>();
				float spawnAngle = Mathf.Atan2(spawnPoints[i].y, spawnPoints[i].x) * Mathf.Rad2Deg;
				actor.Spawn(spawnPoints[i], spawnAngle);

				actor.SetController(actorManager.actors[i].controllerID);
				actor.SetCharacter(actorManager.actors[i].GetName());

				//Spawn and assign huds
				hudManager.CreateHUD(actor);
				newPlayers.Add(actor);

			}

			actorManager.ClearActors ();

			//Add new players to actor list
			for(int i = 0; i<newPlayers.Count; i++){
				actorManager.AddActor(newPlayers[i]);


			}




		}
	}
}
