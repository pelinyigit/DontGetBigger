using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowman : Obstacle
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerController>())
        {
            EventManager.OnSnowmanCollision.Invoke();
            base.Dispose();
        }
    }
}
