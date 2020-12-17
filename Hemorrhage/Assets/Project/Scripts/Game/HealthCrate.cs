/**
 * Created DD/MM/YYYY
 * By: [Insert Name]
 * Last Modified DD/MM/YYYY
 * By: [Insert Name]
 * 
 * Contributors:
 */

using UnityEngine;

/*
 * [Describe the functio of the class]
 * Code based on Zenva Studios -COMPLETE COURSE Create a Unity FPS Game in 3 hours - https://www.youtube.com/watch?v=UtlAqRyZrUw
 */
public class HealthCrate : MonoBehaviour
{
    [Header("Visuals")]
    public GameObject container;
    public float rotationSpeed = 80f;
    
    [Header("Gameplay")]
    public int health = 50;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        container.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
