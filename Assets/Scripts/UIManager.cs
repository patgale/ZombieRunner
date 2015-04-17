using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour 
{
    public Text TestText;
    public static string TempText;

	// Use this for initialization
	void Start () 
    {
        GameEventManager.FloorMovement += FloorMovement;    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void FloorMovement()
    {
        TestText.text = TempText;
    }
}
