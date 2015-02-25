using UnityEngine;
using System.Collections;

public class Botao : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		int i = PlayerPrefs.GetInt ("LMG");

		if (gameObject.name == "Relatorio") {
			Application.LoadLevel("relatorio");
		}
		else if (gameObject.name == "MG1") {
						
						if (i == 1)
								Application.LoadLevel ("minigame");
						else
								Application.LoadLevel ("minigame" + i);
				}
		if (gameObject.name == "Reset") {
			for(int j=1;j<=5;j++){
				PlayerPrefs.SetInt("LPMG"+j,0);				
				
				PlayerPrefs.SetInt("TMG"+j,0);
				
				PlayerPrefs.SetInt("BPMG"+j,0);
				
				PlayerPrefs.SetFloat("APMG"+j,0);
			}

		}

	}
}
