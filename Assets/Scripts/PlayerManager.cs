using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour 
{
    public float JumpVelocity;
    public bool isGrounded;
    
    public static float DistanceTraveled;

	void Start () 
	{
        GameEventManager.GameOver += GameOver;
        DistanceTraveled = 0.0f;
	}

    void GameOver()
    {
        transform.GetComponent<Animator>().enabled = false;
        
        //transform.Rotate(Vector3.back * -90);
    }
	
	void Update () 
	{
        DistanceTraveled += Mathf.Abs(((float)(GameManager.GetMainScrollingSpeed().x * 25) * Time.deltaTime));
        GameEventManager.OnChangeDistance();
	}

    void FixedUpdate()
    {
        if (Input.GetButton("Jump") && isGrounded)
        {
            transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, JumpVelocity));
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.transform.tag == "Ground")
            isGrounded = true;

        if (coll.transform.tag == "KillZone")
            GameEventManager.OnGameOver();
    }

    //void OnCollisionExit2D()
    //{
    //    isGrounded = false;
    //}
}