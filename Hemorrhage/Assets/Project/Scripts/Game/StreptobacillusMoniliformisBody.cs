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

    void Lunge(float multiplier)
    {
        //this.gameObject.transform.position = this.gameObject.transform.position * Time.deltaTime * 0;

        this.gameObject.transform.rotation = Quaternion.Slerp(this.gameObject.transform.rotation, Quaternion.LookRotation(attach.transform.position -
           this.gameObject.transform.position), rotationSpeed * Time.deltaTime);

        m_speed *= 0;

        Debug.Log("Lunge");
        Delay(3);

        m_speed *= multiplier;
    }

    IEnumerator Delay(float secs)
    {
        yield return new WaitForSeconds(secs);
    }

    private Vector3 MoveSourceToDest(Vector3 _source, Vector3 _dest, float _speed)
    {
        Vector3 dist;
        dist.x  = _source.x + distance;
        dist.y = _source.y;
        dist.z = _source.z + distance;
        Vector3 dir = (_dest - dist).normalized;
        _source += (dir * _speed);
        return _source;
    }

}
