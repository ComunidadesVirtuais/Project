using UnityEngine;
using System.Collections;

public class Life : MonoBehaviour {
	
	public Texture2D[] vidaAtual;
	
	public int maxVidas = 3;
	private int qtdVidas = 3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public bool excluirVidas()
	{
		if(qtdVidas > 1)
		{
			qtdVidas --;
			guiTexture.texture = vidaAtual [qtdVidas-1];
			return true;
		}
		return false;
	}

	public bool addVidas()
	{
		if(qtdVidas < maxVidas)
		{	
			qtdVidas ++;
			guiTexture.texture = vidaAtual [qtdVidas - 1];
			return true;
		}
		return false;
	}

	public int GetQtdVidas()
	{
		return qtdVidas;
	}

	public void SetQtdVidas(int value)
	{
		qtdVidas = value;
		guiTexture.texture = vidaAtual [qtdVidas - 1];
	}
}
