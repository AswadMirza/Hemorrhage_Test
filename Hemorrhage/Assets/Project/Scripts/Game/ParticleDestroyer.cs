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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(DestroyEffect());
        }
    }

    IEnumerator DestroyEffect()
    {
        yield return new WaitForSeconds(2);
        Destroy(particle);
    }
}
