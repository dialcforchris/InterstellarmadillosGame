using UnityEngine;
using System.Collections;

namespace Astrodillos{
	public class GravityBody : MonoBehaviour {
		SpriteRenderer spriteRend;
		PolygonCollider2D collider;
		// Use this for initialization
		void Awake () {
			spriteRend = GetComponent<SpriteRenderer> ();
			collider = GetComponent<PolygonCollider2D> ();



			//DestroyPlanetChunk ();

		}

		void Start(){



		}
		
		// Update is called once per frame
		void Update () {
			
		}

		void DestroyPlanetChunk(){

			//Make instance of texture 
			Texture2D texInstance = MonoBehaviour.Instantiate<Texture2D> (spriteRend.sprite.texture);

			//Set pixels to transparent
			Color[] pixels = texInstance.GetPixels ();
			
			for (int y = 0; y<pixels.Length; y++) {
				if(y<10000){
					pixels[y] = new Color(0,0,0,0);

				}
			}

			//Apply pixels to tex instance
			texInstance.SetPixels (pixels);
			texInstance.Apply ();

			//Apply texture to sprite
			MaterialPropertyBlock block = new MaterialPropertyBlock ();
			block.AddTexture ("_MainTex", texInstance);
			spriteRend.SetPropertyBlock(block);




		}
	}

}
