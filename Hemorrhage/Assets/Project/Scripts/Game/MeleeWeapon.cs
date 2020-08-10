using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{

    GameObject playerModel;
    Player player;
    static bool isfired = false;

    float timeAlive;
    // Start is called before the first frame update
    void Start()
    {
       // isfired = false;
        timeAlive = 0.25f;
        playerModel = GameObject.Find("Player");
        player = playerModel.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        //we let the meleeweaponStay active for x seconds. and then destroy it
        if (timeAlive <= 0) {
            isfired = false;
            Destroy(gameObject);
        }
        timeAlive -= Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" && !isfired) {
            Destroy(collision.gameObject);
            int health = player.Health;
            player.Health=health+30;
            isfired = true;
            
        }
        
    }
}
