using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public GameObject Door;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        Door.SetActive(true);
    }
    /*private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            Door.SetActive(true);
        }
    }*/
}
