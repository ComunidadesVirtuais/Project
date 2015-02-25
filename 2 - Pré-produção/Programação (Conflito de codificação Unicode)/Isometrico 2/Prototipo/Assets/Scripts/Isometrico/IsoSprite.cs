using UnityEngine;
using System.Collections;
using Pathfinding;

public class IsoSprite : MonoBehaviour {

	public int isoX, isoY, width, height;
	private int previousIsoX, previousIsoY; // so vai aplicar o sort se o objeto em movimento mudou de posicao

	public bool emMovimento = false; // se esse objeto se move ou nao

	// Use this for initialization
	void Start () {
		previousIsoX = 0;
		previousIsoY = 0;
		SetIsoPosition ();
	}
	
	// Update is called once per frame
	void Update () {
		if(emMovimento) SetIsoPosition(); // sempre atualizara enquanto estiver em movimento
	}

	private void SetIsoPosition()
	{
		GraphNode[] nodes = AstarPath.active.astarData.GetGridGraph ().nodes;
		GraphNode origin = nodes [0]; // no de origem
		GraphNode noAdjacente = nodes [1]; // outro no adjacente
		
		// Vamos descobrir qual a largura e altura de cada no
		
		Vector3 node1PositionScreen = Camera.main.WorldToScreenPoint ((Vector3)origin.position);
		Vector3 node2PositionScreen = Camera.main.WorldToScreenPoint ((Vector3)noAdjacente.position);
		
		float larguraNo = node1PositionScreen.x - node2PositionScreen.x;
		float alturaNo = node1PositionScreen.y - node2PositionScreen.y;
		
		Vector2 centerOriginPos = new Vector2 (node1PositionScreen.x, node1PositionScreen.y - alturaNo);

		//------------------

		Vector3 posAtual = Camera.main.WorldToScreenPoint (this.transform.position);
		
		float difX = posAtual.x - centerOriginPos.x;
		float difY = centerOriginPos.y - posAtual.y;
		
		float qtdTesteX = ((difX - (difX % larguraNo)) / larguraNo) * 0.5f;
		float qtdTesteY = ((difY - (difY % alturaNo)) / alturaNo) * 0.5f;

		int difIsoX = 0;
		int difIsoY = 0;

		if(gameObject.name != "player")
		{
			difIsoX = 1;
			difIsoY = 1;
		}
		isoX = (int)Mathf.Ceil ((qtdTesteX + qtdTesteY)) + difIsoX;
		isoY = (int)Mathf.Ceil ((qtdTesteY - qtdTesteX)) + difIsoY;

		if((previousIsoX != isoX) || (previousIsoY != isoY))
		{
			previousIsoX = isoX;
			previousIsoY = isoY;

			GameObject.Find("Sort").GetComponent<DepthSorter>().Atualizar (true);
		}
		else GameObject.Find("Sort").GetComponent<DepthSorter>().Atualizar (false);
	}

	public void Walk(bool value)
	{
		emMovimento = value;
		//GameObject.Find("Sort").GetComponent<DepthSorter>().Atualizar (value);
	}

	public bool IsWalking()
	{
		return emMovimento;
	}

	public int GetWidth()
	{
		return width;
	}

	public int GetHeight()
	{
		return height;
	}

	public int GetIsoX()
	{
		return isoX;
	}

	public int GetIsoY()
	{
		return isoY;
	}
}
