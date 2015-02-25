using UnityEngine;
using System.Collections;

public class ParticlesScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

		UpdatePosition ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		UpdatePosition ();
	}

	private void UpdatePosition()
	{
		Vector3 pos = GameObject.Find ("Main Camera").GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
		pos.z = 0;
		
		this.transform.position = pos;
	}
}
