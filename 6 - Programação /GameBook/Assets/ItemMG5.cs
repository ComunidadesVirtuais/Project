using UnityEngine;
using System.Collections;

public class ItemMG5 : MonoBehaviour {
	//public float max;
	//public float min;
	//	public float velocidade;
	//public GameObject contador;
	//public int tempoDeVida;
	
	public int codigo;
	
	private Vector3 aux;
	
//	private bool movimentando = true;
	private MapaMinigame5 mapa;
	
	public int ganhaPontos,perdePontos,combo1,combo2,pontocombo1,pontocombo2;
	public static int contacombo = 0;
//	private Vector3 pos0;
	
	
	// Use this for initialization
	void Start () {
//		pos0 = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		mapa = GameObject.Find("Fundo").GetComponent<MapaMinigame5>() as MapaMinigame5;
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
			PontuacaoMG5.pontos = PontuacaoMG5.pontos + ganhaPontos;
			//transform.position = aux;
			print ("acertou");
			Destroy(gameObject);
			GameObject.Find("Gerador1").GetComponent<GeraItensMG5>().nextItem();
			//Invoke("quit",tempoDeVida);
			if(!verificaCombo[0]){
				print("combou");
				contacombo++;
			}
			if (contacombo==combo1)
				PontuacaoMG5.pontos = PontuacaoMG5.pontos + pontocombo1;
			if (contacombo==combo2)
				PontuacaoMG5.pontos = PontuacaoMG5.pontos + pontocombo2;
			
			
		}
		else {   /// se errou o slot
			print ("Errou");
			Destroy(gameObject);
			GameObject.Find("Gerador1").GetComponent<GeraItensMG5>().nextItem();
			contacombo=0;
			PontuacaoMG5.pontos = PontuacaoMG5.pontos - perdePontos;
			//GameObject.Find("Gerador2").GetComponent<GeraItens>().mataTodosEComeca();
			//GameObject.Find("Gerador1").GetComponent<GeraItens>().mataTodosEComeca();
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
		Pontuacao.pontos = Pontuacao.pontos - perdePontos;
		Destroy(gameObject);
	}
	
	
}
