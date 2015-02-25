using UnityEngine;
using System.Collections;

public class Points : MonoBehaviour {

	private int points;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setPoints(int qtd){
		points = qtd;
		gameObject.guiText.text = "Points: " + points;
	}

	public void addPoints(int qtd){
		points += qtd;
		gameObject.guiText.text = "Points: " + points;
	}

	public void removePoints(int qtd){
		points -= qtd;
		gameObject.guiText.text = "Points: " + points;
	}

	public int getPoints()
	{
		return points;
	}
}
