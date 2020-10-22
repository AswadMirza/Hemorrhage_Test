/** 
* Last modified 21/10/2020
* By: Sharek Khan
*/

using UnityEngine;

public class Myoviridae : Enemy
{
    public float chargingDelta = 5f;
    public float chargingDistance = 5f;

    private Player m_player;
    private float m_chargingTimer;

    // Start is called before the first frame update
    void Start()
    {
        // Retrieves the Player script through the active Player GameObject
        m_player = GameObject.Find("Player").GetComponent<Player>();
        // Initializes the rate of which enemy fires
        m_chargingTimer = Random.Range(0, chargingDelta);
    }

    // Update is called once per frame
    void Update()
    {
        // Chasing Logic
        m_chargingTimer -= Time.deltaTime;
        if (m_chargingTimer <= 0 && Vector3.Distance(transform.position, m_player.transform.position) >= chargingDistance)
        {
            m_chargingTimer = chargingDelta;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        // Checks if Enemy has entered the Players vicinity bubble
        if (collider.gameObject.tag == "AIDetection")
        {
            Debug.Log("Myoviridae is inside Player vicinty.");
            // Switch enemy state to attack
            OnAttack();
        }
    }

    void OnTriggerExit(Collider collider)
    {
        // Checks if Enemy has exited the Players vicinity bubble
        if (collider.gameObject.tag == "AIDetection")
        {
            Debug.Log("Myoviridae is outside Player vicinty.");
            //  Switch enemy state to idle
            OnIdle();
        }
    }

    // Enemies Behaviour Patterns when not near Player
    void OnIdle()
    {
        // Translate enemy back and forth, while rotating around

    }

    // Enemies Behaviour Patterns when enter Player vicinity
    void OnAttack()
    {
        // Attack Player by rushing them with melee damage
    }

    protected override void OnKill()
    {
        base.OnKill();
        // Kill State
    }
}
