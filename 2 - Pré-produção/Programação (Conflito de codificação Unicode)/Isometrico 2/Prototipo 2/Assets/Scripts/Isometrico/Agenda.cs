using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Agenda : MonoBehaviour {

	public Texture2D spriteDefault;
	public Texture2D spriteAlerta;

	public string[] hipertextosIniciais;
	private List<string> hipertextos = new List<string>();

	// Use this for initialization
	void Start () {
		if (hipertextosIniciais.Length > 0)
		{
			guiTexture.texture = spriteAlerta;
			for(int i = 0; i < hipertextosIniciais.Length; i++) hipertextos.Add(hipertextosIniciais[i]);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AdicionarHipertexto(string nome)
	{
		if(!hipertextos.Contains (nome)) // para nao adicionar hipertexto repetido
		{
			guiTexture.texture = spriteAlerta;
			hipertextos.Add(nome);
		}
	}

	void OnMouseDown()
	{
		// abre agenda
		guiTexture.texture = spriteDefault;

		print ("Hipertextos:");
		string s = "";
		for(int i=0; i < hipertextos.Count; i++) s += hipertextos[i] + " ";
		print (s);
	}
}
