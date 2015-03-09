using UnityEngine;
using System.Collections;

public class Camera4 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void nextScene (int i) {
		Application.LoadLevel(i);
	}
}
