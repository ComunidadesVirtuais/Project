using UnityEngine;
using System.Collections;
using Pathfinding;

public class AIPather : MonoBehaviour {

	private Seeker seeker;
	private GameObject plano;
	private Path path;
	private int currentWayPoint =0;
	public float speed = 1f;

	private float maxWaypointDistance = 0.2f;

	private bool mouseDown = false;
	private bool previousPathCalculated = true;
	private Vector3 posAnterior = new Vector3(0,0,0);

	public bool enabledMovement = true;

	private Animator animator; //Variavel para controlar os estados da animaçao

	private float count = 0;

	private  bool onClickGUI = false;



	// Use this for initialization
	void Start () {
		seeker = GetComponent<Seeker> ();
		animator = GetComponent<Animator> ();

		plano = GameObject.Find ("InputListener");
	}
	
	// Update is called once per frame
	void Update () {

		// mouse click
		if(mouseDown)
		{
			count += Time.deltaTime;
			if(count >= 0.15f) speed = 3f;
		}

		if(mouseDown && enabledMovement)
		{
			/*if(posAnterior != Input.mousePosition)
			{*/
				RaycastHit hit;
				posAnterior = Input.mousePosition;
				
				Ray ray = Camera.main.ScreenPointToRay(posAnterior);
				
				if (plano.collider.Raycast (ray, out hit, Mathf.Infinity)) {
					Vector3 newPos = new Vector3(hit.point.x, hit.point.y, transform.position.z);

					if(previousPathCalculated && !onClickGUI)
					{
						//print ("start path");
						seeker.StartPath (transform.position, newPos, OnPathComplete);
						previousPathCalculated = false;
					}
				}
			//}
		}

	}

	public void SetOnClickGUI(bool value)
	{
		onClickGUI = value;
	}

	public bool IsMouseDownGUI()
	{
		return onClickGUI;
	}

	public void GetPath()
	{

	}

	void FixedUpdate()
	{
		if (path == null) return;

		if (currentWayPoint >= path.vectorPath.Count)
		{
			/*animator.SetInteger ("walk", 0);*/
			this.GetComponent<IsoSprite>().Walk(false);
			return;
		}

		//animator.SetInteger ("walk",1); 

		Vector3 newPos = new Vector3(path.vectorPath [currentWayPoint].x, path.vectorPath [currentWayPoint].y, transform.position.z);
		Vector3 dif = (newPos - transform.position);

		Vector3 vDif = new Vector3 (dif.x, dif.y, 0f);
		Vector3 dir = Vector3.Normalize (vDif) * speed * Time.fixedDeltaTime;

		//GoToDirection (vDif);

		transform.Translate(dir);

		/*GameObject cam = GameObject.Find ("Main Camera");
		cam.transform.Translate (dir);*/

		if(Vector3.Distance(transform.position,newPos) < maxWaypointDistance)
		{
			currentWayPoint++;
		}

	}

	/*private void GoToDirection(Vector3 dif)
	{
		if(dif.x >= 0.05f)
		{
			if(dif.y >= 0.05f) animator.SetInteger ("angle", 45); 
			else if(dif.y <= -0.05f) animator.SetInteger ("angle", 135);
			else animator.SetInteger ("angle", 90);
		}
		else if(dif.x <= -0.05f)
		{
			if(dif.y >= 0.05f) animator.SetInteger ("angle", 315); 
			else if(dif.y <= -0.05f) animator.SetInteger ("angle", 225); 
			else animator.SetInteger ("angle", 270); 
		}
		else
		{
			if(dif.y >= 0.05f) animator.SetInteger ("angle", 0);  
			else if(dif.y <= -0.05f) animator.SetInteger ("angle", 180); 
		}
	}*/

	private void OnPathComplete(Path p)
	{
		previousPathCalculated = true;
		if (!p.error)
		{
			path = p;
			currentWayPoint = 1;
			this.GetComponent<IsoSprite>().Walk(true);
		}
		else Debug.Log(p.error);
	}

	public void SetMouseEnabled(bool value)
	{
		enabledMovement = value;
	}

	public void SetMouseDown(bool value)
	{
		mouseDown = value;
		if(!value)
		{
			count = 0;
			speed = 1f;
		}
	}
}
