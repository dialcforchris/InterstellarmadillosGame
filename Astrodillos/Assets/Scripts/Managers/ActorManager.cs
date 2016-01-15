using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Astrodillos;

public class ActorManager : MonoBehaviour {

	public static ActorManager instance;

	public GameObject astrodilloPlayerPrefab;



	//A list of actors
	public List<Actor> actors { get; private set; }

	string[] characterNames = new string[8] {"Beige", "Red", "Green", "Cyan", "Pink", "Yellow", "Blue", "Purple"};


	// Use this for initialization
	void Awake () {
		instance = this;
		actors = new List<Actor> ();


	}

	void Start(){
		//Debug
		if (GameType_Astrodillos.instance != null) {
			AddPlayer(0);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Debug
	public void AddPlayer(int controllerIndex){
		GameObject newPlayer = Instantiate (astrodilloPlayerPrefab);
		newPlayer.transform.SetParent (gameObject.transform);
		newPlayer.transform.localPosition = new Vector3 (0, 0, 0);
		newPlayer.transform.localScale = new Vector3 (1, 1, 1);
		Actor_AstrodilloPlayer player = newPlayer.GetComponent<Actor_AstrodilloPlayer> ();
		
		player.SetController (controllerIndex);
		player.SetCharacter (characterNames[controllerIndex]);
		AddActor (player);

		HUDManager.instance.CreateHUD (player);
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

	public string GetCharacterName(int index){
		return characterNames [index];
	}
}
