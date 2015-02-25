using UnityEngine;
using System.Collections;

public class MuiraquitaMecanica : MonoBehaviour {

	public int tempoMaximo = 5;
	private int contadorTempo = 0;

	private bool habilitada = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		/*if(Input.touches.Length>0){
			for(int i=0;i<Input.touchCount; i++){
				
				if(this.guiTexture.HitTest(Input.GetTouch(i).position)){
					
					if(Input.GetTouch(i).phase == TouchPhase.Began){
					}
					if(Input.GetTouch(i).phase== TouchPhase.Ended){
					}
				}
				
			}
		}*/
		
	}
	
	void OnMouseDown()
	{
		if(!habilitada)
		{
			habilitada = true;
			GameObject.Find ("player").GetComponent<Player>().TornarInvisivel();
			InvokeRepeating("ContarTempo", 0.0f, 1.0f);
		}
	}	

	private void ContarTempo()
	{
		contadorTempo++;
		if(contadorTempo >= tempoMaximo)
		{
			CancelInvoke();
			habilitada = false;
			contadorTempo = 0;
			GameObject.Find ("player").GetComponent<Player>().TornarVisivel();
		}
	}
}
