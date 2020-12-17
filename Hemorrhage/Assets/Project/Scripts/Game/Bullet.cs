/**
 * Created DD/MM/YYYY
 * By: Sharek Khan
 * Last Modified DD/MM/YYYY
 * By: [Insert Name]
 * 
 * Contributors: Aswad Mirza
 */

using UnityEngine;

/*
 * [Describe the function of the class]
 * Code based on Zenva Studios -COMPLETE COURSE Create a Unity FPS Game in 3 hours - https://www.youtube.com/watch?v=UtlAqRyZrUw
 */
public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float lifeDuration = 10f;
    public int damage = 5;

    private float lifeTimer;

    private bool shotByPlayer;
    public bool ShotByPlayer { get { return shotByPlayer; } set { shotByPlayer = value; } }

    // Start is called before the first frame update
    void OnEnable()
    {
        lifeTimer = lifeDuration;
    }

    // Update is called once per frame
    void Update()
    {
        // Make the bullet move
        transform.position += transform.forward * speed * Time.deltaTime;

        // Check if the bullet should be destroyed
        lifeTimer -= Time.deltaTime;
        if(lifeTimer <= 0f)
        {
            gameObject.SetActive(false);
        }
    }
}