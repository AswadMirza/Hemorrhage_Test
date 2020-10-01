using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{

    GameObject playerModel;
    Player player;
    static bool isfired = false;

    public float timeAlive =0.25f;
    // Start is called before the first frame update
    void Start()
    {
       // isfired = false;
        //timeAlive = 0.25f;
        playerModel = GameObject.Find("Player");
        player = playerModel.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        //we let the meleeweaponStay active for x seconds. and then destroy it
        if (timeAlive <= 0) {
            isfired = false;
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
        timeAlive -= Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        // gotta change this so instead of killing the enemy, it deals damage
        if (collision.gameObject.GetComponent<Enemy>() != false) {
            Debug.Log("rekt");
            Destroy(collision.gameObject);
            int health = player.Health;
            player.Health=health+30;
            isfired = true;
            
        }
        
    }
}
