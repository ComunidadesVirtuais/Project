using UnityEngine;
using System.Collections;

public class AjusteDeImagens : MonoBehaviour {
	
	public float altura, largura, x, y, z;
	
	
	// Use this for initialization
	void Start () {
		inicia ();
		
		

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void inicia(){

		transform.position = new Vector3(0,0,z);
		transform.localScale = Vector3.zero;
		//if (z != 0f)
		//	transform.position.Set(transform.position.x,transform.position.y,z); 
		//guiTexture.pixelInset.
		guiTexture.pixelInset = new Rect((Screen.width*x)/100, (Screen.height*y)/100, (Screen.width*largura)/100, (Screen.height*altura)/100); 

	}
}
