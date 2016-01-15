using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using Astrodillos;


public class Actor : MonoBehaviour {
	[HideInInspector]
	public int controllerID;


	protected ControllerManager controllerManager{
		set {}
		get { return ControllerManager.instance; }
	}
	protected Controller controller{
		set{}
		get{ return controllerManager.GetController (controllerID);}
	}

	protected Animator animator;


	
	protected string characterName;

	//Array of sprites in the character's spritesheet
	Sprite[] subSprites;

	
	protected virtual void Awake(){
		animator = GetComponent<Animator> ();

	}

	// Use this for initialization
	protected virtual void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LateUpdate(){
		SetSprite ();
	}

	//Set's character along with spritesheet
	public void SetCharacter(string name){
		characterName = name;

		//Load an array of all sprites in the spritesheet
		subSprites = Resources.LoadAll <Sprite> ("Spritesheets/Armadillos/Armadillo_" + characterName + "_Atlas");
		SetSprite ();
	}
	
	public virtual void SetController(int id){
		controllerID = id;
	}
	
	public string GetName(){
		return characterName;
	}

	public virtual void Spawn(Vector2 spawnPos, float spawnAngle){
		transform.position = new Vector3(spawnPos.x, spawnPos.y,0);
		transform.localEulerAngles = new Vector3 (0, 0, spawnAngle);
	}

	void SetSprite(){
		if (characterName == null) {
			return;
		}
		string spriteName = GetSprite().name;

		//Find the name of the current sprite in the loaded spritesheet
		Sprite newSprite = Array.Find(subSprites, item => item.name == spriteName);
		if(newSprite!=null){
			SetSprite(newSprite);
		}
	}

	//Implemented in children
	public virtual Sprite GetSprite(){
		return null;
	}

	//Implemented in children
	public virtual void SetSprite(Sprite sprite){
		return;
	}
}




