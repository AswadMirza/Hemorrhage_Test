using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject Enemy;

    Vector3 objectPos;
    float objectXPos;
    float objectZPos;

    public float maxXPos;
    public float minXPos;

    public float maxZPos;
    public float minZPos;

    public int maxEnemy;
    int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
                objectPos = this.gameObject.transform.position;

        minXPos = objectPos.x - 10f;
        maxXPos = minXPos + 10f;

        minZPos = objectPos.z - 10f;
        maxZPos = minZPos + 10f;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            for(int i = 0; i < maxEnemy; i++)
            {
                
                GameObject virus = Instantiate(Enemy, new Vector3(gameObject.transform.position.x, other.gameObject.transform.position.y , gameObject.transform.position.z), Quaternion.identity);
                virus.transform.parent = GameObject.Find("EnemyController").transform;
                Debug.Log("Spawned");
            }

            Destroy(this.gameObject);
        }

    }
}
