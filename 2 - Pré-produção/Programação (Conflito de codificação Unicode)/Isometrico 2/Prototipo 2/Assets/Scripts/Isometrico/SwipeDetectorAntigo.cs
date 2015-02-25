using UnityEngine;
using System.Collections;

public class SwipeDetectorAntigo : MonoBehaviour 
{
	public bool avancavel = true; // indica se vai para outro quadro ou se volta para o isometrico
	public float minSwipeDistY;
	public float minSwipeDistX;
	
	public float anguloMargemErro = 30;
	private Vector2 startPos;
	
	void Start()
	{
	}
	
	void Update()
	{
		if(Input.GetMouseButtonDown (0))
		{
			if(avancavel) Application.LoadLevel(Application.loadedLevel + 1);
			else Load();
		}
			//Application.LoadLevel(Application.loadedLevel + 1);

		foreach (UnityEngine.Touch touch in Input.touches)
		{
			switch (touch.phase) 
			{
				case TouchPhase.Began:
				{
					startPos = touch.position;
					break;
				}
					
				case TouchPhase.Ended:
				{
					Vector2 delta = touch.position - startPos;
					float angle = Mathf.Atan (delta.y/delta.x) * (180.0f/Mathf.PI);
					
					SwipeHorizontal(touch.position, angle);
					break;
				}
			}
		}
	}
	
	private void SwipeHorizontal(Vector2 touchPosition, float angle)
	{
		float swipeDistHorizontal = (new Vector3(touchPosition.x,0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;
		
		if (swipeDistHorizontal > minSwipeDistX)
		{
			float swipeValue = Mathf.Sign(touchPosition.x - startPos.x);
			
			if (swipeValue < 0)//left swipe
			{
				if(((touchPosition.y > startPos.y) && (angle >= -anguloMargemErro)) || ((touchPosition.y < startPos.y) && (angle <= anguloMargemErro)) || (touchPosition.y == startPos.y))
				{
					if(avancavel) Application.LoadLevel(Application.loadedLevel + 1);
					else Load();
				}
			}
		}
	}

	void OnMouseDown()
	{
		if(avancavel) Application.LoadLevel(Application.loadedLevel + 1);
		else Load();
	}

	private void Load()
	{
		print ("[SwipeDetector] Loading!");
		DataManager.LoadSave ();
		DataManager.load = true;
		DataManager.carregaInventario = true;
		Application.LoadLevel(DataManager.cenaAtual);
	}
}