using UnityEngine;
using System.Collections;

public class ButtonPressed : MonoBehaviour {
	public float valorPrecisaoEsquerda;
	public float valorPrecisaoDireita;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnMouseDown()
	{
		float posX = GameObject.Find ("Arrow").transform.position.x;
		//print (posX);
		if((posX >= valorPrecisaoEsquerda) && (posX <= valorPrecisaoDireita)) {print ("acertou");
			PontosMiniGameArrows.qtd++;
		}
		else print ("errou " + posX);
	}
}
