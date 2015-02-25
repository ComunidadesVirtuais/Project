using UnityEngine;
using System.Collections;

public class InputListener : MonoBehaviour {

	private AIPather pather;
	private GameObject particulas = null;

	// Use this for initialization
	void Start () {
		pather = GameObject.Find ("player").GetComponent<AIPather>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown (0))
		{
			if(!GameObject.Find ("player").GetComponent<AIPather>().IsMouseDownGUI())
			{
				if(particulas == null) particulas = Instantiate(Resources.Load("Particles")) as GameObject;
				pather.SetMouseDown(true);
			}
		}
		if(Input.GetMouseButtonUp (0))
		{
			if(particulas != null)
			{
				Destroy(particulas.gameObject);
				particulas = null;
			}
			pather.SetMouseDown(false);
		}
	}
}
