using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataManager
{
	public static string[] itens;
	public static Vector3 posPlayer;
	public static int cenaAtual;

	public static bool load = false;
	public static bool carregaInventario = false;
	public static List<Dictionary<string,string>> variaveisList;

	// Exemplo de save (tudo em uma linha apenas):
	// Inventario:nomeItem1,nomeItem2,nomeItem3;Variaveis:nomeVariavel1Fase1/valorVariavel1Fase1,
	// nomeVariavel2Fase1/valorVariavel2Fase1|nomeVariavel1Fase2/valorVariavel1Fase2;Cena:numeroCena;
	// PosicaoPlayer:x,y,z
	
	public static void SaveAll(List<Dictionary<string,string>> variaveis)
	{
		Debug.Log ("[DataManager] SaveAll");
		string save = "";
		string stringItens = GameObject.Find ("Inventario").GetComponent<Inventory>().GetNamesItens();
		itens = stringItens.Split(',');
		save += "Inventario:" + stringItens + ";";
		save += "Variaveis:";
		for(int i=0; i < variaveis.Count; i++)
		{
			int index = 0;

			if(variaveis[i].Count == 0) save += ";";
			else
			{
				foreach (KeyValuePair<string, string> pair in variaveis[i])
				{
					index++;
					//Debug.Log(pair.Key + ":" + pair.Value);
					if(index >= variaveis[i].Count) save += pair.Key + "/" + pair.Value + ";";
					else save += pair.Key + "/" + pair.Value + ",";
				}
			}
			if(i < variaveis.Count -1) save += "|";
		}

		save += "Cena:" + cenaAtual + ";";

		Debug.Log (Application.loadedLevelName);


		posPlayer = GameObject.Find ("player").transform.position;
		save += "Posicao_Player:" + posPlayer.x + "," + posPlayer.y + "," + posPlayer.z;

		Debug.Log (save);
		PlayerPrefs.SetString("Save", save);
		PlayerPrefs.Save ();
	}

	// Salva apenas um item da string de save

	public static void SaveProperty(string property, string value)
	{
		if (PlayerPrefs.HasKey ("Save"))
		{
			string newSave = "";
			string save = PlayerPrefs.GetString ("Save");
			string[] partesSave = save.Split(';');
			for(int i =0; i < partesSave.Length; i++)
			{
				string[] tipos = partesSave[i].Split (':');
				if(tipos[0] == property)
				{
					newSave += tipos[0] + ":" + value;
				}
				else newSave += partesSave[i];
				
				if(i < partesSave.Length - 1) newSave += ";";
			}
		}
	}

	public static void LoadSave()
	{
		//Debug.Log ("[DataManager] SaveAll");
		if (PlayerPrefs.HasKey ("Save"))
		{
			string save = PlayerPrefs.GetString ("Save");
			Debug.Log("Loading: " + save);
			string[] partesSave = save.Split(';');
			for(int i =0; i < partesSave.Length; i++)
			{
				string[] tipos = partesSave[i].Split (':');
				switch(tipos[0])
				{
					case "Inventario":
					{
						AdicionarItensInventario(tipos[1]);
						break;
					}
					case "Variaveis":
					{
						AdicionarVariaveis(tipos[1]);
						break;
					}
					case "Cena":
					{
						CarregarCena(tipos[1]);
						break;
					}
					case "Posicao_Player":
					{
						AtualizarPosicaoPlayer(tipos[1]);
						break;
					}
				}
			}
		}
	}

	public static bool SaveExists()
	{
		if (PlayerPrefs.HasKey ("Save")) return true;
		else return false;
	}

	private static void AdicionarItensInventario(string pItens)
	{
		itens = pItens.Split(',');
	}
	
	private static void AdicionarVariaveis(string pVariaveis)
	{
		Debug.Log ("AdicionarVariaveis " + pVariaveis);
		//Variaveis:nomeVariavel1Fase1/valorVariavel1Fase1,
		// nomeVariavel2Fase1/valorVariavel2Fase1|nomeVariavel1Fase2/valorVariavel1Fase2
		string[] variaveisFases = pVariaveis.Split('|');
		variaveisList = new List<Dictionary<string,string>>();

		Debug.Log (variaveisFases.Length);
		for(int i=0; i < variaveisFases.Length; i++)
		{
			Debug.Log (variaveisFases[i]);
			Debug.Log ("Fase " + i);

			Dictionary<string,string> dic = new Dictionary<string,string>();

			if(variaveisFases[i] != "")
			{



				string[] variaveis = variaveisFases[i].Split(',');
				for(int j=0; j < variaveis.Length; j++)
				{
					Debug.Log (variaveis[j]);
					string[] variavel = variaveis[j].Split('/');
					Debug.Log ("Variavel " + variavel[0] + " valor " + variavel[1]);
					dic.Add(variavel[0], variavel[1]);
				}

			}

			variaveisList.Add(dic);
		}

	}
	
	private static void CarregarCena(string numeroCena)
	{
		//Debug.Log ("[DataManager] CarregarCena " + numeroCena);
		cenaAtual = int.Parse(numeroCena);
	}
	
	private static void AtualizarPosicaoPlayer(string pPosicao)
	{
		string[] posicao = pPosicao.Split(',');
		posPlayer = new Vector3 (float.Parse(posicao[0]), float.Parse(posicao[1]), float.Parse(posicao[2]));
	}

	public static void ClearSavedData()
	{
		PlayerPrefs.DeleteAll ();
	}
}
