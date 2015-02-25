using UnityEngine;
using System.Collections;

public class PopupMecanica : MonoBehaviour {

	protected GameObject eventTrigger;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetEventTrigger(GameObject objeto)
	{
		eventTrigger = objeto;
	}

	protected void HideEverything()
	{
		this.renderer.enabled = false;
		foreach (Transform child in transform)
		{
			child.renderer.enabled = false;
		}
	}
}
