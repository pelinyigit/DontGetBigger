using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObstacleBase : MonoBehaviour
{
    public virtual void Dispose()
    {
        Destroy(gameObject);
    }
}
