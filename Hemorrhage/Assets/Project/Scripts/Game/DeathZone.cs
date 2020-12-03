/** 
* Last modified 03/12/2020 
* By: Sharek Khan 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // This code is redundant, Player's HitBox already checks for collision with DeathZone
        if (other.GetComponent<PlayerHitBox>() != false) {
            Debug.LogError("Logic is in DeathZone.cs Line:22.");
            Player player = other.GetComponent<Player>();
            if (player != null) {
                player.Health = 0;
            }
            
        }
    }
}
