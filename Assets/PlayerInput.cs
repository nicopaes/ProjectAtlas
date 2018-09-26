using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour 
{

	
	private bool AlphaisRuning;

	public Text RaycastDebugText;

	[SerializeField]
	private ITarget Target;

	
	void Update () 
	{
		Debug.Log(Target);
		Ray ray = new Ray(transform.position,transform.forward);  //Camera.main.ScreenPointToRay(Input.mousePosition); // IF PC
		RaycastHit hit;
		//Debug.DrawRay(transform.position,transform.forward,Color.green,0.01f);
		if(Physics.Raycast(ray.origin,ray.direction,out hit,Mathf.Infinity))
		{
			RaycastDebugText.text = "RAYCAST: TRUE";
			if(hit.collider.GetComponent<ITarget>() != null)
			{
				Target = hit.collider.GetComponent<ITarget>();
				if(Target.GazedAt == false) Target.SetGazedAt(true);
				if(Input.touchCount > 0)
				{
					Target.Action();
				}
				#if UNITY_EDITOR
				if(Input.GetMouseButtonDown(0))
				{
					Debug.Log("Oh hi there");
					Target.Action();
				}
				#endif // UNITY EDITOR
			}
		}
		else 
		{
			if(Target != null) 
			{
				Target.SetGazedAt(false);
			}
			RaycastDebugText.text = "RAYCAST: FALSE";
		}
		Debug.DrawRay(ray.origin,ray.direction * 500f,Color.red);	
	}
	/*
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
				WAlpha.a -= 0.008f;
				Debug.Log("A:" + WAlpha.a);
			}
		}
		AlphaisRuning = false;		
		Camera360.GetComponent<FPSCamera>().enabled = true;
	}*/
}
