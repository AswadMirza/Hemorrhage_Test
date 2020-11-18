using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    // Start is called before the first frame update

    public int SceneIndex =0;




    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Player>() != null && Vector3.Distance(transform.position, other.transform.position)<3)
        {
            SceneManager.LoadScene(SceneIndex);
        }
    }
   
}
