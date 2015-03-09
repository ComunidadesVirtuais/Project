using UnityEngine;
using System.Collections;

public class Contador : MonoBehaviour {
	public int tempoDeVida;
	// Use this for initialization
	void Start () {
		Invoke("quit",tempoDeVida);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void quit(){
		Destroy(gameObject);
	}
}
