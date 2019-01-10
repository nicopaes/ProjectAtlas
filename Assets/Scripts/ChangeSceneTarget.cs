using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSceneTarget : MonoBehaviour, ITarget
{

    public FadeChangeScene FadeScript;
    [Header("NEW SCENE NAME")]
    public string nextSceneName;
    [Space]
    public TextMesh textMesh;
    public Image RadialVisual;

    //public Material newSkybox;
    //public GameObject nextPortal;
    //public ParticleSystem portalParticleSystem;

    //public List<GameObject> ObjectsToTurnOnOff =  new List<GameObject>();
    [Header("PRIVATE")]
    [SerializeField]
    private float _chargeActionCounter;
    private bool _gazedAt = false;
    private bool _executedAction = false;

    public void OnEnable()
    {
        if (textMesh != null) textMesh.text = nextSceneName;
        RadialVisual = GameObject.Find("RadialVisual").GetComponent<Image>();
    }
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
        if (GazedAt)
        {
            _chargeActionCounter += 0.3f;
            Mathf.Clamp(_chargeActionCounter, 0, 100);
            RadialVisual.fillAmount = Mathf.Clamp(_chargeActionCounter/100,0,1);
            if (_chargeActionCounter >= 100 && !ExecutedAction)
            {
                Action();
                RadialVisual.fillAmount = 0;
            }
        }

        else if (!GazedAt)
        {
            _chargeActionCounter = 0;
        }


        // ParticleSystem.EmissionModule e = portalParticleSystem.emission;
        // e.rateOverTime = _chargeActionCounter;
    }

    public void SetGazedAt(bool newGazed)
    {
        _gazedAt = newGazed;
        if(!newGazed)
        {
            RadialVisual.fillAmount = 0;
        }
    }

    public void GazedAtAction(bool gazedAt)
    {

    }

    public void Action()
    {
        _chargeActionCounter = 0;
        GazedAt = false;

        FadeScript.ChangeNextScene(nextSceneName);

        /*
        if(RenderSettings.skybox != newSkybox)
        {        
        	RenderSettings.skybox = newSkybox;
            ExecutedAction = true;
            nextPortal.SetActive(true);    

           
            this.gameObject.SetActive(false);
        }
        */
    }
    // IEnumerator NoClickAction(float delaySeconds)
    // {   
    //     yield return new WaitForSeconds(delaySeconds);
    //     Action();
    // }
}
