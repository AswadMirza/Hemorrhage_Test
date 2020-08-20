using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingManager : MonoBehaviour
{
    private static ObjectPoolingManager instance;
    public static ObjectPoolingManager Instance { get { return instance; } }

    //  bullets
    public GameObject bulletPrefab;
    public int bulletAmount = 20;
    private List<GameObject> bullets;

    // smgBullets
    public GameObject smgBulletPrefab;
    public int smgBulletAmount = 100;
    private List<GameObject> smgBullets;
    void Awake()
    {
        instance = this; 
        // Preload bullets
        
        bullets = new List<GameObject>(bulletAmount);
        for(int i = 0; i < bulletAmount; i++)
        {
            GameObject prefabInstance = Instantiate(bulletPrefab);
            prefabInstance.transform.SetParent(transform);
            prefabInstance.SetActive(false);
            bullets.Add(prefabInstance);
        }
        
        //preload smgBullets
        smgBullets = new List<GameObject>(smgBulletAmount);
        for (int i = 0; i < smgBulletAmount; i++) {
            GameObject smgPrefabInstance = Instantiate(smgBulletPrefab);
            smgPrefabInstance.transform.SetParent(transform);
            smgBulletPrefab.SetActive(false);
            bullets.Add(smgBulletPrefab);
        }
    }

    // Update is called once per frame
    public GameObject GetBullet (bool shotByPlayer)
    {
        foreach(GameObject bullet in bullets)
        {
            if (!bullet.activeInHierarchy)
            {
                bullet.SetActive(true);
                bullet.GetComponent<Bullet>().ShotByPlayer = shotByPlayer;
                return bullet;
            }
        }
        GameObject prefabInstance = Instantiate(bulletPrefab);
        prefabInstance.transform.SetParent(transform);
        bullets.Add(prefabInstance);
        return prefabInstance;
    }


    public GameObject GetSmgBullet(bool shotByPlayer) {
        foreach (GameObject smgBullet in smgBullets) {
            if (!smgBullet.activeInHierarchy) {
                smgBullet.SetActive(true);
                smgBullet.GetComponent<Bullet>().ShotByPlayer = shotByPlayer;
                return smgBullet;
            }
        }
        GameObject smgPrefabInstance = Instantiate(smgBulletPrefab);
        smgPrefabInstance.transform.SetParent(transform);
        smgBullets.Add(smgPrefabInstance);
        return smgPrefabInstance;
    }
    //just to make the job of preloading a fuckton of bullets easier, and to add more scalability to the project

    /*
    private void fillBulletList( List<GameObject> bulletList,GameObject prefab,  int amount) {
        bulletList = new List<GameObject>(amount);
        for (int i = 0; i < amount; i++)
        {
            GameObject prefabInstance = Instantiate(prefab);
            prefabInstance.transform.SetParent(transform);
            prefabInstance.SetActive(false);
            bulletList.Add(prefabInstance);
        }

    }
    */


    
}
