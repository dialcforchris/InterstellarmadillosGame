using UnityEngine;
using System.Collections;

public class lineRedn : MonoBehaviour {

    LineRenderer line;
	// Use this for initialization
	void Start () {
        line = GetComponent<LineRenderer>();
        line.sortingLayerName="Background";
        line.sortingOrder = 2;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
