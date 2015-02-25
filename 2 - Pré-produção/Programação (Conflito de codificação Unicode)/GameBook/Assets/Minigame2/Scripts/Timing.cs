using UnityEngine;
using System.Collections;

public class Timing : MonoBehaviour {

	public float velocidadeMovimento;
	public float minX;   // posiçao mais a esquerda que o inimigo ira
	public float maxX;   // posiçao mais a direita que o inimigo ira
	public float timeRotation = 0.2f;  // variaveis para criar um tempo minimo para proxima rotaçao
	private float timeMaximoRotation = 0.2f;  //variaveis para criar um tempo minimo para proxima rotaçao
	private bool flag = false;
	public Transform centro;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//	print (timeRotation);
		timeRotation += Time.deltaTime;		// variavel de controle para nao fazer varias rotaçoes
		transform.Translate(Vector2.right * velocidadeMovimento * Time.deltaTime);  // esse transforme fara com que o inimigo sempre avançe para sua frente	
		//caso o inimigo esteja menor que o mim permitido ou maior que o max permitido e o tempo para uma nova rotaçao seja permitido
		
		
		
		if(timeRotation >= timeMaximoRotation)
		if ((this.transform.localPosition.x<minX || this.transform.localPosition.x> maxX ) ) { 
			//transform.Rotate(0,180,0);	// faça uma rotaçao de 180º
			print("local position x:  "+this.transform.localPosition.x);
			timeRotation = 0;		// e resete a variavel de controle de tempo para uma nova rotaçao
			if(!flag){
				
				flag = !flag;
				transform.eulerAngles = new Vector3(0,180,0);
				transform.position = new Vector3(centro.transform.position.x + maxX,transform.position.y, transform.position.z);
				//transform.Translate(Vector2.right * velocidadeMovimento * Time.deltaTime);  // esse transforme fara com que o inimigo sempre avançe para sua frente	
			}
			else{
				flag = !flag;
				transform.eulerAngles = new Vector3(0,0,0);
				transform.position = new Vector3(centro.transform.position.x + minX,transform.position.y, transform.position.z);
				//transform.Translate(Vector2.right * velocidadeMovimento * Time.deltaTime);  // esse transforme fara com que o inimigo sempre avançe para sua frente	
			}
		}
		
		
		// de acordo com a velocidade da variavel "velocidade"


	}




}

