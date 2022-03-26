using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    public GameManager gm;
    public Rigidbody rb;

    [SerializeField] float runSpeed = 500f;
    [SerializeField] float strafeSpeed = 500f;
    [SerializeField] float jumpForce = 15f;

    protected bool strafeLeft = false;
    protected bool strafeRight = false;
    protected bool doJump = false;

    void Update()
    {
		if (Input.GetKey("a"))
		{
            strafeLeft = true;
		} else {
            strafeLeft = false;
        }
        if (Input.GetKey("d"))
        {
            strafeRight = true;
        }
        else
        {
            strafeRight = false;
        }
        if (Input.GetKeyDown("space"))
        {
            doJump = true;
        }
		if (transform.position.y < -5f)
		{
            Debug.Log("The End");
            gm.EndGame();
		}
    }

    void FixedUpdate()
    {
        //rb.AddForce(0, 0, runSpeed * Time.deltaTime);
        rb.MovePosition(transform.position + Vector3.forward * runSpeed * Time.deltaTime);

		if (strafeLeft) 
		{
            //rb.AddForce(-strafeSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            rb.MovePosition(transform.position + Vector3.left * strafeSpeed * Time.deltaTime);
        }
        if (strafeRight)
        {
           //rb.AddForce(strafeSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            rb.MovePosition(transform.position + Vector3.right * strafeSpeed * Time.deltaTime);
        }
        if (doJump) 
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            transform.DORewind();
            transform.DOShakeScale(.5f, .5f, 3, 30);
            doJump = false;

        }
    }

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.tag == "Obstacle") {
            Debug.Log("The End");
            gm.EndGame();
        }
	}
}
