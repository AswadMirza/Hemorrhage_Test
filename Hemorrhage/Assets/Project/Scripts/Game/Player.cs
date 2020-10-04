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

    private bool isHurt;

    private float m_ammoRegenTimer = 0f;
    private int m_ammoRegenTrigger = 3;


    // Start is called before the first frame update
    void Start()
    {
        m_health = initalHealth;
        m_ammo = initialAmmo;
        m_armour = initalArmour;
        m_ammoRegenTimer = initialRegenTimer;
        m_ammoRegenTrigger = initialRegenTrigger;
    }

    // Update is called once per frame
    void Update()
    {
        CheckRegen();
    }

    // Check for collisions
    void OnTriggerEnter(Collider otherCollider)
    {
        // If Player collides with a Health Object
        if(otherCollider.GetComponent<HealthCrate>() != null)
        {
            // Collect health crates
            HealthCrate healthCrate = otherCollider.gameObject.GetComponent<HealthCrate>();
            m_health += healthCrate.health;
            Destroy(healthCrate.gameObject);
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
            // Collect armour
            CellArmour cellArmour = otherCollider.gameObject.GetComponent<CellArmour>();
            m_armour += cellArmour.armourPoint;
            Destroy(cellArmour.gameObject);
        }

        // Lets the player die if they fall to the ground ---- 2020/07/28
        // *NOTE WILL BE ALTERED
        if (otherCollider.GetComponent<DeathZone>() != null) {
            m_health = 0; 
        }

        if (isHurt == false)
        {
            GameObject hazard = null;
            if (otherCollider.GetComponent<Enemy>() != null)
            {
                // Touching enemies
                Enemy enemy = otherCollider.GetComponent<Enemy>();
                if(enemy.Killed == false)
                {
                    hazard = enemy.gameObject;
                    m_health -= enemy.damage;
                }
            }
            else if (otherCollider.GetComponent<Bullet>() != null)
            {
                // Shot by enemies
                Bullet bullet = otherCollider.GetComponent<Bullet>();
                if (bullet.ShotByPlayer == false)
                {
                    hazard = bullet.gameObject;
                    m_health -= bullet.damage;
                    bullet.gameObject.SetActive(false);
                }
            }
            if (hazard != null)
            {
                isHurt = true;
                // Perform the knockback effect
                Vector3 hurtDirection = (transform.position - hazard.transform.position).normalized;
                Vector3 knockbackDirection = (hurtDirection + Vector3.up).normalized;
                GetComponent<ForceReceiver>().AddForce(knockbackDirection, knockbackForce);
                StartCoroutine(HurtRoutine());
            }
            if(m_health <= 0)
            {
                if(m_killed == false)
                {
                    m_killed = true;
                    OnKill();
                }
            }
        }
    }
    IEnumerator HurtRoutine()
    {
        yield return new WaitForSeconds(hurtDuration);
        isHurt = false;
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
