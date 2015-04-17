using UnityEngine;
using System;
using System.Collections;

public class GameEventManager 
{
	public delegate void GameEvent();
	public static event GameEvent GameStart, GameOver, ChangeDistance, FloorMovement;
	
	public static void OnGameStart()
	{
		if (GameStart != null)
		{
			GameStart();
		}
	}
	
	public static void OnGameOver()
	{
		if (GameOver != null)
		{
			GameOver();
		}
	}
	
	public static void OnChangeDistance()
	{
		if (ChangeDistance != null)
		{
			ChangeDistance();
		}
	}

    public static void OnFloorMovement()
    {
        if (FloorMovement != null)
        {
            FloorMovement();
        }
    }
	
	
	public event EventHandler<BoostEventArgs> BoostChanged;
	public void OnBoostChanged(object sender, int boostNumber, bool active)
	{
		if (BoostChanged != null)
		{
			BoostChanged(sender, new BoostEventArgs() { BoostNumber = 0, IsActive = active});
		}
	}
}