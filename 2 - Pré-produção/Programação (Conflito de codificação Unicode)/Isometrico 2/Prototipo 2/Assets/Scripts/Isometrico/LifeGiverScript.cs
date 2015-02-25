using UnityEngine;
using System.Collections;

public class LifeGiverScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		//print ("[Life] colidiu com: " + coll.gameObject.name);
		bool destruirObjeto = GameObject.Find ("Vidas").GetComponent<Life> ().addVidas ();
		if(destruirObjeto) Destroy (this.gameObject);
	}
}
