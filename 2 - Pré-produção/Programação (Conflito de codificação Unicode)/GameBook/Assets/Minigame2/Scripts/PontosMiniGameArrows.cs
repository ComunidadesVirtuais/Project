using UnityEngine;
using System.Collections;

public class PontosMiniGameArrows : MonoBehaviour {

	public static int qtd = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		guiText.text = "Quantidade " + qtd;
	
	}
}
