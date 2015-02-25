using UnityEngine;
using System.Collections;

public class PontuacaoMG4 : MonoBehaviour {
	
	public static int pontos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.guiText.text = "Points: "+pontos;
	}
}
