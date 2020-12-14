/*
 * Written By: Omer Farkhand
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Music : MonoBehaviour
{
    //Fields
    public GameObject backgroundMusic;
    public AudioSource source;
    
    // When the player enters this trigger the background music starts playing
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            backgroundMusic.SetActive(true);
            source.Play();
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
