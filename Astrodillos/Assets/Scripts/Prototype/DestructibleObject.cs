using UnityEngine;
using System.Collections;

public class DestructibleObject : MonoBehaviour {

	SpriteRenderer spriteRenderer;
	Sprite sprite;
	Collider2D collider;

	Texture2D spriteTex;
	// Use this for initialization
	void Awake () {
		//Instance sprite texture so we can modify it
		spriteRenderer = GetComponent<SpriteRenderer> ();
		sprite = spriteRenderer.sprite;
		collider = GetComponent<Collider2D> ();
		Texture2D tex = sprite.texture;

		spriteTex = new Texture2D (tex.width, tex.height, TextureFormat.ARGB32, false);
		spriteTex.SetPixels32(tex.GetPixels32());
		spriteTex.Apply();
		spriteRenderer.sprite = Sprite.Create(spriteTex, spriteRenderer.sprite.rect, new Vector2(0.5f, 0.5f));

	}

	//TODO work with rotated objects
	public void DestroyPixels(SpriteRenderer mask){
		//If the mask actually intersects with the bounds of the sprite
		if (mask.bounds.Intersects (spriteRenderer.bounds)) {

			for (int x = 0; x<mask.sprite.texture.width; x++) {


				for (int y = 0; y<mask.sprite.texture.height; y++) {

					//If this pixel is transparent
					if(mask.sprite.texture.GetPixel(x,y).a!=0){
						//Pixel in worlspace
						Vector2 worldSpace = new Vector2(mask.bounds.min.x + (x/mask.sprite.pixelsPerUnit), 
						                                 mask.bounds.min.y + (y/mask.sprite.pixelsPerUnit));
						//Uses the world space to find the corresponding pixel on the object
						Vector2 spritePixel = new Vector2((worldSpace.x - spriteRenderer.bounds.min.x) * sprite.pixelsPerUnit,
						                                  (worldSpace.y - spriteRenderer.bounds.min.y) * sprite.pixelsPerUnit);

						int spriteX = Mathf.RoundToInt(spritePixel.x);
						int spriteY = Mathf.RoundToInt(spritePixel.y);

						if(spriteX>0 && spriteX<sprite.texture.width &&
						   spriteY>0 && spriteY<sprite.texture.height){
							spriteTex.SetPixel(spriteX,spriteY, new Color(0,0,0,0));
						}
					}
				}
			}
		}
		
		spriteTex.Apply ();

		//Refresh collider
		Destroy(collider);
		collider = gameObject.AddComponent<PolygonCollider2D> ();

	}
}
