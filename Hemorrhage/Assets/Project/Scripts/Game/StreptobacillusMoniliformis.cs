/** 
* Last modified 12/10/2020 
* By: Omer Farkhand
*/

using System.Collections;
using UnityEngine;


public class StreptobacillusMoniliformis : Enemy
{

    public AudioSource deathSound;
    public float speed;
    public float rotationSpeed = 5;
    Vector3 dir1;
    Vector3 dir2;
    float distance;
    public GameObject follow;
    public GameObject[] body = new GameObject[6];
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v1, v2;
        v1 = this.gameObject.transform.position;
        v2 = follow.transform.position;

        Move();
        distance = Vector3.Distance(this.gameObject.transform.position, follow.transform.position);

        if (distance > 5.0f) { 

            Debug.Log(distance);
            Lunge();
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
        //rotate to look at the player
        this.gameObject.transform.rotation = Quaternion.Slerp(this.gameObject.transform.rotation, Quaternion.LookRotation(follow.transform.position -
            this.gameObject.transform.position), rotationSpeed * Time.deltaTime);

        //move towards the player
        this.gameObject.transform.position += this.gameObject.transform.forward * Time.deltaTime * speed;
    }

    IEnumerator Lunge()
    {
        Debug.Log("Lunge");
        this.gameObject.transform.position = this.gameObject.transform.position * Time.deltaTime * 0;

        //rotate to look at the player
        this.gameObject.transform.rotation = Quaternion.Slerp(this.gameObject.transform.rotation, Quaternion.LookRotation(follow.transform.position -
            this.gameObject.transform.position), rotationSpeed * Time.deltaTime);

        yield return new WaitForSeconds(2f);
        this.gameObject.transform.position += this.gameObject.transform.forward * Time.deltaTime * speed*3;
    }


}
