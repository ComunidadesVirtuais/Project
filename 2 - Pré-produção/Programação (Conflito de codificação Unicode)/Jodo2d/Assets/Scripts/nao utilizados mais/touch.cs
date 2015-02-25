using UnityEngine;
using System.Collections;

public class touch : MonoBehaviour {

	// Use this for initialization
	void OnMouseUp(){
		Debug.Log("Up"+this.name);

	}
	void OnMouseDown(){
		Debug.Log("Down"+this.name);
		print("Entrou");

	}
}
