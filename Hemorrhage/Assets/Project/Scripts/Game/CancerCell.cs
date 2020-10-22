/** 
* Last modified 21/10/2020
* By: Sharek Khan
*/

using UnityEngine;

public class CancerCell : Enemy
{
    public float shootingDelta = 5f;
    public float shootingDist = 10f;
    public GameObject weapon;

    private Player m_player;
    private float m_shootingTimer;
    private Vector3 enemyPos;
    private Vector3 initialPos;
    private string enemyState;

    // Start is called before the first frame update
    void Start()
    {
        enemyPos = transform.position;
        initialPos = enemyPos;
        enemyState = "IDLE";

        // Retrieves the Player script through the active Player GameObject
        m_player = GameObject.Find("Player").GetComponent<Player>();
        // Initializes the rate of which enemy fires
        m_shootingTimer = Random.Range(0, shootingDelta);
    }

    // Update is called once per frame
    void Update()
    {
        // Check Enemy behaviour state
        if(enemyState == "IDLE")
        {
            OnIdle();
        }
        else if(enemyState == "ATTACK")
        {
            OnAttack();
        }

        // Rotates the Enemy in direction of Player
        
        // Shooting Logic
        // Decrements the value of delay between shots
        m_shootingTimer -= Time.deltaTime;
        // Check if Enemy is able to fire and within the shooting distance
        if(m_shootingTimer <= 0 && Vector3.Distance(transform.position, m_player.transform.position) >= shootingDist)
        {
            // Reset the shooting timer
            m_shootingTimer = shootingDelta;
            // Instantiate an Ammo type GameObject
            //GameObject plasmaAmmo = ObjectPoolingManager.Instance.GetSmgBullet(false);
            // Set the initial position of the Ammo object to be from PlasmaRifle
            //plasmaAmmo.transform.position = weapon.transform.position;
            // Translate the Ammo object towards the Player
            //plasmaAmmo.transform.forward = (m_player.transform.position - weapon.transform.position).normalized;
            //Debug.Log("Shot fired!");
        }

    }

    void OnTriggerEnter(Collider collider)
    {
        // Checks if Enemy has entered the Players vicinity bubble
        if(collider.gameObject.tag == "AIDetection")
        {
            Debug.Log("CancerCell is inside Player vicinty.");
            // Switch enemy state to attack
            enemyState = "ATTACK";
        }
    }

    void OnTriggerExit(Collider collider)
    {
        // Checks if Enemy has exited the Players vicinity bubble
        if(collider.gameObject.tag == "AIDetection")
        {
            Debug.Log("CancerCell is outside Player vicinty.");
            // Switch enemy state to idle
            enemyState = "IDLE";
        }
    }

    // Enemies Behaviour Patterns when not near Player
    void OnIdle()
    {
        // Translate enemy back and forth, while rotating around
        Vector3 translatePos = transform.TransformDirection(1, 0, 0);
        enemyPos += translatePos * 1 * Time.deltaTime;
        transform.position = translatePos;
    }

    // Enemies Behaviour Patterns when enter Player vicinity
    void OnAttack()
    {
        // Attack Player by shooting projectiles at their direction
    }

    protected override void OnKill()
    {
        base.OnKill();
        // Kill State
    }
}