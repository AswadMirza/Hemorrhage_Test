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
        this.gameObject.transform.rotation = Quaternion.Slerp(this.gameObject.transform.rotation, Quaternion.LookRotation(attach.transform.position -
            this.gameObject.transform.position), rotationSpeed * Time.deltaTime);

        //move towards the player
       Move();

    }
    void Move()
    {
        //move towards the player
        this.gameObject.transform.position += this.gameObject.transform.forward * Time.deltaTime * m_speed;
    }

    IEnumerator Delay(float secs)
    {
        yield return new WaitForSeconds(secs);
    }

    void Lunge(float multiplier)
    {
        Debug.Log("Lunge");
        m_speed *= 0;

       /* this.gameObject.transform.rotation = Quaternion.Slerp(this.gameObject.transform.rotation, Quaternion.LookRotation(attach.transform.position -
           this.gameObject.transform.position), rotationSpeed * Time.deltaTime);*/
        StartCoroutine (Delay(3));

        m_speed *= multiplier;
    }

}
