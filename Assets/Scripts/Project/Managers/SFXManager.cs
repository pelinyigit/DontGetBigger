using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    // !!**
    // !!
    // !!
    // CHECK SOUND FX IF THE PROJECT EVER TO BE PUBLISHED --- ROYALTY**!!
    // !!
    // !!
    // !!**

    AudioSource audioSource;

    [SerializeField] AudioClip levelFinishSFX;
    [SerializeField] AudioClip levelFailSFX;
    [SerializeField] AudioClip fireCollisionSFX;
    [SerializeField] AudioClip snowmanCollisionSFX;
    [SerializeField] AudioClip collectibleSFX;
    

    private void OnEnable()
    {
        EventManager.OnLevelFinish.AddListener(PlayLevelFinishSFX);
        EventManager.OnLevelFail.AddListener(PlayLevelFailSFX);
        EventManager.OnFireCollision.AddListener(PlayFireCollisionSFX);
        EventManager.OnSnowmanCollision.AddListener(PlaySnowmanCollisionSFX);
        EventManager.OnCollectibleGathered.AddListener(PlayCollectibleSFX);
    }

    private void OnDisable()
    {
        EventManager.OnLevelFinish.RemoveListener(PlayLevelFinishSFX);
        EventManager.OnLevelFail.RemoveListener(PlayLevelFailSFX);
        EventManager.OnFireCollision.RemoveListener(PlayFireCollisionSFX);
        EventManager.OnSnowmanCollision.RemoveListener(PlaySnowmanCollisionSFX);
        EventManager.OnCollectibleGathered.RemoveListener(PlayCollectibleSFX);
    }

    private void Start()
    {
       audioSource = Camera.main.GetComponent<AudioSource>();
    }

    private void PlayLevelFinishSFX()
    {
       if (!audioSource) { return; }
       audioSource.PlayOneShot(levelFinishSFX);
    }

    private void PlayLevelFailSFX()
    {
        if (!audioSource) { return; }
        audioSource.PlayOneShot(levelFailSFX);
    }
    private void PlayFireCollisionSFX()
    {
        if (!audioSource) { return; }
        audioSource.PlayOneShot(fireCollisionSFX);
    }

    private void PlaySnowmanCollisionSFX()
    {
        if (!audioSource) { return; }
        audioSource.PlayOneShot(snowmanCollisionSFX);
    }

    private void PlayCollectibleSFX(int score)
    {
        if (!audioSource) { return; }
        audioSource.PlayOneShot(collectibleSFX);
    }
}
