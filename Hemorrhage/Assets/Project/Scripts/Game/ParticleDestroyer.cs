/*
 * Created By: Omer Farkhand
 */

using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ParticleDestroyer : MonoBehaviour
{
    GameObject particle;

    // Start is called before the first frame update
    void Start()
    {
        particle = GameObject.Find("Respawn(Clone)");
        
    }

    /*
     * When the player enters this trigger, this code starts a timer then destroys the particle effect
     */
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(DestroyEffect());
        }
    }

    /*
     * Timer to Destroy the particle effect
     */
    IEnumerator DestroyEffect()
    {
        yield return new WaitForSeconds(2);
        Destroy(particle);
    }
}
