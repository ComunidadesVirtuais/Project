﻿using UnityEngine;
using System.Collections;

public class ToqueBotao : MonoBehaviour {

	public GameObject leftArrow;
	public GameObject rightArrow;
	private float qtdMovimento;
	public static bool podeApertar = false, podeApertar2 = false, podeApertar3=false,podeApertar4=false;
	public Transform sinalVerde,sinalVermelho;

	// Use this for initialization
	void Start () {

		qtdMovimento = GameObject.Find ("minigameBotoes").GetComponent<Gerenciador> ().qtdMovimento;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()

	{
		if((this.name == "Botao1" && podeApertar)||(this.name == "Botao2" && podeApertar2))
		    if(GameObject.Find ("minigameBotoes").GetComponent<Gerenciador>().EstaEmJogo()){
				podeApertar = false;
				podeApertar2 = false;
				Vector3 pastPos = leftArrow.transform.position;
				leftArrow.transform.position = new Vector3 (pastPos.x + qtdMovimento, pastPos.y, pastPos.z);
				leftArrow.GetComponent<ArrowController> ().SetDirecao (1);
				
				pastPos = rightArrow.transform.position;
				rightArrow.transform.position = new Vector3 (pastPos.x - qtdMovimento, pastPos.y, pastPos.z);
				rightArrow.GetComponent<ArrowController> ().SetDirecao (-1);

		}

		if((this.name == "Botao1" && podeApertar3)||(this.name == "Botao2" && podeApertar4))
		if(GameObject.Find ("minigameBotoes").GetComponent<Gerenciador>().EstaEmJogo()){
			podeApertar3 = false;
			podeApertar4 = false;
			Vector3 pastPos = leftArrow.transform.position;
			leftArrow.transform.position = new Vector3 (pastPos.x - qtdMovimento, pastPos.y, pastPos.z);
			leftArrow.GetComponent<ArrowController> ().SetDirecao (-1);
			
			pastPos = rightArrow.transform.position;
			rightArrow.transform.position = new Vector3 (pastPos.x + qtdMovimento, pastPos.y, pastPos.z);
			rightArrow.GetComponent<ArrowController> ().SetDirecao (+1);
			
		}



	}

	void OnMouseUp(){
		GameObject.Find ("minigameBotoes").GetComponent<Gerenciador> ().emiteSinal ();
	}

	public void emiteSinalCerto(){

	
			Instantiate(sinalVerde,transform.position,transform.rotation);
		}


	public void emiteSinalErrado(){
		
		Instantiate(sinalVermelho,transform.position,transform.rotation);
		
	}
}
