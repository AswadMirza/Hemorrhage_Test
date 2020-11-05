/** 
* Last modified 26/10/2020
* By: Aswad Mirza
*/

using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    private GameObject m_playerObject;
    private Player m_player;
    private float m_timeAlive = 0f;
    private static bool m_isFired = false;

    public int heal = 10;
    public int damage = 5;
    public int ammoRestore = 10;
    public float speed = 20f;
    public float enemyDistance = 3f;
    public float initialTimeAlive = 0.25f;
    
    // Start is called before the first frame update
    void Start()
    {
        // isfired = false;
        m_timeAlive = initialTimeAlive;
        m_playerObject = GameObject.Find("Player");
        m_player = m_playerObject.GetComponent<Player>(); 
    }

    // Update is called once per frame
    void Update()
    {

        //MoveObject();

        // We let the meleeweaponStay active for x seconds and then destroy it
        if (m_timeAlive <= 0) {
            m_isFired = false;
            Destroy(this.gameObject);
            //gameObject.SetActive(false);
            m_timeAlive = initialTimeAlive;
        }
        m_timeAlive -= Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Enemy enemy = null;
        // Gotta change this so instead of killing the enemy, it deals damage
        if (collision.gameObject.GetComponent<Enemy>() != null &&!m_isFired) {
            Debug.Log("gottem");

            enemy = collision.gameObject.GetComponent<Enemy>();
            //Destroy(collision.gameObject);
            //collision.gameObject.GetComponent<Enemy>().health -= m_damage;

            // pullObject(collision.gameObject.GetComponent<Enemy>().gameObject);
            enemy.IsGrabbed = true;
            enemy.TakeDamage(damage);
            if (enemy.Health <= 0) {
                m_player.Health += heal;
                m_player.Ammo += ammoRestore;
            }
            // This is to prevent the melee weapon from hitting the enemy for multiple frames
            Destroy(this.gameObject);
        }
    }

    private void MoveObject()
    {
        // Make the weapon move
        transform.position += transform.forward * speed * Time.deltaTime; 
    }

    private void pullObject(GameObject enemy) {
        Vector3 distanceFromPlayer = m_playerObject.transform.forward;
       // distanceFromPlayer.z += m_enemyDistance;
        enemy.transform.position = distanceFromPlayer;
    }
}
