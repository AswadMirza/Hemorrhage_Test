/** 
* Last modified 26/10/2020
* By: Sharek Khan
*/

using UnityEngine;

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

    void OnTriggerExit(Collider collider)
    {
        // Deletes object one it's outside of Players proximity
        if(collider.gameObject.tag == "AIDetection")
        {
            Debug.Log("CholesterolCrate(Broken) Destroyed.");
            Destroy(this.gameObject);
        }
    }
}
