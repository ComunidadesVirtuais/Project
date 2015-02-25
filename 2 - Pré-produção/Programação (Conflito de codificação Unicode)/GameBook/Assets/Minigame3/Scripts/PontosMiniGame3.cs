using UnityEngine;
using System.Collections;

public class PontosMiniGame3 : MonoBehaviour {
	public static int pts = 0;
	public int[] mecanica;
	
	// Use this for initialization
	void Start () {
		pts = 0;
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = "PONTOS "+pts;
	}
}
