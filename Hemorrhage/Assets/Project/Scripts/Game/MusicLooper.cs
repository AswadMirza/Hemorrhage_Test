/*
 * Created By:
 * Omer Farkhand
 * Last modified: 12/12/2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLooper : MonoBehaviour
{
    public AudioClip[] audioClips;

    public GameObject backgroundMusic;
    public AudioSource introAudioSource;
    public AudioSource loopAudioSource;
    public AudioSource endAudioSource;

    // Start is called before the first frame update
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        if(backgroundMusic.activeInHierarchy != false)
        {
            if (!introAudioSource.isPlaying)
            {
                introAudioSource.Stop();
                introAudioSource.clip = loopAudioSource.clip;
                introAudioSource.loop = true;
                introAudioSource.Play();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "MusicEnd")
        {
            introAudioSource.Stop();
            introAudioSource.loop = false;
            introAudioSource.clip = endAudioSource.clip;
            introAudioSource.Play();
            Destroy(GameObject.FindGameObjectWithTag("MusicEnd"));
        }
    }
}
