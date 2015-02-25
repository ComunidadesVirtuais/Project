using UnityEngine;
using System.Collections;

public class CalculaAngle : MonoBehaviour {
	public Transform pos1, pos2;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		print(" Angle "+(pos1.eulerAngles.z-pos2.eulerAngles.z));
		//print(" Angle "+pos2.transform.eulerAngles);
		//print(" Angle "+transform.eulerAngles);
	}
}
