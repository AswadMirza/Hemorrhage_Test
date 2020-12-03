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
        /*
        if (other.tag == "Death")
        {
            //gameObject.transform.position = m_startPos;
            //gameObject.transform.rotation = m_startRot;
            player.Health = 0;
        }
        */
         if (other.tag == "Goal") {
            SceneManager.LoadScene(0);
        }
    }
}
