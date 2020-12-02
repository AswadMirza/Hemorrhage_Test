/** 
* Last modified 12/10/2020 
* By: Omer Farkhand
*/

using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class StreptobacillusMoniliformisHead : Enemy
{
    public int InitialHealth = 100;
    public int damage = 25;

    public AudioSource deathSound;
    public float m_speed;
    public float Speed { get { return m_speed; } set { m_speed = value; } }
    
    public float m_rotation = 0;
    public float RotationSpeed { get { return m_rotation; } set { m_rotation = value; } }

    public GameObject deathEffect;

    Vector3 dir1;
    Vector3 dir2;
    float distance;
    public GameObject player;
    public GameObject[] body = new GameObject[6];
    // Start is called before the first frame update
    void Start()
    {
        this.Health = InitialHealth;
        this.Damage = damage;
    }

    // Update is called once per frame
    void Update()
    {
        //m_speed = 15f;
        Vector3 v1, v2;
        v1 = this.gameObject.transform.position;
        v2 = player.transform.position;
        distance = Vector3.Distance(v1, v2);

        //rotate to look at the player
        this.gameObject.transform.rotation = Quaternion.Slerp(this.gameObject.transform.rotation, Quaternion.LookRotation(player.transform.position -
            this.gameObject.transform.position), m_rotation * Time.deltaTime);


        Move();
    }

    protected override void OnKill()
    {
        base.OnKill();
        deathSound.Play();
        GameObject effect = Instantiate(deathEffect, transform.position, deathEffect.transform.rotation);

        // agent.enabled = false;
        this.enabled = false;
        Destroy(this.gameObject);
        Destroy(body[0]);
        Destroy(body[1]);
        Destroy(body[2]);
        Destroy(body[3]);
        Destroy(body[4]);
        Destroy(body[5]);
    }

    void Move()
    {
        //move towards the player
        this.gameObject.transform.position += this.gameObject.transform.forward * Time.deltaTime * m_speed;
    }

    
    /*IEnumerator Lunge(float multiplier)
    {
        Debug.Log("HeadLunge");
        m_speed *= 0;
        yield return new WaitForSeconds(10);

        Debug.Log("Speed = " + m_speed);
       
        m_speed = 15f;
        m_speed *= multiplier;

        //move towards the player
        this.gameObject.transform.position += this.gameObject.transform.forward * Time.deltaTime * m_speed;
    }*/

}
