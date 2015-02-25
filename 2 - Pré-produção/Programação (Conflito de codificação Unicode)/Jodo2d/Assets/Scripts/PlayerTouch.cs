/// <summary>
/// Player touch.cs
///  Plataforma movel.cs
/// Created in 10/09/2014
/// Descrição: Classe reponsavel pela movimentaçao do player para dispositivo móvel
///				Atraves dele e possivel controlar as animaçoes de correr e pular
/// </summary>

using UnityEngine;
using System.Collections;

public class PlayerTouch : MonoBehaviour {
	
	public float velocidade;
	

	
	public Transform angulo; // game object que indica o angulo de lancamento da pedra
	
	
	public Transform player;
	public Transform player2;
	private Vector2 posInicial;
	private Animator animator;
	
	public bool isGrounded;
	public float force;
	
	public float jumpTime = 0.4f;
	public float jumpDelay = 0.4f;
	public bool jumped;
	public Transform ground;
	//public GUITexture mira;
	private PlayerTouch mira;
	public bool estaMirando;

	public GameObject bomba;

	public Material mat;

	
	// Use this for initialization
	void Start () {
		if(this.name != "Mira"){
			mira = GameObject.FindGameObjectWithTag("Mira").GetComponent<PlayerTouch>() as PlayerTouch;

		}

		animator = player.GetComponent<Animator> ();

		LineRenderer line = gameObject.AddComponent<LineRenderer>();
		line.SetWidth(0.0f,0.0f);
		line.material = mat;
		line.sortingLayerName = "ForenGround";

	}
	
	// Update is called once per frame
	void Update () {

		movimentar ();
	}
	
	void movimentar(){ 
		LineRenderer line = GetComponent<LineRenderer>();

		
		isGrounded = Physics2D.Linecast (player2.transform.position,ground.position,1<< LayerMask.NameToLayer("Plataforma"));



		foreach (UnityEngine.Touch touch in Input.touches){

			if(this.guiTexture.HitTest(touch.position))
			{
				if (touch.phase != TouchPhase.Ended)
				{
					if(this.name == "Mira"){
						Debug.DrawLine(player2.transform.position, angulo.position);  // desenha a linha de mira
					
						line.SetColors(Color.red,Color.black);
						line.SetWidth(0.05f,0.2f);
						line.SetVertexCount(2);
						line.SetPosition(0,player2.transform.position);
						line.SetPosition(1,angulo.position);


						estaMirando = true;
						print("Mirou");
						
					} else{
					if(this.name == "Direita" && !mira.estaMirando){
							animator.SetFloat ("run", 0.2f);
							player2.transform.Translate(Vector2.right * velocidade * Time.deltaTime);
							player2.transform.eulerAngles = new Vector2(0,0);

						}
						if(this.name == "Direita" && mira.estaMirando){
								print("subindo o angulo");
								//angulo.Translate(transform.up * Time.deltaTime);
						//	angulo.localRotation= Quaternion.Euler(0.0f,45.0f,0.0f);
							angulo.RotateAround(player2.position, new Vector3(0,0,1),15f);

								//Rotate(0,0,15,Space.World);
						}
						if(this.name == "Esquerda" && !mira.estaMirando){
							animator.SetFloat ("run", 0.2f);
							player2.transform.Translate(Vector2.right * velocidade * Time.deltaTime);
							player2.transform.eulerAngles = new Vector2(0,180);
						}
						if(this.name == "Esquerda" && mira.estaMirando){
								angulo.Translate(-transform.up * Time.deltaTime);
								print("descendo o angulo");
						}
						if(this.name == "up" && isGrounded && !jumped && !mira.estaMirando){
							//print(transform.up);
							player2.rigidbody2D.AddForce(transform.up*force);
							
							jumpTime = jumpDelay;
							jumped = true;
							animator.SetTrigger("jump");
						}
					}

				}
				if(touch.phase == TouchPhase.Ended)
				{
					print("entrou");
					if(this.name == "Mira")
					{   line.SetWidth(0.0f,0.0f);
						Instantiate (bomba,angulo.transform.position,gameObject.transform.rotation);
						estaMirando = false;
						
					}
					animator.SetFloat ("run", 0.0f);

				}
			}

		}



		
		jumpTime -= Time.deltaTime;
		
		if(jumpTime<=0 && isGrounded && jumped){
			animator.SetTrigger("ground");
			jumped = false;
			
		}
		
		
		
		
	}
	
	

	
	
}