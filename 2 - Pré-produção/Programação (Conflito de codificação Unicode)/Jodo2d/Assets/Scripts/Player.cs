/// <summary>
/// Player.cs
///  Plataforma movel.cs
/// Created in 10/09/2014
/// Descrição: Classe reponsavel pela movimentaçao do player para Desktop
///				Atraves dele e possivel controlar as animaçoes de correr e pular
/// </summary>


using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public float velocidade; // Param de Velocidade do Player

	public Transform player; // Param de Posiçao do player

	private Animator animator; //Variavel para controlar os estados da animaçao

	public bool isGrounded; // Variavel tipo flag para verifica se esta no chao
	public float force;    //Param para indicar a força do pulo do player

	private float jumpTime = 0.2f; // Variavel para controlar o tempo de pulo
	public float jumpDelay = 0.2f; // Param para tempo maximo de pulo
	private bool jumped;            //Variavel para flag se pulou
	public Transform ground;		// Param para saber se ha uma colisao no chao

	//public Transform mira;	// para implementar mira
	//public GameObject bomba;  // para implementar o prefab de bomba

	private Gerenciador main;


	// Use this for initialization
	void Start () {


		// Instancia da main
		main = GameObject.FindGameObjectWithTag("Gerenciador").GetComponent<Gerenciador>() as Gerenciador;
		//Instancia da animato pegando do GO que possui o animetor
		animator = player.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		movimentar ();
	}
	
	void movimentar(){
		//Line cast para verificar se o GO grouns esta colidindo com GO's da camada plataforma
		isGrounded = Physics2D.Linecast (this.transform.position,ground.position,1<< LayerMask.NameToLayer("Plataforma"));

		//Se houver uma variaçao dos inputs nomeado como horizontal, nesse caso esquerda e direita
		if (Input.GetAxis ("Horizontal")!=0.0f)
						animator.SetFloat ("run", 0.2f); // Setar o parametro do animator para diferente de zero
		else
			animator.SetFloat ("run", 0.0f); //caso nao ha variaçao fica em zero mesmo

		//O if else em acima pode ser substituido por essa linha a seguir:
		//	animator.SetFloat ("run", Mathf.Abs (Input.GetAxis ("Horizontal")));

		if(Input.GetAxisRaw("Horizontal") > 0 ){ //Se o jogador ir para direita, o input sera maior que zero e:
			transform.Translate(Vector2.right * velocidade * Time.deltaTime);// mova o player com "velocidade" para direita
			transform.eulerAngles = new Vector2(0,0);  						// e forçe o player ficar com a cara para direita
		}
		if(Input.GetAxisRaw("Horizontal") < 0 ){ //Se o jogador ir para esquerda, o input sera menor que zero e:
			transform.Translate(Vector2.right * velocidade * Time.deltaTime);// mova o player com "velocidade" para direita
			transform.eulerAngles = new Vector2(0,180);						// e forçe o player ficar com a cara para direita
		}
		if (Input.GetButtonDown ("Jump")&& isGrounded && !jumped) {   // caso o jogador aperte espaço, e verifique se ele esta no chao e nao pulando
			main.audioJump();
			rigidbody2D.AddForce(transform.up*force); // adicione força ao player
			jumpTime = jumpDelay;    				  // resete a variavel de controle de tempo
			jumped = true;							// indica que ele esta pulando nesse exato momento
			animator.SetTrigger("jump");			// seta a animaçao para o do pulo
		}
		/*
		if (Input.GetKey ("z")) {
				
			Debug.DrawLine(gameObject.transform.position, mira.position);
			if(Input.GetKeyDown(KeyCode.DownArrow))
				mira.Translate(-transform.up * Time.deltaTime);
			if(Input.GetKeyDown(KeyCode.UpArrow))
				mira.Translate(transform.up * Time.deltaTime);
			if(Input.GetKeyDown("x")){
				Instantiate (bomba,mira.transform.position,gameObject.transform.rotation);



			}

		}*/

		jumpTime -= Time.deltaTime;  // atualize por um determinado tempo

		if(jumpTime<=0 && isGrounded && jumped){  // ate que ele decremente para zero e que tambem possua um contato com o chao e esteja pulando
			animator.SetTrigger("ground");  // para retornar a animaçao para estatico
			jumped = false;					// e setar a variavel de pulando para falso

		}



		
	}






}