/// <summary>
/// resetGame.cs
/// Created in 10/09/2014
/// Author: Jesse Nery
/// Descrição: Classe responsavel por dar ação de resetar o jogo na tela de game over 
/// 			Serve para Desktop e android
/// 			
/// </summary>

using UnityEngine;
using System.Collections;

public class resetGame : MonoBehaviour {
	
	private Gerenciador main;
	
	// Use this for initialization
	void Start () {
		main = GameObject.FindGameObjectWithTag("Gerenciador").GetComponent<Gerenciador>() as Gerenciador;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.touches.Length>0){
			for(int i=0;i<Input.touchCount; i++){
				
				if(this.guiTexture.HitTest(Input.GetTouch(i).position)){
					
					if(Input.GetTouch(i).phase == TouchPhase.Began){
						if(name=="RESET")
							main.fase1();
						if(name=="CONTINUE")
							main.continuaGame();
							
						
					}

				}
				
			}
		}
		
		
	}
	void OnMouseDown(){
		if(name=="RESET")
			main.fase1();
		if(name=="CONTINUE")
			main.continuaGame();
		
	}
}
