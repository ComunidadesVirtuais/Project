using UnityEngine;
using System.Collections;

public class TrocaMapaMG5 : MonoBehaviour {
	public int tempoParaEsconder;
	public Sprite fechado;
	// Use this for initialization
	void Start () {
		Invoke ("esconde",tempoParaEsconder);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void esconde(){
		this.gameObject.GetComponent<SpriteRenderer>().sprite = fechado;
			
	}
}
