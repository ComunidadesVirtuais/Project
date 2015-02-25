using UnityEngine;
using System.Collections;

public class ArrowsSet : MonoBehaviour {

	private int numberArrow; // 1: left, 2: right, 3: up, 4: down

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setArrow(int index, int pos){
		Texture2D texture = Resources.Load<Texture2D>("Seta" + index);
		Sprite sprite = Sprite.Create (texture, new Rect(0,0,128,128), new Vector2(0,0));
		this.GetComponent<SpriteRenderer> ().sprite = sprite;
		//this.transform.position = new Vector2(0, -(pos - 1) * sprite.bounds.size.y);

		float b = -(pos - 1) * sprite.bounds.size.y;

		numberArrow = index;
	}

	public int GetNumberArrow()
	{
		return numberArrow;
	}
}
