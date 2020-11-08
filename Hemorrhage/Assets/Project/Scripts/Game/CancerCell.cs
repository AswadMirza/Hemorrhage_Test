/** 
* Last modified 26/10/2020
* By: Sharek Khan
*/

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

    public float shootingDelta = 1f;
    public float shootingDist = 10f;
    public GameObject weapon;

    // Start is called before the first frame update
    void Start()
    {
        m_initialPos = transform.position;
        m_initialRot = transform.rotation;
        m_enemyState = "IDLE";

        // Retrieves the Player through the active Player GameObject
        m_player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Check Enemy behaviour state
        if (m_enemyState == "IDLE")
        {
            OnIdle();
        }
        else if (m_enemyState == "ATTACK")
        {
            OnAttack();
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

    // Enemies Behaviour Patterns when enter Player vicinity
    void OnAttack()
    {
        // Rotate in Player direction
        Vector3 playerDir = m_player.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(playerDir);
        // Chase Player
        transform.position = CalculateDirection(transform.position, m_player.transform.position, m_chaseSpeed);
        // Attack Player by shooting projectiles at their direction
        // Instantiate an Ammo type GameObject
        GameObject plasmaAmmo = ObjectPoolingManager.Instance.GetSmgBullet(false);
        // Set the initial position of the Ammo object to be from PlasmaRifle
        plasmaAmmo.transform.position = weapon.transform.position;
        // Translate the Ammo object towards the Player
        plasmaAmmo.transform.forward = (m_player.transform.position - weapon.transform.position).normalized;
    }

    protected override void OnKill()
    {
        base.OnKill();
        // Kill State
    }
}