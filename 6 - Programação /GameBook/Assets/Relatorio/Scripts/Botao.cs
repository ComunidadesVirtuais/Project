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

		if (gameObject.name == "Relatorio2") {
						Application.LoadLevel ("relatorio2");
				} else 
			
		if (gameObject.name == "Relatorio") {
			Application.LoadLevel ("relatorio");
		} else 
		if (gameObject.name == "Reset") {
			print ("Deletou tudo");
						for (int j=1; j<=5; j++) {
							int k=1;
							while (PlayerPrefs.HasKey("LPMG"+j+"N"+k)) {
								PlayerPrefs.DeleteKey ("LPMG" + j + "N"+k);	

				
								PlayerPrefs.DeleteKey ("TMG" + j+ "N"+k);
											
								PlayerPrefs.DeleteKey ("BPMG" + j+ "N"+k);
											
								PlayerPrefs.DeleteKey ("APMG" + j+ "N"+k);
											
								PlayerPrefs.DeleteKey ("SMG" + j+ "N"+k);

								PlayerPrefs.DeleteKey ("TMG" + j+ "N"+k);
								k++;
							}
						}

				} else
						Application.LoadLevel(this.gameObject.name);

	}
}
