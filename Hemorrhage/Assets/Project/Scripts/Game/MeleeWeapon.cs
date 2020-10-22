/** 
* Last modified 06/10/2020
* By: Aswad Mirza
*/

using UnityEngine;

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
        // gotta change this so instead of killing the enemy, it deals damage
        if (collision.gameObject.GetComponent<Enemy>() != false) {
            Debug.Log("srekt");
            //Destroy(collision.gameObject);
            //collision.gameObject.GetComponent<Enemy>().health -= m_damage;
            collision.gameObject.GetComponent<Enemy>().TakeDamage(m_damage);
            if (collision.gameObject.GetComponent<Enemy>().health <= 0) {
                player.Health += m_heal;
            }
            //this is to prevent the melee weapon from hitting the enemy for multiple frames
            isfired = true;
            
        }
        
    }

    private void MoveObject()
    {
        // Make the weapon move
        transform.position += transform.forward * speed * Time.deltaTime;

         

    }
}
