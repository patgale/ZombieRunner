using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{

    public Vector2 MainScrollingSpeed;
    public static GameManager Gmanager;

    void Awake ()
    {
        Gmanager = this;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static Vector2 GetMainScrollingSpeed()
    {
        return Gmanager.MainScrollingSpeed;
    }
}
