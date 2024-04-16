using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


[Serializable]
public class Sounds
{
    public string name;

    public AudioClip clip;

    [Range(0, 1)]
    public float volume = 1;

    [Range (0.3f, 3.5f)]
    public float pitch = 1;

    public bool loop;

    [HideInInspector] public AudioSource source;
}
