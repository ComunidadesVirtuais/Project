using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AcoesJogador : MonoBehaviour
{
	public const int ACTION_TALK = 1;
	public const int ACTION_QUIT = 2;
	public const int ACTION_COLLECT = 3;
	public const int ACTION_POPUP = 4;

	private Vector2 medidasIniciais = new Vector2 (96.5f, 48.25f);

	public GUIText textObject;

	public struct Option{
		public string descricao;
		public int tipo;
		public string data;
	}

	public struct Action{
		public GameObject eventTrigger;
		public List<Option> opcoes;
		public string reward;
	}

	private Action acaoAtual;

	private List<GUIText> textos = new List<GUIText>();

	void Start () {
		Hide ();
	}
	
	// Update is called once per frame
	void Update ()
	{

		/*if(Input.touches.Length>0)
		{
			for(int i=0;i<Input.touchCount; i++)
			{
				GameObject pergaminho = GameObject.Find ("Pergaminho");
				GUIText op1 = pergaminho.transform.Find("OP1").GetComponent<GUIText>();
				if(op1.HitTest(Input.GetTouch(i).position))
				{
				}
				
			}
		}*/
	}

	public void LoadAction(int indexOption)
	{
		Option op = acaoAtual.opcoes [indexOption];

		switch(op.tipo)
		{
			case ACTION_TALK:
			{
				GameObject.Find ("Scripts").GetComponent<LoadScene>().HideGUIElements();
				GameObject.Find ("CaixaDialogo").GetComponent<LoadXmlData>().GetAction(op.data, acaoAtual.eventTrigger);
				Hide ();
				break;
			}
			case ACTION_COLLECT:
			{
				GameObject.Find ("Inventario").GetComponent<Inventory>().ColetarItem(op.data);
				//Destroy(acaoAtual.eventTrigger);
				Hide ();
				break;
			}
			case ACTION_POPUP:
			{
				/*if(op.data == "Quadro1") GameObject.Find (op.data).GetComponent<PopupMecanica1>().Show();
				else if(op.data == "Quadro2") GameObject.Find (op.data).GetComponent<PopupMecanica2>().Show();*/
				GameObject popup = Instantiate(Resources.Load(op.data)) as GameObject;
				popup.gameObject.name = op.data;
				if(op.data == "Quadro1")
				{
					popup.GetComponent<PopupMecanica1>().SetEventTrigger(acaoAtual.eventTrigger);
					popup.GetComponent<PopupMecanica1>().Show();
				}
				else if(op.data == "Quadro2")
				{
					popup.GetComponent<PopupMecanica2>().SetEventTrigger(acaoAtual.eventTrigger);
					popup.GetComponent<PopupMecanica2>().Show();
				}
				else if(op.data == "Quadro3")
				{
					popup.GetComponent<PopupMecanica3>().SetEventTrigger(acaoAtual.eventTrigger);
					popup.GetComponent<PopupMecanica3>().Show();
				}
				
				//Destroy(acaoAtual.eventTrigger);
				//Hide ();
				break;
			}
			case ACTION_QUIT: Hide (); break;
		}
	}

	public void SetAcaoAtual( Action value )
	{
		acaoAtual = value;

		DestroyAllGUITexts ();

		for(int i=0; i < acaoAtual.opcoes.Count; i++)
		{
			Option op = acaoAtual.opcoes[i];

			GUIText text = Instantiate(textObject) as GUIText;
			text.transform.parent = this.transform;
			text.transform.localPosition = new Vector3(0, 0, 2);
			text.text = op.descricao;

			float porcent = (guiTexture.pixelInset.width - medidasIniciais.x) / medidasIniciais.x;
			float xOffset = 10 + 10 * porcent;
			float yOffset = (-5 - 20 * i) - (5 + 20 * i) * porcent;

			text.pixelOffset = new Vector2(guiTexture.pixelInset.x + xOffset, guiTexture.pixelInset.y + (guiTexture.pixelInset.yMax - guiTexture.pixelInset.yMin) + yOffset);

			text.fontSize = (int)Mathf.Floor(text.fontSize + text.fontSize * porcent);

			text.GetComponent<OptionText>().SetIndex(i);
			textos.Add(text);
		}
	}

	private void DestroyAllGUITexts()
	{
		for(int i = 0; i < textos.Count; i++)
		{
			Destroy (textos[i].gameObject);
		}

		textos.Clear ();
	}

	public void Show()
	{
		guiTexture.enabled = true;
	}
	
	public void Hide()
	{
		guiTexture.enabled = false;
		DestroyAllGUITexts ();
		//GameObject.Find ("player").GetComponent<AIPather> ().enabledMovement = true;
	}
}
