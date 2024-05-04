using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    public static soundManager instance { get; private set; } // singleton
    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        instance = this;
    }

    public void PlaySound(AudioClip __sound)
    {
        source.PlayOneShot(__sound); // Play audio clip once
    }
}
