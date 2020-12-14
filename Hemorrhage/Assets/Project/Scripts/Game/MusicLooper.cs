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

    // Update is called once per frame
    void Update()
    {
        //checks if background music is not false, then checks whether the intro of the song is playing, if not switches the clip to loop
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
        //Plays the End of the Song 
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
