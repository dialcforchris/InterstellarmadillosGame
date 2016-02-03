using UnityEngine;
using System.Collections;

public class TestAnim : MonoBehaviour {

	Animator anim;

	Controller controller{
		get{ return ControllerManager.instance.GetController (0); }
		set{ }
	}
	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 stickAim = new Vector2 (controller.rightButton.GetValue (), controller.upButton.GetValue ());
		if (stickAim.x != 0 || stickAim.y != 0) {
			float angle = (Mathf.Atan2(stickAim.x, -stickAim.y) * Mathf.Rad2Deg);

			//Flip x scale if less than 0 angle - temp untill left side sprites?
			int xScale = (angle>=0) ? 1 : -1;
			gameObject.transform.localScale = new Vector3(xScale,1,1);


			anim.SetFloat("angle", Mathf.Abs(angle));
			anim.SetBool ("walking", true);
		}
	}
}
