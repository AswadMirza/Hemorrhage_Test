using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMG : MonoBehaviour
{
    public GameObject playerObject;
    public Camera playerCamera;
    Player _player;

    // internal counter for checking if it is time to fire another bullet
    private float _fireRate = 0f;
    //Rate of fire that is set
    public float initialFireRate = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        _player = playerObject.GetComponent<Player>();
       
        _fireRate = initialFireRate;
    }

    // Update is called once per frame
    void Update()
    {
        _fireRate -= Time.deltaTime;

        if (Input.GetMouseButton(0)) {
            if (_player.Ammo > 0 && _player.Killed != true && _fireRate <=0) {
                _player.Ammo--;
                GameObject smgBulletObject = ObjectPoolingManager.Instance.GetSmgBullet(true);
                smgBulletObject.transform.position = playerCamera.transform.position + playerCamera.transform.forward;
                smgBulletObject.transform.forward = playerCamera.transform.forward;
            }
        
        }
        

        if (_fireRate <= 0) {
            _fireRate = initialFireRate;
        }
    }
}
