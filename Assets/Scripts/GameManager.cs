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
	void Start () 
    {
        GameEventManager.GameOver += GameOver;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static Vector2 GetMainScrollingSpeed()
    {
        return Gmanager.MainScrollingSpeed;
    }

    void GameOver()
    {
        MainScrollingSpeed = new Vector2(0.0f, 0.0f);
    }
}
