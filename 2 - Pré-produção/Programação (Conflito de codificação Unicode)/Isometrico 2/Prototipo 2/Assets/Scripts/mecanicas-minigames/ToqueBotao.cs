using UnityEngine;
using System.Collections;

public class ToqueBotao : MonoBehaviour {

	public GameObject leftArrow;
	public GameObject rightArrow;
	public GameObject popup;

	private float qtdMovimento;

	// Use this for initialization
	void Start () {
		qtdMovimento = popup.GetComponent<Gerenciador> ().qtdMovimento;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		print ("oi");
		if(popup.GetComponent<Gerenciador>().EstaEmJogo())
		{
			Vector3 pastPos = leftArrow.transform.position;
			leftArrow.transform.position = new Vector3 (pastPos.x + qtdMovimento, pastPos.y, pastPos.z);
			leftArrow.GetComponent<ArrowController> ().SetDirecao (1);
			
			pastPos = rightArrow.transform.position;
			rightArrow.transform.position = new Vector3 (pastPos.x - qtdMovimento, pastPos.y, pastPos.z);
			rightArrow.GetComponent<ArrowController> ().SetDirecao (-1);
		}
	}
}
