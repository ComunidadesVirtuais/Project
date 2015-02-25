using UnityEngine;
using System.Collections;

public class LifeGaiola : MonoBehaviour {
	public static int pts = 0;
	

	// Use this for initialization
	void Start () {
		pts = 0;
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = "PONTOS "+pts;
	}
}
