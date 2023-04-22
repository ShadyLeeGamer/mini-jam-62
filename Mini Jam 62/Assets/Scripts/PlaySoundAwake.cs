using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundAwake : MonoBehaviour
{
    public GameObject SFX;

    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        GameObject SFX_ = Instantiate(SFX, transform.position, Quaternion.identity);
        SFX_.GetComponent<AudioSource>().clip = audioSource.clip;
        SFX_.GetComponent<AudioSource>().Play();

        Destroy(SFX_, audioSource.clip.length);
    }
}
