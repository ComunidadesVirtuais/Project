using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AssetMecanica : MonoBehaviour {

	public string popupName;
	public string prefabName;
	private bool mecanicaDisponivel = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if((collider.gameObject.name == "player") && mecanicaDisponivel)
		{
			AcoesJogador.Action action = new AcoesJogador.Action ();
			action.opcoes = new List<AcoesJogador.Option>();
			action.eventTrigger = gameObject;
			action.reward = prefabName;
			AcoesJogador.Option op1 = new AcoesJogador.Option ();
			op1.descricao = "Vasculhar";
			op1.tipo = AcoesJogador.ACTION_POPUP;
			op1.data = popupName;
			action.opcoes.Add (op1);
			AcoesJogador.Option op2 = new AcoesJogador.Option ();
			op2.descricao = "Sair";
			op2.tipo = AcoesJogador.ACTION_QUIT;
			action.opcoes.Add (op2);
			
			GameObject.Find ("Pergaminho").GetComponent<AcoesJogador> ().SetAcaoAtual(action);
			GameObject.Find ("Pergaminho").GetComponent<AcoesJogador> ().Show ();

			//popup.GetComponent<PopupMecanica>().SetEventTrigger(gameObject);
			
			//if(valorVariavel != "") GameObject.Find("CaixaDialogo").GetComponent<LoadXmlData> ().SetVariavel(1, variavel, valorVariavel);
		}
	}
	
	void OnTriggerExit2D(Collider2D collider)
	{
		GameObject.Find ("Pergaminho").GetComponent<AcoesJogador> ().Hide ();
	}

	public void SetDisponibilidadeMecanica(bool value)
	{
		mecanicaDisponivel = value;
	}

	public void InstantiateItem()
	{
		GameObject fruta = Instantiate(Resources.Load(prefabName)) as GameObject;
		fruta.name = "FruitTree";
		fruta.transform.position = new Vector3(transform.position.x + 0.3f, transform.position.y - 0.3f, transform.position.z);
	}
}
