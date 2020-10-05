/** 
* Last modified 04/10/2020
* By: Sharek Khan
*/

using UnityEngine;

public class CholesterolCrate : MonoBehaviour
{
    public int crateHealth = 100;
    public GameObject brokenCholestrolCrate;
    public GameObject vitaCapsule;

    private int m_crateHealth;
    private bool m_isBroken;

    // Start is called before the first frame update
    void Start()
    {
        // Initializes the crates starting health
        m_crateHealth = crateHealth;
        m_isBroken = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Checks health of crate to verify if its broken
        if(m_crateHealth <= 0)
        {
            m_isBroken = true;
        }
        // Checks if the crate has been broken
        if(m_isBroken != false)
        {
            // Breaks the crate by subbing in the destroyed model
            Instantiate(brokenCholestrolCrate, transform.position, transform.rotation);
            // Instantiates a VitaCapsule on destruction for Player pickup
            Instantiate(vitaCapsule, new Vector3(transform.position.x, 3, transform.position.z), vitaCapsule.gameObject.transform.rotation);
            // Destroys the base object
            Destroy(gameObject);
        }
    }

    // Checks for any objects colliding with the crate
    void OnCollisionEnter(Collision collision)
    {
        // If crates detects collision with object with Bullet script
        if(collision.gameObject.GetComponent<Bullet>() != null)
        {
            // Reduce crate health
            m_crateHealth -= 25;
        }
    }
}
