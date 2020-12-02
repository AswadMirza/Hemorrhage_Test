using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject Myoviridae;
    public GameObject Cancer;
    public GameObject EnemyContainer;
    public GameObject[] spawnPoints;
    public GameObject spawnEffect;

    //public AudioSource audioSource;

    public GameObject Door;

    Vector3 objectPos;


    public float maxXPos;
    public float minXPos;

    public float maxZPos;
    public float minZPos;

    private List<GameObject> enemiesSpawned = new List<GameObject>();
    private bool spawned = false;
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
        //destroys the game obect if all the enemies are dead and disables the door
        if (Door != null && AreEnemiesDead())
        {
            Door.SetActive(false);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Spawn();

            if (Door != null)
            {
                Door.SetActive(true);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }

    void Spawn()
    {
        //if we havnt spawned enemies, then spawn them
        if (!spawned)
        {
            if (spawnPoints.Length >= 4)
            {
                for (int i = 0; i < spawnPoints.Length; i++)
                {
                    if (spawnPoints.Length == 10)
                    {
                        if (spawnPoints.Length - i <= 4)
                        {
                            GameObject effect = Instantiate(spawnEffect, spawnPoints[i].transform.position, spawnEffect.transform.rotation);
                            //audioSource.transform.position = spawnPoints[i].transform.position;
                            //audioSource.Play();
                            GameObject virus = Instantiate(Cancer, spawnPoints[i].transform.position, Quaternion.identity);

                            //spawnPoints[i].Equals(virus);
                            //spawnPoints[i].transform.parent = EnemyContainer.transform;
                            virus.transform.parent = EnemyContainer.transform;
                            enemiesSpawned.Add(virus);
                            Debug.Log("Spawned");
                            //Destroy(effect);
                        }
                        else
                        {
                            GameObject effect = Instantiate(spawnEffect, spawnPoints[i].transform.position, spawnEffect.transform.rotation);
                            //audioSource.transform.position = spawnPoints[i].transform.position;
                            //audioSource.Play();
                            GameObject virus = Instantiate(Myoviridae, spawnPoints[i].transform.position, Quaternion.identity);

                            //spawnPoints[i].Equals(virus);
                            //spawnPoints[i].transform.parent = EnemyContainer.transform;
                            virus.transform.parent = EnemyContainer.transform;
                            enemiesSpawned.Add(virus);
                            Debug.Log("Spawned");
                            //Destroy(effect);
                        }
                    }
                    else
                    {
                        if (spawnPoints.Length - i <= 2)
                        {
                            GameObject effect = Instantiate(spawnEffect, spawnPoints[i].transform.position, spawnEffect.transform.rotation);
                            //audioSource.transform.position = spawnPoints[i].transform.position;
                            //audioSource.Play();
                            GameObject virus = Instantiate(Cancer, spawnPoints[i].transform.position, Quaternion.identity);

                            //spawnPoints[i].Equals(virus);
                            //spawnPoints[i].transform.parent = EnemyContainer.transform;
                            virus.transform.parent = EnemyContainer.transform;
                            enemiesSpawned.Add(virus);
                            Debug.Log("Spawned");
                            //Destroy(effect);
                        }
                        else
                        {
                            GameObject effect = Instantiate(spawnEffect, spawnPoints[i].transform.position, spawnEffect.transform.rotation);
                            //audioSource.transform.position = spawnPoints[i].transform.position;
                            //audioSource.Play();
                            GameObject virus = Instantiate(Myoviridae, spawnPoints[i].transform.position, Quaternion.identity);

                            //spawnPoints[i].Equals(virus);
                            //spawnPoints[i].transform.parent = EnemyContainer.transform;
                            virus.transform.parent = EnemyContainer.transform;
                            enemiesSpawned.Add(virus);
                            Debug.Log("Spawned");
                            //Destroy(effect);
                        }
                    }
                }
                spawned = true;
                Debug.Log("Spawn " + enemiesSpawned.Count);
            }
            else
            {
                for (int i = 0; i < spawnPoints.Length; i++)
                {
                    GameObject effect = Instantiate(spawnEffect, spawnPoints[i].transform.position, spawnEffect.transform.rotation);
                    //audioSource.transform.position = spawnPoints[i].transform.position;
                    //audioSource.Play();
                    GameObject virus = Instantiate(Myoviridae, spawnPoints[i].transform.position, Quaternion.identity);
                    //spawnPoints[i].Equals(virus);
                    //spawnPoints[i].transform.parent = EnemyContainer.transform;
                    virus.transform.parent = EnemyContainer.transform;
                    enemiesSpawned.Add(virus);
                    Debug.Log("Spawned");
                    //Destroy(effect);
                }
                spawned = true;
                Debug.Log("Spawn " + enemiesSpawned.Count);
            }
        }
    }

    bool AreEnemiesDead()
    {
        bool check = true;
        if (spawned)
        {
            foreach (GameObject virus in enemiesSpawned)
            {
                // if the virus is destroyed this will be null
                if (virus != null)
                {
                    check = false;
                    break;
                }
            }
        }
        else
        {
            check = false;
        }

        return check;
    }
}