/** 
* Last modified 02/12/2020
* By: Aswad Mirza
*/

using System.Collections;
using UnityEngine;

public class CancerCell : Enemy
{
    private GameObject m_player;
    private Vector3 m_initialPos;
    private Quaternion m_initialRot;
    private int m_speed = 2;
    private int m_chaseSpeed = 3;
    private int m_rotSpeed = 180;
    private string m_enemyState;

    public int InitialHealth = 10;
    public float shootingDelta = 1f;
    public float shootingDist = 10f;
    public GameObject weapon01;
    public GameObject weapon02;

    public GameObject cancerCellKilled;
    
    private AudioSource m_source;
    // Fire rate
    public float m_fireRate = 1f;

    private float m_initialFireRate = 0f;
    // Grab variables
    public float grabDistance = 3f;
    public float grabSpeed = 12;
    private Vector3 m_lastPlayerLocation = Vector3.zero;

    Rigidbody m_rigidbody;
    bool originalKinematicSetting = false;

    // Start is called before the first frame update
    void Start()
    {
        m_initialPos = transform.position;
        m_initialRot = transform.rotation;
        //m_enemyState = "IDLE";
        m_enemyState = "ATTACK";

        this.Health = InitialHealth;
        m_initialFireRate = m_fireRate;
        // Retrieves the Player through the active Player GameObject
        m_player = GameObject.FindGameObjectWithTag("Player");

        m_source = GetComponent<AudioSource>();

        m_rigidbody = GetComponent<Rigidbody>();
        if (m_rigidbody != null) {
            originalKinematicSetting = m_rigidbody.isKinematic;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Grabbed();
        // Check Enemy behaviour state
        if (m_enemyState == "IDLE")
        {
            OnIdle();
        }
        else if (m_enemyState == "ATTACK")
        {
            LookAtPlayer();
            m_fireRate -= Time.deltaTime;

            if (m_fireRate <= 0) {
                OnAttack();
            }
            
        }

        if (m_fireRate <= 0) {
            m_fireRate = m_initialFireRate;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        // Checks if Enemy has entered the Players vicinity bubble
        if (collider.gameObject.tag == "AIDetection")
        {
            Debug.Log("CancerCell is inside Player vicinty.");
            // Switch enemy state to attack
            m_enemyState = "ATTACK";
        }

        // because we are using ontrigger enter in this class, it needs to be updated
        if (collider.GetComponent<Bullet>() != null)
        {
            // Calls an instance of the PlasmaAmmo script component
            Bullet bullet = collider.GetComponent<Bullet>();
            // Checks if PlasmaAmmo was shot by Player
            if (bullet.ShotByPlayer == true)
            {
                // Enemy takes damage
                TakeDamage(bullet.damage);
                // PlasmaAmmo will be deactivated once contact is made
                bullet.gameObject.SetActive(false);

            }
        }
    }

    void OnTriggerExit(Collider collider)
    {
        // Checks if Enemy has exited the Players vicinity bubble
        if (collider.gameObject.tag == "AIDetection")
        {
            Debug.Log("CancerCell is outside Player vicinty.");
            // Reset enemy position
            // transform.position = m_initialPos;
            transform.rotation = m_initialRot;
            // Switch enemy state to idle
            m_enemyState = "IDLE";
        }
    }

    // Enemies Behaviour Patterns when not near Player
    void OnIdle()
    {
        // Translate enemy back and forth, while rotating around
        transform.Translate(Vector3.forward * m_speed * Time.deltaTime);
        if (transform.position.z >= (m_initialPos.z + 10))
        {
            // Rotate Enemy
            transform.Rotate(Vector3.up, m_rotSpeed * Time.deltaTime);
        }
        else if (transform.position.z <= (m_initialPos.z - 10))
        {
            // Rotate Enemy
            transform.Rotate(Vector3.up, m_rotSpeed * Time.deltaTime);
        }
    }



    //Added by aswad, seperating the function to look at the player and function to attack
    void LookAtPlayer() {
        // Rotate in Player direction
        Vector3 playerDir = m_player.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(playerDir);
        // Chase Player
        transform.position = CalculateDirection(transform.position, m_player.transform.position, m_chaseSpeed);
    }


    // Enemies Behaviour Patterns when enter Player vicinity
    void OnAttack()
    {
        //LookAtPlayer();
        // StartCoroutine(fireBullet(m_fireRate));
        // Attack Player by shooting projectiles at their direction
        // Instantiate an Ammo type GameObject
        GameObject plasmaAmmo = ObjectPoolingManager.Instance.GetSmgBullet(false);
        // Set the initial position of the Ammo object to be from PlasmaRifle
        plasmaAmmo.transform.position = weapon01.transform.position;
        // Translate the Ammo object towards the Player
        plasmaAmmo.transform.forward = (m_player.transform.position - weapon01.transform.position).normalized;
    }

    /*
    IEnumerator fireBullet(float firedelay) {
        yield return new WaitForSeconds(firedelay);
        // Attack Player by shooting projectiles at their direction
        // Instantiate an Ammo type GameObject
        GameObject plasmaAmmo = ObjectPoolingManager.Instance.GetSmgBullet(false);
        // Set the initial position of the Ammo object to be from PlasmaRifle
        plasmaAmmo.transform.position = weapon.transform.position;
        // Translate the Ammo object towards the Player
        plasmaAmmo.transform.forward = (m_player.transform.position - weapon.transform.position).normalized;
    }
    */

    protected override void OnKill()
    {
        base.OnKill();
        // Kill State
        Debug.Log("CancerCell is killed.");
        Instantiate(cancerCellKilled, transform.position, transform.rotation);
        Destroy(this.gameObject);
        
        // gameObject.GetComponent<Rigidbody>().isKinematic = false;

        // if (!m_source.isPlaying) {
        //     m_source.Play();
        //}

        //this.enabled = false;
        //Destroy(this.gameObject);
        //transform.localEulerAngles = new Vector3(10, transform.localEulerAngles.y, transform.localEulerAngles.z);
    }

    protected override void Grabbed()
    {
        if (IsGrabbed)
        {
            Debug.Log("Grabbed");
            //disable the navmesh agent


            if (m_rigidbody != null)
            {

                m_rigidbody.isKinematic = true;
            }

            if (m_lastPlayerLocation.Equals(Vector3.zero))
            {
                Debug.Log("Going to the last Player location");
                m_lastPlayerLocation = m_player.transform.position;
            }

            if (Vector3.Distance(transform.position, m_lastPlayerLocation) > grabDistance)
            {

                transform.position = CalculateDirection(transform.position, m_lastPlayerLocation, grabSpeed);
            }
            else
            {
                IsGrabbed = false;
                m_lastPlayerLocation = Vector3.zero;
                if (m_rigidbody != null)
                {
                    m_rigidbody.isKinematic = originalKinematicSetting;
                }
                Debug.Log("Not Grabbed Anymore");
            }
        }
    }
}