/// <summary>
/// Inimigo.cs
/// Created in 10/09/2014
/// Author: Jesse Nery
/// Descrição: Classe que controla as açoes do inimigo desde movimentar, mirar e jogar bomba
/// 		   Possui atributos publicos para controlar o inimigo e privados para auxiliar
/// 		   possui metodos privados para movimentar em x, y e rotacionar, mirar e atacar, colidir e se auto destruir caso colida com a parte de cima do inimigo
/// </summary>


using UnityEngine;
using System.Collections;

public class inimigo : MonoBehaviour {
	public float velocidade;  //Controla a velocidadde com que o inimigo anda
	private bool target;      // Flag para indicar se o player esta na mira
	public bool target2;	  // Flag usado para ajustar altura do inimigo
	public bool target3;	// Flag usado para ajustar altura do inimigo	
	public Transform alvo;  // posiçao que sera passado por parametro que sera o gatilho para lançar uma bomba (isso se o player estiver entre esse alvo e o inimigo)
	public Transform posBomba;       //  posiçao logo abaixo do inimigo para soltar a bomba e nao haver colisoes
	public Transform newPosition;    // posiçao para ajustar a altura do inimigo
	public Transform newPosition2;   // posiçao para ajustar a altura do inimigo
	public GameObject bomba;      // prefab da bomba 
	private float time;			// variavel para gerenciar o tempo
	public float tempoMaximoProximaBomba; // variavel para ser o tempo maximo entre uma bomba e outra do inimigo
	public float velocidadeVertical;   // velocidade vertival do inimigo
	public float minX;   // posiçao mais a esquerda que o inimigo ira
	public float maxX;   // posiçao mais a direita que o inimigo ira
	private float timeRotation = 0.2f;  // variaveis para criar um tempo minimo para proxima rotaçao
	private float timeMaximoRotation = 0.2f;  //variaveis para criar um tempo minimo para proxima rotaçao
	private Gerenciador main;

	void Start(){
		//criaçao de uma instancia da classe principal
		main = GameObject.FindGameObjectWithTag("Gerenciador").GetComponent<Gerenciador>() as Gerenciador;
	}

	// Update is called once per frame
	void Update () {
		movimento ();
		controlaAltura ();
		miraAtaca ();	
	}
	

	void movimento(){  //funçao que controla a velocidade e rotaçao
		
		timeRotation += Time.deltaTime;		// variavel de controle para nao fazer varias rotaçoes
				
		//caso o inimigo esteja menor que o mim permitido ou maior que o max permitido e o tempo para uma nova rotaçao seja permitido
		if ((this.transform.position.x<minX || this.transform.position.x> maxX ) && timeRotation >= timeMaximoRotation) { 
			transform.Rotate(0,180,0);	// faça uma rotaçao de 180º
			timeRotation = 0;		// e resete a variavel de controle de tempo para uma nova rotaçao
			
		}
		
		transform.Translate(-Vector2.right * velocidade * Time.deltaTime);  // esse transforme fara com que o inimigo sempre avançe para sua frente
																			// de acordo com a velocidade da variavel "velocidade"
		
		
	}

	void controlaAltura(){ // funçcao que controla a autura

		target2 = Physics2D.Linecast (this.transform.position,newPosition.position,1<< LayerMask.NameToLayer("Plataforma"));
		target3 = Physics2D.Linecast (this.transform.position,newPosition2.position,1<< LayerMask.NameToLayer("Plataforma"));


		if (target2 && target3) {
			transform.Translate(Vector2.up * velocidadeVertical * Time.deltaTime);		
		}
		else if (!target2 && !target3)
			transform.Translate(-Vector2.up * velocidadeVertical * Time.deltaTime);		
	}



	void OnTriggerEnter2D (Collider2D colisor){  // evento que indica a colisao da parte de cima do inimigo
		if (colisor.gameObject.tag == "Player"){ // caso colida com o jogador
			main.aumentarPontos(30);			// incrementar os pontos do jogador
			Destroy (gameObject);				// autodestruir o inimigo e seus filhos
		}
	}



	void miraAtaca(){			// funçao responsavel por mirar e atacar o player

		target = Physics2D.Linecast(this.transform.position,alvo.position,1<< LayerMask.NameToLayer("UI")); //  se o player passar entre o inimigo e o alvo havera um disparo
		//O player devera se encontrar na camada UI

		time += Time.deltaTime;  // auto incremento da variavel time para que nao seja criada varias bombas
		
		if (target) {  // se o linecast setar o target
			
			if (time >= tempoMaximoProximaBomba) {  // e houver se passado um tempoMaximoProximaBomba 
				Instantiate (bomba, posBomba.transform.position,transform.rotation);  // cria uma bomba
				time = 0;	// e reseta a variavel de controle de proxima bomba
			}
			
			
		}

	}

}
