/// <summary>
/// Plataforma movel.cs
/// Created in 10/09/2014
/// Author: Jesse Nery
/// Descrição: Classe que controla a plataforma móvel (ainda em desenvolvimento)
/// 			Testes com funções que trabalham com o rigidybody2d
/// </summary>
using UnityEngine;
using System.Collections;

public class PlataformaMovel : MonoBehaviour {

	private float timeRotation = 0.5f;  // variaveis para criar um tempo minimo para proxima rotaçao
	private float timeMaximoRotation = 0.5f;  //variaveis para criar um tempo minimo para proxima rotaçao
	public float min;   // posiçao mais a esquerda que o inimigo ira
	public float max;   // posiçao mais a direita que o inimigo ira
	public bool horizontal;
	public float velocidade;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		movimento ();
	}

	void movimento(){  //funçao que controla a velocidade e rotaçao

		timeRotation += Time.deltaTime;		// variavel de controle para nao fazer varias rotaçoes

		if (horizontal) {
						this.rigidbody2D.velocity = new Vector2 (1, 0)*velocidade;
						//caso o inimigo esteja menor que o mim permitido ou maior que o max permitido e o tempo para uma nova rotaçao seja permitido
							if (this.rigidbody2D.position.x > max && timeRotation >= timeMaximoRotation) { 
								//transform.Rotate (0, 180, 0);	// faça uma rotaçao de 180º
								//rigidbody2D.position.
								velocidade = - velocidade;
								timeRotation = 0;
								//print ("virou");
								// e resete a variavel de controle de tempo para uma nova rotaçao
			
						}
						if (this.rigidbody2D.position.x < min && timeRotation >= timeMaximoRotation) {
								velocidade = - velocidade;
								timeRotation = 0;
								//transform.Translate (-Vector2.right * velocidade * Time.deltaTime);  // esse transforme fara com que o inimigo sempre avançe para sua frente
								// de acordo com a velocidade da variavel "velocidade"
		
						}
				}
		else{
			
			//caso o inimigo esteja menor que o mim permitido ou maior que o max permitido e o tempo para uma nova rotaçao seja permitido
			if ((this.transform.position.y < min || this.transform.position.y > max) && timeRotation >= timeMaximoRotation) { 
				transform.Rotate (180, 0, 0);	// faça uma rotaçao de 180º
				timeRotation = 0;		// e resete a variavel de controle de tempo para uma nova rotaçao
				
			}
			
			transform.Translate (Vector2.up * velocidade * Time.deltaTime);  // esse transforme fara com que o inimigo sempre avançe para sua frente
			// de acordo com a velocidade da variavel "velocidade"
			
		}
	}
}
