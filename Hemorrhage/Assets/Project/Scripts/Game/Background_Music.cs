using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Music : MonoBehaviour
{
    public GameObject backgroundMusic;
    public AudioSource source;
    // Start is called before the first frame update

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
