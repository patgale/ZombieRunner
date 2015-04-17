using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
	public GameObject TargetObject;
	private float distanceToTarget;
	
	void Start()
	{
		distanceToTarget = transform.position.x - TargetObject.transform.position.x;
	}
	
	void Update()
	{
		var targetObjectX = TargetObject.transform.position.x;
		
		var newCameraPosition = transform.position;
		newCameraPosition.x = targetObjectX + distanceToTarget;
		transform.position = newCameraPosition;
	}
}