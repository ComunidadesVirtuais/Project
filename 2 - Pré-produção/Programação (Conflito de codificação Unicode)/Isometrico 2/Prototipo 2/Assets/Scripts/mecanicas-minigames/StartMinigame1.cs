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
						//Application.LoadLevel(1);  // vai startar o minigame	
					}
				}
			}
		}
	}

	void OnMouseDown()
	{
		GameObject minigame = Instantiate (Resources.Load("MinigameSwipe")) as GameObject;
		minigame.gameObject.name = "MinigameSwipe";
		minigame.transform.parent = this.transform.parent.transform.parent.transform;
		minigame.transform.localPosition = new Vector3 (0,0,0);

		foreach (Transform child in minigame.transform)
		{

			//child.renderer.enabled = false;
			if((child.name == "Pontuacao") || (child.name == "Timer"))
			{
				child.transform.localPosition = new Vector3(0, 0, 2);

				int i;
				if(child.name == "Pontuacao") i = 0;
				else i = 1;
				float yOffset = -5;
				float xOffset = 10 + 20 * i;

				child.guiText.pixelOffset = new Vector2(xOffset, yOffset);
			}
		}

		Destroy (this.transform.parent.gameObject);
	}
}
