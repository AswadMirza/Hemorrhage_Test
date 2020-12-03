/** 
* Last modified 03/12/2020 
* By: Sharek Khan 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{

    private Vector3 m_startPos;
    private Quaternion m_startRot;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        m_startPos = transform.position;
        m_startRot = transform.rotation;
        player = gameObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // This code is redundant, Player's HitBox already checks for collision with DeathZone
        if (other.GetComponent<PlayerHitBox>() != false)
        {
            // Debug.LogError("Logic is in Respawn.cs Line:30.");
            // gameObject.transform.position = m_startPos;
            // gameObject.transform.rotation = m_startRot;
            // player.Health = 0;
        }
        // Play reaches the level goal
        else if (other.tag == "Goal") {
            SceneManager.LoadScene(0);
        }
    }
}
