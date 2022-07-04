using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource soundtrack, shoot;
    public void PlaySoundtrack()
    {
        soundtrack.Play();
    }

    public void StopSoundtrack()
    {
        soundtrack.Stop();
    }

    public void PlayShoot()
    {
        shoot.Play();
    }
}
