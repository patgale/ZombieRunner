using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour 
{
    public float JumpVelocity;
    private bool isGrounded;
    
    public static float DistanceTraveled;

	void Start () 
	{
        DistanceTraveled = 0.0f;
	}
	
	void Update () 
	{
        //transform.Translate(0.05f, 0.0f, 0.0f);

        if (Input.GetButtonDown("Jump")) // && isGrounded)
        {
            transform.Translate(Vector3.up * JumpVelocity * Time.deltaTime, Space.World);
            //transform.position += transform.up * JumpVelocity * Time.deltaTime;
            //transform.Translate(0.0f, JumpVelocity, 0.0f); //.GetComponent<Rigidbody2D>().AddForce(JumpVelocity, ForceMode2D.Force);
            isGrounded = false;
        }

        DistanceTraveled = (5.0f * Time.deltaTime);
	}

    void FixedUpdate()
    {
    }

    void OnCollision2DEnter()
    {
        isGrounded = true;
    }

    void OnCollision2DExit()
    {
        isGrounded = false;
    }
}