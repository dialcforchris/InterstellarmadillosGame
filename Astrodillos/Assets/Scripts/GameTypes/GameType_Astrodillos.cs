﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Astrodillos {
	public class GameType_Astrodillos : GameType {

		//Reference to self, allows Game access anywhere
		public static GameType_Astrodillos instance;

		public MissileManager missileManager;
		public ParticleSystem explosionParticles;
		public HUDManager hudManager;


		ActorManager actorManager {
			set {}
			get { return GameManager.instance.actorManager; }
		}

		List<Controller> controllers;

		// Use this for initialization
		void Awake () {
			instance = this;
			GameManager.instance.gameType = this;


			//Spawn players when we start
			SpawnPlayers ();
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		//Use the single particle emitter for all explosions
		public void Explosion(Vector3 explosionPos, float explosionSize = 0.2f){
			explosionParticles.transform.position = explosionPos;

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

		void SpawnPlayers(){
			List<Actor_AstrodilloPlayer> newPlayers = new List<Actor_AstrodilloPlayer>();
		
			for (int i = 0; i<actorManager.actors.Count; i++) {
				//TODO make sure right character spawns
				GameObject player = Instantiate(actorPrefab);
				Actor_AstrodilloPlayer actor = player.GetComponent<Actor_AstrodilloPlayer>();

				actor.SetController(actorManager.actors[i].controllerID);

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