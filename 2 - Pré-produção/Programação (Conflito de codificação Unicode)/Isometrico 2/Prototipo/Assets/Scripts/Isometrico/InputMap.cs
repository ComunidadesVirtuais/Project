using UnityEngine;
using System.Collections;

public class InputMap : MonoBehaviour {

	int teste = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver(){
		//print ("over");
	}

	void OnMouseExit(){
		//print ("out");
	}

	void OnMouseDown()
	{
		teste++;
		//print ("colisao: " + teste);
		//GameObject.Find ("player").GetComponent<AIPather> ().GetPath ();
	}
}
