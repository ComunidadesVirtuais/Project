using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CollectibleItem : MonoBehaviour {

	public string prefabName;
	public string objetoPai;
	public string variavel;
	public string valorVariavel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		print (collider.gameObject.name);
		//if(collider.gameObject.name != objetoPai))
		if(collider.gameObject.name == "player")
		{
			print("oxe, entrou?");
			AcoesJogador.Action action = new AcoesJogador.Action ();
			action.opcoes = new List<AcoesJogador.Option>();
			action.eventTrigger = gameObject;
			AcoesJogador.Option op1 = new AcoesJogador.Option ();
			op1.descricao = "Coletar item";
			op1.tipo = AcoesJogador.ACTION_COLLECT;
			op1.data = prefabName;
			action.opcoes.Add (op1);
			AcoesJogador.Option op2 = new AcoesJogador.Option ();
			op2.descricao = "Sair";
			op2.tipo = AcoesJogador.ACTION_QUIT;
			action.opcoes.Add (op2);

			GameObject.Find ("Pergaminho").GetComponent<AcoesJogador> ().SetAcaoAtual(action);
			GameObject.Find ("Pergaminho").GetComponent<AcoesJogador> ().Show ();

			if(valorVariavel != "") GameObject.Find("CaixaDialogo").GetComponent<LoadXmlData> ().SetVariavel(1, variavel, valorVariavel);
		}
	}

	void OnTriggerExit2D(Collider2D collider)
	{
		GameObject.Find ("Pergaminho").GetComponent<AcoesJogador> ().Hide ();
	}
}
