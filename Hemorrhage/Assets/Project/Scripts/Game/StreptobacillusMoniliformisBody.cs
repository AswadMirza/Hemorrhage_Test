/**
 * Created DD/MM/YYYY
 * By: Omer Farkhand
 * Last Modified 12/10/2020
 * By: Omer Farkhand
 * 
 * Contributors:
 */

using UnityEngine;

/*
 * [Describe the function of the class]
 */
public class StreptobacillusMoniliformisBody : Enemy
{
    public int InitialHealth = 100;
    public int damage = 25;
    public float m_speed;
    public float Speed { get { return m_speed; } set { m_speed = value; } }
    public float m_rotation = 0;
    public float RotationSpeed { get { return m_rotation; } set { m_rotation = value; } }
    float distance = 1;
    
    public GameObject body;


    // Start is called before the first frame update
    void Start()
    {
        this.Health = InitialHealth;
        this.Damage = damage;
    }

    // Update is called once per frame
    void Update()
    {
        //m_speed = 16f;
        Vector3 v1, v2;
        v1 = this.gameObject.transform.position;
        v2 = body.transform.position;
        distance = Vector3.Distance(v1, v2);

        this.gameObject.transform.rotation = Quaternion.Slerp(this.gameObject.transform.rotation, Quaternion.LookRotation(body.transform.position -
           this.gameObject.transform.position), m_rotation * Time.deltaTime);

        Move();
    }

    // [Describe the function of this method]
    void Move()
    {
        //move towards the player
        this.gameObject.transform.position += this.gameObject.transform.forward * Time.deltaTime * m_speed;
    }

    // [Describe the function of this method]
    public GameObject getAttach()
    {
        return body;
    }

}
