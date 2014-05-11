﻿using UnityEngine;
using System.Collections;

public class CollisionAction : MonoBehaviour {
	//Record original scale
	private Vector3 originScale;
	private Vector3 originPos;
	private Vector3 originOri;
	private bool IMBA = false;
	// Use this for initialization
	void Start () {
		originScale = this.transform.localScale;
		originPos = this.transform.position;
		originOri = this.transform.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision col)
	{
	}

	void OnCollisionExit()
	{
	}

	void OnControllerColliderHit(ControllerColliderHit hit)
	{

		if(hit.transform.tag == "Coin")
		{
			hit.transform.GetComponent<ToolBehavior>().delete();
			UI.coinAdd(10);
		}
		else if(hit.transform.tag == "Mushroom")
		{
			//Scale up the characte
			hit.transform.GetComponent<ToolBehavior>().delete();
			this.transform.localScale = this.transform.localScale * (1.0f + 0.5f);
			IMBA = true;
			UI.startRecordTime();
		}
		else if(hit.transform.tag == "Beer")
		{
			GameObject.Find ("MainCamera").GetComponent<UI>().EndOfGame = true;
		}
		/*else if(hit.transform.tag == "Monster")
		{
			if(IMBA)
			{
				//Death
				hit.transform.GetComponent<MonsterBehavior1>().setDeath();	
				hit.transform.GetComponent<MonsterBehavior2>().setDeath();
				hit.transform.GetComponent<MonsterBehavior3>().setDeath();
			}
			else{
				//reset to its original position	
				reset();
			}
		}*/
	}
	
	public void resetScale()
	{
		this.transform.localScale = originScale;
		IMBA = false;
	}

	public bool isIMBA()
	{
		if(IMBA)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public void reset()
	{
		this.transform.position = originPos;
		this.transform.eulerAngles = originOri;
	}
}
