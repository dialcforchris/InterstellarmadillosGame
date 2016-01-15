using UnityEngine;
using System.Collections;
using Astrodillos;


public class Actor : MonoBehaviour {
	[HideInInspector]
	public int controllerID;
	
	protected string characterName;
	protected ControllerManager controllerManager{
		set {}
		get { return ControllerManager.instance; }
	}
	protected Controller controller{
		set{}
		get{ return controllerManager.GetController (controllerID);}
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
}




