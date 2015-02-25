using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour
{
	public bool machinima;

	private 

	// Use this for initialization
	void Start ()
	{
		//print ("Start loadscene");
		DataManager.cenaAtual = Application.loadedLevel;

		GameObject inventario = GameObject.Find ("Inventario");
		inventario.GetComponent<Inventory> ().InicializarSlots ();

		inventario.GetComponent<GUITexturePosicionamento>().UpdatePostion ();

		// se for uma nova fase, nao usa save. porem o inventario sempre sera carregado, a nao ser q seja novo jogo
		if(DataManager.SaveExists())
		{
			//print ("save existe");
			if(DataManager.carregaInventario)
			{
				//print ("carrega inventario");
				// Objetos do inventario
				string[] itens = DataManager.itens;
				for(int i=0; i < itens.Length; i++)
				{
					if(itens[i] != "") inventario.GetComponent<Inventory>().ColetarItem(itens[i]);
				}

				// se vai carregar o invnetario, entao tb vai carregar as vidas, assim como dinheiro
				GameObject.Find ("Vidas").GetComponent<Life>().SetQtdVidas(DataManager.qtdVidas);
				GameObject.Find ("QtdDinheiro").GetComponent<DinheiroInterface>().SetQtdDinheiro(DataManager.qtdDinheiro);
			}

			if(DataManager.load)
			{
				GameObject.Find ("player").transform.position = DataManager.posPlayer;
				GameObject.Find ("CaixaDialogo").GetComponent<LoadXmlData>().SetVariaveis(DataManager.variaveisList);

				if((DataManager.coinsNames != null) && DataManager.cenaMoedas == Application.loadedLevel)
				{
					for(int j=0; j < DataManager.coinsNames.Length; j++)
					{
						string coin = DataManager.coinsNames[j];
						Destroy(GameObject.Find(coin));
					}
				}
			}


		}

		if(machinima && !DataManager.load)
		{
			HideGUIElements();
			IniciarMovimentoBorboletas();
		}
		else if(Application.loadedLevelName == "iso1")
		{
			Destroy(GameObject.Find ("borboleta1"));
			Destroy(GameObject.Find ("borboleta2"));
		}

		DataManager.load = false;
	}

	public void HideGUIElements()
	{
		foreach (Transform child in GameObject.Find ("Inventario").transform)
			child.guiTexture.enabled = false;

		GameObject.Find ("player").GetComponent<AIPather> ().SetMouseEnabled(false);
		GameObject.Find ("Inventario").guiTexture.enabled = false;
		GameObject.Find ("Pergaminho").GetComponent<AcoesJogador> ().Hide ();
		GameObject.Find ("Vidas").guiTexture.enabled = false;
		GameObject.Find ("Dinheiro").guiTexture.enabled = false;
		GameObject.Find ("QtdDinheiro").guiText.enabled = false;
		GameObject.Find ("Agenda").guiTexture.enabled = false;
		GameObject.Find ("Muiraquita").guiTexture.enabled = false;

		/*GameObject.Find ("player").GetComponent<AIPather> ().SetMouseEnabled(false);
		GameObject.Find ("Inventario").SetActive (false);
		GameObject.Find ("Pergaminho").SetActive (false);
		GameObject.Find ("Vidas").SetActive (false);*/
	}

	public void ShowGUIElements()
	{
		foreach (Transform child in GameObject.Find ("Inventario").transform)
			child.guiTexture.enabled = true;

		GameObject.Find ("player").GetComponent<AIPather> ().SetMouseEnabled(true);
		GameObject.Find ("Inventario").guiTexture.enabled = true;
		GameObject.Find ("Vidas").guiTexture.enabled = true;
		GameObject.Find ("Dinheiro").guiTexture.enabled = true;
		GameObject.Find ("QtdDinheiro").guiText.enabled = true;
		GameObject.Find ("Agenda").guiTexture.enabled = true;
		GameObject.Find ("Muiraquita").guiTexture.enabled = true;

		/*GameObject.Find ("player").GetComponent<AIPather> ().SetMouseEnabled(true);
		GameObject.Find ("Inventario").SetActive (true);
		GameObject.Find ("Vidas").SetActive (true);*/
	}

	private void IniciarMovimentoBorboletas()
	{
		GameObject.Find ("borboleta1").GetComponent<MovimentoBorboleta>().IniciarMovimento("direita");
		GameObject.Find ("borboleta2").GetComponent<MovimentoBorboleta>().IniciarMovimento("baixo");
	}
	
	// Update is called once per frame
	void Update () {
		//print ("oi?");
	}
}
