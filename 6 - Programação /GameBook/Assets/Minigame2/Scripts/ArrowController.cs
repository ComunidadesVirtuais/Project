using UnityEngine;
using System.Collections;

public class ArrowController : MonoBehaviour
{
	private Vector3 posInicial;
	private int direcao;
	private float distanciaVolta, distanciaAvanca;

	//private float resistenciaPorDistancia;

	// Use this for initialization
	void Start () {
		posInicial = this.transform.position;
		//distanciaVolta = GameObject.Find ("minigameBotoes").GetComponent<Gerenciador> ().distanciaVolta;
		//resistenciaPorDistancia = GameObject.Find ("minigameBotoes").GetComponent<Gerenciador> ().resistenciaPorDistancia;
	}
	
	// Update is called once per frame
	void Update ()
	{
	//	if(GameObject.Find ("minigameBotoes").GetComponent<Gerenciador>().EstaEmJogo()) Movimentar();
	}

	// 1 para seta que com toque se move para direita
	// -1 para seta que com toque se move para esquerda

	public void SetDirecao(int value)
	{
		direcao = value;
	}
	/*
	private void Movimentar2()
	{

//		print ("%: " + porcentagemDistancia);


		if(direcao == 1) 
		{
			if(transform.position.x > posInicial.x) transform.position = new Vector3(transform.position.x - dif, transform.position.y, transform.position.z); // vai voltar pra sua posicao na esquerda
			else if(transform.position.x < posInicial.x) this.transform.position = posInicial;
		}
		else
		{
			if(transform.position.x < posInicial.x) transform.position = new Vector3(transform.position.x + dif, transform.position.y, transform.position.z); // vai voltar pra sua posicao na direita
			else if(transform.position.x > posInicial.x) this.transform.position = posInicial;	
		}
	}
	*/
	void OnTriggerEnter2D(Collider2D coll)
	{


		GameObject.Find ("minigameBotoes").GetComponent<Gerenciador>().FinalizarJogo();

	}
}
