using UnityEngine;
using System.Collections;

public class Gerenciador2 : MonoBehaviour {
	
	private bool emJogo = true;
	public float qtdMovimento = 0.5f;
	public float velocidadeVolta = 0.5f;
	public float resistenciaPorDistancia;
	//public int qtdParaGanhar;

	public int ganhaPontos,perdePontos,pontosParaGanhar;
	public float tamanhoDaFenda,velocidadeSeta,posicaoFenda;

		
	
	// Use this for initialization
	void Start () {
		gameObject.name = "minigameFenda";
	}
	
	// Update is called once per frame
	void Update () {
		
		if(GameObject.Find ("Pontuacao1").GetComponent<Points> ().getPoints()>=pontosParaGanhar){
			print ("Ganhou Minigame das Setas");
			GameObject.Find ("Pontuacao1").GetComponent<Points> ().setPoints(0);
			GameObject.Find("GerenciadorGaiolas").GetComponent<MapaMG2>().proximoMiniGame();
			Destroy(gameObject);
		}
		
	}
	
	public bool EstaEmJogo()
	{
		return emJogo;
	}
	
	public void FinalizarJogo()
	{
		emJogo = false;
		Destroy(gameObject);
		// fazer oq tiver de fazer no final
	}
	
	
}
