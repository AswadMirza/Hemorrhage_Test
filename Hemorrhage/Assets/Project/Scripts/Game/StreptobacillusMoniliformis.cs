/** 
* Last modified 12/10/2020 
* By: Omer Farkhand
*/

using System.Collections;
using UnityEngine;


public class StreptobacillusMoniliformis : MonoBehaviour
{

    float m_speed;
    float rotationSpeed = 5;
    Vector3 dir1;
    Vector3 dir2;
    public GameObject follow;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.gameObject.transform.position, follow.transform.position) > 10)
        {
            print("worked");
            Debug.Log("Distance is optimal");
            Lunge();
        }
        
    }

    void Lunge()
    {
        //this.gameObject.transform.position = this.gameObject.transform.position * Time.deltaTime * 0;

        this.gameObject.transform.rotation = Quaternion.Slerp(this.gameObject.transform.rotation, Quaternion.LookRotation(follow.transform.position -
           this.gameObject.transform.position), rotationSpeed * Time.deltaTime);
        Debug.Log("Lunge");
        Delay(3);

        this.gameObject.transform.position += this.gameObject.transform.forward * Time.deltaTime * m_speed*3;
    }

    IEnumerator Delay(float secs)
    {
        yield return new WaitForSeconds(secs);
    }
}
