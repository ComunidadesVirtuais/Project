using UnityEngine;
using System.Collections;

public class AjustaVolume : MonoBehaviour {

	public AudioSource somTesteSFX;
	public AudioSource somTesteMusica;

	public GUITexture botao;
	public GUITexture botao2;

	public static float volumeSFX = 1;
	public static float volumeMusica = 1;


	// Use this for initialization
	void Start () {

		if(!PlayerPrefs.HasKey("volumeSFX"))          //se o jogo é a primeira vez que está sendo carregado deve-se armazenar 100%
			PlayerPrefs.SetFloat("volumeSFX",1f);
		else{
			volumeSFX = PlayerPrefs.GetFloat("volumeSFX");
			float retorno = botao.guiTexture.GetScreenRect().size.x*0.5f*(1.0f*(1.0f-volumeSFX));
			botao.guiTexture.pixelInset = new Rect (botao.guiTexture.GetScreenRect().x - retorno,botao.guiTexture.GetScreenRect().y, botao.guiTexture.GetScreenRect().size.x,botao.guiTexture.GetScreenRect().size.y);
		}

		if (!PlayerPrefs.HasKey ("volumeMusica"))          //se o jogo é a primeira vez que está sendo carregado deve-se armazenar 100%
			PlayerPrefs.SetFloat ("volumeMusica", 1f);
		else {
			volumeMusica = PlayerPrefs.GetFloat ("volumeMusica");
			float retorno = botao2.guiTexture.GetScreenRect ().size.x * 0.5f * (1.0f * (1.0f - volumeMusica));
			botao2.guiTexture.pixelInset = new Rect (botao2.guiTexture.GetScreenRect ().x - retorno, botao2.guiTexture.GetScreenRect ().y, botao2.guiTexture.GetScreenRect ().size.x, botao2.guiTexture.GetScreenRect ().size.y);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown(){

		if(name=="menos1")
				if(botao.guiTexture.GetScreenRect().x > 0.20f*Screen.width){
					
						volumeSFX = volumeSFX - 0.25f;
						PlayerPrefs.SetFloat("volumeSFX",volumeSFX);
						somTesteSFX.volume = volumeSFX;
						somTesteSFX.Play();
						
					

					botao.guiTexture.pixelInset = new Rect (botao.guiTexture.GetScreenRect().x - botao.guiTexture.GetScreenRect().size.x*0.5f,botao.guiTexture.GetScreenRect().y, botao.guiTexture.GetScreenRect().size.x,botao.guiTexture.GetScreenRect().size.y);
				}		
		if(name=="mais1")
			if(botao.guiTexture.GetScreenRect().x < 0.55f*Screen.width){
				
					volumeSFX = volumeSFX + 0.25f;
					PlayerPrefs.SetFloat("volumeSFX",volumeSFX);
					somTesteSFX.volume = volumeSFX;
					somTesteSFX.Play();
					
				
				botao.guiTexture.pixelInset = new Rect (botao.guiTexture.GetScreenRect().x + botao.guiTexture.GetScreenRect().size.x*0.5f,botao.guiTexture.GetScreenRect().y, botao.guiTexture.GetScreenRect().size.x,botao.guiTexture.GetScreenRect().size.y);
			}
		if(name=="menos2")
		if(botao2.guiTexture.GetScreenRect().x > 0.20f*Screen.width){
			
			volumeMusica = volumeMusica - 0.25f;
			PlayerPrefs.SetFloat("volumeMusica",volumeMusica);
			somTesteMusica.volume = volumeMusica;
			somTesteMusica.Play();
			
			
			
			botao2.guiTexture.pixelInset = new Rect (botao2.guiTexture.GetScreenRect().x - botao2.guiTexture.GetScreenRect().size.x*0.5f,botao2.guiTexture.GetScreenRect().y, botao2.guiTexture.GetScreenRect().size.x,botao2.guiTexture.GetScreenRect().size.y);
		}		
		if(name=="mais2")
		if(botao2.guiTexture.GetScreenRect().x < 0.55f*Screen.width){
			
			volumeMusica = volumeMusica + 0.25f;
			PlayerPrefs.SetFloat("volumeMusica",volumeMusica);
			somTesteMusica.volume = volumeMusica;
			somTesteMusica.Play();
			
			
			botao2.guiTexture.pixelInset = new Rect (botao2.guiTexture.GetScreenRect().x + botao2.guiTexture.GetScreenRect().size.x*0.5f,botao2.guiTexture.GetScreenRect().y, botao2.guiTexture.GetScreenRect().size.x,botao2.guiTexture.GetScreenRect().size.y);
		}
	//	botao.guiTexture.transform.position.Set (Input.mousePosition.x,botao.guiTexture.transform.position.y,botao.guiTexture.transform.position.z);
		//botao.transform.position.Set (Input.mousePosition.x,botao.transform.position.y,botao.transform.position.z);
		print ("VolumeSFX"+volumeSFX);
		print ("VolumeMUSICA"+volumeMusica);
		print (botao.guiTexture.GetScreenRect().x);
		//
	}

}
