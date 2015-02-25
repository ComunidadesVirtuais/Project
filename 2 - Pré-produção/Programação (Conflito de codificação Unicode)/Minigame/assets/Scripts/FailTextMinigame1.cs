using UnityEngine;
using System.Collections;

public class FailTextMinigame1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		if(PlayerPrefs.GetInt ("Highscore_minigame1") >0) gameObject.guiText.text = "Alcance " + PlayerPrefs.GetInt ("Highscore_minigame1") + " pontos para completar o desafio.";
		else gameObject.guiText.text = "Voce venceu! yahooo!!  :-)";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
