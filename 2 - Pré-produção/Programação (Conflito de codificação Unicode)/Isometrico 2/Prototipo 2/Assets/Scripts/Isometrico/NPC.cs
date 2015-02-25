using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPC : MonoBehaviour
{
	public string nomeNPC = "";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		//if(collider.gameObject.name != nomeNPC)
		if(collider.gameObject.name == "player")
		{
			AcoesJogador.Action action = new AcoesJogador.Action ();
			action.opcoes = new List<AcoesJogador.Option>();
			action.eventTrigger = gameObject;
			AcoesJogador.Option op1 = new AcoesJogador.Option ();
			op1.descricao = "Falar";
			op1.tipo = AcoesJogador.ACTION_TALK;
			op1.data = nomeNPC;
			action.opcoes.Add (op1);
			AcoesJogador.Option op2 = new AcoesJogador.Option ();
			op2.descricao = "Sair";
			op2.tipo = AcoesJogador.ACTION_QUIT;
			action.opcoes.Add (op2);
			
			GameObject.Find ("Pergaminho").GetComponent<AcoesJogador> ().SetAcaoAtual(action);
			GameObject.Find ("Pergaminho").GetComponent<AcoesJogador> ().Show ();
		}
	}

	void OnTriggerExit2D(Collider2D collider)
	{
		GameObject.Find ("Pergaminho").GetComponent<AcoesJogador> ().Hide ();
		GameObject.Find ("CaixaDialogo").GetComponent<TextPlayer>().Hide ();
	}
}
