using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {
	SpriteRenderer s;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	  
	}

	void OnMouseDown(){
		Application.LoadLevel(4);

	}
}
