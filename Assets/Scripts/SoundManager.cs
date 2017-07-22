using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static SoundManager instance = null;

    public AudioClip goalBloop;
    public AudioClip lossBuzz;
    public AudioClip hitPaddle;
    public AudioClip winSound;
    public AudioClip wallBloop;

    public AudioSource soundEffectAudio;

    // Use this for initialization
    void Start () {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

        AudioSource[] sources =
            GetComponents<AudioSource>();

        foreach(AudioSource source in sources)
        {
            if(source.clip == null)
            {
                soundEffectAudio = source;
            }
        }
	}

    public void PlayOneShot(AudioClip clip)
    {
        soundEffectAudio.PlayOneShot(clip);
    }

}
