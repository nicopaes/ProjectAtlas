using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour 
{
	[Header("360 Scene")]
	public SpriteRenderer iconSpriteRenderer;
	public Animator swordLoreAnim;
	public Camera Camera360;

	[Header("GalaxyMap")]
	public List<SpriteRenderer> MapSprites;

	[SerializeField]
	private bool AlphaisRuning;


	
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
				if(Input.GetMouseButton(0))
				{
					swordLoreAnim.SetBool("OUT",true);
					swordLoreAnim.SetBool("IN",false);
				}
			}
			else if (hit.collider.name == "Select")
			{
				if(Input.GetMouseButton(0))
				{
					if(!AlphaisRuning)
					{
						StartCoroutine(ApalhaDecrease());
					}
					Camera360.GetComponent<Animator>().enabled = false;
					
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
	private IEnumerator ApalhaDecrease()
	{
		Color WAlpha = Color.white;
		while(WAlpha.a >= 0)
		{
			AlphaisRuning = true;
			yield return new WaitForSeconds(0.008f);						
			{
				foreach(SpriteRenderer srend in MapSprites)
				{
					srend.color = WAlpha;
				}
				WAlpha.a -= 0.002f;
				Debug.Log("A:" + WAlpha.a);
			}
		}
		AlphaisRuning = false;		
		Camera360.GetComponent<FPSCamera>().enabled = true;
	}
}
