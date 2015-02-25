using UnityEngine;
using System.Collections;

public class DinheiroInterface : MonoBehaviour {

	private int qtdDinheiro = 0;

	// Use this for initialization
	void Start () {
		guiText.text = qtdDinheiro.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SomarDinheiro(int valor)
	{
		qtdDinheiro += valor;
		guiText.text = qtdDinheiro.ToString();
	}

	public bool SubtrairDinheiro(int valor)
	{
		if(valor <= qtdDinheiro)
		{
			qtdDinheiro -= valor;
			guiText.text = qtdDinheiro.ToString();
			return true;
		}
		else return false;
	}

	public int GetQuantidadeDinheiro()
	{
		return qtdDinheiro;
	}

	public void SetQtdDinheiro(int valor)
	{
		qtdDinheiro = valor;
	}
}
