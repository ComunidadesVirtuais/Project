/// <summary>
/// Item coletavel.cs
/// Created in 10/09/2014
/// Author: Jesse Nery
/// Descrição: Classe criada para gerenciar os eventos das coisas que são coledas no jogo: Bomba, Coração, Pontos
/// 			Possue um tempo de vida que é passado por param e pontos do item que utilizado para a estrela
/// </summary>

using UnityEngine;
using System.Collections;

public class ItemColetavel : MonoBehaviour {

	public int pontosDoItem;
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
			print (this.name);
			if(this.name == "life(Clone)"){ //se for life
			
				main.addVida(); // adiciona uma vida e se destroi;
			}
			if(this.name == "estrela(Clone)"){ //se for life
				main.aumentarPontos(pontosDoItem); // adiciona 10 pontos e se destroi;
			}
			if(this.name == "bomba(Clone)"){ //se for life
				main.removerVida(); // adiciona uma vida e se destroi;
			}
			
			Destroy (gameObject);
		}
	}
	
	void autoDestruir(){
		
		timeVida += Time.deltaTime;
		if (timeVida >= tempoMaximoVida)
			Destroy (gameObject);
	}
	
	
}
