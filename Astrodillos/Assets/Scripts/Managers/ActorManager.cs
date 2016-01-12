using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Astrodillos;

public class ActorManager : MonoBehaviour {

	//A list of actors
	public List<Actor> actors { get; private set; }


	// Use this for initialization
	void Awake () {
		actors = new List<Actor> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddActor(Actor actor){
		actors.Add (actor);
	}

	//Parents all actors to gameobject to move across scenes
	public void ParentActors(){
		for(int i =0; i<actors.Count; i++){
			actors[i].gameObject.transform.SetParent(gameObject.transform);
		}
	}

	public void ClearActors(){
		actors.Clear ();
	}
}
