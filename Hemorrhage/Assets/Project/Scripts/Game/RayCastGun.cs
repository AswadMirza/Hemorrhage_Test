/** 
* Last modified 02/10/2020
* By: Sharek Khan
*/

using UnityEngine;

//Code is based on Brackeys
public class RayCastGun : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;

    public Camera PlayerCamera;
    // Start is called before the first frame update
    void Start()
    {

       
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            // Shoot();
        }
    }
}
