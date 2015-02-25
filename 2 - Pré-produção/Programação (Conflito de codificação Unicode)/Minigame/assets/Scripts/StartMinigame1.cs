using UnityEngine;
using System.Collections;

public class StartMinigame1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void Update ()
	{
		if(Input.touches.Length>0){
			for(int i=0;i<Input.touchCount; i++)
			{
				if(this.guiTexture.HitTest(Input.GetTouch(i).position))
				{
					if(Input.GetTouch(i).phase == TouchPhase.Began)
					{
						Application.LoadLevel(1);  // vai startar o minigame	
					}
				}
			}
		}
	}

	void OnMouseDown()
	{
		Application.LoadLevel(1);  // vai startar o minigame	
	}
}
