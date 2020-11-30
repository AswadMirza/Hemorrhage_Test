/** 
* Last modified 25/11/2020
* By: Sharek Khan
*/

using UnityEngine;

public  class Gun : MonoBehaviour
{
    private Player m_player;

    public GameObject playerObject;
    public Camera playerCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        // Retrieve the Player scripts component of the Player object
        m_player = playerObject.GetComponent<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (m_player.Plasma > 0 && m_player.IsKilled != true)
            {
                m_player.Plasma--;
                GameObject bulletObject = ObjectPoolingManager.Instance.GetBullet(true);
                bulletObject.transform.position = playerCamera.transform.position + playerCamera.transform.forward;
                bulletObject.transform.forward = playerCamera.transform.forward;
            }

        }
    }
}
