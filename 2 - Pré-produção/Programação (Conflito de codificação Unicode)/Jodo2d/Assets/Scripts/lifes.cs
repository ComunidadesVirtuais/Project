/// <summary>
/// Lifes.cs
/// Created in 10/09/2014
/// Author: Jesse Nery
/// Classe responsavel pela exibiçao das quantidades de vidas que o jogador possui
/// Essa Classe recebe como entrada um vetor de Texture2D em que a menor posiçao possui 1 vida
/// e as demais posiçoes crecentes tem mais vidas
/// Possui  3 metodos: addVidas, excluirVidas e setVidas
/// Sempre tem que setar as vidas antes de aumentar ou diminuir
/// </summary>


using UnityEngine;
using System.Collections;

public class lifes : MonoBehaviour {

	public Texture2D[] vidaAtual;

	//private int maxVidas;
	private int qtdVidas;



	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}



	public void setVidas(int qtd){
		qtdVidas = qtd;// o indice e atualizado pelo parametro qtd
		guiTexture.texture = vidaAtual [qtdVidas-1];//eh setado o elemento indicado do vetor para a textura que exibe
	}

	public void excluirVidas()
	{
		qtdVidas --;// o indice e atualizado
		guiTexture.texture = vidaAtual [qtdVidas-1];//eh setado novo elemento do vetor para a textura que exibe						
				
	}
	public void addVidas() // metodo que adiciona vida
	{
			qtdVidas ++;   // o indice e atualizado
			guiTexture.texture = vidaAtual [qtdVidas - 1]; //eh setado novo elemento do vetor para a textura que exibe

	
	}

}
