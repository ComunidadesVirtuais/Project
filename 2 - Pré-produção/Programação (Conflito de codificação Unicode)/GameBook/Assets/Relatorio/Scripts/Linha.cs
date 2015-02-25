using UnityEngine;
using System.Collections;

public class Linha : MonoBehaviour {
	public Material material;
	public Color cor;
	public float[] valores;

	public GameObject grid;
	private int controleLinhasGrid = 1;
	LineRenderer lineRenderer2; 
	 

	// Use this for initialization
	void Start () {


		for (int j=1; j<=5; j++) {
						//int i = PlayerPrefs.GetInt("LMG");
						print("Last Point " + j +" " +PlayerPrefs.GetInt("LPMG"+j));
						print("Best Point " + j +" " + PlayerPrefs.GetInt("BPMG"+j));
						print("AVG Point "  + PlayerPrefs.GetFloat("APMG"+j));
						print("Turn "       + PlayerPrefs.GetInt("TMG"+j));
						if (PlayerPrefs.GetInt ("BPMG" + j) == 0)
								valores [j-1] = 0;
						else
								valores [j-1] = 3 * PlayerPrefs.GetFloat ("APMG" + j) / (float)PlayerPrefs.GetInt ("BPMG" + j);
				}

		for (int j=0; j<=4; j++)
			print ("valor "+valores[j]+" ");

		init();


	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void init(){

		LineRenderer lineRenderer; 
		float x,y,xOld=0,yOld=0;
		lineRenderer = gameObject.AddComponent<LineRenderer>();
		lineRenderer.useWorldSpace = false;
		lineRenderer.material = new Material(material);
		lineRenderer.SetColors(new Color(cor.r,cor.g,cor.b), new Color(cor.r,cor.g,cor.b));
		lineRenderer.SetWidth(0.3f,0.3f);
		lineRenderer.SetVertexCount(valores.Length+1);
		initGrid();
		
		for(int i=0;i<=valores.Length;i++){


		
			if(valores[i%valores.Length]==0){
				y = 1*Mathf.Sin((i*2*Mathf.PI)/valores.Length);
				x = 1*Mathf.Cos((i*2*Mathf.PI)/valores.Length);
				linhaGrid(x,y,3);
				x=0;y=0;
			}
			else{
			    y = valores[i%valores.Length]*Mathf.Sin((i*2*Mathf.PI)/valores.Length);
				x = valores[i%valores.Length]*Mathf.Cos((i*2*Mathf.PI)/valores.Length);
				linhaGrid(x,y,3/valores[i%valores.Length]);
			}

			lineRenderer.SetPosition(i,new Vector3(x,y,0));
//			print ("x = "+x+" y = "+y);
//			print ("xold = "+xOld+" yold = "+yOld);
			xOld = x;
			yOld=y;
			
		}

	}
	void initGrid(){
		print ("initgrid");
//		float x,y,xOld=0,yOld=0;
		lineRenderer2 = grid.gameObject.AddComponent<LineRenderer>();
		lineRenderer2.useWorldSpace = false;
		lineRenderer2.material = new Material(material);
		lineRenderer2.SetColors(Color.gray, Color.gray);
		lineRenderer2.SetWidth(0.1f,0.1f);
		lineRenderer2.SetVertexCount(valores.Length*2+1);
		lineRenderer2.SetPosition(0,new Vector3(0,0,0));
	}
	void linhaGrid(float pontoX,float pontoY,float i){
		print ("add line in grid "+ controleLinhasGrid);
		if(valores.Length*2>=controleLinhasGrid+1){

			lineRenderer2.SetPosition(controleLinhasGrid,new Vector3(pontoX*i,pontoY*i,0.0f));
			lineRenderer2.SetPosition(controleLinhasGrid+1,new Vector3(0,0,0));
			controleLinhasGrid=controleLinhasGrid+2;
		}

	}

	
}
