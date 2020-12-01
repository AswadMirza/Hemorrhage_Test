using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Music : MonoBehaviour
{
    public AudioSource source;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            source.Play();
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
