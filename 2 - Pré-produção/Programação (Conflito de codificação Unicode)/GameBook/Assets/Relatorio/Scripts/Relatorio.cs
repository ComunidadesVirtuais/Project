﻿using UnityEngine;
using System.Collections;

public class Relatorio : MonoBehaviour {
	public Material material;
	public Transform estrelaCheia, estrelaVazia,restart;
	//public float x, y;//,xOld=0,yOld=0;
	// Use this for initialization
	void Start () {

		LineRenderer lineRenderer; 

		lineRenderer = gameObject.AddComponent<LineRenderer>();
		lineRenderer.useWorldSpace = true;
		lineRenderer.material = new Material(material);

		lineRenderer.SetWidth(2.0f,2.0f);

		//Codigos
		// BPMGX = BestPoints do Minigame X
		// LPMGX = Lastpoints do Minigame X
		// APMGX = AVGPoints do Minigame X
		// TMGX  = Turns do Minigame X
		// LMG   = Last Minigame

		int i = PlayerPrefs.GetInt("LMG");
		int j = 1;
		print ("has key "+PlayerPrefs.HasKey("LPMG"+i+"N"+j));
		while (PlayerPrefs.HasKey("LPMG"+i+"N"+j)) {
						int y = 0;
						print ("Last Point " + PlayerPrefs.GetInt ("LPMG" + i + "N" + j));
						print ("Best Point " + PlayerPrefs.GetInt ("BPMG" + i + "N" + j));
						print ("AVG Point " + PlayerPrefs.GetFloat ("APMG" + i + "N" + j));
						print ("Turn " + PlayerPrefs.GetInt ("TMG" + i + "N" + j));
						print ("Star " + PlayerPrefs.GetInt ("SMG" + i + "N" + j));
						int star = PlayerPrefs.GetInt ("SMG" + i + "N" + j);
						
						for(int x=0;x<4;x++){
							print ("x "+x+" y "+y+" star "+ star);
							if (star>0){
								
								Instantiate(estrelaCheia,new Vector3(transform.position.x+x,transform.position.y+y,transform.position.z),this.transform.rotation);
								star--;
							}else if (x!=3){	
								Instantiate(estrelaVazia,new Vector3(transform.position.x+x,transform.position.y+y,transform.position.z),this.transform.rotation);
							}
							if(x==3){
								Instantiate(restart,new Vector3(transform.position.x+x,transform.position.y+y,transform.position.z),this.transform.rotation);
							}
						}
						j++;
						y=y-5;
				}
		/*if(this.guiText.name=="BestPointsMG1") {
			lineRenderer.SetColors(Color.red, Color.red);
			lineRenderer.SetPosition(0,new Vector3(x,y,+1.0f));
			lineRenderer.SetPosition(1,new Vector3(x,y+3.0f,+1.0f));
//			print (PlayerPrefs.HasKey("BPMG1"));
			this.guiText.text = "Best Points MG"+i+ " " + PlayerPrefs.GetInt("BPMG"+i);
//			print("Best Points MG1 " + PlayerPrefs.GetInt("BPMG1"));
			}

		if(this.guiText.name=="LastPointsMG1"){
			lineRenderer.SetColors(Color.green, Color.green);
//			print (PlayerPrefs.HasKey("LPMG1"));
			lineRenderer.SetPosition(0,new Vector3(x,y,0));
			lineRenderer.SetPosition(1,new Vector3(x,y+3.0f * (PlayerPrefs.GetInt("LPMG"+i)/(float)PlayerPrefs.GetInt("BPMG"+i)),0));
			this.guiText.text = "Last Points MG"+i+" " + PlayerPrefs.GetInt("LPMG"+i);
//			print("Last Points MG1 " + PlayerPrefs.GetInt("LPMG1"));
		
		}

*/
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
