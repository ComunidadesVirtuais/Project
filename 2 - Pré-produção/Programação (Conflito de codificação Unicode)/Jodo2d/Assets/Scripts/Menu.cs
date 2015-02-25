/// <summary>
/// startGame.cs
/// Created in 10/09/2014
/// Author: Jesse Nery
/// Descrição: Classe responsavel por criar os botoes do menu do jogo
/// 			Deve ser construido
/// 			
/// </summary>

using UnityEngine;
using System.Collections;



public class Menu : MonoBehaviour {
	public GUISkin skinMenu;
	public Texture2D btnIniciar;
	public Texture2D titulo;
	public Texture2D btmSair;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


	
	}

	void OnGUI(){
		GUI.skin = skinMenu;
		GUI.DrawTexture( new Rect ( Screen.width/2 - titulo.width/2, 150, 
		                           titulo.width, titulo.height),
		                           titulo);
		//bool play = GUI.Button ( new Rect ( Screen.width/2 -
		  //                                 164, Screen.height -
		//                                   100, 64, 64),
		             //           btnIniciar);
		//if(play)
		//	Application.LoadLevel(1);

	}

}
