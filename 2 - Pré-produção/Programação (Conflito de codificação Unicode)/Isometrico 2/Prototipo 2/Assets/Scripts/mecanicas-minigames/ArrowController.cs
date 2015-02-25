using UnityEngine;
using System.Collections;

public class ArrowController : MonoBehaviour
{
	private Vector3 posInicial;
	private int direcao;
	private float velocidadeVolta;
	private float resistenciaPorDistancia;

	public GameObject popup;

	// Use this for initialization
	void Start () {
		posInicial = this.transform.position;
		velocidadeVolta = popup.GetComponent<Gerenciador> ().velocidadeVolta;
		resistenciaPorDistancia = popup.GetComponent<Gerenciador> ().resistenciaPorDistancia;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(popup.GetComponent<Gerenciador>().EstaEmJogo()) Movimentar();
	}

	// 1 para seta que com toque se move para direita
	// -1 para seta que com toque se move para esquerda

	public void SetDirecao(int value)
	{
		direcao = value;
	}

	private void Movimentar()
	{
		float porcentagemDistancia = 1 - ((GameObject.Find ("EndPoint").transform.position.x - transform.position.x)/(GameObject.Find ("EndPoint").transform.position.x - posInicial.x));
		//print ("%: " + porcentagemDistancia);
		float dif = 0.1f * (velocidadeVolta + (porcentagemDistancia * resistenciaPorDistancia));

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

	public void SetPosicaoInicial(Vector3 newPos)
	{
		posInicial = newPos;
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		popup.GetComponent<Gerenciador> ().FinalizarJogo ();
	}
}
