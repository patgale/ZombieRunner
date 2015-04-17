using UnityEngine;
using System.Collections.Generic;

public class FloorManager : MonoBehaviour 
{
	public Transform FloorPrefab;
	public int NumberOfObjects;
	public float RecycleOffset;

    public Vector3 Speed;
	
	private float tileWidth;

	public Vector3 StartPosition;	
	private Vector3 nextPosition;
	
    private List<Transform> objectList;

    void Awake()
    {
        GameEventManager.GameStart += GameStart;
        GameEventManager.GameOver += GameOver;
    }

	void Start() 
	{
		tileWidth = (float)FloorPrefab.GetComponent<Renderer>().bounds.size.x;

        objectList = new List<Transform>();
        FillScreen();
	
		enabled = false;

        GameStart();
	}

	void Update () 
	{
        var removeList = new List<Transform>();

        foreach (var obj in objectList)
        {
            obj.Translate(Speed);

            if (obj.localPosition.x < RecycleOffset)
            {
                removeList.Add(obj);
            }
        }

        for (var i = 0; i < removeList.Count; i++)
        {
            AddObject();
        }

        foreach (var obj in removeList)
        {
            objectList.Remove(obj);
            Destroy(obj.gameObject);
        }
	}

    private void FillScreen()
    {
        nextPosition = StartPosition;

        for (var i = 0; i < NumberOfObjects; i++)
        {
            objectList.Add((Transform)Instantiate(FloorPrefab, nextPosition, Quaternion.identity));
            nextPosition.x += tileWidth;
        }
    }

    void AddObject()
    {
        nextPosition.x = objectList[objectList.Count - 1].localPosition.x + tileWidth;

        objectList.Add((Transform)Instantiate(FloorPrefab, nextPosition, Quaternion.identity));
    }
	
	void GameStart()
	{
		enabled = true;
	}

    void GameOver()
    {
        enabled = false;
    }
}