using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Obstacle
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            EventManager.OnFireCollision.Invoke();
            base.Dispose();
        }
    }
}
