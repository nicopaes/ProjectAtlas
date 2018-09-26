using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTarget : MonoBehaviour, ITarget
{
	[SerializeField]
	private bool _gazedAt = false;

	[SerializeField]
	private bool _executedAction = false;
	public bool GazedAt
	{
		get
		{
			return this._gazedAt;
		}
		set
		{
			this._gazedAt = value;
		}
	}
	public bool ExecutedAction
	{
		get
		{
			return this._executedAction;
		}
		set
		{
			this._executedAction = value;
		}
	}

	public void SetGazedAt(bool gazedAt)
	{
		_gazedAt = gazedAt;
	}
	
	public void GazedAtAction(bool gazedAt)
	{
		if(gazedAt && !ExecutedAction)  GetComponent<MeshRenderer>().material.color = Color.red;
		else if (!ExecutedAction) GetComponent<MeshRenderer>().material.color = Color.white;
	}
    public void Action()
    {
		if(!ExecutedAction)	
		{
			ExecutedAction = true;
			GetComponent<MeshRenderer>().material.color = Color.green;
		}
		else if(ExecutedAction)
		{
			ExecutedAction = false;
			GetComponent<MeshRenderer>().material.color = Color.white;
		}
    }
	void Update()
	{		
		GazedAtAction(_gazedAt);
	}
}
