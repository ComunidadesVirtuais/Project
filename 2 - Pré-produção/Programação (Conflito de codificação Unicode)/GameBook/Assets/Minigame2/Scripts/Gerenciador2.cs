using UnityEngine;
using System.Collections;

public class Gerenciador2 : MonoBehaviour {
	
	private bool emJogo = true;
	public float qtdMovimento = 0.5f;
	public float velocidadeVolta = 0.5f;
	public float resistenciaPorDistancia;
	public int qtdParaGanhar;
	
	// Use this for initialization
	void Start () {
		gameObject.name = "minigameFenda";
	}
	
	// Update is called once per frame
	void Update () {
		
		if(PontosMiniGameArrows.qtd>=qtdParaGanhar){
			print ("aki2");
			PontosMiniGameArrows.qtd = 0;
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
