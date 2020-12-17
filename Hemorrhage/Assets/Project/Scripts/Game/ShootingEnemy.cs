/**
 * Created DD/MM/YYYY
 * By: [Insert Name]
 * Last Modified 26/10/2020
 * By: Sharek Khan
 * 
 * Contributors:
 */

using UnityEngine;
using UnityEngine.AI;

/*
 * [Describe the function of the class]
 * Code based on Zenva Studios -COMPLETE COURSE Create a Unity FPS Game in 3 hours - https://www.youtube.com/watch?v=UtlAqRyZrUw
 */
public class ShootingEnemy : Enemy
{

    public int InitialHealth = 10;
    public AudioSource deathSound;
    public float shootingInterval = 4f;
    public float shootingDistance = 3f;
    public float chasingInterval = 2f;
    public float chasingDistance = 12f;

    private Player player;
    private float shootingTimer;
    private float chasingTimer;
    private NavMeshAgent agent;

    private Vector3 m_lastPlayerLocation = Vector3.zero;

    // Variables for when the enemy is hit by the melee weapon   
    public float grabDistance=3f;
    public float grabSpeed = 120f;

    // Start is called before the first frame update
    void Start()
    {
        this.Health = InitialHealth;
        player = GameObject.Find("Player").GetComponent<Player>();
        agent = GetComponent<NavMeshAgent>();
        shootingTimer = Random.Range(0, shootingInterval);
        agent.SetDestination(player.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(player.IsKilled == true)
        {
            agent.enabled = false;
            this.enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
        }
        /*
         * Removed since TakeDamage is now a base class function
         * 
        if (health<=0) {
            Killed = true;
            OnKill();
        }
        */
        // Shooting Logic
        shootingTimer -= Time.deltaTime;
        if(shootingTimer <= 0 && Vector3.Distance(transform.position, player.transform.position) <= shootingDistance)
        {
            shootingTimer = shootingInterval;
            GameObject bullet = ObjectPoolingManager.Instance.GetBullet(false);
            bullet.transform.position = transform.position;
            //Problem, shooting the bullet is too slow
            bullet.transform.forward = (player.transform.position - transform.position).normalized;
           // Rigidbody rb = bullet.GetComponent<Rigidbody>();
           // rb.AddRelativeForce(new Vector3(0,0,2000));
        }
        // Chasing Logic
        chasingTimer -= Time.deltaTime;
        if (chasingTimer <= 0 && Vector3.Distance(transform.position, player.transform.position) <= chasingDistance)
        {
            chasingTimer = chasingInterval;
            agent.SetDestination(player.transform.position);
        }

        // Grabbed logic
        Grabbed();
    }

    /*
    // OnCollisionEnter detects all collisions on entry
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.GetComponent<MeleeWeapon>() != null) {
            isGrabbed = true;
        }
    }
    */


    // [Describe the function of this method]
    protected override void OnKill()
    {
        base.OnKill();
        deathSound.Play();
        // agent.enabled = false;
        this.enabled = false;
        transform.localEulerAngles = new Vector3(10, transform.localEulerAngles.y, transform.localEulerAngles.z);
    }


    // [Describe the function of this method]
    protected override void Grabbed()
    {
        if (IsGrabbed)
        {
            Debug.Log("Grabbed"); 
            if (m_lastPlayerLocation.Equals(Vector3.zero))
            {
                Debug.Log("Going to the last Player location");
                m_lastPlayerLocation = player.transform.position;
            } 
            if (Vector3.Distance(transform.position, m_lastPlayerLocation) > grabDistance)
            { 
                transform.position = CalculateDirection(transform.position, m_lastPlayerLocation, grabSpeed);
            }
            else
            {
                IsGrabbed = false;
                m_lastPlayerLocation = Vector3.zero;
                Debug.Log("not grabbed anymore");
            }
        }
    }
}