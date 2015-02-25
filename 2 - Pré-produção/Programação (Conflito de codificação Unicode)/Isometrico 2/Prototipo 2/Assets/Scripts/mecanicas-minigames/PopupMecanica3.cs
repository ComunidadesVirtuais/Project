using UnityEngine;
using System.Collections;

public class PopupMecanica3 : PopupMecanica {

	private bool emJogo = true;
	private bool venceu = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Show()
	{
		Vector3 posPlayer = GameObject.Find ("player").transform.position;
		float difX = posPlayer.x - this.transform.position.x;
		float difY = posPlayer.y - this.transform.position.y;
		
		this.transform.localPosition = new Vector3(posPlayer.x, posPlayer.y, transform.position.z);
		
		GameObject.Find ("Scripts").GetComponent<LoadScene>().HideGUIElements ();

		GameObject telaInicial = Instantiate (Resources.Load("StartMinigame")) as GameObject;
		telaInicial.gameObject.name = "Start";
		telaInicial.transform.parent = this.transform;
		telaInicial.transform.localPosition = new Vector3 (0,0,0);

	}
	
	public bool EstaEmJogo()
	{
		return emJogo;
	}
	
	public void FinalizarJogo()
	{
		emJogo = false;
		venceu = true;
		print ("Voce ganhou! :-)");
	}
	
	void OnDestroy()
	{
		// se tiver vencido o jogo, nao abrirá novamente a mecância e vai dropar um item
		if(venceu)
		{
			eventTrigger.GetComponent<AssetMecanica> ().SetDisponibilidadeMecanica (false);
			eventTrigger.GetComponent<AssetMecanica> ().InstantiateItem();
		}
	}
}
