/*
 * Created By: 
 * Omer Farkhand
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLevel : MonoBehaviour
{
    public GameObject door;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            door.SetActive(true);
            GameObject.Find("Tail").GetComponent<StreptobacillusMoniliformisBody>().enabled = true;
            GameObject.Find("Body4").GetComponent<StreptobacillusMoniliformisBody>().enabled = true;
            GameObject.Find("Body3").GetComponent<StreptobacillusMoniliformisBody>().enabled = true;
            GameObject.Find("Body2").GetComponent<StreptobacillusMoniliformisBody>().enabled = true;
            GameObject.Find("Body").GetComponent<StreptobacillusMoniliformisBody>().enabled = true;
            GameObject.Find("Head").GetComponent<StreptobacillusMoniliformisHead>().enabled = true;
        }
    }
}
