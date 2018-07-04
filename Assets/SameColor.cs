using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SameColor : MonoBehaviour {

	public SpriteRenderer IconSpriteRenderer;
	
	// Update is called once per frame
	void Update () 
	{
		GetComponent<TextMesh>().color = IconSpriteRenderer.color;
		GetComponent<MeshRenderer>().enabled = IconSpriteRenderer.enabled;
	}
}
