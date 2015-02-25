using UnityEngine;
using System.Collections;

public class Emissor : MonoBehaviour {

	public float tempo;
	public float velocidade;
	public GameObject[] prefabs; 
	public float taxaDeEmissao;

	// Use this for initialization
	void Start () {
		InvokeRepeating("criaPrefab",tempo,taxaDeEmissao);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	
	void criaPrefab() {


		GameObject obj = (GameObject)Instantiate(prefabs[Random.Range(0,prefabs.Length)],transform.position,transform.rotation);
		//instance.velocity = Random.insideUnitSphere * 5;
		esteira est = obj.GetComponent<esteira>() as esteira;
		est.velocidade = velocidade;
	}
	
	
}
