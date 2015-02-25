using UnityEngine;
using System.Collections;

public class MovimentoBorboleta : MonoBehaviour {

	private bool movimento = false;
	private string direcao = "";
	public float velocidade = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(movimento) Movimentar();
	}

	public void IniciarMovimento(string pDirecao)
	{
		//print ("[MovimentoBorboleta] IniciarMovimento");
		movimento = true;
		direcao = pDirecao;
	}

	private void Movimentar()
	{
		//print ("[MovimentoBorboleta] Movimentar " + direcao);
		switch(direcao)
		{
			case "direita": transform.Translate(Vector2.right * velocidade * Time.deltaTime); transform.eulerAngles = new Vector2(0,0); break;
			case "esquerda": transform.Translate(Vector2.right * velocidade * Time.deltaTime); transform.eulerAngles = new Vector2(0,180); break;
			case "cima": transform.Translate(Vector2.up * velocidade * Time.deltaTime); break;
			case "baixo": transform.Translate(Vector2.up * -velocidade * Time.deltaTime); break;
		}
	}

	void OnTriggerExit2D(Collider2D colisor)
	{
		movimento = false;
		Destroy (gameObject);
		GameObject.Find ("Main Camera").GetComponent<LoadScene> ().ShowGUIElements ();
	}
}
