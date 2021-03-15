﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    public virtual void Dispose()
    {
        Destroy(gameObject);
    }
}
