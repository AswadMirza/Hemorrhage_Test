using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookShot : MonoBehaviour
{

    private bool m_IsGrabbed = false;
    public bool IsGrabbed { get {return m_IsGrabbed; } set {m_IsGrabbed = value; } }

    public float GrabSpeed;
    public float GrabDistance;
    public GameObject PlayerObject;
    private Player m_player;
    
    // Start is called before the first frame update
    void Start()
    {
        //m_player = GameObject.Find();
        m_player = PlayerObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Traversal();
    }

    protected Vector3 CalculateDirection(Vector3 source, Vector3 destination, float speed)
    {
        Vector3 direction = (destination - source).normalized;
        source += (direction * speed * Time.deltaTime);
        return source;
    }

    //basically just moves the player to the object that has the collision
    void Traversal() {
        if (IsGrabbed)
        {
            Debug.Log("Moving Player to Object");
             
            if (Vector3.Distance(transform.position, PlayerObject.transform.position) > GrabDistance)
            {
                PlayerObject.transform.position = CalculateDirection(PlayerObject.transform.position,transform.position , GrabSpeed);
            }
            else
            {
                IsGrabbed = false;
               
                Debug.Log("Player Arrived close enough to object");
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        MeleeWeapon melee;
        if (collision.gameObject.GetComponent<MeleeWeapon>() != null) {
            melee = collision.gameObject.GetComponent<MeleeWeapon>();
            IsGrabbed = true;
            Debug.Log("You triggered me");
        }
    }
}
