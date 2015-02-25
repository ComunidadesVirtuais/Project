using UnityEngine;
using System.Collections;

public class AjustesDeImagem : MonoBehaviour {

	public float altura, largura, x, y, z;


	// Use this for initialization
	void Start () {



		transform.position = new Vector3(0,0,z);
		transform.localScale = Vector3.zero;
		//if (z != 0f)
		//	transform.position.Set(transform.position.x,transform.position.y,z);
		guiTexture.pixelInset = new Rect((Screen.width*x)/100, (Screen.height*y)/100, (Screen.width*largura)/100, (Screen.height*altura)/100); 
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
