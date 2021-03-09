using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowman : ObstacleBase
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerController>())
        {
            EventManager.OnCharacterScaleUp.Invoke();
            base.Dispose();
        }
    }
}
