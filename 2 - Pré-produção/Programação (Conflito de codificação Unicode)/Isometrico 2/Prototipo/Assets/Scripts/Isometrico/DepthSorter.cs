using UnityEngine;
using System.Collections;

public class DepthSorter : MonoBehaviour {

	public GameObject[] sprites;
	private bool atualizar = false;

	//private int[] numeros = {4,5,3,1,9,7,5,32,0,46,56,2,34,76,8,5645,5657};
	//private int[] numeros = {25,48 ,37 ,12, 57 ,86, 33, 92};


	// Use this for initialization
	void Start () {
		Quicksort (sprites, 0, sprites.Length - 1);
		UpdateOrderInLayer ();
	}
	
	// Update is called once per frame
	void Update () {
		if(atualizar) // so vai verificar novamente quando ouver movimentacao
		{
			print ("atualizando");
			Quicksort (sprites, 0, sprites.Length - 1);
			UpdateOrderInLayer ();
			atualizar = false;
		}
	}

	private void Quicksort(GameObject[] input, int low, int high)
	{
		int pivot_loc = 0;
		
		if (low < high) {
			pivot_loc = partition(input, low, high);
			Quicksort(input, low, pivot_loc - 1);
			Quicksort(input, pivot_loc + 1, high);
		}
	}
	
	private int partition(GameObject[] input, int low, int high)
	{
		GameObject pivot = input[high];
		int i = low - 1;
		
		for (int j = low; j < high; j++)
		{
			//if (input[j] <= pivot)
			if(EstaNaFrente(input[j], pivot) || (input[j] == pivot))
			{
				i++;
				swap(input, i, j);
			}
		}
		swap(input, i + 1, high);
		return i + 1;
	}

	private void swap(GameObject[] ar, int a, int b)
	{
		GameObject temp = ar[a];
		ar[a] = ar[b];
		ar[b] = temp;
	}

	// Retorna true se objeto 1 esta na frente de objeto 2. Caso nao, retorna falso.
	private bool EstaNaFrente(GameObject objeto1, GameObject objeto2)
	{
		IsoSprite isoSprite1 = objeto1.GetComponent<IsoSprite>();
		IsoSprite isoSprite2 = objeto2.GetComponent<IsoSprite>();

		if(isoSprite1.GetIsoY() < isoSprite2.GetIsoY())
		{
			if((isoSprite1.GetIsoY() + isoSprite1.GetHeight()) <= isoSprite2.GetIsoY())
			{
				// Isosprite2 na frente de isosprite1
				return false;
			}
			else if((isoSprite1.GetIsoX() + isoSprite1.GetWidth()) <= isoSprite2.GetIsoX())
			{
				// Isosprite2 na frente de isosprite1
				return false;
			}
			else return true;
		}
		if(isoSprite2.GetIsoY() < isoSprite1.GetIsoY())
		{
			if((isoSprite2.GetIsoY() + isoSprite2.GetHeight()) <= isoSprite1.GetIsoY())
			{
				// Isosprite2 na frente de isosprite1
				return true;
			}
			else if((isoSprite2.GetIsoX() + isoSprite2.GetWidth()) <= isoSprite1.GetIsoX())
			{
				// Isosprite2 na frente de isosprite1
				return true;
			}
			else return false;
		}
		else if(isoSprite1.GetIsoX() < isoSprite2.GetIsoX()) return false;
		else return true;
	}

	private void printArray()
	{
		for(int j=0; j < sprites.Length; j++)
		{
			print (sprites[j].name);
		}
	}

	private void UpdateOrderInLayer()
	{
		for(int i =0; i < sprites.Length; i++)
		{
			SpriteRenderer spriteRenderer = sprites[i].GetComponent<SpriteRenderer>();
			spriteRenderer.sortingOrder = i * -10;
		}
	}

	public void Atualizar(bool valor)
	{
		atualizar = valor;
	}
}
