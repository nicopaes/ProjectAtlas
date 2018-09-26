using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTarget : MonoBehaviour, ITarget
{
	public SpriteRenderer TextImage;
	private bool _executedAction = false;

    public bool GazedAt
    {
        get
        {
            throw new System.NotImplementedException();
        }

        set
        {
            throw new System.NotImplementedException();
        }
    }

    public bool ExecutedAction 
	{ 
		get 
		{
			return _executedAction;
	 	}
	  	set
	  	{
			this._executedAction = value;
		}
	}

    public void Action()
	{
		if(!ExecutedAction)	
		{
			TextImage.enabled = true;
			ExecutedAction = true;
		}
		else if(ExecutedAction)
		{
			TextImage.enabled = false;
			ExecutedAction = false;
		}
		
	}

    public void GazedAtAction(bool gazedAt)
    {
        throw new System.NotImplementedException();
    }

    public void SetGazedAt(bool newGazed)
    {
        throw new System.NotImplementedException();
    }
}
