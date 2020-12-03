using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Made by Aswad Mirza - On December 2nd 2020
public class AudioListPlayer : MonoBehaviour
{

    public AudioClip[] clips;
    AudioSource m_audioSource;
    int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        //while (counter < clips.Length) {
        if (counter < clips.Length)
        {
            if (m_audioSource.isPlaying)
            {

            }
            else
            {
                counter++;
                if (counter < clips.Length) {
                    m_audioSource.clip = clips[counter];
                    m_audioSource.Play();
                }
                
            }

        }
        else {
            Destroy(this);
        }
            
        
        
    }
}
