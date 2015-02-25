using UnityEngine;
using System.Collections;

[ExecuteInEditMode]  
public class LookAtPoint : MonoBehaviour {
	
	Vector3 lookAtPoint = Vector3.zero;
	
	void Update () {
		transform.LookAt (lookAtPoint);
	}
}