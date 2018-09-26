using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour {

	public RotationAxis axis = RotationAxis.MouseX;
	public enum RotationAxis
	{
		MouseX = 1,
		MouseY = 2
	}

	public float sensHorizontal = 10.0f;
	public float sensVertical = 10.0f;
	[Space]
	public float minimumVert = -45f;
	public float maximumVert = 45f;


	public float _rotationX = 0;



	
	// Update is called once per frame
	void Update () 
	{	
		/* 
		if(axis == RotationAxis.MouseX)
		{
			transform.Rotate(0,Input.GetAxis("Mouse X") * sensHorizontal,0);
		}
		else if (axis == RotationAxis.MouseY)
		{
			_rotationX -= Input.GetAxis ("Mouse Y") * sensVertical;

			float rotationY = transform.localEulerAngles.y;
			transform.localEulerAngles = new Vector3(_rotationX,rotationY,0);
		}*/
		if(Input.GetMouseButton(1))
		{
			transform.Rotate(0,Input.GetAxis("Mouse X") * sensHorizontal,0);

			_rotationX -= Input.GetAxis ("Mouse Y") * sensVertical;
			_rotationX = Mathf.Clamp(_rotationX,minimumVert,maximumVert);

			float rotationY = transform.localEulerAngles.y;
			transform.localEulerAngles = new Vector3(_rotationX,rotationY,0);
		}
	}
}
