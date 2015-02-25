using UnityEngine;
using System.Collections;

public class ResetMinigame1 : MonoBehaviour {
	
	//private Player player;
	
	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.touches.Length>0)
		{
			for(int i=0;i<Input.touchCount; i++)
			{
				if(this.guiTexture.HitTest(Input.GetTouch(i).position))
				{
					if(Input.GetTouch(i).phase == TouchPhase.Began)
					{
						Application.LoadLevel(1); // vai reiniciar o minigame						
					}
				}
				
			}
		}
	}
	void OnMouseDown()
	{
		Application.LoadLevel(1); // vai reiniciar o minigame	
	}
}
