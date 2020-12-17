/**
 * Created DD/MM/YYYY
 * By: Aswad Mirza
 * Last Modified DD/MM/YYYY
 * By: [Insert Name]
 * 
 * Contributors: Aswad Mirza
 */

using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * [Main purpose of this class is to load the next scene when the player stays inside of it]
 */
public class Goal : MonoBehaviour
{
    public int SceneIndex = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // OnTriggerStay detects all trigger collisions on duration of collision
    private void OnTriggerStay(Collider other)
    {
        // Condition checks if colliding object has a Player component and is within a specific distance
        if (other.GetComponent<Player>() != null && Vector3.Distance(transform.position, other.transform.position)<3)
        {
            // SceneManager will load the next scene
            SceneManager.LoadScene(SceneIndex);
        }
    }
   
}
