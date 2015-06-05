using UnityEngine;
using System.Collections;

public class CameraControls : MonoBehaviour 
{
	public float smoothness = 3f;  //smoothness variable
	Transform standardPos;

	// initialize things
	void Start () 
	{
		standardPos = GameObject.Find ("CamPos").transform;

	}
	
	// update camera position
	void FixedUpdate () 
	{
		transform.position = Vector3.Lerp (transform.position, standardPos.position, Time.deltaTime * smoothness);
		transform.forward = Vector3.Lerp (transform.forward, standardPos.forward, Time.deltaTime * smoothness);
	}
}
