using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class Actor : MonoBehaviour {
	
	[HideInInspector]
	public int controllerID = 0;
	
	protected Controller controller{
		set{}
		get{ return ControllerManager.instance.GetController (controllerID);}
	}
	
	
	protected SpriteRenderer spriteRenderer;
	protected Animator animator;
	protected Rigidbody2D body;
	
	protected string characterName;
	
	
	protected Weapon weapon;
   // protected Weapon weapon2;
	//Array of sprites in the character's spritesheet
	private Sprite[] subSprites;
	
	
	protected virtual void Awake(){
        
		animator = GetComponent<Animator> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
		body = GetComponent<Rigidbody2D> ();
		
		//Debug set character to placeholder
		SetCharacter ("placeholder");
		//Weapon
		//weapon = gameObject.AddComponent<Weapon_Bazooka> ();
        weapon = gameObject.AddComponent<Weapon_MachineGun>();
	}
	
	// Use this for initialization
	protected virtual void Start () {
		
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		
	}
	
	protected virtual void LateUpdate(){
		SetSprite ();
	}
	
	//Set's character along with spritesheet
	public void SetCharacter(string name){
		characterName = name;
		
		//Load an array of all sprites in the spritesheet
		subSprites = Resources.LoadAll <Sprite> ("Spritesheets/Armadillos/armad_" + characterName + "_atlas");
		SetSprite ();
	}
	
	public virtual void SetController(int id){
		controllerID = id;
	}
	
	public string GetName(){
		return characterName;
	}
	
	public virtual void Spawn(Vector2 spawnPos){
		transform.position = new Vector3(spawnPos.x, spawnPos.y,0);
	}
	
	public void TakeDamage(){
		
	}
	
	void SetSprite(){
		if (characterName == null) {
			return;
		}
		string spriteName = spriteRenderer.name;
		
		//Find the name of the current sprite in the loaded spritesheet
		Sprite newSprite = Array.Find(subSprites, item => item.name == spriteName);
		if(newSprite!=null){
			spriteRenderer.sprite = newSprite;
		}
	}
	
}