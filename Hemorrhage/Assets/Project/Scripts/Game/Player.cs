/** 
* Last modified 04/10/2020 
* By: Aswad Mirza 
*/

using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Fields visible to Unity Inpsector for tuning
    [Header("Visuals")]
    public Camera playerCamera;
    [Header("Gameplay")]
    public int initalHealth = 100;
    public int initalArmour = 0;
    public int initialAmmo = 100;
    public float knockbackForce = 10f;
    public float hurtDuration = 0.5f;
    public float initialRegenTimer = 5f;
    // having less ammo then this amount causes the player to slowly restore ammo/plasma
    public int initialRegenTrigger = 3;
    // Player gameplay properties
    private int m_health;
    public int Health { get { return m_health; } set { m_health = value; } }
    private int m_ammo;
    public int Ammo { get { return m_ammo; }  set { m_ammo = value; } }
    private int m_armour;
    public int Armour { get { return m_armour; } set { m_armour = value; } }

    // Player state properties
    private bool m_killed;
    public bool Killed { get { return m_killed; } }

    private bool m_isHurt;
    private bool m_isArmourEquipped;

    private float m_ammoRegenTimer = 0f;
    private int m_ammoRegenTrigger = 3;


    // Start is called before the first frame update
    void Start()
    {
        m_health = initalHealth;
        m_ammo = initialAmmo;
        m_armour = initalArmour; 
        m_isArmourEquipped = false; 
        m_ammoRegenTimer = initialRegenTimer;
        m_ammoRegenTrigger = initialRegenTrigger; 
    }

    // Update is called once per frame
    void Update()
    {
        CheckRegen();

        if (m_ammo <= 0) {
            m_ammo = 0;
        }
    }

    // Check for collisions
    void OnTriggerEnter(Collider otherCollider)
    {
        // If Player collides with a VitaCapsule
        if(otherCollider.GetComponent<VitaCapsule>() != null)
        {
            // Collect health from VitaCapsule
            VitaCapsule vitaCapsule = otherCollider.gameObject.GetComponent<VitaCapsule>();
            m_health += vitaCapsule.health;
            Destroy(vitaCapsule.gameObject);
        }
        // If Player collides with a Ammo Object *NOTE WILL BE ALTERED
        if (otherCollider.GetComponent<AmmoCrate>() != null)
        {
            // Collect ammo crates
            AmmoCrate ammoCrate = otherCollider.gameObject.GetComponent<AmmoCrate>();
            m_ammo += ammoCrate.ammo;
            Destroy(ammoCrate.gameObject);
        }
        // If Player collides with a CellAmour Object
        if(otherCollider.GetComponent<CellArmour>() != null)
        {
            // Player is now equipped with armour
            m_isArmourEquipped = true;
            // Collect armour
            CellArmour cellArmour = otherCollider.gameObject.GetComponent<CellArmour>();
            m_armour += cellArmour.armourPoint;
            Destroy(cellArmour.gameObject);
        }

        // Lets the Player die if they fall to the ground ---- 2020/07/28
        // *NOTE WILL BE ALTERED
        if (otherCollider.GetComponent<DeathZone>() != null) {
            m_health = 0; 
        }

        // Checks if Player hasn't already taken damage
        if (m_isHurt == false)
        {
            GameObject hazard = null;
            // Checks if Player was damaged by an Enemy by melee
            if (otherCollider.GetComponent<Enemy>() != null)
            {
                // Touching enemies
                Enemy enemy = otherCollider.GetComponent<Enemy>();
                // Checks if Enemy isn't already dead
                if(enemy.Killed == false)
                {
                    hazard = enemy.gameObject;
                    // Checks if Player is equipped with CellArmour
                    if (m_isArmourEquipped != false)
                    {
                        // Decrements Armour
                        m_armour -= enemy.damage;
                        // Decrements Health by half because of armour padding
                        m_health -= enemy.damage / 2;
                    }
                    // Player isn't equipped with CellArmour
                    else
                    {
                        // Decrements Health
                        m_health -= enemy.damage;
                    }
                }
            }
            // Checks if Player was damaged by an Enemy through projectile
            else if (otherCollider.GetComponent<Bullet>() != null)
            {
                // Shot by enemies
                Bullet bullet = otherCollider.GetComponent<Bullet>();
                // Checks if Enemy isn't already dead
                if (bullet.ShotByPlayer == false)
                {
                    hazard = bullet.gameObject;
                    // Checks if Player is equipped with CellArmour
                    if(m_isArmourEquipped != false)
                    {
                        // Decrements Armour
                        m_armour -= bullet.damage;
                        // Decrements Health by half because of armour padding
                        m_health -= bullet.damage / 2;
                    }
                    // Player isn't equipped with CellArmour
                    else
                    {// Decrements Health
                        m_health -= bullet.damage;
                    }
                    bullet.gameObject.SetActive(false);
                }
            }
            // Checks if knockback is required on attack
            if (hazard != null)
            {
                m_isHurt = true;
                // Perform the knockback effect
                Vector3 hurtDirection = (transform.position - hazard.transform.position).normalized;
                Vector3 knockbackDirection = (hurtDirection + Vector3.up).normalized;
                GetComponent<ForceReceiver>().AddForce(knockbackDirection, knockbackForce);
                StartCoroutine(HurtRoutine());
            }
            // Checks to see if Player died because of depleted health
            if(m_health <= 0)
            {
                // Checks if Player isn't already dead
                if(m_killed == false)
                {
                    // Officially declares the Player dead
                    m_killed = true;
                    // Performs the procedure that'll happen at death
                    OnKill();
                }
            }
        }
    }
    IEnumerator HurtRoutine()
    {
        yield return new WaitForSeconds(hurtDuration);
        m_isHurt = false;
    }

    private void OnKill()
    {
        // Disabled due to bricking the game through different GameStates
        // GetComponent<CharacterController>().enabled = false;
        // GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
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
}
