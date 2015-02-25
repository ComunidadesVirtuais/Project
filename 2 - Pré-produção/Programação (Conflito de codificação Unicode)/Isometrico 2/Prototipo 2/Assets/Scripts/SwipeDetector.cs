using UnityEngine;
using System.Collections;

public class SwipeDetector : MonoBehaviour 
{
	
	public bool avancavel = true; // indica se vai para outro quadro ou se volta para o isometrico

	public float minSwipeDistY;
	
	public float minSwipeDistX;

	public float anguloMargemErro = 15;
	
	private Vector2 startPos;

	//private Minigame main;

	public bool isMinigame = false;

	void Start()
	{
		//main = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Minigame>() as Minigame;
	}
	
	void Update()
	{
		VerifyInput ();

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
					float dist = Mathf.Sqrt(Mathf.Pow(delta.x, 2) + Mathf.Pow (delta.y, 2));
					float angle = Mathf.Atan (delta.y/delta.x) * (180.0f/Mathf.PI);

					if(!SwipeVertical(touch.position, angle)) SwipeHorizontal(touch.position, angle);
					break;
				}
			}
		}
	}

	private void VerifyInput()
	{
		if(Input.GetButtonUp("Direita")) GameObject.Find ("MinigameSwipe").GetComponent<Minigame>().PlayerAnswer(2);
		else if(Input.GetButtonUp("Esquerda"))
		{
			if(isMinigame) GameObject.Find ("MinigameSwipe").GetComponent<Minigame>().PlayerAnswer(1);
			else
			{
				if(avancavel) Application.LoadLevel(Application.loadedLevel + 1);
				else Load();
			}
		}
		else if(Input.GetButtonUp("Cima")) GameObject.Find ("MinigameSwipe").GetComponent<Minigame>().PlayerAnswer(3);
		else if(Input.GetButtonUp("Baixo")) GameObject.Find ("MinigameSwipe").GetComponent<Minigame>().PlayerAnswer(4);
	}

	private bool SwipeVertical(Vector2 touchPosition, float angle)
	{
		if(isMinigame)
		{
			bool willSwipe = false;
			float swipeDistVertical = (new Vector2(0, touchPosition.y) - new Vector2(0, startPos.y)).magnitude;
			
			if (swipeDistVertical > minSwipeDistY)
				
			{
				float swipeValue = Mathf.Sign(touchPosition.y - startPos.y);
				
				if (swipeValue > 0)//up swipe
				{
					if(((touchPosition.x > startPos.x) && (angle >= 90 - anguloMargemErro)) || ((touchPosition.x < startPos.x) && (angle <= -90 + anguloMargemErro)) || (touchPosition.x == startPos.x))
					{
						willSwipe = true;
						GameObject.Find ("MinigameSwipe").GetComponent<Minigame>().PlayerAnswer(3);
					}
				}
				else if (swipeValue < 0)//down swipe
				{
					if(((touchPosition.x > startPos.x) && (angle <= -90 + anguloMargemErro)) || ((touchPosition.x < startPos.x) && (angle >= 90 - anguloMargemErro)) || (touchPosition.x == startPos.x))
					{
						willSwipe = true;
						GameObject.Find ("MinigameSwipe").GetComponent<Minigame>().PlayerAnswer(4);
					}
				}
			}
			return willSwipe;
		}
		else return false;
	}
	
	private void SwipeHorizontal(Vector2 touchPosition, float angle)
	{
		float swipeDistHorizontal = (new Vector3(touchPosition.x,0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;
		
		if (swipeDistHorizontal > minSwipeDistX) 
			
		{
			float swipeValue = Mathf.Sign(touchPosition.x - startPos.x);

			if ((swipeValue > 0) && isMinigame) //right swipe
			{
				if(((touchPosition.y > startPos.y) && (angle <= anguloMargemErro)) || ((touchPosition.y < startPos.y) && (angle >= -anguloMargemErro)) || (touchPosition.y == startPos.y))
				{
					if(isMinigame) GameObject.Find ("MinigameSwipe").GetComponent<Minigame>().PlayerAnswer(2);
				}
			}
			else if (swipeValue < 0)//left swipe
			{
				if(((touchPosition.y > startPos.y) && (angle >= -anguloMargemErro)) || ((touchPosition.y < startPos.y) && (angle <= anguloMargemErro)) || (touchPosition.y == startPos.y))
				{
					if(isMinigame) GameObject.Find ("MinigameSwipe").GetComponent<Minigame>().PlayerAnswer(1);
					else
					{
						print ("Entrou onde nao devia");
						if(avancavel) Application.LoadLevel(Application.loadedLevel + 1);
						else Load();
					}

				}
			}
		}
	}

	void OnMouseDown()
	{
		if(!isMinigame)
		{
			print ("Entrou onde nao devia");
			if(avancavel) Application.LoadLevel(Application.loadedLevel + 1);
			else Load();
		}
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