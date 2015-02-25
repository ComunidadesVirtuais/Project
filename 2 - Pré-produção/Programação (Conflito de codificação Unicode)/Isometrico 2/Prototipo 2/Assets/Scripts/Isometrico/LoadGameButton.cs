using UnityEngine;
using System.Collections;

public class LoadGameButton : MonoBehaviour
{
	private bool buttonEnaled;
	// Use this for initialization
	void Start ()
	{

		buttonEnaled = DataManager.SaveExists ();

		if(!buttonEnaled) // se nao tiver save, botao ficara com transparencia
		{
			Color cor = guiTexture.color;
			guiTexture.color = new Color(cor.r, cor.g, cor.b, 0.2f);
		}
		DataManager.LoadSave ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.touches.Length>0){
			for(int i=0;i<Input.touchCount; i++){
				
				if(this.guiTexture.HitTest(Input.GetTouch(i).position)){
					
					if(Input.GetTouch(i).phase == TouchPhase.Began)
					{
						//print ("Vai carregar: " + DataManager.cenaAtual);
						if(buttonEnaled) Load ();
					}
				}
				
			}
		}
	}

	private void Load()
	{
		DataManager.load = true;
		DataManager.carregaInventario = true;
		Application.LoadLevel(DataManager.cenaAtual);
	}
	void OnMouseDown()
	{
		print ("Vai carregar: " + DataManager.cenaAtual);
		if(buttonEnaled) Load ();
	}
}
