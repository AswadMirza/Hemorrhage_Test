/** 
* Last modified 12/10/2020 
* By: Omer Farkhand
*/
using System.Collections;
using UnityEngine;

public class StreptobacillusMoniliformisBody : Enemy
{
    public int InitialHealth = 100;
    public float m_speed;
    public float Speed { get { return m_speed; } set { m_speed = value; } }
    public float m_rotation = 0;
    public float RotationSpeed { get { return m_rotation; } set { m_rotation = value; } }
    float distance = 1;
    public GameObject attach;

    GameObject tail, body1, body2, body3, body4, body5;
    // Start is called before the first frame update
    void Start()
    {
        this.Health = InitialHealth;
        tail = GameObject.Find("Tail");
        body1 = GameObject.Find("Body1");
        body2 = GameObject.Find("Body2");
        body3 = GameObject.Find("Body3");
        body4 = GameObject.Find("Body4");
        body5 = GameObject.Find("Body5");
    }

    // Update is called once per frame
    void Update()
    {
        //m_speed = 16f;
        Vector3 v1, v2;
        v1 = this.gameObject.transform.position;
        v2 = attach.transform.position;
        distance = Vector3.Distance(v1, v2);

        this.gameObject.transform.rotation = Quaternion.Slerp(this.gameObject.transform.rotation, Quaternion.LookRotation(attach.transform.position -
           this.gameObject.transform.position), m_rotation * Time.deltaTime);

        Move();

        if (distance > 10)
        {
            //StartCoroutine(Lunge(5));
        }


    }
    void Move()
    {
        //move towards the player
        this.gameObject.transform.position += this.gameObject.transform.forward * Time.deltaTime * m_speed;
    }

   /* IEnumerator Delay(float secs)
    {
        Debug.Log("Delay Called");
        yield return new WaitForSeconds(secs);
    }
*/
    public GameObject getAttach()
    {
        return attach;
    }

    IEnumerator Lunge(float multiplier)
    {
        Debug.Log("BodyLunge");
        m_speed *= 0;
        yield return new WaitForSeconds(10);

        Debug.Log("Speed = " + m_speed);

        m_speed = 15f;
        m_speed *= multiplier;

        //move towards the player
        this.gameObject.transform.position += this.gameObject.transform.forward * Time.deltaTime * m_speed;
    }

}
