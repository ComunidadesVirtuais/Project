using UnityEngine;
using System.Collections;

public class MapaMG2 : MonoBehaviour {
	
	public Transform[] posicao;
	public int[] acertos;
	private GameObject[] ganha;
	public float distanciaParaElemento;
	
	public Transform[] MG; // vetor de minigames
	private int[] minigame = {0,0,0}; // vetor que recebe os minigames que serão jogados quando escolhe a gaiola
	public Transform gaiolas;
	private int controleMiniGame = 1;
	private int bonus;
	public int bonusDouble;
	private Transform aux,auxCadeado;
	
	
	// Use this for initialization
	void Start () {
		
		ganha = new GameObject[acertos.Length];
		for(int i=0;i<ganha.Length;i++){
			ganha[i]=null;
		}
		
		for (int i=0;i<posicao.Length;i++){
			int inicio = Random.Range(0,posicao.Length);
			int fim = Random.Range(0,posicao.Length);
			Vector3 aux3;// = new SpriteRenderer();
			aux3 = new Vector3(posicao[inicio].transform.position.x,posicao[inicio].transform.position.y,posicao[inicio].transform.position.z );
			posicao[inicio].transform.position = new Vector3(posicao[fim].transform.position.x,posicao[fim].transform.position.y,posicao[fim].transform.position.z);
			posicao[fim].transform.position =  new Vector3(aux3.x,aux3.y,aux3.z);
			
		}
		
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public Vector3 testaMapa(GameObject elemento, int codigo, bool[] verifica){
		
		
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
		
	}
	void ganhou(){
		bool WIN = true;
		for(int i=0;i<ganha.Length;i++)
		if(ganha[i]==null){
			print (ganha[i]);
			WIN = false;
		}
		if(WIN){
			print ("Ganhou!!!!!");
			
			/*if(!PlayerPrefs.HasKey("BestMinigame1")  && !PlayerPrefs.HasKey("LastPointsMG1")){
				print("primeira entrada ");
				PlayerPrefs.SetInt("LastPointsMG1",Pontuacao.pontos);
				
				PlayerPrefs.SetInt("BestMinigame1",Pontuacao.pontos);
				//PlayerPrefs.Save();
			}
			else{
				print("segunda entrada ");
				PlayerPrefs.SetInt("LastPointsMG1",Pontuacao.pontos);
				if(PlayerPrefs.GetInt("BestMinigame1")<Pontuacao.pontos)
					PlayerPrefs.SetInt("BestMinigame1",Pontuacao.pontos);
				
			}
			
			Application.LoadLevel("relatorio");*/
		}
	}
	
	
	public void chamaMiniGame(int codigo,Transform cadeado){
		auxCadeado = cadeado;
		switch(codigo){
		case 1: // minigame simples e unico 
		case 2:
		case 3:
			gaiolas.gameObject.SetActive(false);
			print ("aki");
			minigame[0]=0; 
			minigame[1]=0; 
			minigame[2]=0; 
			aux = Instantiate(MG[(int)codigo-1],this.transform.position, this.transform.rotation) as Transform;
			if(codigo==3){
				aux.GetComponent<Gerenciador2>().ganhaPontos =  cadeado.GetComponent<VariaveisMG3>().ganhaPontos;
				aux.GetComponent<Gerenciador2>().perdePontos =  cadeado.GetComponent<VariaveisMG3>().perdePontos;
				aux.GetComponent<Gerenciador2>().pontosParaGanhar =  cadeado.GetComponent<VariaveisMG3>().pontosParaGanhar;
				aux.GetComponent<Gerenciador2>().tamanhoDaFenda =  cadeado.GetComponent<VariaveisMG3>().tamanhoDaFenda;
				aux.GetComponent<Gerenciador2>().posicaoFenda =  cadeado.GetComponent<VariaveisMG3>().posicaoFenda;
				aux.GetComponent<Gerenciador2>().velocidadeSeta =  cadeado.GetComponent<VariaveisMG3>().velocidadeSeta;
			}else if(codigo==2){
				aux.GetComponent<Gerenciador>().distanciaAvanca =  cadeado.GetComponent<VariaveisMG2>().distanciaAvanca;
				aux.GetComponent<Gerenciador>().distanciaVoltaVermelho =  cadeado.GetComponent<VariaveisMG2>().distanciaVoltaVermelho;
				aux.GetComponent<Gerenciador>().distanciaVoltaVerde =  cadeado.GetComponent<VariaveisMG2>().distanciaVoltaVerde;
				aux.GetComponent<Gerenciador>().waitTime =  cadeado.GetComponent<VariaveisMG2>().waitTime;
				aux.GetComponent<Gerenciador>().quantidadeMaximaDeVermelhos =  cadeado.GetComponent<VariaveisMG2>().quantidadeMaximaDeVermelhos;

			}else{
				aux.GetComponent<Minigame>().numberLevels =  cadeado.GetComponent<VariaveisMG1>().numberLevels;
				aux.GetComponent<Minigame>().pontosAcerto =  cadeado.GetComponent<VariaveisMG1>().pontosAcerto;
				aux.GetComponent<Minigame>().pontosErro =  cadeado.GetComponent<VariaveisMG1>().pontosErro;
				aux.GetComponent<Minigame>().pontosAcerto1s =  cadeado.GetComponent<VariaveisMG1>().pontosAcerto1s;
				aux.GetComponent<Minigame>().pontosAcerto2s =  cadeado.GetComponent<VariaveisMG1>().pontosAcerto2s;
				aux.GetComponent<Minigame>().pontosAcerto3s =  cadeado.GetComponent<VariaveisMG1>().pontosAcerto3s;
				aux.GetComponent<Minigame>().pontosAcertoMaisDe3s =  cadeado.GetComponent<VariaveisMG1>().pontosAcertoMaisDe3s;
				aux.GetComponent<Minigame>().pontosAcerto5vezes =  cadeado.GetComponent<VariaveisMG1>().pontosAcerto5vezes;
				//aux.GetComponent<Minigame>().timer =  cadeado.GetComponent<VariaveisMG1>().timer;
				aux.GetComponent<Minigame>().timeForNextTurn =  cadeado.GetComponent<VariaveisMG1>().timeForNextTurn;
				aux.GetComponent<Minigame>().scoreMinimo =  cadeado.GetComponent<VariaveisMG1>().scoreMinimo;

			}
			//MG[0].gameObject.SetActive(true);
			break;
			
			
		case 12: 
		case 21:
		case 31:
		case 13:
		case 23:
		case 32:
			gaiolas.gameObject.SetActive(false);
			minigame[0]=codigo%10; 
			minigame[1]=0; 
			minigame[2]=0; 
			aux = Instantiate(MG[codigo/10 -1],this.transform.position, this.transform.rotation) as Transform;
			if(codigo/10==3){
				aux.GetComponent<Gerenciador2>().ganhaPontos =  cadeado.GetComponent<VariaveisMG3>().ganhaPontos;
				aux.GetComponent<Gerenciador2>().perdePontos =  cadeado.GetComponent<VariaveisMG3>().perdePontos;
				aux.GetComponent<Gerenciador2>().pontosParaGanhar =  cadeado.GetComponent<VariaveisMG3>().pontosParaGanhar;
				aux.GetComponent<Gerenciador2>().tamanhoDaFenda =  cadeado.GetComponent<VariaveisMG3>().tamanhoDaFenda;
				aux.GetComponent<Gerenciador2>().posicaoFenda =  cadeado.GetComponent<VariaveisMG3>().posicaoFenda;
				aux.GetComponent<Gerenciador2>().velocidadeSeta =  cadeado.GetComponent<VariaveisMG3>().velocidadeSeta;
			}
			else if(codigo/10==2){
				aux.GetComponent<Gerenciador>().distanciaAvanca =  cadeado.GetComponent<VariaveisMG2>().distanciaAvanca;
				aux.GetComponent<Gerenciador>().distanciaVoltaVermelho =  cadeado.GetComponent<VariaveisMG2>().distanciaVoltaVermelho;
				aux.GetComponent<Gerenciador>().distanciaVoltaVerde =  cadeado.GetComponent<VariaveisMG2>().distanciaVoltaVerde;
				aux.GetComponent<Gerenciador>().waitTime =  cadeado.GetComponent<VariaveisMG2>().waitTime;
				aux.GetComponent<Gerenciador>().quantidadeMaximaDeVermelhos =  cadeado.GetComponent<VariaveisMG2>().quantidadeMaximaDeVermelhos;
				
			}
			else{
				aux.GetComponent<Minigame>().numberLevels =  cadeado.GetComponent<VariaveisMG1>().numberLevels;
				aux.GetComponent<Minigame>().pontosAcerto =  cadeado.GetComponent<VariaveisMG1>().pontosAcerto;
				aux.GetComponent<Minigame>().pontosErro =  cadeado.GetComponent<VariaveisMG1>().pontosErro;
				aux.GetComponent<Minigame>().pontosAcerto1s =  cadeado.GetComponent<VariaveisMG1>().pontosAcerto1s;
				aux.GetComponent<Minigame>().pontosAcerto2s =  cadeado.GetComponent<VariaveisMG1>().pontosAcerto2s;
				aux.GetComponent<Minigame>().pontosAcerto3s =  cadeado.GetComponent<VariaveisMG1>().pontosAcerto3s;
				aux.GetComponent<Minigame>().pontosAcertoMaisDe3s =  cadeado.GetComponent<VariaveisMG1>().pontosAcertoMaisDe3s;
				aux.GetComponent<Minigame>().pontosAcerto5vezes =  cadeado.GetComponent<VariaveisMG1>().pontosAcerto5vezes;
				//aux.GetComponent<Minigame>().timer =  cadeado.GetComponent<VariaveisMG1>().timer;
				aux.GetComponent<Minigame>().timeForNextTurn =  cadeado.GetComponent<VariaveisMG1>().timeForNextTurn;
				aux.GetComponent<Minigame>().scoreMinimo =  cadeado.GetComponent<VariaveisMG1>().scoreMinimo;
				
			}
			break;
			
		case 123: 
		case 132:
		case 213:
		case 231:
		case 312:
		case 321:
			gaiolas.gameObject.SetActive(false);
			minigame[0]=(codigo%100)/10; 
			minigame[1]=(codigo%10); 
			minigame[2]=0; 
			aux = Instantiate(MG[codigo/100 - 1],this.transform.position, this.transform.rotation) as Transform;
			if(codigo/100==3){
				aux.GetComponent<Gerenciador2>().ganhaPontos =  cadeado.GetComponent<VariaveisMG3>().ganhaPontos;
				aux.GetComponent<Gerenciador2>().perdePontos =  cadeado.GetComponent<VariaveisMG3>().perdePontos;
				aux.GetComponent<Gerenciador2>().pontosParaGanhar =  cadeado.GetComponent<VariaveisMG3>().pontosParaGanhar;
				aux.GetComponent<Gerenciador2>().tamanhoDaFenda =  cadeado.GetComponent<VariaveisMG3>().tamanhoDaFenda;
				aux.GetComponent<Gerenciador2>().posicaoFenda =  cadeado.GetComponent<VariaveisMG3>().posicaoFenda;
				aux.GetComponent<Gerenciador2>().velocidadeSeta =  cadeado.GetComponent<VariaveisMG3>().velocidadeSeta;
			}else if(codigo/100==2){
				aux.GetComponent<Gerenciador>().distanciaAvanca =  cadeado.GetComponent<VariaveisMG2>().distanciaAvanca;
				aux.GetComponent<Gerenciador>().distanciaVoltaVermelho =  cadeado.GetComponent<VariaveisMG2>().distanciaVoltaVermelho;
				aux.GetComponent<Gerenciador>().distanciaVoltaVerde =  cadeado.GetComponent<VariaveisMG2>().distanciaVoltaVerde;
				aux.GetComponent<Gerenciador>().waitTime =  cadeado.GetComponent<VariaveisMG2>().waitTime;
				aux.GetComponent<Gerenciador>().quantidadeMaximaDeVermelhos =  cadeado.GetComponent<VariaveisMG2>().quantidadeMaximaDeVermelhos;
				
			}else{
				aux.GetComponent<Minigame>().numberLevels =  cadeado.GetComponent<VariaveisMG1>().numberLevels;
				aux.GetComponent<Minigame>().pontosAcerto =  cadeado.GetComponent<VariaveisMG1>().pontosAcerto;
				aux.GetComponent<Minigame>().pontosErro =  cadeado.GetComponent<VariaveisMG1>().pontosErro;
				aux.GetComponent<Minigame>().pontosAcerto1s =  cadeado.GetComponent<VariaveisMG1>().pontosAcerto1s;
				aux.GetComponent<Minigame>().pontosAcerto2s =  cadeado.GetComponent<VariaveisMG1>().pontosAcerto2s;
				aux.GetComponent<Minigame>().pontosAcerto3s =  cadeado.GetComponent<VariaveisMG1>().pontosAcerto3s;
				aux.GetComponent<Minigame>().pontosAcertoMaisDe3s =  cadeado.GetComponent<VariaveisMG1>().pontosAcertoMaisDe3s;
				aux.GetComponent<Minigame>().pontosAcerto5vezes =  cadeado.GetComponent<VariaveisMG1>().pontosAcerto5vezes;
				//aux.GetComponent<Minigame>().timer =  cadeado.GetComponent<VariaveisMG1>().timer;
				aux.GetComponent<Minigame>().timeForNextTurn =  cadeado.GetComponent<VariaveisMG1>().timeForNextTurn;
				aux.GetComponent<Minigame>().scoreMinimo =  cadeado.GetComponent<VariaveisMG1>().scoreMinimo;
				
			}

			break;
			
		default:
			print ("codigo invalido");
			break;
			
		}
	}
	public void proximoMiniGame(){  // quando os minigames ganharem chama essa função
		
		LifeGaiola.pts = LifeGaiola.pts + controleMiniGame*10 + bonus;
		bonus = 0;
		controleMiniGame++;
		
		bool volta = true;   // flag para testar se existe ainda minigames para ser jogado antes de voltar
		for(int i=0;i<3;i++) // testa o vetor de minigames para ver se existe minigames para jogar
		if(minigame[i]!=0){ // se existe um minigame 1,2 ou 3 para ser jogado
			bonus = (bonusDouble) * (i+1);
			volta=false;  // entao nao volta
			
			print ("vai rodar o minigame"+(minigame[i]-1)); // nao joga esse minigame de novo);
			aux = Instantiate(MG[minigame[i]-1],this.transform.position, this.transform.rotation) as Transform; //inicia o minigame i
			if(minigame[i]==3){
				aux.GetComponent<Gerenciador2>().ganhaPontos =  auxCadeado.GetComponent<VariaveisMG3>().ganhaPontos;
				aux.GetComponent<Gerenciador2>().perdePontos =  auxCadeado.GetComponent<VariaveisMG3>().perdePontos;
				aux.GetComponent<Gerenciador2>().pontosParaGanhar =  auxCadeado.GetComponent<VariaveisMG3>().pontosParaGanhar;
				aux.GetComponent<Gerenciador2>().tamanhoDaFenda =  auxCadeado.GetComponent<VariaveisMG3>().tamanhoDaFenda;
				aux.GetComponent<Gerenciador2>().posicaoFenda =  auxCadeado.GetComponent<VariaveisMG3>().posicaoFenda;
				aux.GetComponent<Gerenciador2>().velocidadeSeta =  auxCadeado.GetComponent<VariaveisMG3>().velocidadeSeta;
			}else if(minigame[i]==2){
				aux.GetComponent<Gerenciador>().distanciaAvanca =  auxCadeado.GetComponent<VariaveisMG2>().distanciaAvanca;
				aux.GetComponent<Gerenciador>().distanciaVoltaVermelho =  auxCadeado.GetComponent<VariaveisMG2>().distanciaVoltaVermelho;
				aux.GetComponent<Gerenciador>().distanciaVoltaVerde =  auxCadeado.GetComponent<VariaveisMG2>().distanciaVoltaVerde;
				aux.GetComponent<Gerenciador>().waitTime =  auxCadeado.GetComponent<VariaveisMG2>().waitTime;
				aux.GetComponent<Gerenciador>().quantidadeMaximaDeVermelhos =  auxCadeado.GetComponent<VariaveisMG2>().quantidadeMaximaDeVermelhos;
				
			}
			else{
				aux.GetComponent<Minigame>().numberLevels =  auxCadeado.GetComponent<VariaveisMG1>().numberLevels;
				aux.GetComponent<Minigame>().pontosAcerto =  auxCadeado.GetComponent<VariaveisMG1>().pontosAcerto;
				aux.GetComponent<Minigame>().pontosErro =  auxCadeado.GetComponent<VariaveisMG1>().pontosErro;
				aux.GetComponent<Minigame>().pontosAcerto1s =  auxCadeado.GetComponent<VariaveisMG1>().pontosAcerto1s;
				aux.GetComponent<Minigame>().pontosAcerto2s =  auxCadeado.GetComponent<VariaveisMG1>().pontosAcerto2s;
				aux.GetComponent<Minigame>().pontosAcerto3s =  auxCadeado.GetComponent<VariaveisMG1>().pontosAcerto3s;
				aux.GetComponent<Minigame>().pontosAcertoMaisDe3s =  auxCadeado.GetComponent<VariaveisMG1>().pontosAcertoMaisDe3s;
				aux.GetComponent<Minigame>().pontosAcerto5vezes =  auxCadeado.GetComponent<VariaveisMG1>().pontosAcerto5vezes;
				//aux.GetComponent<Minigame>().timer =  auxCadeado.GetComponent<VariaveisMG1>().timer;
				aux.GetComponent<Minigame>().timeForNextTurn =  auxCadeado.GetComponent<VariaveisMG1>().timeForNextTurn;
				aux.GetComponent<Minigame>().scoreMinimo =  auxCadeado.GetComponent<VariaveisMG1>().scoreMinimo;
				
			}
			minigame[i]=0; // nao joga esse minigame de novo
			break; // para o laço de repeticao
		}
		if(volta)  //caso passou no laço de repeticao e nao tem jogos para jogar 
			gaiolas.gameObject.SetActive(true); // ativa de novo as gaiolas e tem que agora mudar a imagem que ja jogou
		
		
	}
	
	
	
	
	
}
