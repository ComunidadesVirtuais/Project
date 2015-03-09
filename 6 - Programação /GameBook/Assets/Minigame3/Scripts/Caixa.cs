using UnityEngine;
using System.Collections;

public class Caixa : MonoBehaviour {
	
	//public int codigo;
	public Sprite aberto;
	public Sprite certo;
	//private Mapa maps;
	public bool usou = false;
	private Sprite antigo;
//	private bool exibiu = false;
	private float tempoParaIniciar,tempoDeExibicao;
	private MapaCaixas mapaCaixas;
	
	// Use this for initialization
	void Start () {

		//maps = GameObject.Find("GerenciadorGaiolas").GetComponent<Mapa>() as Mapa;
		antigo = this.gameObject.GetComponent<SpriteRenderer>().sprite;
		mapaCaixas = GameObject.Find("GerenciadorGaiolas").GetComponent<MapaCaixas>() as MapaCaixas;
		tempoDeExibicao = mapaCaixas.tempoDeExibicao;
		tempoParaIniciar = mapaCaixas.tempoParaIniciar;
		Invoke("exibe",tempoParaIniciar);
	}
	
	// Update is called once per frame
	void Update () {


		
	}
	
	void OnMouseDown(){
		if(!usou){
			usou = true;
			this.gameObject.GetComponent<SpriteRenderer>().sprite = aberto;
			mapaCaixas.verifica();
			//maps.chamaMiniGame(codigo);
		}
		
	}

	public void exibe(){

		this.gameObject.GetComponent<SpriteRenderer>().sprite = aberto;
		Invoke("retorna",tempoDeExibicao);



	}
	public void retorna(){
		this.gameObject.GetComponent<SpriteRenderer>().sprite = antigo;
		usou = false;


	}

	public void viraCerto(){
		aberto = certo;

	}
}
