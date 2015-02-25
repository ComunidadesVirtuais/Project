using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]

public class video : MonoBehaviour {

	//public MovieTexture movie;
	public Texture fones;
	private bool flag = false;


	// Use this for initialization
	void Start () {


		guiTexture.texture = fones;//movie as MovieTexture;
		transform.position = Vector3.zero;
		transform.localScale = Vector3.zero;
		guiTexture.pixelInset = new Rect(0, 0, Screen.width, Screen.height); 
		//movie.Play ();
	}

	void Update(){


		//if(!movie.isPlaying){
		//	guiTexture.texture = fones;
		//	flag = true;

	//	}



	}

	void OnMouseDown(){
	//	if (flag)
			Application.LoadLevel("MenuInicial");
	}
 
}


