using UnityEngine;
using System.Collections;

public class Gerenciador : MonoBehaviour {

	private bool emJogo = false;
	public float qtdMovimento = 0.5f;
	public float velocidadeVolta = 0.5f;
	public float resistenciaPorDistancia;

	private bool venceu = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool EstaEmJogo()
	{
		return emJogo;
	}

	public void FinalizarJogo()
	{
		emJogo = false;
		venceu = true;
		// fazer oq tiver de fazer no final
	}

	public void IniciarJogo()
	{
		emJogo = true;
	}

	public bool Venceu()
	{
		return venceu;
	}
}
