using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float playerPosZ = 100f;

    public float PlayerPosZ {get { return playerPosZ; } }

    private void Awake()
    {
        playerPosZ = 200f;
    }

}
