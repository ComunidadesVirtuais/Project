using UnityEngine;
using System.Collections;

public class DraggableItemInventory : MonoBehaviour {

	Vector3 previousPos;
	Vector2 index;

	public string scene;
	public string objectName;

	public float largura, altura,z;

	private Vector2 medidasIniciais = new Vector2 (96.5f,96.5f);

	private bool mouseDown;
	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update () {
		if(mouseDown)
		{
			Vector3 p1 = Camera.main.ScreenToWorldPoint (new Vector3(Input.mousePosition.x, Input.mousePosition.y, 3));
			Vector3 p2 = Camera.main.ScreenToWorldPoint (new Vector3(previousPos.x, previousPos.y, 3));
			//this.transform.position = new Vector3(point.x, point.y, -2);

			guiTexture.pixelInset = new Rect (Input.mousePosition.x,Input.mousePosition.y, guiTexture.pixelInset.width,guiTexture.pixelInset.height);
			Debug.DrawLine(p2, p1, Color.red);
		}
	}

	void OnMouseDown()
	{
		previousPos = new Vector2(guiTexture.pixelInset.x, guiTexture.pixelInset.y);
		mouseDown = true;
	}

	void OnMouseUp()
	{
		mouseDown = false; 
		guiTexture.pixelInset = new Rect (previousPos.x,previousPos.y, guiTexture.pixelInset.width,guiTexture.pixelInset.height);
	}

	public Rect SetIndex(int i, int j)
	{
		index.x = i;
		index.y = j;

		float porcent = (this.transform.parent.guiTexture.pixelInset.width - medidasIniciais.x) / medidasIniciais.x;
		/*float xOffset = 10 + 10 * porcent;
		float yOffset = (-5 - 20 * i) - (5 + 20 * i) * porcent;*/
		
		transform.localPosition = new Vector3 (0, 0, z);
		transform.localScale = Vector3.zero;

		Vector2 sizeSlot = new Vector2 (this.transform.parent.guiTexture.pixelInset.width/4, this.transform.parent.guiTexture.pixelInset.height/4);

		float xOffset = (12 + 12 * porcent);
		//print (xOffset + " e " + ind);
		float newPosX = this.transform.parent.guiTexture.pixelInset.x + (12 + 12 * porcent) + (index.x * sizeSlot.x);
		float newPosY = this.transform.parent.guiTexture.pixelInset.yMax - (12 + 12 * porcent) - (index.y * sizeSlot.y) - sizeSlot.y;
		
		guiTexture.pixelInset = new Rect ( newPosX, newPosY, (Screen.width * largura) / 100,(Screen.width * altura) / 100);

		return guiTexture.pixelInset;
	}
}
