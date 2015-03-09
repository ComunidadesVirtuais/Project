using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {
	//public float max;
	//public float min;
//	public float velocidade;
	//public GameObject contador;
	//public int tempoDeVida;

	public int codigo;

	private Vector3 aux;

//	private bool movimentando = true;
	private MapaMinigame4 mapa;

	public int ganhaPontos,perdePontos,combo1,combo2,pontocombo1,pontocombo2;
	public static int contacombo = 0;


	// Use this for initialization
	void Start () {
		mapa = GameObject.Find("Fundo").GetComponent<MapaMinigame4>() as MapaMinigame4;
	}
	
	// Update is called once per frame
	void Update () {

		/*
		if(movimentando)
		transform.Translate(Vector3.up*velocidade*Time.deltaTime);
	    if (transform.position.y > max || transform.position.y < min)
			Destroy(gameObject);

		*/




	}

	void OnMouseDrag(){
	//	movimentando = false;
		//print(Camera.main.ScreenToWorldPoint(Input.mousePosition));

		transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);



	}
	void OnMouseUp(){
		bool[] verificaCombo = {false};
		aux = mapa.testaMapa(this.gameObject,codigo,verificaCombo);
		if(aux != new Vector3(0,0,0)){ /// se acertou no slot destinado a ele
			//Instantiate(contador,aux,transform.rotation);
			PontuacaoMG4.pontos = PontuacaoMG4.pontos + ganhaPontos;
			transform.position = aux;
			//Invoke("quit",tempoDeVida);
			if(!verificaCombo[0]){
				print("combou");
				contacombo++;
			}
			if (contacombo==combo1)
				PontuacaoMG4.pontos = PontuacaoMG4.pontos + pontocombo1;
			if (contacombo==combo2)
				PontuacaoMG4.pontos = PontuacaoMG4.pontos + pontocombo2;


		}
		else {   /// se errou o slot
			print ("Errou");
			contacombo=0;
			PontuacaoMG4.pontos = PontuacaoMG4.pontos - perdePontos;
			GameObject.Find("Gerador2").GetComponent<GeraItens>().mataTodosEComeca();
			GameObject.Find("Gerador1").GetComponent<GeraItens>().mataTodosEComeca();
			//Destroy(gameObject);
		}
	//	if(transform.position)
		//print();

	}

	void OnTriggerEnter2D(Collider2D coll) {
	//void OnCollisionEnter2D(Collision2D coll) {
		//posicao = coll.gameObject.transform.position;
		print ("kikou");

	}

	void quit(){
		PontuacaoMG4.pontos = PontuacaoMG4.pontos - perdePontos;
		Destroy(gameObject);
	}


}
