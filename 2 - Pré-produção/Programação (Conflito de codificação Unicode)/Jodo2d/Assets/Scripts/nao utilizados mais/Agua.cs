using UnityEngine;
using System.Collections;

public class Agua : MonoBehaviour {
	private Gerenciador main;
	// Use this for initialization
	void Start () {
		main = GameObject.FindGameObjectWithTag("Gerenciador").GetComponent<Gerenciador>() as Gerenciador;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void  OnTriggerEnter2D (Collider2D colisor){
		if (colisor.gameObject.tag == "Player"){
			main.removerVida();
			main.posicaoInicialJogador();
		}
	}
}
