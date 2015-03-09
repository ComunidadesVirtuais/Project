using UnityEngine;
using System.Collections;

public class Fenda : MonoBehaviour {
	//public Transform seta;
	public bool hitando = false;
	// Use this for initialization
	void Start () {

		alteraPosicaoX (GameObject.Find ("minigameFenda").GetComponent<Gerenciador2> ().posicaoFenda);
		alteraTamanhoX (GameObject.Find ("minigameFenda").GetComponent<Gerenciador2> ().tamanhoDaFenda);
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void alteraPosicaoX(float x){
		transform.position =  new Vector3(x,transform.position.y,transform.position.z);



		
	}

	void alteraTamanhoX(float x){

		transform.localScale = new Vector3(x,transform.localScale.y,transform.localScale.z);

	}

	public bool hitou(){
		return hitando;

	}

	void OnTriggerEnter2D(Collider2D coll){

		if (coll.gameObject.name == "Arrow") {
			hitando=true;
		}
	}
	void OnTriggerExit2D(Collider2D coll){
		
		if (coll.gameObject.name == "Arrow") {
			hitando=false;
		}
	}
}
