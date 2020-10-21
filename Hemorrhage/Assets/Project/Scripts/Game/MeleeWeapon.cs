using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Last modified by Aswad Mirza on OCT 21st 2020
public class MeleeWeapon : MonoBehaviour
{

    GameObject playerModel;
    Player player;
    static bool isfired = false;

    public float initialTimeAlive =0.25f;
    private float m_timeAlive = 0f;
    public int m_damage = 5;
    public int m_heal = 10;
    public float speed = 20f;
    public int ammoRestore = 10;
    public float m_enemyDistance = 3f;


    

    // Start is called before the first frame update
    void Start()
    {
        // isfired = false;
        m_timeAlive = initialTimeAlive;
        playerModel = GameObject.Find("Player");
        player = playerModel.GetComponent<Player>(); 
    }

    // Update is called once per frame
    void Update()
    {

        //MoveObject();

        //we let the meleeweaponStay active for x seconds. and then destroy it
        if (m_timeAlive <= 0) {
            isfired = false;
            Destroy(gameObject);
            //gameObject.SetActive(false);
            m_timeAlive = initialTimeAlive;
        }
        m_timeAlive -= Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Enemy enemy = null;
        // gotta change this so instead of killing the enemy, it deals damage
        if (collision.gameObject.GetComponent<Enemy>() != null &&!isfired) {
            Debug.Log("gottem");

            enemy = collision.gameObject.GetComponent<Enemy>();
            //Destroy(collision.gameObject);
            //collision.gameObject.GetComponent<Enemy>().health -= m_damage;

            // pullObject(collision.gameObject.GetComponent<Enemy>().gameObject);
            enemy.IsGrabbed = true;
            enemy.TakeDamage(m_damage);
            if (enemy.health <= 0) {
                player.Health += m_heal;
                player.Ammo += ammoRestore;
            }
            //this is to prevent the melee weapon from hitting the enemy for multiple frames
            Destroy(gameObject);
            
        }
        
    }

    private void MoveObject()
    {
        // Make the weapon move
        transform.position += transform.forward * speed * Time.deltaTime; 
    }

    private void pullObject(GameObject enemy) {
        Vector3 distanceFromPlayer = player.gameObject.transform.forward;
       // distanceFromPlayer.z += m_enemyDistance;
        enemy.transform.position = distanceFromPlayer;
    }
}
