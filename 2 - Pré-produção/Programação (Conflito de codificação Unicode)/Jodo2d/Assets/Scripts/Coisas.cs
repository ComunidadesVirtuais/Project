/// <summary>
/// Coisas.cs
/// Created in 10/09/2014
/// Author: Jesse Nery
/// Descrição: Classe criada para gerenciar os eventos das coisas estáticas do jogo: Aguas, Portas, Chaves e Infos
/// </summary>


using UnityEngine;
using System.Collections;

public class Coisas : MonoBehaviour {
	private Gerenciador main;
	// Use this for initialization
	void Start () {
		main = GameObject.FindGameObjectWithTag("Gerenciador").GetComponent<Gerenciador>() as Gerenciador;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnCollisionEnter2D (Collision2D colisor){
		if (colisor.gameObject.name == "Player") {

			if(this.name=="bosskey"){
				main.coletaChave();
				Destroy (gameObject);

			}

			if(this.name == "porta1" && main.coletouChave()){
				main.passaFase("Fase2");
			}
			if(this.name == "porta2a" && main.possuiPontos()){
				main.passaFase("Fase3");
			}
			if(this.name == "porta2b" && main.possuiPontos()){
				main.passaFase("Fase4");
			}
			if(this.name == "porta3" && main.coletouChave()){
				main.passaFase("Fase5");
			}
			if(this.name == "porta4" && main.coletouChave()){
				main.passaFase("Fase5");
			}
			if(this.name == "porta5" && main.possuiPontos() && main.coletouChave()){
				main.historia5();
			}
			if(this.name == "porta6"){
				main.historia6();
			}

		}
		
	}


	void  OnTriggerEnter2D (Collider2D colisor){
		if (colisor.gameObject.tag == "Player"){
			if(this.name=="aguas"){
				main.removerVida();
				main.posicaoInicialJogador();
			}
			if(this.name=="info"){
				main.info();
				main.coletaChave();
				Destroy (gameObject);
			}
		}

	}
}
