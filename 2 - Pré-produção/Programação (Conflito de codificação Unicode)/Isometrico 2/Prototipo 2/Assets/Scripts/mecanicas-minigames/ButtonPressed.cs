using UnityEngine;
using System.Collections;

public class ButtonPressed : MonoBehaviour {
	public float valorPrecisaoEsquerda;
	public float valorPrecisaoDireita;
	public int qtdAcertosVitoria;
	private int acertosSeguidos = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnMouseDown()
	{
		if(this.transform.parent.GetComponent<PopupMecanica2>().EstaEmJogo())
		{

			float posX = GameObject.Find ("Arrow").transform.position.x;

			if((posX >= valorPrecisaoEsquerda) && (posX <= valorPrecisaoDireita))
			{
				print (posX + " acertou");
				acertosSeguidos++;
				VerificaCondicaoVitoria();
			}
			else 
			{
				print (posX + " errou");
				acertosSeguidos--;
			}
		}
	}

	private void VerificaCondicaoVitoria()
	{
		if(acertosSeguidos >= qtdAcertosVitoria)
		{
			this.transform.parent.GetComponent<PopupMecanica2>().FinalizarJogo();
		}
	}
}
