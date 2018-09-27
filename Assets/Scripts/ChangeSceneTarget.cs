using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneTarget : MonoBehaviour, ITarget {

	public Material newSkybox;
    public GameObject nextPortal;
    public ParticleSystem portalParticleSystem;
    [SerializeField]
    private float _chargeActionCounter;
    private bool _gazedAt = false;
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

    void Update()
    {
        if(GazedAt)
        {
            _chargeActionCounter += 0.3f;
            Mathf.Clamp(_chargeActionCounter,0,100);
            if(_chargeActionCounter >= 100 && !ExecutedAction) 
            {
                Action();
            }
        }
            
        else if(!GazedAt)
        {
            _chargeActionCounter = 0;
        }           

        
        ParticleSystem.EmissionModule e = portalParticleSystem.emission;
        e.rateOverTime = _chargeActionCounter;
    }

    public void SetGazedAt(bool newGazed)
	{
        _gazedAt = newGazed;
	}

    public void GazedAtAction(bool gazedAt)
	{
        
	}
    
    public void Action()
	{
        if(RenderSettings.skybox != newSkybox)
        {        
        	RenderSettings.skybox = newSkybox;
            ExecutedAction = true;
            nextPortal.SetActive(true);   

            portalParticleSystem.Stop();            
            _chargeActionCounter = 0;
            ParticleSystem.EmissionModule e = portalParticleSystem.emission;            
            e.rateOverTime = _chargeActionCounter;
            GazedAt = false;
            this.gameObject.SetActive(false);
        }
	}

    // IEnumerator NoClickAction(float delaySeconds)
    // {   
    //     yield return new WaitForSeconds(delaySeconds);
    //     Action();
    // }
}
