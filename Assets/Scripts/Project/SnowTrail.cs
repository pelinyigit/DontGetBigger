using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowTrail : MonoBehaviour
{
    [SerializeField]Transform player;

    private void Update()
    {
        transform.position = new Vector3(player.position.x, 0.1f, player.position.z);
    }
}
