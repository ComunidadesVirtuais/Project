using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D colisor)
	{

		if(colisor.gameObject.name == "player")
		{
			colisor.gameObject.transform.position = new Vector3(colisor.transform.position.x - 0.2f, colisor.transform.position.y + 0.2f, colisor.transform.position.z);
			//print ("Loading: " + this.gameObject.name);
			GameObject.Find ("CaixaDialogo").GetComponent<LoadXmlData>().Save();
			Application.LoadLevel(this.gameObject.name);
		}
	}
}
