using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour 
{
	void OnEnable()
	{
		Cursor.visible = false;
	}
	void Update () 
	{
		GetComponent<RectTransform>().position = Input.mousePosition - new Vector3(1,1,0);
	}
}
