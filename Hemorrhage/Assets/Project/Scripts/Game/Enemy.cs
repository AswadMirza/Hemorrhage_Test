using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 5;
    public int damage = 5;
    
    private bool killed = false;
    public bool Killed { get { return killed; }  set { killed = value; } }
    void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.GetComponent<Bullet>() != null)
        {
            Bullet bullet = otherCollider.GetComponent<Bullet>();
            if (bullet.ShotByPlayer == true)
            {
                health -= bullet.damage;
                bullet.gameObject.SetActive(false);
                if (health <= 0)
                {
                    if (killed == false)
                    {
                        killed = true;
                        OnKill();
                    }
                }
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

    // makes the enemy take x damage, and then check if it is dead or not
    public void TakeDamage(int damage) {
        this.health -= damage;
        if (health <= 0) {
            if (killed == false) {
                killed = true;
                OnKill();
            }
        }
    }
}
