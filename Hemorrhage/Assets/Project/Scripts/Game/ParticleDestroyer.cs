/**
 * Created DD/MM/YYYY
 * By: Omer Farkhand
 * Last Modified DD/MM/YYYY
 * By: [Insert Name]
 * 
 * Contributors:
 */

using System.Collections;
using UnityEngine;

/*
 * [Describe the function of the class]
 */
public class ParticleDestroyer : MonoBehaviour
{
    GameObject particle;

    // Start is called before the first frame update
    void Start()
    {
        particle = GameObject.Find("Respawn(Clone)");
        
    }

    // OnTriggerEnter detects all trigger collisions on entry
    private void OnTriggerEnter(Collider other)
    {
        // Condition checks if the colliding object has a Player tag
        if (other.gameObject.tag == "Player")
        {
            // Starts a timer then destroys the particle effect
            StartCoroutine(DestroyEffect());
        }
    }

    // DestroyEffect has a timer to destroy the particle effect
    IEnumerator DestroyEffect()
    {
        yield return new WaitForSeconds(2);
        Destroy(particle);
    }
}