using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseMeleeWeapon : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject meleeWeapon;
    public AudioClip meleeSounds;

    private AudioSource source;
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) {
            float volume = Random.Range(5,10);
            source.PlayOneShot(meleeSounds,volume);

            Vector3 weaponRotation = transform.rotation.eulerAngles;
            weaponRotation.x = 90;

            GameObject weapon = Instantiate(meleeWeapon, transform.position, Quaternion.Euler(weaponRotation));
            //GameObject weapon =ObjectPoolingManager.Instance.GetMeleeWeapon();
           // weapon.transform.position = gameObject.transform.position;
            Rigidbody rb = weapon.GetComponent<Rigidbody>();

            //Launch that shit with the might of zeus
            rb.AddRelativeForce(0, 2000, 0);

            
        }
    }
}
