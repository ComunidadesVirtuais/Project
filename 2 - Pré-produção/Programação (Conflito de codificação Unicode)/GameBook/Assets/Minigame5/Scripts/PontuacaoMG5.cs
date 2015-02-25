using UnityEngine;
using System.Collections;

public class PontuacaoMG5 : MonoBehaviour {
	
	public static int pontos;
	// Use this for initialization
	void Start () {
		pontos = 0;
	}
	
	// Update is called once per frame
	void Update () {
		this.guiText.text = "Points: "+pontos;
	}
}
