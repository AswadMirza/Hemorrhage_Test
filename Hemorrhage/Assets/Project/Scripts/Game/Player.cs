/** 
* Last modified 26/10/2020 
* By: Sharek Khan 
*/

using UnityEngine;

public class Player : MonoBehaviour
{
    // Plasma regeneration properties
    private float m_ammoRegenTimer = 0f;
    private int m_ammoRegenTrigger = 3;

    // Fields visible to Unity Inpsector for tuning
    [Header("Visuals")]
    public Camera playerCamera;
    [Header("Gameplay")]
    public int initalHealth = 100;
    public int initalArmour = 0;
    public int initialAmmo = 100;
    public float initialRegenTimer = 5f;
    // Having less ammo then this amount causes the player to slowly restore ammo/plasma
    public int initialRegenTrigger = 3;

    // Player gameplay properties
    private int m_health;
    public int Health { get { return m_health; } set { m_health = value; } }
    private int m_ammo;
    public int Ammo { get { return m_ammo; }  set { m_ammo = value; } }
    private int m_armour;
    public int Armour { get { return m_armour; } set { m_armour = value; } }
    // Player state properties
    private bool m_isKilled;
    public bool IsKilled { get { return m_isKilled; } }
    // Player collision properties
    private bool m_isHurt;
    public bool IsHurt { get { return m_isHurt; } set { m_isHurt = value; } }
    private bool m_isArmourEquipped;
    public bool IsArmourEquipped { get { return m_isArmourEquipped; } set { m_isArmourEquipped = value; } }

    // Start is called before the first frame update
    void Start()
    {
        m_health = initalHealth;
        m_ammo = initialAmmo;
        m_armour = initalArmour;
        m_isKilled = false;
        m_isHurt = false;
        m_isArmourEquipped = false; 
        m_ammoRegenTimer = initialRegenTimer;
        m_ammoRegenTrigger = initialRegenTrigger; 
    }

    // Update is called once per frame
    void Update()
    {
        CheckRegen();
        // Validates Health value from being negative
        if (m_health <= 0)
        {
            m_health = 0;
            // Checks if Player isn't already dead
            if (m_isKilled == false)
            {
                // Officially declares the Player dead
                m_isKilled = true;
                // Performs the procedure that'll happen at death
                OnKill();
            }
        }
        // Validates Ammo value from being negative
        if (m_ammo <= 0) {
            m_ammo = 0;
        }
        // Validates Armour value from being negative
        if (m_armour <= 0)
        {
            m_armour = 0;
        }
    }

    private void CheckRegen() {
        if (m_ammo < m_ammoRegenTrigger)
        {
            m_ammoRegenTimer -= Time.deltaTime;
            if (m_ammoRegenTimer <= 0) {
                m_ammo++;
                m_ammoRegenTimer = initialRegenTimer;
            }
        }
        else
        {
            m_ammoRegenTimer = initialRegenTimer;
        }

    }

    private void OnKill()
    {
        // Disabled due to bricking the game through different GameStates
        // GetComponent<CharacterController>().enabled = false;
        // GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
    }
}
