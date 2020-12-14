/*
 * Created By: Omer Farkhand
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public GameObject Door;

    /*
     * The Door Closes when the player enters this trigger
     */
    private void OnCollisionEnter(Collision collision)
    {
        Door.SetActive(true);
    }
}
