/** 
* Last modified 26/10/2020
* By: Sharek Khan
*/

using UnityEngine;
using UnityEngine.AI;

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

    //variables for when the enemy is hit by the melee weapon   
    
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


        //grabbed logic
        Grabbed();
    }

    /*
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.GetComponent<MeleeWeapon>() != null) {
            isGrabbed = true;
        }
    }
    */
    protected override void OnKill()
    {
        base.OnKill();
        deathSound.Play();
        // agent.enabled = false;
        this.enabled = false;
        transform.localEulerAngles = new Vector3(10, transform.localEulerAngles.y, transform.localEulerAngles.z);
    }

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