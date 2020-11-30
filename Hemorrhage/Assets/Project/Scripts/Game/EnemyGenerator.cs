using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject EnemyContainer;
    public GameObject[] spawnPoints;
    public GameObject spawnEffect;

    public GameObject Door = null;

    Vector3 objectPos;


    public float maxXPos;
    public float minXPos;

    public float maxZPos;
    public float minZPos;
    int enemyCount = 10;

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
       /* for (int i = 0; i <= spawnPoints.Length; i++)
        {
            if (spawnPoints[i].GetComponent<Enemy>().Health == 0)
            {
                Debug.Log("Enemy = " + enemyCount);
                enemyCount--;
            }

        }

        if(enemyCount == 0)
        {
            Door.SetActive(false);
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            for(int i = 0; i < spawnPoints.Length; i++)
            {
                GameObject effect = Instantiate(spawnEffect, spawnPoints[i].transform.position, spawnEffect.transform.rotation);


                GameObject virus = Instantiate(Enemy, spawnPoints[i].transform.position, Quaternion.identity);
                //spawnPoints[i].Equals(virus);
                //spawnPoints[i].transform.parent = EnemyContainer.transform;
                Debug.Log("Spawned");
                Destroy(effect);

            }
            if (Door != null)
            {
                Door.SetActive(true);
            }

            Destroy(this.gameObject);
        }

    }
}
