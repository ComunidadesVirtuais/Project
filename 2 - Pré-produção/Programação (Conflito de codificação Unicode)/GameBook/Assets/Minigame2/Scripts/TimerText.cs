using UnityEngine;
using System.Collections;

public class TimerText : MonoBehaviour {


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setTime(int value)
	{
		gameObject.guiText.text = "Time left: " + value;
	}
}
