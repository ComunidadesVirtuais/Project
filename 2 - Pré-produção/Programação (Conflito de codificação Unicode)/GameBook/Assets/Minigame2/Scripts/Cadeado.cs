using UnityEngine;
using System.Collections;

public class Cadeado : MonoBehaviour {

	public int codigo;
	public Sprite aberto;
	private MapaMG2 maps;
	private bool usou = false;

	// Use this for initialization
	void Start () {
		maps = GameObject.Find("GerenciadorGaiolas").GetComponent<MapaMG2>() as MapaMG2;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		if(!usou){
				usou = true;
				this.gameObject.GetComponent<SpriteRenderer>().sprite = aberto;
				maps.chamaMiniGame(codigo);
		}
	
	}
}
