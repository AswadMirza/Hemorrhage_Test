/** 
* Last modified 18/11/2020
* By: Sharek Khan
*/

using UnityEngine;

public class Destructible : MonoBehaviour
{
    private AudioSource m_audioSource;

    // Start is called before the first frame update
    void Start()
    {
        if(this.gameObject.name == "CholesterolCrate(Broken)")
        {
            m_audioSource = GameObject.Find("CholesterolCrate").GetComponent<AudioSource>();
        }
        else if(this.gameObject.name == "Myoviridae(Killed)")
        {
            m_audioSource = GameObject.Find("Myoviridae").GetComponent<AudioSource>();
        }
        //if(!m_audioSource.isPlaying)
        //{
            // m_audioSource.Play();
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit(Collider collider)
    {
        // Deletes object one it's outside of Players proximity
        if (collider.gameObject.tag == "AIDetection")
        {
            Debug.Log(this.gameObject.name + " Destroyed.");
            Destroy(this.gameObject);
        }
    }
}
