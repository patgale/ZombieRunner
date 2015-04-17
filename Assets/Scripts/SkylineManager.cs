using UnityEngine;
using System.Collections.Generic;

public class SkylineManager : MonoBehaviour
{
    public Transform Prefab;
    public int NumberOfObjects;
    public float RecycleOffset;

    public Vector2 SpeedOffset;
    private Vector2 speed;

    public Vector3 StartPosition;
    private Vector3 nextPosition;
    private float tileWidth;

    private List<Transform> objectList;

    void Awake()
    {
        GameEventManager.GameStart += GameStart;
        GameEventManager.GameOver += GameOver;
    }

    void Start()
    {
        tileWidth = (float)Prefab.GetComponent<Renderer>().bounds.size.x;
        speed = GameManager.GetMainScrollingSpeed();        

        objectList = new List<Transform>();
        FillScreen();

        enabled = false;

        GameStart();
    }

    void Update()
    {
        var removeList = new List<Transform>();   
     
        UIManager.TempText = (speed.x + SpeedOffset.x).ToString();
        GameEventManager.OnFloorMovement();

        foreach (var obj in objectList)
        {
            obj.Translate(speed + SpeedOffset);

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
            objectList.Add((Transform)Instantiate(Prefab, nextPosition, Quaternion.identity));
            nextPosition.x += tileWidth;
        }
    }

    void AddObject()
    {
        nextPosition.x = objectList[objectList.Count - 1].localPosition.x + tileWidth;
        objectList.Add((Transform)Instantiate(Prefab, nextPosition, Quaternion.identity));
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