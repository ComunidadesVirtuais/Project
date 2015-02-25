using UnityEngine;
using System.Collections;

public class GeraItensMG5 : MonoBehaviour {
	
	public GameObject[] objeto;
	//public int quantidadeDeItens;
	// Use this for initialization
	void Start () {
		inicia();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void inicia(){
		
		;//for(int i = 0; i < quantidadeDeItens ; i++){
		GameObject obj = Instantiate(objeto[Random.Range(0,50)%objeto.Length],new Vector3(transform.position.x,transform.position.y,transform.position.z),transform.rotation) as GameObject;
		obj.transform.parent = this.transform;
		//}
		
	}
	public void nextItem(){
		GameObject obj = Instantiate(objeto[Random.Range(0,50)%objeto.Length],new Vector3(transform.position.x,transform.position.y,transform.position.z),transform.rotation) as GameObject;
		obj.transform.parent = this.transform;
	}
	
	void mataTodos(){
		foreach(Transform child in transform)
			Destroy(child);
		
	}
	public void mataTodosEComeca(){
		foreach(Transform child in transform)
			Destroy(child.gameObject);
		inicia();
	}
}
