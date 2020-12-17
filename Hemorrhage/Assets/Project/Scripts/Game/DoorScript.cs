/**
 * Created DD/MM/YYYY
 * By: Omer Farkhand
 * Last Modified DD/MM/YYYY
 * By: [Insert Name]
 * 
 * Contributors:
 */

using UnityEngine;

/*
 * [Describe the function of the class]
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
