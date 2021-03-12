using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int score;

    private void Start()
    {
        score = 1;
    }

    public void Dispose()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Dispose();
        EventManager.OnCollectibleGathered?.Invoke(score);
    }
}
