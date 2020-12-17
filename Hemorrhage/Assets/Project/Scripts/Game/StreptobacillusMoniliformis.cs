/**
 * Created DD/MM/YYYY
 * By: Omer Farkhand
 * Last Modified DD/MM/YYYY
 * By: [Insert Name]
 * 
 * Contributors:
 */

using System.Collections;
using UnityEngine;

/*
 * [Describe the function of the class]
 */
public class StreptobacillusMoniliformis : MonoBehaviour
{
    public float m_speed;
    public float Speed { get { return m_speed; } set { m_speed = value; } }

    public float m_rotation = 0;
    public float RotationSpeed { get { return m_rotation; } set { m_rotation = value; } }

    Vector3 dir1;
    Vector3 dir2;
    float distance;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v1, v2;
        v1 = this.gameObject.transform.position;
        v2 = player.transform.position;
        distance = Vector3.Distance(v1, v2);

        if (distance > 10)
        {
            StartCoroutine(Lunge(5));
        }
    }

    // [Describe the function of this method]
    IEnumerator Lunge(float multiplier)
    {
        Debug.Log("HeadLunge");
        m_speed *= 0;
        yield return new WaitForSeconds(10);

        //rotate to look at the player
        this.gameObject.transform.rotation = Quaternion.Slerp(this.gameObject.transform.rotation, Quaternion.LookRotation(player.transform.position -
            this.gameObject.transform.position), m_rotation * Time.deltaTime);

        Debug.Log("Speed = " + m_speed);

        m_speed = 15f;        m_speed *= multiplier;

        //move towards the player
        this.gameObject.transform.position += this.gameObject.transform.forward * Time.deltaTime * m_speed;
    }
}