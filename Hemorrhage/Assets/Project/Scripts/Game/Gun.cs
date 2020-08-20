using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Gun : MonoBehaviour
{
    public GameObject playerObject;
    public Camera playerCamera;
    Player _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = playerObject.GetComponent<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_player.Ammo > 0 && _player.Killed != true)
            {
                _player.Ammo--;
                GameObject bulletObject = ObjectPoolingManager.Instance.GetBullet(true);
                bulletObject.transform.position = playerCamera.transform.position + playerCamera.transform.forward;
                bulletObject.transform.forward = playerCamera.transform.forward;
            }

        }
    }
}
