using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OculusGoInput : MonoBehaviour
{
    public LayerMask lm;

    // Update is called once per frame
    void Update ()
    {
        Debug.DrawRay(transform.position, transform.forward, Color.red);
        Ray newRay = new Ray(transform.position, transform.forward);
        OVRInput.Update();

        
        RaycastHit info = new RaycastHit();
        if (Physics.Raycast(newRay, out info, Mathf.Infinity, lm))
        {
            ChangeSceneTarget cst = info.transform.GetComponent<ChangeSceneTarget>();
            if (cst != null)
            {
                Debug.Log(" Hello");
                GetComponent<LineRenderer>().startColor = Color.green;
                GetComponent<LineRenderer>().endColor = Color.green;
                if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
                {
                    GetComponent<LineRenderer>().startColor = Color.red;
                    GetComponent<LineRenderer>().endColor = Color.red;
                    cst.Action();
                }
            }
        }
        else
        {
            GetComponent<LineRenderer>().startColor = Color.white;
            GetComponent<LineRenderer>().endColor = Color.white;
        }
    }
}
