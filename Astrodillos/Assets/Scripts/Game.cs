using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Astrodillos {
	public class Game : MonoBehaviour {

		//Reference to self, allows Game access anywhere
		public static Game game;

		public MissileManager missileManager;
		public ParticleSystem explosionParticles;

		List<Controller> controllers;

		// Use this for initialization
		void Awake () {
			game = this;
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
	}
}
