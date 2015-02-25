using UnityEngine;
using System.Collections;

[ExecuteInEditMode]  

public class GUITexturePosicionamento : MonoBehaviour {

	public float altura, largura, x, y, z;

	// Use this for initialization
	void Start ()
	{
		transform.localPosition = new Vector3 (0, 0, z);
		transform.localScale = Vector3.zero;
		guiTexture.pixelInset = new Rect ((Screen.width * x) / 100,(Screen.height * y) / 100, (Screen.width * largura) / 100,(Screen.width * altura) / 100);

	}
	
	// Update is called once per frame
	void Update ()
	{
		UpdatePostion ();
		/*transform.localPosition = new Vector3 (0, 0, z);
		transform.localScale = Vector3.zero;
		guiTexture.pixelInset = new Rect ((Screen.width * x) / 100,(Screen.height * y) / 100, (Screen.width * largura) / 100,(Screen.width * altura) / 100);*/
	}

	public void UpdatePostion()
	{
		transform.localPosition = new Vector3 (0, 0, z);
		transform.localScale = Vector3.zero;
		guiTexture.pixelInset = new Rect ((Screen.width * x) / 100,(Screen.height * y) / 100, (Screen.width * largura) / 100,(Screen.width * altura) / 100);

	}
}
