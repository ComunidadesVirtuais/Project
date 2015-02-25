using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private bool visible = true;
	private bool vulnerable = true;

	public Sprite spriteVisible;
	public Sprite spriteInvisible;

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	}

	public void TornarInvisivel()
	{
		visible = false;
		vulnerable = false;
		GetComponent<SpriteRenderer>().sprite = spriteInvisible;
	}

	public void TornarVisivel()
	{
		visible = true;
		vulnerable = true;
		GetComponent<SpriteRenderer>().sprite = spriteVisible;
	}

	public bool IsVulnerable()
	{
		return vulnerable;
	}

}