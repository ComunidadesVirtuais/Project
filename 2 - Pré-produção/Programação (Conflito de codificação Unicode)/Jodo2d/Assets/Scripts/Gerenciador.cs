/// <summary>
/// Gerenciador.cs
/// Created in 10/09/2014
/// Author: Jesse Nery
/// Descrição: Classe que controla os estados do jogo, possui controle sobre a quantidade de vidas, pontos globais, pontos de minigames
/// </summary>


using UnityEngine;
using System.Collections;

public class Gerenciador : MonoBehaviour {


	public AudioSource[] audio;
	private bool key = false;
	public int qtdVida = 3;
	public int maxVidas = 3;
	public int pontos = 0;
	public int pontosMinigame = 0;
	public int maxPontos;
	public int continuajogo;
	//public int faseAtual;
	//public int proximaFase;

	private lifes mostradorVidas;
	private pontos mostradorPontos;
	private pontos mostradorPontosMiniGame;

	public GameObject popUp;

	public Transform player;
	private Vector2 posInicial;



	// Use this for initialization
	void Start () {

		//if(!PlayerPrefs.HasKey("volumeSFX"))          //se o jogo é a primeira vez que está sendo carregado deve-se armazenar 100%
		//	PlayerPrefs.SetFloat("volumeSFX",1f);
		//else{
		//	float volumeSFX = PlayerPrefs.GetFloat("volumeSFX");
		//}

		try{
		for(int i= 0;i<5;i++)
			audio[i].volume=AjustaVolume.volumeSFX;
		for(int i= 5;i<8;i++)
			audio[i].volume=AjustaVolume.volumeMusica;
		}
		catch{
			print ("nao alterou o volume dos sons corretamente");
		}

		try {posInicial = player.position;}
		catch{print ("error nao encontrou player");
		}

		try {mostradorVidas = GameObject.FindGameObjectWithTag("Vidas").GetComponent<lifes>() as lifes;}
		catch {print ("error nao encontrou vidas");}

		try {mostradorPontos = GameObject.FindGameObjectWithTag("Pontos").GetComponent<pontos>() as pontos;}
		catch {print ("error nao encontrou pontos");}


		 if (Application.loadedLevel != 1 && PlayerPrefs.HasKey ("Vidas")) {
			qtdVida = PlayerPrefs.GetInt ("Vidas");

		}
		try{
		mostradorVidas.setVidas(qtdVida);
		}catch {print ("error nao conseguiu setar as vidas");}

		if (Application.loadedLevel != 1 && PlayerPrefs.HasKey ("Pontos")) {
			
			pontos = PlayerPrefs.GetInt ("Pontos");
		}
		try{
		mostradorPontos.setPontos (pontos);
		}
		catch {print ("error nao consegui setar os pontos");}
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	public void addVida(){
		audio[0].Play ();
		if (qtdVida < maxVidas) {	
						qtdVida++;
						mostradorVidas.addVidas ();
				}
		}


	public void removerVida()
		{
		audio[1].Play ();
		if(qtdVida>1)
			{		
				qtdVida--;
				mostradorVidas.excluirVidas();
			}
			else if(qtdVida == 1)

		{		PlayerPrefs.SetInt("Pontos", pontos);
				PlayerPrefs.SetInt("Ganhou", 0);
				Application.LoadLevel("GameOver");
			}
		}

	public void audioJump(){
		audio[2].Play (); //audio do jump
	}
	public void audioSlideAcerto(){
		audio[3].Play (); //audio do acerto
	}
	public void audioSlideErro(){
		audio[4].Play (); //audio do Erro
	}
	public void aumentarPontos(int qtd){
		audio[0].Play ();
		pontos = pontos + qtd;
		mostradorPontos.setPontos (pontos);
		//audio[]
	}
	public void diminuirPontos(int qtd){
		pontos = pontos - qtd;
		mostradorPontos.setPontos (pontos);
	}


	public void posicaoInicialJogador(){
		player.position = posInicial;
	}

	public void novoJogo(){
		PlayerPrefs.SetInt("Pontos", 0);
		PlayerPrefs.SetInt("Vidas", 3);
		PlayerPrefs.SetString ("Fase", "Fase1");
		PlayerPrefs.SetInt ("Historia", 0);
		Application.LoadLevel("Historias");
	}
	public void historia5(){
		PlayerPrefs.SetInt ("Historia", 4);
		Application.LoadLevel("Historias");
	}
	public void historia6(){
		PlayerPrefs.SetInt ("Historia", 5);
		Application.LoadLevel("Historias");
	}

	public void fase1(){
		Application.LoadLevel("Fase1");
	}

	public void opcoes(){
		Application.LoadLevel("Opcoes");
	}
	public void menuInicial(){
		Application.LoadLevel("MenuInicial");
	}
	public void sairJogo(){
		Application.Quit();
	}
	public void creditos(){
		Application.LoadLevel("Creditos");
	}
	public void miniGame(){
		Application.LoadLevel("StartMinigame1");
	}



	public void passaFase(string fase){

		PlayerPrefs.SetInt("Pontos", pontos);
		PlayerPrefs.SetInt("Vidas", qtdVida);	
		PlayerPrefs.SetString ("Fase", fase);
		Application.LoadLevel(fase);	
	}

	public void continuaGame(){
		Application.LoadLevel(PlayerPrefs.GetString("Fase"));
	}

	public void ganhaJogo(){
		PlayerPrefs.SetInt("Pontos", pontos);
		PlayerPrefs.SetInt("Ganhou", 1);
		Application.LoadLevel("GameOver");
	}



	public void coletaChave(){
			key = true;
	}
	public bool coletouChave(){
		return key;
	}
	public void info(){
		print ("Coletou a INFO");
		PlayerPrefs.SetInt ("Historia", 3);
		Instantiate(popUp,this.transform.position,this.transform.rotation);
	}
	public bool possuiPontos(){
		if (pontos >= maxPontos)
						return true;
				else
						return false;


	}


}
