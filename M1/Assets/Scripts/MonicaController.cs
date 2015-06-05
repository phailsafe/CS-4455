using UnityEngine;
using System.Collections;

public class MonicaController : MonoBehaviour 
{

	//public float jumpUpForce = 20000f;
	//public float jumpForwardForce = 10000f;
	public float speedSmoother = 2f;

	//private Rigidbody rb;
	private Animator anim;
	private AnimatorStateInfo currentBaseState;
	private float oldV;
	//static int jumpState = Animator.StringToHash("Base Layer.Jump");
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
		//rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame

	void Update () 
	{
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		/*
		if (Input.GetKey (KeyCode.LeftShift))
		{
			if(oldV == 1)
			{
				oldV = v;
			}
			if (oldV > 0.2f)
			{
				v = Mathf.Lerp(oldV, 0.2f, Time.deltaTime * speedSmoother);
			}
			oldV = v;

		}
		if (Input.GetKeyUp (KeyCode.LeftShift)) 
		{
			oldV = 1;
		}
		*/

		anim.SetFloat ("Speed", v);
		anim.SetFloat ("Direction", h);

		if (Input.GetKey (KeyCode.LeftShift)) 
		{
			if(anim.GetFloat("Speed") > 0.2)
			{
				anim.SetFloat ("Speed", 0.2f);
			}

		}
		currentBaseState = anim.GetCurrentAnimatorStateInfo(0);

		if (Input.GetKeyDown (KeyCode.F)) 
		{
			anim.SetBool ("Punch", true);
			anim.speed = 0.5f;
		} 

		else if (currentBaseState.IsName ("Punch")) 
		{
			if (!anim.IsInTransition(0))
			{
				anim.SetBool("Punch", false);
				anim.speed = 1;
			}
		}


		if (Input.GetButtonDown ("Jump")) 
		{
			anim.SetBool("Jump", true);
			//rb.AddForce(transform.up * jumpUpForce);
		}
		else if (currentBaseState.IsName("Jump"))
		{
			if (!anim.IsInTransition(0))
			{
				anim.SetBool("Jump", false);
			}
		}

	}
}
