using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Made by Aswad Mirza student number 991445135
public class TimerDestroy : MonoBehaviour
{

    public float Timer = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer <= 0) {
            Destroy(gameObject);
        }

        Timer -= Time.deltaTime;
        
    }
}
