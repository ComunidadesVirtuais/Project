using UnityEngine;
using System.Collections;

public class ButtonPressed : MonoBehaviour {
	public float valorPrecisaoEsquerda;
	public float valorPrecisaoDireita;
	public Transform fenda;
	private int ganhaPontos,PerdePontos;
	// Use this for initialization
	void Start () {
		ganhaPontos = GameObject.Find("minigameFenda").GetComponent<Gerenciador2>().ganhaPontos;
		PerdePontos = GameObject.Find("minigameFenda").GetComponent<Gerenciador2>().perdePontos;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnMouseDown()
	{
		float posX = GameObject.Find ("Arrow").transform.position.x;
		//print (posX);
		//if((posX >= valorPrecisaoEsquerda) && (posX <= valorPrecisaoDireita)) {print ("acertou");
		if (GameObject.Find ("Hit").GetComponent<Fenda> ().hitou ()) {
						print ("acertou");
						GameObject.Find ("Pontuacao1").GetComponent<Points> ().addPoints (ganhaPontos);
				} else {
						print ("errou " + posX);
						GameObject.Find("Pontuacao1").GetComponent<Points>().addPoints(-PerdePontos);
				}
	}
}
