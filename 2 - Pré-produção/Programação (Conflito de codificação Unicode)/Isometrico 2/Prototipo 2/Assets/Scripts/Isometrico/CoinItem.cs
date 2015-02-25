using UnityEngine;
using System.Collections;

public class CoinItem : MonoBehaviour {

	public AudioClip collectSound;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.gameObject.name == "player")
		{
			GameObject.Find ("QtdDinheiro").GetComponent<DinheiroInterface>().SomarDinheiro(1);
			AudioSource.PlayClipAtPoint(collectSound, transform.position);
			SaveCoinCollected(Application.loadedLevel, this.gameObject.name);
			Destroy (this.gameObject);
		}
	}

	private void SaveCoinCollected(int scene, string coinName)
	{
		string save = "";
		if (PlayerPrefs.HasKey ("MoedasColetadas"))
		{
			save = PlayerPrefs.GetString ("MoedasColetadas");
			string[] coins = save.Split(':');
			if(int.Parse (coins[0]) == scene) save += "," + coinName;
		}
		else save += scene + ":" + coinName;

		//print ("Salvando: " + save);
		PlayerPrefs.SetString("MoedasColetadas", save);
		PlayerPrefs.Save ();
	}
}
