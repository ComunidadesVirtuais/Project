/// <summary>
/// pontos.cs
/// Created in 10/09/2014
/// Author: Jesse Nery
/// Classe responsavel pela exibiçao das quantidades de pontos que o jogador possui
/// </summary>

using UnityEngine;
using System.Collections;

public class pontos : MonoBehaviour {

	public int ponto = 0;
	// Use this for initialization
	void Start () {
					
				
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setPontos(int qtd){

		ponto = qtd;
		gameObject.guiText.text = "Pontos: " + ponto;
	}

}
