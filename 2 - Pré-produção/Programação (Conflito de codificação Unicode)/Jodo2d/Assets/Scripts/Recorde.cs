/// <summary>
/// Recorde.cs
/// Created in 10/09/2014
/// Author: Jesse Nery
/// Descrição: Classe responsavel por gravar e exibir o recorde do jogador
/// 			Deve ser melhorado!!
/// </summary>
using UnityEngine;
using System.Collections;

public class Recorde : MonoBehaviour {

	// Use this for initialization
	void Start () {


		if(PlayerPrefs.GetInt("Ganhou")==1)
			gameObject.guiText.text = "Voce Ganhou";
		else
			gameObject.guiText.text = "Voce Perdeu";



		if ((PlayerPrefs.HasKey ("Recorde") == false )|| (PlayerPrefs.GetInt ("Pontos") > PlayerPrefs.GetInt ("Recorde"))) {
						PlayerPrefs.SetInt ("Recorde", PlayerPrefs.GetInt ("Pontos"));
					
						gameObject.guiText.text += "\nNovo Recorde " + PlayerPrefs.GetInt ("Pontos");

				} else{
			gameObject.guiText.text += "\nRecorde " + PlayerPrefs.GetInt ("Recorde");
		}
	

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
