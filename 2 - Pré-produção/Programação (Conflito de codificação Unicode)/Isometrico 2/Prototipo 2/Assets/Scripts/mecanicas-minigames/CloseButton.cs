using UnityEngine;
using System.Collections;

public class CloseButton : MonoBehaviour
{
	public int mecanica;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		GameObject.Find ("player").GetComponent<AIPather>().SetOnClickGUI(true);
	}

	void OnMouseUp()
	{
		GameObject.Find ("Scripts").GetComponent<LoadScene>().ShowGUIElements ();
		GameObject.Find ("player").GetComponent<AIPather>().SetOnClickGUI(false);
		Destroy (this.transform.parent.gameObject);
	}
}
