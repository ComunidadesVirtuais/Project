/// <summary>
/// Gerador.cs
/// Created in 10/09/2014
/// Author: Jesse Nery
/// Descrição: Classe criada para gerenciar o surgimento de life e estrela
/// 			Recebe como entrada um vetor de elementos que serão jogados pelo gerador
/// </summary>

using UnityEngine;
using System.Collections;

public class Gerador : MonoBehaviour {
	public GameObject[] objetos;  //Param vetor de GO para serem jogados pelo gerador

	public float velocidade;  // Param de velocidade do gerador
	public float mxDelay;

	public float geradorTempo;
	public float geradorDalay;

	private float timeMovimento = 5f;


	private float timeVida = 0;
	public float tempoMaximoVida;

	// Use this for initialization
	void Start () {
	//	InvokeRepeating ("spawn", geradorTempo, geradorDalay);
	}
	
	// Update is called once per frame
	void Update () {
		movimento ();

	timeVida += Time.deltaTime;
		if (timeVida >= tempoMaximoVida) {
						Invoke ("spawn", 0);
			timeVida = 0;	
		}
	
	}
	void spawn(){

		int index = Random.Range (0, objetos.Length);



		Instantiate (objetos [index], transform.position, objetos [index].transform.rotation);



	}

	void movimento(){

		timeMovimento -= Time.deltaTime;
	
		if (timeMovimento <= 0) {
						timeMovimento = mxDelay;	
						velocidade = -velocidade;
				
		}

	transform.Translate(Vector2.right * velocidade * Time.deltaTime);


	}
}
