﻿using UnityEngine;
using System.Collections;

public class life : MonoBehaviour {
	
	private float timeVida;  //variavel de controle de tempo
	public float tempoMaximoVida; //Parametro de tempo Maximo de vida
	private Gerenciador main; // variavel que recebera uma instancia da main
	
	// Use this for initialization
	void Start () {
		//criaçao de uma instancia da classe principal
		main = GameObject.FindGameObjectWithTag("Gerenciador").GetComponent<Gerenciador>() as Gerenciador;
		
	}	
	// Update is called once per frame
	void Update () {
		autoDestruir ();

		
	}
	void  OnCollisionEnter2D (Collision2D colisor){ //Evento que controla a colisao com player
		if (colisor.gameObject.tag == "Player"){
			main.addVida(); // Se colidir com o player adiciona uma vida e se destroi;
			Destroy (gameObject);
		}
	}

	void autoDestruir(){
		
		timeVida += Time.deltaTime;
		if (timeVida >= tempoMaximoVida)
			Destroy (gameObject);
	}
	
	
}
