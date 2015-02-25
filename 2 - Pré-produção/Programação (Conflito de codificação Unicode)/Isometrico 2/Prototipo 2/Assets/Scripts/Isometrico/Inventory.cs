using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

	public struct Slot
	{
		public GameObject image;
		public string prefabName;
		public Rect area;
	}

	private Slot[,] slots;

	private const int NUM_ROWS = 3;
	private const int NUM_COLUMNS = 3;

	private Vector2 sizeSlot;
	private float width;
	private float height;

	private Vector2 medidasIniciais = new Vector2 (96.5f,96.5f);

	// Use this for initialization
	void Start () {
	}

	public void InicializarSlots()
	{
		slots = new Slot[NUM_ROWS,NUM_COLUMNS];
		
		sizeSlot.x = (guiTexture.pixelInset.width) / 4;
		sizeSlot.y = (guiTexture.pixelInset.height) / 4;
		
		float porcent = (guiTexture.pixelInset.width - medidasIniciais.x) / medidasIniciais.x;
		
		for(int i=0; i < NUM_ROWS; i++)
		{
			for(int j = 0; j < NUM_COLUMNS; j++)
			{
				float newPosX = guiTexture.pixelInset.x + (12 + 12 * porcent) + (i * sizeSlot.x);
				float newPosY = guiTexture.pixelInset.yMax - (12 + 12 * porcent) - (j * sizeSlot.y) - sizeSlot.y;
				
				slots[i,j].area = new Rect ( newPosX, newPosY, sizeSlot.x,sizeSlot.y);
				
				slots[i,j].image = null;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

		/*if(Input.touches.Length>0){
			for(int i=0;i<Input.touchCount; i++){
				
				if(this.guiTexture.HitTest(Input.GetTouch(i).position)){
					
					if(Input.GetTouch(i).phase == TouchPhase.Began)
					{
						GameObject.Find ("player").GetComponent<AIPather>().SetOnClickGUI(true);
					}
					else if(Input.GetTouch(i).phase == TouchPhase.Ended)
					{
						GameObject.Find ("player").GetComponent<AIPather>().SetOnClickGUI(false);
					}
				}
				
			}
		}*/
	}

	public void DropItem(Vector2 begin, Vector2 end, Vector2 index)
	{
		/*float limiteX = begin.x + sizeSlot.x / 2;
		float limiteY = begin.y + sizeSlot.y / 2;

		float inicioX = guiTexture.pixelInset.x - sizeSlot.x;
		float inicioY = guiTexture.pixelInset.yMax;

		float cond1, cond2, cond3, cond4, cond5, cond6;
		
		cond1 = guiTexture.pixelInset.x;
		cond2 = begin.x + sizeSlot.x;
		cond3 = guiTexture.pixelInset.xMax;
		cond4 = guiTexture.pixelInset.yMax;
		cond5 = begin.y + sizeSlot.y;
		cond6 = guiTexture.pixelInset.y;

		GameObject key = slots [(int)index.x, (int)index.y].image;

		if(SaiuEspacoSlot (begin,end))
		{
			//print ("Pos inicial: " + begin + " Pos final: " + end + "1: " + cond1 + " 2: " + cond2 + " 3: " + cond3 + " 4: " + cond4 + " 5: " + cond5 + " 6: " + cond6);

			// verifica se saiu da area do inventario OU se foi pra outro slot
			if((end.x < guiTexture.pixelInset.x) || (end.x + sizeSlot.x > guiTexture.pixelInset.xMax)
			   || (end.y + sizeSlot.y > guiTexture.pixelInset.yMax) || (end.y < guiTexture.pixelInset.y))
				print("saiu do inventario");
			//key.guiTexture.pixelInset = new Rect (begin.x,begin.y, key.guiTexture.pixelInset.width,key.guiTexture.pixelInset.height);
			else
			{
				BoteNoSlotMaisProximo(end);
				print ("ta no inventario");
			}
				
		}
		else
		{
			//key.guiTexture.pixelInset = new Rect (begin.x,begin.y, key.guiTexture.pixelInset.width,key.guiTexture.pixelInset.height);
		}*/
		GameObject key = slots [(int)index.x, (int)index.y].image;
		key.guiTexture.pixelInset = new Rect (begin.x,begin.y, key.guiTexture.pixelInset.width,key.guiTexture.pixelInset.height);
		//}

		/*for(int i=0; i < NUM_ROWS; i++)
		{
			for(int j = 0; j < NUM_COLUMNS; j++)
			{
				if((end.x > slots[j,i].position.x) && (slots[j,i].position.y == begin.y)) // achou item!
				{
					slots[j,i].image = (GameObject)Instantiate(item, slots[j,i].position, Quaternion.identity);
					
					slots[j,i].image.transform.position = new Vector3(slots[j,i].image.transform.position.x,slots[j,i].image.transform.position.y,-2);
					return;
				}
			}
		}*/
	}

	private bool BoteNoSlotMaisProximo(Vector2 end)
	{
		for(int i=0; i < NUM_ROWS; i++)
		{
			for(int j = 0; j < NUM_COLUMNS; j++)
			{
				if(slots[i,j].image == null)
				{
					print ("slot[" +i + "," + j + "] contem: " + end + " ?" + " Rect: xMin x xMax " + slots[i,j].area.xMin + "x" + slots[i,j].area.xMax + " yMin x yMax " + slots[i,j].area.yMin + "x" + slots[i,j].area.yMax);
					if(slots[i,j].area.Contains(end))
					{
						print ("achouuu");
						return true;
					}
				}
			}
		}
		return false;
	}

	private bool SaiuEspacoSlot(Vector2 begin, Vector2 end)
	{
		float cond1, cond2, cond3, cond4;

		cond1 = begin.x + sizeSlot.x / 2;
		cond2 = begin.y + sizeSlot.y / 2;
		cond3 = begin.x - sizeSlot.y / 2;
		cond4 = begin.y - sizeSlot.y / 2;

		//print ("Pos inicial: " + begin + " Pos final: " + end + "1: " + cond1 + " 2: " + cond2 + " 3: " + cond3 + " 4: " + cond4);
		if ((end.x > begin.x + sizeSlot.x / 2) || (end.y > begin.y + sizeSlot.y / 2)
		    || (end.x < begin.x - sizeSlot.y / 2) || (end.y < begin.y - sizeSlot.y / 2))
		{
			//print ("saiu do slot");
			return true;
		}
		else
		{
			print ("ainda ta no slot");
			return false;
		}


	}

	public string GetNamesItens()
	{
		string s = "";
		for(int i=0; i < NUM_ROWS; i++)
		{
			for(int j = 0; j < NUM_COLUMNS; j++)
			{
				if(slots[j,i].image != null)
				{
					if(s!= "") s += "," + slots[j,i].prefabName;
					else s += slots[j,i].prefabName;
				}
			}
		}
		return s;
	}

	public void ColetarItem(string prefabName)
	{
		for(int i=0; i < NUM_ROWS; i++)
		{
			for(int j = 0; j < NUM_COLUMNS; j++)
			{
				if(slots[j,i].image == null)
				{
					slots[j,i].image = Instantiate(Resources.Load(prefabName)) as GameObject;

					DraggableItemInventory script = slots[j,i].image.GetComponent<DraggableItemInventory>() as DraggableItemInventory;
					ExcluirItemCenario(script.scene, script.objectName);
					slots[j,i].prefabName = prefabName;
					slots[j,i].image.transform.parent = this.transform;
					//slots[j,i].image.transform.localPosition = slots[j,i].position;

					//slots[j,i].image.transform.position = new Vector3(0,0,2);

					Rect r = slots[j,i].image.GetComponent<DraggableItemInventory>().SetIndex (i,j);
					slots[j,i].area = new Rect(r.x,r.y,r.width,r.height);
					return;
				}
			}
		}
	}

	private void ExcluirItemCenario(string fase, string nomeObjeto)
	{
		// se for um item daquela fase, vai excluir do cenario. isso serve para o load
		if(Application.loadedLevelName == fase)
		{
			if(nomeObjeto != "null") Destroy(GameObject.Find (nomeObjeto));
		}
	}
}
