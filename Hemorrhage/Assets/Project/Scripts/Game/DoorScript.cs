using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public GameObject Door;
    private void OnCollisionEnter(Collision collision)
    {
        Door.SetActive(true);
    }
}
