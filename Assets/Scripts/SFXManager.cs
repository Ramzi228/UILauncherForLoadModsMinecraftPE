using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource Audio;

    public AudioClip Click;

    public static SFXManager sfxInsance;

    private void Awake()
    {
        if(sfxInsance != null && sfxInsance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        sfxInsance = this;
        DontDestroyOnLoad(this);
    }
}
