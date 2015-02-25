using UnityEngine;
using System.Collections;

public class GerenciadorGeral : MonoBehaviour {

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
				}else{
					i = 4;
					pontos = PontuacaoMG4.pontos;
				}

		//Codigos
		// BPMGX = BestPoints do Minigame X
		// LPMGX = Lastpoints do Minigame X
		// APMGX = SumPoints do Minigame X
		// TMGX  = Turns do Minigame X
		// LMG   = Last Minigame
		//PlayerPrefs.DeleteAll();
		

		if( PlayerPrefs.HasKey("LPMG"+i) && PlayerPrefs.HasKey("TMG"+i) && PlayerPrefs.HasKey("BPMG"+i) && PlayerPrefs.HasKey("APMG"+i) && PlayerPrefs.HasKey("LMG") ){
			print("segunda entrada ");
			PlayerPrefs.SetInt("LPMG"+i,pontos);
			if(PlayerPrefs.GetInt("BPMG"+i)<pontos)
				PlayerPrefs.SetInt("BPMG"+i,pontos);
			
			PlayerPrefs.SetFloat("APMG"+i,((pontos + PlayerPrefs.GetInt("TMG"+i) * PlayerPrefs.GetFloat("APMG"+i))/(PlayerPrefs.GetInt("TMG"+i)+1)));
			PlayerPrefs.SetInt("TMG"+i,PlayerPrefs.GetInt("TMG"+i)+1);
			PlayerPrefs.SetInt("LMG",i);
			
		}
		else {
			
			PlayerPrefs.SetInt("LPMG"+i,pontos);				
			
			PlayerPrefs.SetInt("TMG"+i,1);
			
			PlayerPrefs.SetInt("BPMG"+i,pontos);
			
			PlayerPrefs.SetFloat("APMG"+i,pontos);
			
			PlayerPrefs.SetInt("LMG",i);
			
		}
		
		Application.LoadLevel("relatorio");
	}
}
