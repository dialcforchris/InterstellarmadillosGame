using UnityEngine;
using System.Collections;

namespace Astrodillos {
	public class Armadillo : MonoBehaviour {
		
		float jetpackPower = 0.1f;
		float rotateSpeed = 60f;
		
		Rigidbody2D body;
		// Use this for initialization
		void Awake () {
			body = GetComponent<Rigidbody2D>();
		}
		
		// Update is called once per frame
		void Update () {
			if (Input.GetKey(KeyCode.Space)){
				Thrust();
			}

			UpdateRotation ();

		}
		
		void Thrust(){
			body.AddForce(transform.up * jetpackPower);
		}


		void UpdateRotation(){
			if (Input.GetKey (KeyCode.D)) {
				Rotate(-1);
				return;
			}
			if (Input.GetKey (KeyCode.A)) {
				Rotate(1);
				return;
			}

			//Stop rotating
			Rotate (0);
		}

		void Rotate(float rotDir){
			body.angularVelocity = rotDir * rotateSpeed;
		}
	}
}


