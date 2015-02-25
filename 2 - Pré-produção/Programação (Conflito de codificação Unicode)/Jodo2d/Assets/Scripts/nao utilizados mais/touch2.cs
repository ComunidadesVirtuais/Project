using UnityEngine;
using System.Collections;

public class touch2 : MonoBehaviour {

	private Player player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>() as Player;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.touches.Length>0){
			for(int i=0;i<Input.touchCount; i++){

				if(this.guiTexture.HitTest(Input.GetTouch(i).position)){

					if(Input.GetTouch(i).phase == TouchPhase.Began){
						Debug.Log(Input.GetTouch(i).position + " Tocou na Teka, usando metidi Began");


					}
					if(Input.GetTouch(i).phase== TouchPhase.Ended){
						Debug.Log(Input.GetTouch(i).position + "Tirou o dedo da tela usando o metodo Ended");
					}
				}

			}
		}

	
	}
}
