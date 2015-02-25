using UnityEngine;
using System.Collections;

public class MapaCaixas : MonoBehaviour {
	
	public Transform[] posicao;
	public int[] acertos;
	private int[] ganha;
	//public float distanciaParaElemento;
	
	public Sprite Correto; // prefab correto
	//private int[] minigame = {0,0,0}; // vetor que recebe os minigames que serão jogados quando escolhe a gaiola
	//public Transform gaiolas;
	//private int controleMiniGame = 1;
	//private int bonus;

	public float tempoParaIniciar, tempoDeExibicao;
	public int pontosErroSimples,pontosErrosMedio,pontosAcertos;
	public int bonusDouble;
	
	
	// Use this for initialization
	void Start () {
		ganha = new int[acertos.Length];
		for(int i=0;i<acertos.Length;i++){
			ganha[i]=acertos[i];
			
		}

		/*ganha = new GameObject[acertos.Length];
		for(int i=0;i<ganha.Length;i++){
			ganha[i]=null;
		}*/
		
		embaralha();
		
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
/*	public Vector3 testaMapa(GameObject elemento, int codigo, bool[] verifica){
		
		
		float distancia = Vector3.Distance(elemento.transform.position,posicao[0].position);
		int elementoN = 0;
		//print(distancia);
		
		for(int i = 0;i<posicao.Length;i++){
			if(Vector3.Distance(elemento.transform.position,posicao[i].position)<distancia){
				distancia=Vector3.Distance(elemento.transform.position,posicao[i].position);
				elementoN = i;
			}
			
		}
		
		
		
		
		if(distancia<distanciaParaElemento){
			if(acertos[elementoN]==codigo){
				print ("Acertou");
				if(ganha[elementoN]!=null){
					verifica[0] = true;
					Destroy(ganha[elementoN]);
				}
				ganha[elementoN]=elemento;
				ganhou ();
				return posicao[elementoN].position;
			}
			else {
				print ("Errou");
				return new Vector3(0,0,0);
			}
			
		}
		
		
		return new Vector3(0,0,0);
		
	} */
	void ganhou(){
		bool WIN = true;
		for(int i=0;i<ganha.Length;i++)
		if(ganha[i]>1){
			print (acertos[i]);
			WIN = false;
		}
		if(WIN){
			print ("Ganhou!!!!!");
			int pos;
			do{
				pos = (int) Random.Range(0,posicao.Length);
			}while(acertos[pos]>=1);
			posicao[pos].GetComponent<Caixa>().viraCerto();
			ganha[pos] = 2;
			acertos [pos] = 2;
			Invoke("inicia",1.0f);
		}
		
		
	}

	void embaralha(){

		for (int i=0;i<posicao.Length;i++){
			int inicio = Random.Range(0,posicao.Length);
			int fim = Random.Range(0,posicao.Length);
			Vector3 aux3;// = new SpriteRenderer();
			aux3 = new Vector3(posicao[inicio].transform.position.x,posicao[inicio].transform.position.y,posicao[inicio].transform.position.z );
			posicao[inicio].transform.position = new Vector3(posicao[fim].transform.position.x,posicao[fim].transform.position.y,posicao[fim].transform.position.z);
			posicao[fim].transform.position =  new Vector3(aux3.x,aux3.y,aux3.z);
			
		}
	}

	public void verifica (){
		print ("verifica");
		for (int i=0;i<posicao.Length;i++){ // percorre as posiçoes das caixas
			if(posicao[i].GetComponent<Caixa>().usou){ // verificas se o item ja foi usado
				if(ganha[i]==2){  // se ja foi usado e é para pontuar
					PontosMiniGame3.pts = PontosMiniGame3.pts + pontosAcertos;
					ganha[i]= -1; // poe ele para 0
				}
				if(ganha[i]==1){ // se ja ja foi usado e é para perder ponto
					PontosMiniGame3.pts = PontosMiniGame3.pts - pontosErrosMedio;
					ganha[i]= -1; // poe ele para 0 
				}
				if(ganha[i]==0){ // se ja ja foi usado e é para perder ponto
					PontosMiniGame3.pts = PontosMiniGame3.pts - pontosErroSimples;
					ganha[i]= -1; // poe ele para 0
				}
			}
		}
		this.ganhou();
	}
	

	void inicia(){
		for(int i=0;i<acertos.Length;i++){
			ganha[i]=acertos[i];

		}

		for (int i=0;i<posicao.Length;i++){ // percorre as posiçoes das caixas
			posicao[i].GetComponent<Caixa>().retorna();
		}
		embaralha();
		Invoke ("exibeTodos",1.5f);
	}
	void exibeTodos(){

		for (int i=0;i<posicao.Length;i++){ // percorre as posiçoes das caixas
			posicao[i].GetComponent<Caixa>().exibe();
		}
	}
	
	
	
	
}
