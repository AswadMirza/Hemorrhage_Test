/** 
* Last modified 12/10/2020 
* By: Omer Farkhand
*/

using System.Collections;
using UnityEngine;


public class StreptobacillusMoniliformis : MonoBehaviour
{

    public float m_speed;
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
            Delay(3);
            Debug.Log("Distance is optimal");
            m_speed *= 3;
        }
        else if (Vector3.Distance(this.gameObject.transform.position, follow.transform.position) < 10)
        {
            print("worked");
            Debug.Log("Distance is optimal");
            m_speed *= 1;
        }
    }

    IEnumerator Delay(float secs)
    {
        yield return new WaitForSeconds(secs);
    }
}
