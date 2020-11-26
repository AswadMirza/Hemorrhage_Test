using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Made By Aswad Mirza 2020, November
public class HookShot : MonoBehaviour
{

    private bool m_IsGrabbed = false;
    public bool IsGrabbed { get {return m_IsGrabbed; } set {m_IsGrabbed = value; } }

    public float GrabSpeed;
    public float GrabDistance;
    public GameObject PlayerObject;
    private Player m_player;

    private AudioSource m_audio;
    // Start is called before the first frame update
    void Start()
    {
        //m_player = GameObject.Find();
        m_player = PlayerObject.GetComponent<Player>();
        m_audio = gameObject.GetComponent<AudioSource>();
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

            //plays the sound clip of the audio source attached to this object
            if (m_audio != null) {
                if (!m_audio.isPlaying) {
                    m_audio.Play();
                }
            
            }
            Debug.Log("You triggered me");
        }
    }
}
