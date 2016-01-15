using UnityEngine;
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

	
	protected virtual void Awake(){
		animator = GetComponent<Animator> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
}




