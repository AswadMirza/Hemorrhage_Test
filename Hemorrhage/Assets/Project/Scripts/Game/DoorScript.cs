/**
 * Created DD/MM/YYYY
 * By: Omer Farkhand
 * Last Modified DD/MM/YYYY
 * By: [Insert Name]
 * 
 * Contributors:
 * Omer Farkhand
 */

using UnityEngine;

/*
 * Activates Doors
 */
public class DoorScript : MonoBehaviour
{
    public GameObject Door;

    // OnCollisionEnter detects all collisions on entry
    private void OnCollisionEnter(Collision collision)
    {
        // The Door Closes when the player enters this trigger
        Door.SetActive(true);
    }
}
