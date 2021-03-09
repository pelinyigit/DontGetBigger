using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : ObstacleBase
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            EventManager.OnCharacterScaleDown.Invoke();
            base.Dispose();
        }
    }
}
