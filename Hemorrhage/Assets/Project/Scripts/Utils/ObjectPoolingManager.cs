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


    //ShotgunPellets

    public GameObject shotgunShellPrefab;
    public int shotgunShellAmount = 20;
    private List<GameObject> _shotgunShells;

    // MeleeWeapon
    public GameObject meleeWeaponPrefab;
    public int meleeWeaponAmount = 5;
    private List<GameObject> _meleeWeapons;
    void Awake()
    {
        instance = this;
        // Preload bullets

        bullets = new List<GameObject>(bulletAmount);
        for (int i = 0; i < bulletAmount; i++)
        {
            GameObject prefabInstance = Instantiate(bulletPrefab);
            prefabInstance.transform.SetParent(transform);
            prefabInstance.SetActive(false);
            bullets.Add(prefabInstance);
        }

        //preload smgBullets
        smgBullets = new List<GameObject>(smgBulletAmount);
        for (int i = 0; i < smgBulletAmount; i++)
        {
            GameObject smgPrefabInstance = Instantiate(smgBulletPrefab);
            smgPrefabInstance.transform.SetParent(transform);
            smgPrefabInstance.SetActive(false);
            smgBullets.Add(smgPrefabInstance);
        }

        // preload ShotgunShells
        _shotgunShells = new List<GameObject>(shotgunShellAmount);
        for (int i = 0; i < smgBulletAmount; i++)
        {
            GameObject shotgunShellPrefabInstance = Instantiate(shotgunShellPrefab);
            shotgunShellPrefabInstance.transform.SetParent(transform);
            shotgunShellPrefabInstance.SetActive(false);
            _shotgunShells.Add(shotgunShellPrefabInstance);
        }

        //Preload MeleeWeapons
        //_meleeWeapons = new List<GameObject>(meleeWeaponAmount);
        fillBulletList(ref _meleeWeapons, meleeWeaponPrefab, meleeWeaponAmount);
    }
        // Update is called once per frame
        public GameObject GetBullet (bool shotByPlayer) {
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

    public GameObject GetShotgunShell(bool shotByPlayer)
    {
        foreach (GameObject shotgunShell in _shotgunShells)
        {
            if (!shotgunShell.activeInHierarchy)
            {
                shotgunShell.SetActive(true);
                foreach (Transform pellet in shotgunShell.transform) {
                    Bullet childBullet = pellet.GetComponent<Bullet>();
                    childBullet.ShotByPlayer = shotByPlayer;

                }
                //shotgunShell.GetComponent<Bullet>().ShotByPlayer = shotByPlayer;
                return shotgunShell;
            }
        }
        GameObject shotgunShellPrefabInstance = Instantiate(shotgunShellPrefab);
        shotgunShellPrefabInstance.transform.SetParent(transform);
        _shotgunShells.Add(shotgunShellPrefabInstance);
        return shotgunShellPrefabInstance;
    }

    public GameObject GetMeleeWeapon() {
        foreach (GameObject melee in _meleeWeapons) {
            if (!melee.activeInHierarchy)
            {
                melee.SetActive(true);
                return melee;
            }
            
            
        }
        GameObject meleeWeaponInstance = Instantiate(meleeWeaponPrefab);
        meleeWeaponPrefab.transform.SetParent(transform);
        _meleeWeapons.Add(meleeWeaponInstance);
        return meleeWeaponInstance;
    }
    //just to make the job of preloading a fuckton of bullets easier, and to add more scalability to the project

    
    private void fillBulletList( ref List<GameObject> bulletList,GameObject prefab,  int amount) {
        bulletList = new List<GameObject>(amount);
        for (int i = 0; i < amount; i++)
        {
            GameObject prefabInstance = Instantiate(prefab);
            prefabInstance.transform.SetParent(transform);
            prefabInstance.SetActive(false);
            bulletList.Add(prefabInstance);
        }

    }
    



}
