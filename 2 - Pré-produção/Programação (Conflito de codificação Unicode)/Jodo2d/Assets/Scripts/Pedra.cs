/// <summary>
/// Pedra.cs
/// Created in 10/09/2014
/// Author: Jesse Nery
/// Descrição: Classe para criaçao do elemento pedra e instanciaçao de uma força inicial. Nao possui metodos
/// Mas necessita de uma posiçao inicia uma final para que seja indicada a direçao do lançamento e um float para a intensidade
/// Esses elementos sao identificados por uma tag AlvoFim e Alvo Inicio
/// </summary>

using UnityEngine;
using System.Collections;

public class Pedra : MonoBehaviour {

	// Use this for initialization
	public float forca;  // força com qual a pedra ira ser lancada
	private Vector2 posInicial;   // posicao inicial do vetor, geralmente o player
	private Vector2 posFinal;    // posicao final do vetor, um elemento externo
	private float timeVida;  //variavel de controle de tempo
	public float tempoMaximoVida; //Parametro de tempo Maximo de vida
	void Start () {
		posFinal = GameObject.FindGameObjectWithTag("AlvoFim").transform.position; // os elementos sao localizados pela tag
		posInicial = GameObject.FindGameObjectWithTag("AlvoInicio").transform.position; // os elementos sao localizados pela tag
		rigidbody2D.AddForce((posFinal-posInicial)*forca);  // iserindo força no inicio desse objeto
	}
	
	// Update is called once per frame
	void Update () {

		autoDestruir ();
	
	}

	void autoDestruir(){

		timeVida += Time.deltaTime;
		if (timeVida >= tempoMaximoVida)
			Destroy (gameObject);
	}
}
