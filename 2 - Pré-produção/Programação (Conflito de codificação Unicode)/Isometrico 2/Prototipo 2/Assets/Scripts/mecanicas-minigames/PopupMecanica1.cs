using UnityEngine;
using System.Collections;

public class PopupMecanica1 : PopupMecanica {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnDestroy()
	{
		// se tiver vencido o jogo, nao abrirá novamente a mecância e vai dropar um item
		if(this.GetComponent<Gerenciador>().Venceu ())
		{
			eventTrigger.GetComponent<AssetMecanica> ().SetDisponibilidadeMecanica (false);
			eventTrigger.GetComponent<AssetMecanica> ().InstantiateItem();
		}
	}

	public void Show()
	{
		Vector3 posPlayer = GameObject.Find ("player").transform.position;
		float difX = posPlayer.x - this.transform.position.x;
		float difY = posPlayer.y - this.transform.position.y;
		
		this.transform.localPosition = new Vector3(posPlayer.x, posPlayer.y, transform.position.z);

		foreach (Transform child in transform)
		{
			if((child.gameObject.name == "Seta1") || (child.gameObject.name == "Seta2")) child.GetComponent<ArrowController>().SetPosicaoInicial(child.transform.position);
		}

		this.GetComponent<Gerenciador> ().IniciarJogo ();

		GameObject.Find ("Scripts").GetComponent<LoadScene>().HideGUIElements ();
	}
}
