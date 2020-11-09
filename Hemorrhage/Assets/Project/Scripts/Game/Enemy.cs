
/** 
* Last modified 26/10/2020
* By: Sharek Khan
*/

using UnityEngine;

//Last edited by Aswad Mirza on Octorber 12th 2020

public class Enemy : MonoBehaviour
{
    private int m_health = 5;
    public int Health { get { return m_health; } set { m_health = value; } }
    private int m_damage = 5;
    public int Damage { get { return m_damage; } set { m_damage = value; } }
    private bool m_isGrabbed;
    public bool IsGrabbed { get { return m_isGrabbed; } set { m_isGrabbed = value; } }
    private bool m_isKilled = false;
    public bool IsKilled { get { return m_isKilled; } set { m_isKilled = value; } }
    
    void OnTriggerEnter(Collider otherCollider)
    {
        // If Enemy is colliding with PlasmaAmmo
        if (otherCollider.GetComponent<Bullet>() != null)
        {
            // Calls an instance of the PlasmaAmmo script component
            Bullet bullet = otherCollider.GetComponent<Bullet>();
            // Checks if PlasmaAmmo was shot by Player
            if (bullet.ShotByPlayer == true)
            {
                // Enemy takes damage
                TakeDamage(bullet.damage);
                // PlasmaAmmo will be deactivated once contact is made
                bullet.gameObject.SetActive(false);
        
            }
        }
        // code for if melee weapon becomes a trigger
        /*
        else if (otherCollider.GetComponent<MeleeWeapon>() != null) {
            MeleeWeapon melee = otherCollider.GetComponent<MeleeWeapon>();
            TakeDamage(melee.m_damage);
            melee.gameObject.SetActive(false);
        }
        */
    }

    // Base function that will be overriden by inherited class, determing how enemy will behave on death
    protected virtual void OnKill() { }

    // Makes the enemy take x damage, and then check if it is dead or not
    public void TakeDamage(int damage) {
        m_health -= damage;
        if (m_health <= 0) {
            m_health = 0;
            if (m_isKilled == false) {
                m_isKilled = true;
                OnKill();
            }
        }
    }

    // Helper function for calculating direction of vectors
    protected Vector3 CalculateDirection(Vector3 source, Vector3 destination, float speed) {
        Vector3 direction = (destination - source).normalized;
        source += (direction * speed * Time.deltaTime);
        return source;
    }
}
