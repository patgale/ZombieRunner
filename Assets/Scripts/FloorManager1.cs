using UnityEngine;
using System.Collections.Generic;

public class FloorManager1 : MonoBehaviour 
{

	public Transform FloorPrefab;
	public int NumberOfObjects;
	public float RecycleOffset;
	
    //public Vector3 minSize, maxSize, minGap, maxGap;
    //public float minY, maxY;
	
	private float tileWidth;
	
    //public Material[] Materials;
    //public PhysicMaterial[] PhysicsMaterials;
	
	public Vector3 StartPosition;	
	private Vector3 nextPosition;
	
	private Queue<Transform> objectQueue;
	
	void Start() 
	{
		//GameEventManager.GameStart += GameStart;
		//GameEventManager.GameOver += GameOver;
		
		tileWidth = (float)FloorPrefab.GetComponent<Renderer>().bounds.size.x;
		
		objectQueue = new Queue<Transform>(NumberOfObjects);
		for (var i = 0; i < NumberOfObjects; i++)
		{
			objectQueue.Enqueue((Transform)Instantiate(FloorPrefab, new Vector3(0.0f, 0.0f, -100.0f), Quaternion.identity));
		}		
		enabled = false;
		
		GameStart();
	}
	
	void Update () 
	{
        if (objectQueue.Peek().localPosition.x + RecycleOffset < PlayerManager.DistanceTraveled)
        {
            Recycle();
        }
	}
	
	void GameStart()
	{
		nextPosition = StartPosition;		
		
		for (var i = 0; i < NumberOfObjects; i++)
		{
			Recycle();
		}
		enabled = true;
	}
	
	void Recycle()
	{
		//var scale = new Vector3(1, 1, 1);//Random.Range(minSize.x, maxSize.x),
		                        //Random.Range(minSize.y, maxSize.y),
		                        //Random.Range(minSize.z, maxSize.z));
		
		var position = nextPosition;
		position.x += tileWidth * 0.5f; // scale.x * 0.5f;
        position.y += StartPosition.y; // *0.5f;
		//booster.SpawnIfAvailable(position);
		
		var o = objectQueue.Dequeue();
		//o.localScale = scale;
		o.localPosition = position;
		
		//var materialIndex = Random.Range (0, Materials.Length);
		//o.GetComponent<Renderer>().material = Materials[materialIndex];
		//o.GetComponent<BoxCollider>().material = PhysicsMaterials[materialIndex];
		
		nextPosition.x += tileWidth; // scale.x;
		objectQueue.Enqueue (o);
		
		//nextPosition += new Vector3(Random.Range(minGap.x, maxGap.x) + tileWidth, //scale.x,
		//                            Random.Range(minGap.y, maxGap.y),
		//                            Random.Range(minGap.z, maxGap.z));
		
        //if (nextPosition.y < minY)
        //{
        //    nextPosition.y = minY + maxGap.y;
        //}
        //else if (nextPosition.y > maxY)
        //{
        //    nextPosition.y = maxY - maxGap.y;
        //}
	}
}