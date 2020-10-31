/** 
* Last modified 12/10/2020 
* By: Omer Farkhand
*/
using System.Collections;
using UnityEngine;

public class StreptobacillusMoniliformisBody : MonoBehaviour
{
    public float m_speed;
    public float rotationSpeed = 5;
    public float distance;
    public GameObject attach;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_speed = 15f;
        Vector3 v1, v2;
        v1 = this.gameObject.transform.position;
        v2 = attach.transform.position;

        distance = Vector3.Distance(v1, v2);

        this.gameObject.transform.rotation = Quaternion.Slerp(this.gameObject.transform.rotation, Quaternion.LookRotation(attach.transform.position -
            this.gameObject.transform.position), rotationSpeed * Time.deltaTime);

        Move();

        //move towards the player
        if (distance > 10)
        {
            Lunge(3);
        }

    }
    void Move()
    {
        //move towards the player
        this.gameObject.transform.position += this.gameObject.transform.forward * Time.deltaTime * m_speed;
    }

    IEnumerator Delay(float secs)
    {
        Debug.Log("Delay Called");
        yield return new WaitForSeconds(secs);
    }

    void Lunge(float multiplier)
    {
        Debug.Log("BodyLunge");
        m_speed *= 0;

        StartCoroutine (Delay(3));
        Debug.Log("Speed = " + m_speed);
        m_speed = 15f;
        m_speed *= multiplier;
    }

}
