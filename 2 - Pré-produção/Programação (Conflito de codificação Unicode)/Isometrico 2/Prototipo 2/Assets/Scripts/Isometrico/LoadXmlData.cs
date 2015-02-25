using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class LoadXmlData : MonoBehaviour {

	string[] nomesArquivos = new string[3] {"joaquina", "joao", "francisco"};
	public int quantidadeFases = 1;

	private DataXML dialogoRecente;

	public struct DataXML
	{
		public string nome;
		public Color corTexto;
		public string fase;
		public XmlNodeList dialogos;
		public XmlNodeList eventos;
	}

	private List<DataXML> listaDados = new List<DataXML>();
	private List<Dictionary<string,string>> variaveis = null;

	// Use this for initialization
	void Start ()
	{
		if(variaveis == null)
		{
			variaveis = new List<Dictionary<string,string>>();
			for(int i=0; i < quantidadeFases; i++) variaveis.Add (new Dictionary<string,string>()); // para cada fase, ha um grupo de variaveis
		}
		ReadAllXmlData ();
		//print ("depois de ler dados");
		//teste ();
		//GetAction ("Joaquina");
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void ReadAllXmlData()
	{
		for(int i=0; i< nomesArquivos.Length; i++)
		{

			//XmlReaderSettings readerSettings = new XmlReaderSettings();
			//readerSettings.IgnoreComments = true;
			/*using (XmlReader reader = XmlReader.Create(nomesArquivos[i], readerSettings))
			{
				XmlDocument xmlDoc = new XmlDocument();
				xmlDoc.Load(reader);*/

				TextAsset textAsset = (TextAsset)Resources.Load(nomesArquivos[i], typeof(TextAsset));
				XmlDocument xmlDoc = new XmlDocument ();
				xmlDoc.LoadXml ( textAsset.text );
				
				DataXML data = new DataXML();
				XmlNodeList propriedades = xmlDoc.GetElementsByTagName("propriedades");
				foreach (XmlNode nosPropriedades in propriedades)
				{
					foreach (XmlNode propriedade in nosPropriedades)
					{
						if(propriedade.Name == "cor_texto")
						{
							int red = 0;
							int green = 0;
							int blue = 0;
							
							foreach (XmlNode tipoCor in propriedade)
							{
								if(tipoCor.Name == "red") red = int.Parse (tipoCor.InnerText);
								else if(tipoCor.Name == "green") green = int.Parse (tipoCor.InnerText);
								else if(tipoCor.Name == "blue") blue = int.Parse (tipoCor.InnerText);
							}

							/*float redF = red / 255f;
						float greenF = green / 255f;
						float blueF = blue / 255f;*/

							data.corTexto = new Color(red,green,blue,255);
						}
						else if(propriedade.Name == "nome") data.nome = propriedade.InnerText;
						else if(propriedade.Name == "fase") data.fase = propriedade.InnerText;
					}
				}
				
				data.dialogos = xmlDoc.GetElementsByTagName("dialogo");
				data.eventos = xmlDoc.GetElementsByTagName("interacao");
				listaDados.Add (data);
				// etc...
			//}


		}
	}

	// Chamada por AcoesJogador.cs, ao escolher uma das opcoes ao encontrar um NPC

	public void GetAction(string npcName, GameObject eventTrigger)
	{
		for (int i = 0; i < listaDados.Count; i++)
		{
			if(listaDados[i].nome == npcName)
			{
				dialogoRecente = listaDados[i];
				foreach (XmlNode eventoInfo in listaDados[i].eventos)
				{
					XmlNodeList conteudoEventos = eventoInfo.ChildNodes;

					bool condicaoSatisfeita = false;

					foreach (XmlNode noEvento in conteudoEventos) // levels itens nodes.
					{
						if(noEvento.Name == "condicoes")
						{
							XmlNodeList condicoes = noEvento.ChildNodes;
							foreach(XmlNode condicao in condicoes)
							{
								condicaoSatisfeita = VerificaCondicao(condicao);
								/*if(condicao.Attributes["tipo"].Value == "variavel")
								{
									string valor = GetVariavel(int.Parse(listaDados[i].fase),condicao.Attributes["nome"].Value,condicao.Attributes["valor"].Value);

									print ("Valor condicao encontrada : " + valor + " valor real da condicao: " + condicao.Attributes["valor"].Value);
									if(condicao.Attributes["valor"].Value == valor) condicaoSatisfeita = true;
									else
									{
										print ("nao satisfeita");
										condicaoSatisfeita = false;
										break;
									}
								}*/
							}
						}
						else if((noEvento.Name == "acoes") && condicaoSatisfeita)
						{
							XmlNodeList acoes = noEvento.ChildNodes;
							RealizarAcoes(acoes, eventTrigger);
						}
					}
				}
			}
		}
	}

	public bool VerificaCondicao(XmlNode condicao)
	{
		bool condicaoSatisfeita = false;
		if(condicao.Attributes["tipo"].Value == "variavel")
		{
			string valor = GetVariavel(1,condicao.Attributes["nome"].Value,condicao.Attributes["valor"].Value);
			
			if(condicao.Attributes["valor"].Value == valor) condicaoSatisfeita = true;
			else
			{
				condicaoSatisfeita = false;
			}
		}
		return condicaoSatisfeita;
	}
	
	public void RealizarAcoes(XmlNodeList acoes, GameObject eventTrigger)
	{
		print ("[LoadXmlData] RealizarAcoes");
		//GameObject npc = GameObject.Find (npcData.nome);
		foreach(XmlNode acao in acoes)
		{
			if(acao.NodeType != XmlNodeType.Comment)
			{
				switch(acao.Attributes["tipo"].Value)
				{
					case "iniciar_dialogo":
					{
						GameObject.Find ("CaixaDialogo").GetComponent<TextPlayer>().IniciarDialogo(GetDialogo(acao.Attributes["dialogo"].Value, dialogoRecente.dialogos), dialogoRecente.corTexto, eventTrigger);
						break;
					}
					case "variavel":
					{
						SetVariavel(1,acao.Attributes["nome"].Value,acao.Attributes["valor"].Value);
						break;
					}
					case "encerrar_dialogo":
					{
						print ("encerrar_dialogo");
						//GameObject.Find ("player").GetComponent<AIPather> ().enabledMovement = true;
						//GameObject.Find ("player").GetComponent<AIPather> ().EnabledMovementDelayed();
						break;
					}
					case "ir_para_fase":
					{
						DataManager.carregaInventario = true;
						DataManager.SaveAll(variaveis);
						Application.LoadLevel(int.Parse(acao.Attributes["nome"].Value));
						break;
					}
					case "adicionar_inventario":
					{
						break;
					}
					case "adicionar_hipertexto":
					{
						GameObject.Find ("Agenda").GetComponent<Agenda>().AdicionarHipertexto(acao.Attributes["nome"].Value);
						break;
					}
					case "iniciar_minigame":
					{
						
						bool retorno = GameObject.Find ("QtdDinheiro").GetComponent<DinheiroInterface>().SubtrairDinheiro(int.Parse(acao.Attributes["valor"].Value));
						if(retorno)
						{
							DataManager.SaveAll(variaveis);
							Application.LoadLevel(int.Parse(acao.Attributes["nome"].Value));
						}
						break;
					}
				}
			}
		}
	}

	private XmlNode GetDialogo(string nomeDialogo, XmlNodeList listaDialogos)
	{
		foreach (XmlNode dialogo in listaDialogos)
		{
			if(dialogo.Attributes["nome"].Value == nomeDialogo) return dialogo;
		}
		return null;
	}

	public void SetVariaveis(List<Dictionary<string,string>> pVariaveis)
	{
		variaveis = pVariaveis;
		/*print ("Set Variaveis");

		variaveis =  new List<Dictionary<string,string>>();

		for(int i = 0; i < pVariaveis.Count; i++)
		{
			variaveis.Add(pVariaveis[i]);
		}
		print ("qtd chaves: " + variaveis[0].Count);*/
		/*for(int i = 0; i < variaveis.Count; i++)
		{
			Dictionary<string,string> d = variaveis[i];
			print ("qtd chaves: " + d.Count + " na fase: " + i);
		}*/
	}

	public void SetVariavel(int numeroFase, string nomeVariavel, string valorVariavel)
	{
		//print ("Set variavel");
		if(variaveis[numeroFase-1].ContainsKey(nomeVariavel))
		{
			//print ("[Loadxmldata] setando variavel: " + nomeVariavel + " com valor: " + valorVariavel + " e valor anterior : " + variaveis[numeroFase-1][nomeVariavel]);
			variaveis[numeroFase-1][nomeVariavel] = valorVariavel;
			//print ("Ficou assim: " + variaveis[numeroFase-1][nomeVariavel]);
		}
		else
		{
			//print ("n achou variavel: " + nomeVariavel);
			variaveis[numeroFase-1].Add (nomeVariavel, valorVariavel);
		}
	}
	
	public string GetVariavel(int numeroFase, string nomeVariavel, string valorVariavel)
	{
		string valor = "";

		print ("(1): " + variaveis.Count);
		print ("fase: " + numeroFase);
		print ("(2): " + variaveis[numeroFase - 1].Count);
		if(variaveis[numeroFase-1].ContainsKey(nomeVariavel))
		{
			// achou variavel
			valor = variaveis[numeroFase-1][nomeVariavel];
		}
		else
		{
			//print ("n achou variavel: " + nomeVariavel + " na fase: " + numeroFase);
			variaveis[numeroFase-1].Add (nomeVariavel, valorVariavel);
			valor = valorVariavel;
		}
		/*if(variaveis[numeroFase-1].TryGetValue(nomeVariavel,out valor)) // achou variavel
		{
		}
		else
		{
			variaveis[numeroFase-1].Add (nomeVariavel, valorVariavel);
			valor = valorVariavel;
		}*/

		return valor;
	}

	void OnApplicationQuit() {
		DataManager.SaveAll (variaveis);
	}

	public void Save()
	{
		DataManager.SaveAll (variaveis);
	}
}
