using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{

    public GameObject playerObject;
    public Camera playerCamera;
    private Player _player;
    // Start is called before the first frame update

    //private float _fireRate=0f;
   // public float initialFireRate=0.5f;
    void Start()
    {
     //   _fireRate = initialFireRate;
        _player = playerObject.GetComponent<Player>();

    }

    // Update is called once per frame
    void Update()
    {

        

         Fire();
    }

    void Fire() {
      //  _fireRate -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            if (_player.Ammo > 0 && _player.Killed != true )
            {
                _player.Ammo--;
                GameObject shotgunShellObject = ObjectPoolingManager.Instance.GetShotgunShell(true);
                shotgunShellObject.transform.position = playerCamera.transform.position + playerCamera.transform.forward;
                shotgunShellObject.transform.forward = playerCamera.transform.forward;
            }

        }
        /*
        if (_fireRate <= 0) {
            _fireRate = initialFireRate;
        }
        */
    }
}
