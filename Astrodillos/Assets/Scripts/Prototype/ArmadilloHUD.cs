using UnityEngine;
using System.Collections;
using DG.Tweening;

public class ArmadilloHUD : MonoBehaviour {

	public GameObject fuelFill;
	public GameObject ammo;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateFuelFill(float fillAmount){
		fuelFill.transform.localScale = new Vector3 (fillAmount, 1, 1);
	}

	public void RemoveAmmo(){
		DOTween.To(()=> ammo.transform.localScale, x=> ammo.transform.localScale = x, new Vector3(0,0,1), 0.1f);
	}

	public void RefillAmmo(){
		DOTween.To(()=> ammo.transform.localScale, x=> ammo.transform.localScale = x, new Vector3(1,1,1), 0.1f);
	}
}
