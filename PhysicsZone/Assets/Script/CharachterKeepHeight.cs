using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharachterKeepHeight : MonoBehaviour
{

    new protected Rigidbody rigidbody;
    public float desiredHeight = 1.0f;
    public float pullUpForce = 10.0f;
    public float leadTime = 0.3f;
    public Transform inRelationTo = null;
    protected float groundHeight = 0;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		RaycastHit groundHit;
		if(Physics.Raycast(new Ray(transform.position, Vector3.down), out groundHit, 100, 1 << LayerMask.NameToLayer("Ground")))
		{
			groundHeight = groundHit.point.y;
		}
		float diff = (groundHeight + desiredHeight) - (transform.position.y + rigidbody.velocity.y * leadTime);
		if(inRelationTo != null)
		{
			diff = inRelationTo.TransformPoint(Vector3.up * desiredHeight).y - (transform.position.y + rigidbody.velocity.y * leadTime);
		}
		float dist = Mathf.Abs(diff);
		float pullM = Mathf.Clamp01(dist/ 0.3f);
		rigidbody.AddForce(new Vector3(0, Mathf.Sign(diff) * pullUpForce * pullM * Time.fixedDeltaTime, 0), ForceMode.Impulse);
    }
}
