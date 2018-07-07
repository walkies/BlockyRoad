using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Audio")]
public class ScriptableAudio : ScriptableObject
{
    public new string name;
    public AudioClip Clip;
    public float Pitch;
    public float Volume;
    private AudioSource Source;
    

    public void SetSource(AudioSource Source2)
    {
        Source = Source2;
        Source.clip = Clip;
    }

    public void Play()
    {
        Source.Play();
    }
}
/*
 * Scriptable objects created as New Audio
 * Contains variables for audioclips
 * Set source of Audio
 * Play function 
 */
