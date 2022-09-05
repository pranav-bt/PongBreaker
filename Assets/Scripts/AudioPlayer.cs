using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public void PlaySound(AudioClip AudioToPlay)
    {
        GetComponent<AudioSource>().clip = AudioToPlay;
        GetComponent<AudioSource>().Play();
    }
}
