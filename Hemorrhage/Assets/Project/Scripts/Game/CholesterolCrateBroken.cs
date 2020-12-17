/**
 * Created DD/MM/YYYY
 * By: Sharek Khan
 * Last Modified 26/10/2020
 * By: Sharek Khan
 *
 * Contributors: 
 */

using UnityEngine;

/*
 * [Describe the function of the class]
 */
public class CholesterolCrateBroken : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // OnTriggerExit detects all trigger collisions on exit
    void OnTriggerExit(Collider collider)
    {
        // Condition checks if the colliding object has a AIDetection tag
        if(collider.gameObject.tag == "AIDetection")
        {
            // Deletes object one it's outside of Players proximity
            Debug.Log("CholesterolCrate(Broken) Destroyed.");
            Destroy(this.gameObject);
        }
    }
}
