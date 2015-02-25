using UnityEngine;
using System.Collections;

public class Gerenciador : MonoBehaviour {

	public bool emJogo = true;
	public float qtdMovimento = 0.5f;
	public float velocidadeVolta = 0.5f;
	public float resistenciaPorDistancia;
	public float waitTime;
	//public int qtdParaGanhar;


	// Use this for initialization
	void Start () {
		//emJogo = true;

		gameObject.name = "minigameBotoes";
		//InvokeRepeating("chamaSinais",0.0f,1.0f);
		emiteSinal ();
	}
	
	// Update is called once per frame
	void Update () {

	

	}

	public bool EstaEmJogo()
	{
		return emJogo;
	}

	public void FinalizarJogo()
	{

		ToqueBotao.podeApertar = false;
		ToqueBotao.podeApertar2 = false;
		ToqueBotao.podeApertar3 = false;
		ToqueBotao.podeApertar4 = false;
				
		emJogo = false;
		GameObject.Find("GerenciadorGaiolas").GetComponent<MapaMG2>().proximoMiniGame();
		Destroy(gameObject);
		// fazer oq tiver de fazer no final
	}

	public void waitNewSignal(){
		if (ToqueBotao.podeApertar3 || ToqueBotao.podeApertar4) {
						ToqueBotao.podeApertar = false;
						ToqueBotao.podeApertar2 = false;
						ToqueBotao.podeApertar3 = false;
						ToqueBotao.podeApertar4 = false;
				}
		emiteSinal ();
		}

	public void chamaSinais(){
		

			
			GameObject.Find("Botao1").GetComponent<ToqueBotao>().emiteSinalCerto();

	}
	
	public void chamaSinais2(){
			GameObject.Find("Botao2").GetComponent<ToqueBotao>().emiteSinalCerto();

	}

	public void chamaSinaisErrado(){
		
		
		
		GameObject.Find ("Botao1").GetComponent<ToqueBotao> ().emiteSinalErrado ();
		
	}
	
	public void chamaSinais2Errado(){
		GameObject.Find ("Botao2").GetComponent<ToqueBotao> ().emiteSinalErrado ();
		
	}

	public void emiteSinal(){

		if(emJogo)
		if(!ToqueBotao.podeApertar && !ToqueBotao.podeApertar2 && !ToqueBotao.podeApertar3 && !ToqueBotao.podeApertar4){
			int rand = Random.Range(1,6);
			
			if(rand==1||rand==2){
				ToqueBotao.podeApertar = true;
				Invoke("chamaSinais",0.0f);
			}
			else if(rand==3 || rand==4){
				ToqueBotao.podeApertar2 = true;
				Invoke("chamaSinais2",0.0f);
			}else if(rand==5){
				ToqueBotao.podeApertar3 = true;
				Invoke("chamaSinaisErrado",0.0f);
				Invoke("waitNewSignal",waitTime);
				
			}
			else if(rand == 6){
				ToqueBotao.podeApertar4 = true;
				Invoke("chamaSinais2Errado",0.0f);
				Invoke("waitNewSignal",waitTime);
				
				
			}
			
		}

	}


}
