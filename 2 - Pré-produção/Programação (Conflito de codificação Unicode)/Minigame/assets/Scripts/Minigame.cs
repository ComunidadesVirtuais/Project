using UnityEngine;
using System.Collections;

public class Minigame : MonoBehaviour {

	public int numberLevels = 15;
	private int actualLevel;
	public float numberSet = 3.0f; // quantas setas
	GameObject arrows;

	public int pontosAcerto = 100;
	public int pontosErro = 20;
	public int pontosAcerto1s = 10;
	public int pontosAcerto2s = 5;
	public int pontosAcerto3s = 1;
	public int pontosAcertoMaisDe3s = 0;
	public int pontosAcerto5vezes = 50;
	public int timer = 30;

	public int scoreMinimo = 1500;

	private bool countTime = false;

	private float roundTimer;

	private int winsStreak;

	// Use this for initialization
	void Start ()
	{
		arrows = GameObject.Find ("Arrows");
		actualLevel = 1;
		winsStreak = 0;

		PlaceAtRandomPosition();
		InvokeRepeating ("decreaseTimeRemaining", 1.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (countTime) RoundTimer ();
	}

	// Funçao que controla o tempo do minigame. Se chegar a 0, acaba o jogo e verifica se tem o score minimo.
	private void decreaseTimeRemaining()
	{
		timer--;
		TimerText timerText = GameObject.Find ("Timer").GetComponent<TimerText> () as TimerText;
		timerText.setTime (timer);
		if(timer <= 0) EndGame();
	}

	// Para cada conjunto de setas, vai contar o tempo de resposta do player para verificaçao de bonus.

	private void RoundTimer()
	{
		roundTimer += Time.deltaTime;
	}

	private void StartRoundTimer()
	{
		roundTimer = 0.0f;
		countTime = true;
	}

	private int VerificaBonusAcerto()
	{
		int bonus = 0;

		if (roundTimer <= 1) bonus += pontosAcerto1s;
		else if (roundTimer <= 2) bonus += pontosAcerto2s;
		else if (roundTimer <= 3) bonus += pontosAcerto3s;
		else bonus += pontosAcertoMaisDe3s;

		if(winsStreak >= 5) bonus += pontosAcerto5vezes;

		return bonus;
	}

	public void PlayerAnswer(int value)
	{
		countTime = false;

		ArrowsSet arrowSet = arrows.transform.Find("Arrow" + Mathf.CeilToInt(numberSet/2)).gameObject.GetComponent<ArrowsSet>() as ArrowsSet;
		Points pontuacao = GameObject.Find ("Pontuacao").GetComponent<Points> () as Points;

		if (arrowSet.GetNumberArrow () == value) // acertou :-)
		{
			winsStreak++;
			pontuacao.addPoints (pontosAcerto + VerificaBonusAcerto());
		}
		else
		{
			winsStreak = 0;
			pontuacao.removePoints (pontosErro);
		}
		actualLevel++;

		if (actualLevel <= numberLevels) PlaceAtRandomPosition ();
		else EndGame (); // atingiu limite de conjuntos
	}

	private void EndGame()
	{
		CancelInvoke ();

		Points pontuacao = GameObject.Find ("Pontuacao").GetComponent<Points> () as Points;

		if(pontuacao.getPoints() < scoreMinimo)
		{
			// nao atingiu o score minimo! passei o valor pra colocar na tela de #fail
			PlayerPrefs.SetInt("Highscore_minigame1", scoreMinimo); 
			Application.LoadLevel(2);
		}
		else
		{
			// jogador conseguiu! nessa parte vai chamar a proxima fase ou oq quer q seja. por enquanto carrega a mesma tela de #fail
			// mas com msg dizendo q ele ganhou

			PlayerPrefs.SetInt("Highscore_minigame1", 0);
			Application.LoadLevel(2);
		}
	}

	private void PlaceAtRandomPosition()
	{
		int number;
		ArrowsSet arrowSet;

		// Vamos pegar uma seta randomica (uma das quatro direcoes) e setar o conjunto
		for (int i=1; i < 4; i++)
		{
			arrowSet = arrows.transform.Find("Arrow" + i).gameObject.GetComponent<ArrowsSet>() as ArrowsSet;
			number = Random.Range (1, 4);
			arrowSet.setArrow (number, i);
		}

		float sizeOfArrow = arrows.transform.Find ("Arrow1").gameObject.GetComponent<SpriteRenderer> ().sprite.bounds.size.x;

		Vector3 randomPos = GetRandomPositionScreen(sizeOfArrow);
		arrows.transform.position = randomPos;

		StartRoundTimer ();
	}

	private Vector3 GetRandomPositionScreen(float size)
	{
		Vector3 max = new Vector3(Screen.width, Screen.height, 0);
		Vector3 min = new Vector3(0, 0, 0);
		
		Vector3 worldPosMax = camera.ScreenToWorldPoint(max);
		Vector3 worldPosMin = camera.ScreenToWorldPoint(min);

		Vector3 randomPoint = new Vector3 (Random.Range (worldPosMin.x, worldPosMax.x), Random.Range (worldPosMin.y, worldPosMax.y), 0);

		if (isPositionValid (randomPoint, size)) return randomPoint;
		else return GetRandomPositionScreen (size);
	}

	private bool isPositionValid(Vector3 random, float size)
	{
		bool ok = true;

		float x_ = random.x + size + size/ 2; // ate onde vai no eixo x
		float y_ = random.y - (size * numberSet) + size/2; // ate onde vai no eixo y

		Vector3 v = new Vector3(Screen.width, Screen.height, 0);
		Vector3 limite = camera.ScreenToWorldPoint (v);

		if ((random.x > 0) && (x_ > limite.x))
						return false;
		if ((random.y < 0) && (Mathf.Abs (y_) > limite.y))
						return false;
		if ((random.y >= 0) && (random.y + size + size / 2) > limite.y)
						return false;
		if ((random.x <= 0) && Mathf.Abs (random.x - (size + size / 2)) > limite.x)
						return false; 

		return ok;
	}
}
