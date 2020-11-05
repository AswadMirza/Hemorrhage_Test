/** 
* Last modified 12/10/2020 
* By: Omer Farkhand
*/

using System.Collections;
using UnityEngine;


public class StreptobacillusMoniliformisHead : Enemy
{
    public int InitialHealth = 100;
    public AudioSource deathSound;
    public float m_speed;
    public float rotationSpeed = 5;
    Vector3 dir1;
    Vector3 dir2;
    float distance;
    public GameObject follow;
    public GameObject[] body = new GameObject[6];
    // Start is called before the first frame update
    void Start()
    {
        this.Health = InitialHealth;
    }

    // Update is called once per frame
    void Update()
    {
        m_speed = 15f;
        Vector3 v1, v2;
        v1 = this.gameObject.transform.position;
        v2 = follow.transform.position;
        distance = Vector3.Distance(v1, v2);

        //rotate to look at the player
        this.gameObject.transform.rotation = Quaternion.Slerp(this.gameObject.transform.rotation, Quaternion.LookRotation(follow.transform.position -
            this.gameObject.transform.position), rotationSpeed * Time.deltaTime);

        Move();

        if (distance > 10)
        {
            Lunge(3);
        }
    }

    protected override void OnKill()
    {
        base.OnKill();
        deathSound.Play();
        // agent.enabled = false;
        this.enabled = false;

        body[5].SetActive(false);
        body[4].SetActive(false);
        body[3].SetActive(false);
        body[2].SetActive(false);
        body[1].SetActive(false);
        body[0].SetActive(false);
        this.gameObject.SetActive(false);
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
        Debug.Log("HeadLunge");
        m_speed *= 0;

        StartCoroutine(Delay(3));
        Debug.Log("Speed = " + m_speed);
        m_speed = 15f;
        m_speed *= multiplier;

    }

}
