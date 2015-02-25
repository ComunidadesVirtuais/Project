/// <summary>
/// startGame.cs
/// Created in 10/09/2014
/// Author: Jesse Nery
/// Descrição: Classe responsavel por dar ação de iniciar o jogo na tela de game over 
/// 			Serve para Desktop e android
/// 			
/// <summary/>

using UnityEngine;
using System.Collections;

public class startGame : MonoBehaviour {

	private Gerenciador main; // variavel que recebera uma instancia da main

	// Use this for initialization
	void Start () {
		main = GameObject.Find("Gerenciador").GetComponent<Gerenciador>() as Gerenciador;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.touches.Length>0){
			for(int i=0;i<Input.touchCount; i++){

					if(this.guiTexture.HitTest(Input.GetTouch(i).position)){
						
						if(Input.GetTouch(i).phase == TouchPhase.Began){// Acesso aos métodos da classe Gerenciador.
							if(this.name == "novoJogo")// Quando clicado inicia o jogo.
								main.novoJogo();
							if(this.name == "continuar")// Quando clicado inicia o jogo de onde foi salvo anteriormente.
								main.continuaGame();
						    if(this.name=="opcoes")// Quando clicado abre a (cena) com as opções relativas ao jogo.
							    main.opcoes();
						    if(this.name == "creditos")// Quando clicado  abre a (cena) com os creditos do jogo.
							    main.creditos(); 	
							if(this.name == "voltar")// Um GUI que quando clicado retorna ao Menu Inicial.
								main.menuInicial();
							  if(this.name == "sair")// quando clicado o jogo deverá ser fechado.
								 main.sairJogo();
						}
						//if(Input.GetTouch(i).phase== TouchPhase.Ended){
					    //}
					}
				
			}
		}
		
	}

	void OnMouseDown(){// Mesmos acessos aos métodos feito com o uso do MOUSE.
		if (this.name == "novoJogo")
			 main.novoJogo();
		if (this.name == "continuar")
			main.continuaGame();
		if (this.name=="opcoes")
			 main.opcoes();
		if (this.name == "creditos")
			 main.creditos ();
		if (this.name == "voltar")
			main.menuInicial();
		if (this.name == "sair")
			 main.sairJogo();

		
	}
	
}
