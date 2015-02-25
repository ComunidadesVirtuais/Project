using UnityEngine;
using System.Collections;


public class vetorDeImagens : MonoBehaviour { 

	public Texture2D[] imagemExibida;
	public AudioSource[] narracoes;
	public int count=0;
	private Gerenciador main;

	public float minSwipeDistY;
	
	public float minSwipeDistX;
	
	public float anguloMargemErro = 15;
	
	private Vector2 startPos;


	// Use this for initialization
	void Start () {
		count = PlayerPrefs.GetInt ("Historia");
		print ("Count " + count);
		main = GameObject.FindGameObjectWithTag("Gerenciador").GetComponent<Gerenciador>() as Gerenciador;
		guiTexture.texture = imagemExibida [count];
		narracoes[count].transform.position = this.transform.position;
		narracoes [count].Play ();
		
	}
	
	// Update is called once per frame
	void Update()
	{

		
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
				
				if(SwipeHorizontal(touch.position, angle)){
					funcao ();
				}
				break;
			}
			}
		}
	}




	void OnMouseDown(){
		funcao ();
	}
	private void funcao(){
		count++;
		if (count == 3)
			main.fase1 ();
		else if (count == 4) {
			Destroy (this.gameObject);
		}
		else if(count == 5) {
			main.miniGame ();
		}
		else if(count == 6) {
			main.creditos ();
		}
		else {          
			narracoes [count-1].Stop();
			guiTexture.texture = imagemExibida [count];
			narracoes [count].Play ();
		}
	}

	private bool SwipeHorizontal(Vector2 touchPosition, float angle)
	{
		float swipeDistHorizontal = (new Vector3(touchPosition.x,0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;
		
		if (swipeDistHorizontal > minSwipeDistX) 
			
		{
			float swipeValue = Mathf.Sign(touchPosition.x - startPos.x);
			
			if (swipeValue > 0)//right swipe
			{
				if(((touchPosition.y > startPos.y) && (angle <= anguloMargemErro)) || ((touchPosition.y < startPos.y) && (angle >= -anguloMargemErro)) || (touchPosition.y == startPos.y))
				{
					//main.PlayerAnswer(2);
					return true;
				}
			}
			else if (swipeValue < 0)//left swipe
			{
				if(((touchPosition.y > startPos.y) && (angle >= -anguloMargemErro)) || ((touchPosition.y < startPos.y) && (angle <= anguloMargemErro)) || (touchPosition.y == startPos.y))
				{
					//main.PlayerAnswer(1);
					return false;
				}
			}
		}
		return false;
	}
}