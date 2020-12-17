/**
 * Created DD/MM/YYYY
 * By: Aswad Mirza
 * Last Modified DD/MM/YYYY
 * By: [Insert Name]
 * 
 * Contributors:
 */

using UnityEngine;

/*
 * [Describe the function of the class]
 */
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