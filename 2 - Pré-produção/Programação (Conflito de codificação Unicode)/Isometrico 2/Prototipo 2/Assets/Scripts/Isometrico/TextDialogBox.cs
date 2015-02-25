using UnityEngine;
using System.Collections;
using System.Xml;

public class TextDialogBox : MonoBehaviour {
	
	private int index;
	private XmlNode option;
	private GameObject evttrigger;

	private Vector3 corAnterior;

	// Use this for initialization
	void Start () {
		guiText.color = Color.black;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void SetAcoes(XmlNode a, GameObject evt)
	{
		option = a;
		evttrigger = evt;
	}
	
	void OnMouseDown()
	{
		XmlNodeList optionsNodes = option.ChildNodes;
		foreach (XmlNode op in optionsNodes)
		{
			if(op.Name == "acoes")
			{
				GameObject.Find ("CaixaDialogo").GetComponent<LoadXmlData> ().RealizarAcoes (op.ChildNodes, evttrigger);
				GameObject.Find ("CaixaDialogo").GetComponent<TextPlayer> ().Hide ();
			}
		}

	}
	
	void OnMouseOver()
	{
		guiText.color = Color.red;
	}
	
	void OnMouseExit()
	{
		guiText.color = Color.black;
	}
}
