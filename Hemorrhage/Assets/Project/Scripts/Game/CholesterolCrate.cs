/** 
* Last modified 14/10/2020
* By: Sharek Khan
*/
using UnityEngine;

public class CholesterolCrate : MonoBehaviour
{
    // Broken Cholesterol Crate Model
    public GameObject brokenCholestrolCrate;
    // VitaCapsule GameObject
    public GameObject vitaCapsule;
    // CholesterolCrate base health
    public int crateHealth = 100;
    // CholesterolCrate chance to generate a VitaCapsule
    public int rngChance = 25;

    private int m_crateHealth;
    private int m_rngChance;
    private bool m_isBroken;

    // Start is called before the first frame update
    void Start()
    {
        // Initializes the crates starting health
        m_crateHealth = crateHealth;
        // Initializes the crates chance to generate a VitaCapsule
        m_rngChance = rngChance;
        // Initializes the crates dexterity status
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
            // Checks if a random number generated is in bounds of RNG Chance
            if(RNG(1, 100) <= m_rngChance)
            {
                // Instantiates a VitaCapsule on destruction for Player pickup
                Instantiate(vitaCapsule, new Vector3(transform.position.x, transform.position.y +1, transform.position.z), vitaCapsule.gameObject.transform.rotation);
            }
            // Destroys the base object
            Destroy(gameObject);
        }
    }

    int RNG(int _minValue, int _maxValue)
    {
        System.Random rng = new System.Random();
        return rng.Next(_minValue, _maxValue);
    }

    // Checks for any trigger collisions the CholesterolCrate is colliding with
    private void OnTriggerEnter(Collider _other)
    {
        if (_other.gameObject.GetComponent<Bullet>() != null) {
            m_crateHealth -= 25;
        }
    }
}
