using UnityEngine;
using System.Collections;

public class WaitMe : MonoBehaviour {


	public void wait(float f) {

		float i = f;

		while(i>0){
			i -= Time.deltaTime;
		}
	}
}