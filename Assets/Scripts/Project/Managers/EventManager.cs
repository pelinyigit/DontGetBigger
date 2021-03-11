using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager 
{
    #region Game States
    public static UnityEvent OnGameStart = new UnityEvent();
    public static UnityEvent OnGameOver = new UnityEvent();
    #endregion

    #region Levels
    public static UnityEvent OnLevelStart = new UnityEvent();
    public static UnityEvent OnLevelFinish = new UnityEvent();
    public static UnityEvent OnLevelFail = new UnityEvent();
    #endregion

    #region Character
    public static UnityEvent OnSnowmanCollision = new UnityEvent();
    public static UnityEvent OnFireCollision = new UnityEvent();
    #endregion

    #region Player Events
    public static UnityEvent OnPlayerStartMovement = new UnityEvent();
    public static UnityEvent OnPlayerScaleUp = new UnityEvent();
    public static UnityEvent OnPlayerScaleDown = new UnityEvent();
    #endregion

    
}
