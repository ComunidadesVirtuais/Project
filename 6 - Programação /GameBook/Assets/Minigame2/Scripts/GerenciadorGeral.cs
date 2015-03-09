using UnityEngine;
using System.Collections;

public class GerenciadorGeral : MonoBehaviour {
	public float star1, star2, star3;
	public int timer;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("decreaseTimeRemaining", 1.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {

	}
	private void decreaseTimeRemaining()
	{
		timer--;
		gameObject.guiText.text = "Tempo Geral: " + timer;
		if (timer <= 0)
						Invoke ("win",1.0f);


	}
	void win(){
		print ("Ganhou!!!!!");
		int i;
		int pontos;
		if (this.gameObject.name == "TimeMG2") {
						i = 2;
						pontos = LifeGaiola.pts;
				} else if (this.gameObject.name == "TimeMG3") {
						i = 3;
						pontos = PontosMiniGame3.pts;
				} else if (this.gameObject.name == "TimeMG5") {
						i = 5;
						pontos = PontuacaoMG5.pontos;
				} else if (this.gameObject.name == "TimeMG4") {
						i = 4;
						pontos = PontuacaoMG4.pontos;
				} else {
					i=0;
					pontos = 0;
					print ("error");
				}

		//Codigos
		// BPMGX = BestPoints do Minigame X
		// LPMGX = Lastpoints do Minigame X
		// APMGX = SumPoints do Minigame X
		// TMGX  = Turns do Minigame X
		// LMG   = Last Minigame
		//PlayerPrefs.DeleteAll();
		

		if( PlayerPrefs.HasKey("LP"+Application.loadedLevelName) && PlayerPrefs.HasKey("T"+Application.loadedLevelName) && PlayerPrefs.HasKey("BP"+Application.loadedLevelName) && PlayerPrefs.HasKey("AP"+Application.loadedLevelName) && PlayerPrefs.HasKey("LMG") &&  PlayerPrefs.HasKey("S"+Application.loadedLevelName)){
			print("segunda entrada "+"LP"+Application.loadedLevelName);
			PlayerPrefs.SetInt("LP"+Application.loadedLevelName,pontos);
			if(PlayerPrefs.GetInt("BP"+Application.loadedLevelName)<pontos)
				PlayerPrefs.SetInt("BP"+Application.loadedLevelName,pontos);
			
			PlayerPrefs.SetFloat("AP"+Application.loadedLevelName,((pontos + PlayerPrefs.GetInt("T"+Application.loadedLevelName) * PlayerPrefs.GetFloat("AP"+Application.loadedLevelName))/(PlayerPrefs.GetInt("T"+Application.loadedLevelName)+1)));
			PlayerPrefs.SetInt("T"+Application.loadedLevelName,PlayerPrefs.GetInt("T"+Application.loadedLevelName)+1);
			PlayerPrefs.SetInt("LMG",i);
			if(pontos>=star1 && PlayerPrefs.GetInt("S",0)==0)
				PlayerPrefs.SetInt("S"+Application.loadedLevelName,1);
			if(pontos>=star2 && PlayerPrefs.GetInt("S",0)<=1)
				PlayerPrefs.SetInt("S"+Application.loadedLevelName,2);
			if(pontos>=star3 & PlayerPrefs.GetInt("S",0)<=2)
				PlayerPrefs.SetInt("S"+Application.loadedLevelName,3);
			
		}
		else {
			print("Primeira entrada "+"LP"+Application.loadedLevelName);
			print("LP"+Application.loadedLevelName + pontos);
			PlayerPrefs.SetInt("LP"+Application.loadedLevelName,pontos);				
			
			PlayerPrefs.SetInt("T"+Application.loadedLevelName,1);
			
			PlayerPrefs.SetInt("BP"+Application.loadedLevelName,pontos);
			
			PlayerPrefs.SetFloat("AP"+Application.loadedLevelName,pontos);
			
			PlayerPrefs.SetInt("LMG"+Application.loadedLevelName,i);
			
			if(pontos>=star1 && PlayerPrefs.GetInt("S",0)==0)
				PlayerPrefs.SetInt("S"+Application.loadedLevelName,1);
			if(pontos>=star2 && PlayerPrefs.GetInt("S",0)<=1)
				PlayerPrefs.SetInt("S"+Application.loadedLevelName,2);
			if(pontos>=star3 & PlayerPrefs.GetInt("S",0)<=2)
				PlayerPrefs.SetInt("S"+Application.loadedLevelName,3);
			
		}
		
		Application.LoadLevel("relatorio");
	}
}
