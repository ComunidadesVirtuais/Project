using UnityEngine;
using System.Collections;

public class TrapScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		//print ("[Trap] colidiu com: " + coll.gameObject.name);

		bool permitido = GameObject.Find ("player").GetComponent<Player>().IsVulnerable();
		if(permitido) GameObject.Find ("Vidas").GetComponent<Life> ().excluirVidas ();
	}
}
