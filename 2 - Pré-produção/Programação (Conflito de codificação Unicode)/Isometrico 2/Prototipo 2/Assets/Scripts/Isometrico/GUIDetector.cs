using UnityEngine;
using System.Collections;

public class GUIDetector : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver()
	{
		print ("false");
		GameObject.Find ("player").GetComponent<AIPather> ().enabledMovement = false;
	}

	void OnMouseExit()
	{
		print ("true");
		GameObject.Find ("player").GetComponent<AIPather> ().enabledMovement = true;
	}
}
