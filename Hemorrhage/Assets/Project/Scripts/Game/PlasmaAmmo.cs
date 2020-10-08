/** 
* Last modified 04/10/2020
* By: Sharek Khan
*/

using UnityEngine;

public class PlasmaAmmo : MonoBehaviour
{
    public float speed = 20f;
    public float duration = 10f;
    public int damage = 5;

    private float m_lifespan;

    private bool m_shotByPlayer;
    public bool ShotByPlayer { get { return m_shotByPlayer; } set { m_shotByPlayer = value; } }
    // Start is called before the first frame update
    void Start()
    {
        m_lifespan = duration;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the PlasmaAmmo should be destroyed
        m_lifespan -= Time.deltaTime;
        if(m_lifespan <= 0f)
        {
            // Destroys the PlasmaAmmo
            Destroy(gameObject);
        }
    }
}
