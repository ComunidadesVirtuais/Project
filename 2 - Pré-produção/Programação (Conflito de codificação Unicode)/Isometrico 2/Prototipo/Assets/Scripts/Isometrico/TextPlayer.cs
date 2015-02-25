using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class TextPlayer : MonoBehaviour {

	public GUIText textObject;
	private XmlNode dialogoAtual;
	public int caracteresPorSegundo = 8;
	private GameObject eventTrigger;

	private Color cor;

	public struct Text{
		public string personagem;
		public string fala;
	}

	private List<GUIText> textos = new List<GUIText>();

	private List<Text> conversa;

	// Use this for initialization
	void Start () {
		//guiText.pixelOffset = new Vector2(Screen.width/2,Screen.height/2); // near the bottom of the rendered view
		//guiText.text = "Nao acho que seja uma boa ideia";
		Hide ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Chamada por LoadXmlData.cs, na funcao RealizarAcoes
	public void IniciarDialogo(XmlNode dialogo, Color corTexto, GameObject pEventTrigger)
	{
		dialogoAtual = dialogo;
		eventTrigger = pEventTrigger;
		cor = corTexto;

		if (dialogo == null) print ("[TextPlayer.cs] Dialogo nulo.");
		else
		{
			if(dialogo.Attributes["tipo"].Value == "falas") IniciarDialogoFalas();
			else if(dialogo.Attributes["tipo"].Value == "opcoes") MostrarOpcoesDialogo();//Show();
		}
	}

	private void MostrarOpcoesDialogo()
	{
		int i = 0;
		bool condicaoSatisfeita = false;
		foreach (XmlNode node in dialogoAtual)
		{
			XmlNodeList optionsNodes = node.ChildNodes;
			foreach (XmlNode option in optionsNodes)
			{
				XmlNodeList nodes = option.ChildNodes;
				foreach (XmlNode op in nodes)
				{
					if(op.Name == "condicoes")
					{
						foreach (XmlNode condicao in op.ChildNodes)
						{
							condicaoSatisfeita = gameObject.GetComponent<LoadXmlData> ().VerificaCondicao (condicao);
						}
					}
				}

				if(condicaoSatisfeita)
				{

					GUIText text = Instantiate(textObject) as GUIText;
					text.transform.parent = this.transform;
					text.transform.localPosition = new Vector3(0, 0, 2);
					text.text = option.InnerText;
					
					/*float porcent = (guiTexture.pixelInset.width - medidasIniciais.x) / medidasIniciais.x;
					float xOffset = 10 + 10 * porcent;
					float yOffset = (-5 - 20 * i) - (5 + 20 * i) * porcent;*/
					
						float xOffset = 10;
					float yOffset = (-5 - 20 * i);
					
					text.pixelOffset = new Vector2(guiTexture.pixelInset.x + xOffset, guiTexture.pixelInset.y + (guiTexture.pixelInset.yMax - guiTexture.pixelInset.yMin) + yOffset);
					//text.fontSize = (int)Mathf.Floor(text.fontSize + text.fo);

					text.GetComponent<TextDialogBox>().SetAcoes(option, eventTrigger);
					textos.Add(text);
					i++;
				}

			}
		}
		Show ();
	}

	private void DestroyAllGUITexts()
	{
		//print ("[AcoesJogador] DestroyAllGUITexts() textos.count = " + textos.Count);
		for(int i = 0; i < textos.Count; i++)
		{
			//print ("i: " + i);
			Destroy (textos[i].gameObject);
		}
		
		textos.Clear ();
	}

	private void IniciarDialogoFalas()
	{
		foreach (XmlNode node in dialogoAtual)
		{
			if(node.Name == "falas")
			{
				XmlNodeList listFalas = node.ChildNodes;
				conversa = new List<Text>();
				foreach (XmlNode fala in listFalas) // levels itens nodes.
				{
					Text texto = new Text();
					texto.personagem = fala.Attributes["personagem"].Value;
					texto.fala = fala.InnerText;
					conversa.Add(texto);
				}
			}
		}
		StartCoroutine(ImprimirDialogo ());
	}

	private void VerificarAcoesPosteriores()
	{
		foreach (XmlNode node in dialogoAtual)
		{
			if(node.Name == "acoes")
			{
				gameObject.GetComponent<LoadXmlData> ().RealizarAcoes (node.ChildNodes, eventTrigger);
			}
		}
	}

	private IEnumerator ImprimirDialogo()
	{
		guiText.color = cor;
		for (int i=0; i < conversa.Count; i++)
		{
			int tempo = (int)Mathf.Floor((conversa[i].fala.Length)/caracteresPorSegundo);
			PosicionarFala(conversa[i]);
			yield return new WaitForSeconds(tempo);
		}
		guiText.text = "";

		GameObject.Find ("Main Camera").GetComponent<LoadScene>().ShowGUIElements();

		VerificarAcoesPosteriores();
	}

	private void PosicionarFala(Text texto)
	{
		guiText.text = texto.fala;
		if(texto.personagem == "Player")
		{
			Vector3 screenPosition = Camera.main.WorldToScreenPoint(GameObject.Find("player").transform.position);
			guiText.pixelOffset = new Vector2(screenPosition.x, screenPosition.y + 50);
		}
		else
		{
			Vector3 screenPosition = Camera.main.WorldToScreenPoint(eventTrigger.transform.position);
			guiText.pixelOffset = new Vector2(screenPosition.x, screenPosition.y + 40);
		}
	}

	public void Hide()
	{
		guiTexture.enabled = false;
		DestroyAllGUITexts ();
		//DestroyAllGUITexts ();
		//GameObject.Find ("player").GetComponent<AIPather> ().enabledMovement = true;
	}

	public void Show()
	{
		guiTexture.enabled = true;
	}
}
