using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public Transform cameraTransform;
    public Vector3 cameraOffset;
    public float speed = 50f;

    private Rigidbody rb;
    private Vector3 controlDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cameraOffset = cameraTransform.position - transform.position;
    }
    
    void Update()
    {
        cameraTransform.position = transform.position + cameraOffset;
        controlDirection = cameraTransform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
    }

	private void FixedUpdate()
	{
        rb.AddForce(controlDirection * speed * Time.deltaTime, ForceMode.VelocityChange);
	}
}
