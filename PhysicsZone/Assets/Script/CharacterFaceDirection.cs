using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFaceDirection : MonoBehaviour
{
    new protected Rigidbody rigidbody;
    public Vector3 bodyForward = new Vector3(0.0f, 0.0f, 0.0f);
    public Vector3 facingDirection = Vector3.zero;
    public float facingForce = 800;
    public float leadTime = 0.3f;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (leadTime == 0)
        {
            if (facingDirection != Vector3.zero)
            {
                rigidbody.AddForceAtPosition(facingForce * facingDirection * Time.fixedDeltaTime, rigidbody.transform.TransformDirection(bodyForward), ForceMode.Impulse);
                rigidbody.AddForceAtPosition(-facingForce * facingDirection * Time.fixedDeltaTime, rigidbody.transform.TransformDirection(-bodyForward), ForceMode.Impulse);
            }
        }
        else
        {
			Vector3 targetPoint = transform.position + facingDirection * bodyForward.magnitude;
			Vector3 currentPoint = transform.TransformPoint(bodyForward);
			Vector3 reversePoint = transform.TransformPoint(-bodyForward);
			Vector3 velocity = rigidbody.GetPointVelocity(currentPoint);
			Vector3 diff = targetPoint - (currentPoint + velocity * leadTime);

			rigidbody.AddForceAtPosition(facingForce * diff * Time.fixedDeltaTime, currentPoint, ForceMode.Impulse);
			rigidbody.AddForceAtPosition(-facingForce * diff * Time.fixedDeltaTime, reversePoint, ForceMode.Impulse);
        }
    }
}
