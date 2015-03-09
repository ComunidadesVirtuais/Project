using UnityEngine;
using System.Collections;

public class Mapa : MonoBehaviour {

	public float star1, star2, star3;
	public Sprite[] changes;
	public float offSetX, offSetY;
	public GameObject prefab;
	public int linhas, colunas;
	private GameObject[] posicao;
	public int[] tipos;
	private int[] acertos;
	private GameObject[] ganha;
	private float distanciaParaElemento = 1.0f;
	public int ganhaPontos,perdePontos,combo1,combo2,pontocombo1,pontocombo2;
	private int contacombo=0;

	// Use this for initialization
	void Start () {
		Pontuacao.pontos = 0;
		acertos = new int[linhas*colunas];
		for (int i=0,count = 0; i<tipos.Length; i++)
						for (int j=0; j<tipos[i]; j++, count++) {
								acertos [count] = i+1;
								print (i+1);
						}
		posicao = new GameObject[linhas*colunas];

		for(int c=0,count = 0;c<colunas;c++)
		  for (int l=0; l<linhas; l++,count++) {
			print ("changes" + acertos.Length);

			posicao[count] = Instantiate(prefab,new Vector3(transform.position.x + offSetX + 3.0f*c,transform.position.y + offSetY - 1.7f*l,transform.position.z),transform.rotation) as GameObject;
			posicao[count].transform.parent = this.transform;
			posicao[count].gameObject.GetComponent<SpriteRenderer>().sprite = changes[acertos[count]-1];
		}
		ganha = new GameObject[linhas*colunas];


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
	public void combo(){
		contacombo++;
		if (contacombo==combo1)
			Pontuacao.pontos = Pontuacao.pontos + pontocombo1;
		if (contacombo==combo2)
			Pontuacao.pontos = Pontuacao.pontos + pontocombo2;
	}
	public void limpaCombo(){
		contacombo=0;
	}
	public void ganharPontos(){
		Pontuacao.pontos = Pontuacao.pontos + ganhaPontos;
	}
	public void perderPontos(){
		Pontuacao.pontos = Pontuacao.pontos - perdePontos;
	}

	public Vector3 testaMapa(GameObject elemento, int codigo, bool[] verifica){


		float distancia = Vector3.Distance(elemento.transform.position,posicao[0].transform.position);
		int elementoN = 0;
		//print(distancia);
		
		for(int i = 0;i<posicao.Length;i++){
			if(Vector3.Distance(elemento.transform.position,posicao[i].transform.position)<distancia){
				distancia=Vector3.Distance(elemento.transform.position,posicao[i].transform.position);
				elementoN = i;
			}
			
		}
		

		
		
		if(distancia<distanciaParaElemento){
			print (acertos[elementoN] + " " + codigo);
			if(acertos[elementoN]==codigo){
			
				print ("Acertou");
				if(ganha[elementoN]!=null){
					verifica[0] = true;
					Destroy(ganha[elementoN]);
				}
				ganha[elementoN]=elemento;
				ganhou ();
				return posicao[elementoN].transform.position;
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
			Invoke("win",1.0f);
		}
	}



		
		
	void win(){
		print ("Ganhou!!!!!");
		
		//Codigos
		// BP = BestPoints do Minigame X N Y
		// LP = Lastpoints do Minigame X N Y
		// AP= SumPoints do Minigame X N Y
		// T  = Turns do Minigame X N Y
		// L   = Last Minigame
		// S = Star N
		//PlayerPrefs.DeleteAll();
		int i = 1;
		int pontos = Pontuacao.pontos;
		if( PlayerPrefs.HasKey("LP"+Application.loadedLevelName) && PlayerPrefs.HasKey("T"+Application.loadedLevelName) && PlayerPrefs.HasKey("BP"+Application.loadedLevelName) && PlayerPrefs.HasKey("AP"+Application.loadedLevelName) && PlayerPrefs.HasKey("LMG") &&  PlayerPrefs.HasKey("S"+Application.loadedLevelName)){
			print("segunda entrada "+"LP"+Application.loadedLevelName);
			PlayerPrefs.SetInt("LP"+Application.loadedLevelName,pontos);
			if(PlayerPrefs.GetInt("BP"+Application.loadedLevelName)<pontos)
				PlayerPrefs.SetInt("BP"+Application.loadedLevelName,pontos);
			
			PlayerPrefs.SetFloat("AP"+Application.loadedLevelName,((pontos + PlayerPrefs.GetInt("T"+Application.loadedLevelName) * PlayerPrefs.GetFloat("AP"+Application.loadedLevelName))/(PlayerPrefs.GetInt("T"+Application.loadedLevelName)+1)));
			PlayerPrefs.SetInt("T"+Application.loadedLevelName,PlayerPrefs.GetInt("T"+Application.loadedLevelName)+1);
			PlayerPrefs.SetInt("LMG",i);
			if(pontos>=star1 && PlayerPrefs.GetInt("S",0)==0)
				PlayerPrefs.SetInt("S"+Application.loadedLevelName,1);
			if(pontos>=star2 && PlayerPrefs.GetInt("S",0)<=1)
				PlayerPrefs.SetInt("S"+Application.loadedLevelName,2);
			if(pontos>=star3 & PlayerPrefs.GetInt("S",0)<=2)
				PlayerPrefs.SetInt("S"+Application.loadedLevelName,3);
			
		}
		else {
			print("Primeira entrada "+"LP"+Application.loadedLevelName);
			PlayerPrefs.SetInt("LP"+Application.loadedLevelName,pontos);				
			
			PlayerPrefs.SetInt("T"+Application.loadedLevelName,1);
			
			PlayerPrefs.SetInt("BP"+Application.loadedLevelName,pontos);
			
			PlayerPrefs.SetFloat("AP"+Application.loadedLevelName,pontos);
			
			PlayerPrefs.SetInt("LMG"+Application.loadedLevelName,i);

			PlayerPrefs.SetInt("S"+Application.loadedLevelName,0);

			if(pontos>=star1 && PlayerPrefs.GetInt("S",0)==0)
				PlayerPrefs.SetInt("S"+Application.loadedLevelName,1);
			if(pontos>=star2 && PlayerPrefs.GetInt("S",0)<=1)
				PlayerPrefs.SetInt("S"+Application.loadedLevelName,2);
			if(pontos>=star3 & PlayerPrefs.GetInt("S",0)<=2)
				PlayerPrefs.SetInt("S"+Application.loadedLevelName,3);
			
		}
		
		Application.LoadLevel("relatorio");
	}



}
