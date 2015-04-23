using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour 
{
    public Text DistanceText;
    public static string TempText;

	// Use this for initialization
	void Start () 
    {
        GameEventManager.FloorMovement += FloorMovement;
        GameEventManager.ChangeDistance += ChangeDistance;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void ChangeDistance()
    {
        DistanceText.text = string.Format("Distance: {0}m", PlayerManager.DistanceTraveled.ToString("f0"));
    }

    private void FloorMovement()
    {
        
    }
}
