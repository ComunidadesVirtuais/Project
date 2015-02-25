using UnityEngine;
using System.Collections;

public class AjustarPlanoDeFundo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.position = new Vector3(0,0,1);
		transform.localScale = Vector3.zero;
		guiTexture.pixelInset = new Rect(0, 0, Screen.width, Screen.height); 

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
