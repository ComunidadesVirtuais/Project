using UnityEngine;
using System.Collections;

public class OptionText : MonoBehaviour {

	private int index;

	void Start () {
		guiText.color = Color.black;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetIndex(int i)
	{
		index = i;
	}

	public int GetIndex()
	{
		return index;
	}

	void OnMouseDown()
	{
		GameObject.Find ("Pergaminho").GetComponent<AcoesJogador> ().LoadAction (index);
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
