using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour 
{
    public static float DistanceTraveled;

	void Start () 
	{
        DistanceTraveled = 0.0f;
	}
	
	void Update () 
	{
	
	}

    void FixedUpdate()
    {
        //transform.Translate(5.0f * Time.deltaTime, 0.0f, 0.0f);

        DistanceTraveled = (5.0f * Time.deltaTime); // transform.localPosition.x;
    }

    void OnCollisionEnter()
    {
        
    }

    void OnCollisionExit()
    {

    }
}