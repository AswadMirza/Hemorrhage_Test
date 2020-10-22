/** 
* Last modified 14/10/2020
* By: Sharek Khan
*/

using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 5;
    public int damage = 5;
    
    private bool m_killed = false;
    public bool Killed { get { return m_killed; }  set { m_killed = value; } }

    // Checks triggered collision being interacted with Enemy
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

    protected virtual void OnKill() { }

    // Makes the enemy take x damage, and then check if it is dead or not
    public void TakeDamage(int damage) {
        this.health -= damage;
        if (health <= 0) {
            health = 0;
            if (m_killed == false) {
                m_killed = true;
                OnKill();
            }
        }
    }
}
