using UnityEngine;
using System.Collections;

public class ponto : MonoBehaviour {
	
	private float timeVida = 0;
	public float tempoMaximoVida;
	private Gerenciador main;
	public int pontos;
	
	// Use this for initialization
	void Start () {
		main = GameObject.FindGameObjectWithTag("Gerenciador").GetComponent<Gerenciador>() as Gerenciador;
	}
	
	// Update is called once per frame
	void Update () {
		
		timeVida += Time.deltaTime;
		if (timeVida >= tempoMaximoVida)
			Destroy (gameObject);
		
	}
	void OnCollisionEnter2D (Collision2D colisor){
		if (colisor.gameObject.tag == "Player"){
			main.aumentarPontos(pontos);
			Destroy (gameObject);
		}
	}
	
	
}
