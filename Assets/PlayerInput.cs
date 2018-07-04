using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour 
{
	public SpriteRenderer iconSpriteRenderer;
	public Animator swordLoreAnim;
	
	void Update () 
	{
		
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(ray.origin,ray.direction,out hit,Mathf.Infinity))
		{
			if(hit.collider.name == "Sword")
			{
				iconSpriteRenderer.enabled = true;
				if(Input.GetMouseButton(0))
				{
					//swordLoreRenderer.enabled = true;
					swordLoreAnim.SetBool("IN",true);
				}
				
			}
			else if (hit.collider.name == "Exit")
			{
				Debug.Log("HERE");
				if(Input.GetMouseButton(0))
				{
					swordLoreAnim.SetBool("OUT",true);
					swordLoreAnim.SetBool("IN",false);
				}
			}
			else
			{
				iconSpriteRenderer.enabled = false;
			}			
		}
		else
		{
			iconSpriteRenderer.enabled = false;
		}
		Debug.DrawRay(ray.origin,ray.direction * 500f,Color.red);	
	}
}
