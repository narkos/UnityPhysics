using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUpright : MonoBehaviour
{

    protected Rigidbody rigidbody;
    public bool keepUp = true;
    public float upforce = 10.0f;
    public float upOffset = 1.45f;
    public float additionalUpForce = 10.0f;
    public float dampenAngularForce = 0.0f;


    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.maxAngularVelocity = 40.0f;
    }

    // Update is called once per frame
    void Update()
    {
		if(keepUp)
		{
			rigidbody.AddForceAtPosition(new Vector3(0, (upforce + additionalUpForce), 0),
				transform.position + transform.TransformPoint(new Vector3(0, upOffset, 0)), ForceMode.Force);

			rigidbody.AddForceAtPosition(new Vector3(0, -upforce, 0),
				transform.position + transform.TransformPoint(new Vector3(0, -upOffset, 0)), ForceMode.Force);
		
		}
		if (dampenAngularForce > 0)
		{
			rigidbody.angularVelocity *= (1 - Time.fixedDeltaTime * dampenAngularForce);
		}
    }
}
