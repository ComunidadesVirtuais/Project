using UnityEngine;
using System.Collections;

public class Movimento : MonoBehaviour {

	public float velocidade,forcaDoPulo;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	if (Input.GetKey (KeyCode.RightArrow)) {
						transform.Translate (Vector2.right * velocidade * Time.deltaTime);
				}
	if (Input.GetKey (KeyCode.LeftArrow)) {
		transform.Translate (-Vector2.right * velocidade * Time.deltaTime);
	}
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			transform.Translate (Vector2.up * forcaDoPulo * Time.deltaTime);
		}

	}

	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.name=="StartButton")
			Destroy (coll.gameObject);
	}

}
