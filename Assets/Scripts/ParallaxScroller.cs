using UnityEngine;
using System.Collections;

public class ParallaxScroller : MonoBehaviour 
{
    public static Vector2 Speed;

	void Start () 
    {
	
	}
	
	void Update () 
    {
        var movement = new Vector3(-Speed.x, Speed.y, 0);
        movement *= Time.deltaTime;
        transform.Translate(movement);
	}
}
