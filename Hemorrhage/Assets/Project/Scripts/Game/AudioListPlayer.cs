/**
 * Created 02/12/2020
 * By: Aswad Mirza
 * Last Modified DD/MM/YYYY
 * By: [Insert Name]
 * 
 * Contributors: Aswad Mirza
 */

using UnityEngine;

/*
 * The class basically takes a public array of audioclips and just plays through each clip one by one until it reaches the
 * end of the audioclips, and then the script deletes itself from the object
 */
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