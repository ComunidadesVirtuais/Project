using UnityEngine;
using System.Collections;

public class BlockMovementGUI : MonoBehaviour {

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
		GameObject.Find ("player").GetComponent<AIPather>().SetOnClickGUI(false);
	}

	void OnDestroy()
	{
		GameObject player = GameObject.Find ("player");
		if(player) player.GetComponent<AIPather>().SetOnClickGUI(false);
	}
}
