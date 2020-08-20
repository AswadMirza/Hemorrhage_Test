using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMG : MonoBehaviour
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
        if (Input.GetMouseButton(0)) {
            if (_player.Ammo > 0 && _player.Killed != true) {
                _player.Ammo--;
                GameObject smgBulletObject = ObjectPoolingManager.Instance.GetSmgBullet(true);
                smgBulletObject.transform.position = playerCamera.transform.position + playerCamera.transform.forward;
                smgBulletObject.transform.forward = playerCamera.transform.forward;
            }
        
        }
    }
}
