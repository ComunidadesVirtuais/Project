using UnityEngine;
using System.Collections;

public class esteira : MonoBehaviour {
	public float max;
	public float min;
	public float velocidade;
	public bool exibeContador;
	public GameObject contador;
	public int tempoDeVida;

	public int codigo;

	private Vector3 aux;

	private bool movimentando = true;
	private Mapa mapa;
	private Animator animacao;

	// Use this for initialization
	void Start () {
		animacao = this.gameObject.GetComponent<Animator> () as Animator;
		mapa = GameObject.Find("Gerenciador").GetComponent<Mapa>() as Mapa;
		animacao.speed = 0.0f;

	}
	
	// Update is called once per frame
	void Update () {


		if(movimentando)
		transform.Translate(Vector3.up*velocidade*Time.deltaTime);
	    if (transform.position.y > max || transform.position.y < min)
			Destroy(gameObject);






	}

	void OnMouseDrag(){
		movimentando = false;
		//print(Camera.main.ScreenToWorldPoint(Input.mousePosition));

		transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);



	}
	void OnMouseUp(){
		bool[] verificaCombo = {false};
		aux = mapa.testaMapa(this.gameObject,codigo,verificaCombo);
		if(aux != new Vector3(0,0,0)){ /// se acertou no slot destinado a ele
			animacao.speed=tempoDeVida/10.0f;
			if(exibeContador)
			Instantiate(contador,aux,transform.rotation);// cria a animação de afundamento
			mapa.ganharPontos(); // pontuaçao quando acerta um slot

			transform.position = aux;
			Invoke("quit",tempoDeVida);
			if(!verificaCombo[0]){
				print("combou");
				mapa.combo();
			}



		}
		else {   /// se errou o slot
			mapa.limpaCombo();
			mapa.perderPontos();
			Destroy(gameObject);
		}
	//	if(transform.position)
		//print();

	}

	void OnTriggerEnter2D(Collider2D coll) {
	//void OnCollisionEnter2D(Collision2D coll) {
		//posicao = coll.gameObject.transform.position;
		print ("tocou");

	}

	void quit(){
//		Pontuacao.pontos = Pontuacao.pontos - perdePontos;
		mapa.perderPontos();
		Destroy(gameObject);
	}


}
