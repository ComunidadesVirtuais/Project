using UnityEngine;
using System.Collections;

public class Timing : MonoBehaviour {

	public float velocidadeMovimento;
	public float minX;   // posiçao mais a esquerda que o inimigo ira
	public float maxX;   // posiçao mais a direita que o inimigo ira
	private float timeRotation = 0.2f;  // variaveis para criar um tempo minimo para proxima rotaçao
	private float timeMaximoRotation = 0.2f;  //variaveis para criar um tempo minimo para proxima rotaçao
	private float direcao = 1;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(this.transform.parent.GetComponent<PopupMecanica2>().EstaEmJogo()) movimento ();
	}

	void movimento(){  //funçao que controla a velocidade e rotaçao
		
		timeRotation += Time.deltaTime;		// variavel de controle para nao fazer varias rotaçoes



		//caso o inimigo esteja menor que o mim permitido ou maior que o max permitido e o tempo para uma nova rotaçao seja permitido
		if ((this.transform.localPosition.x<minX || this.transform.localPosition.x> maxX ) && timeRotation >= timeMaximoRotation) { 

			if(direcao > 0) transform.eulerAngles = new Vector3(0, 180, 0);
			else transform.eulerAngles = new Vector3(0, 0, 0);

			direcao *= -1;

			timeRotation = 0;		// e resete a variavel de controle de tempo para uma nova rotaçao
	
		}

		this.transform.Translate(Vector2.right * velocidadeMovimento * Time.deltaTime * direcao, Space.World);  // esse transforme fara com que o inimigo sempre avançe para sua frente
		// de acordo com a velocidade da variavel "velocidade"
	}
}
