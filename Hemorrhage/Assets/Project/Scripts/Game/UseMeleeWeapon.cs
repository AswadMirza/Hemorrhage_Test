using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// last updated by Aswad Mirza on 0ct 21st 2020
public class UseMeleeWeapon : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject meleeWeapon;
    public AudioClip meleeSounds;

    private AudioSource source;

    //logic for fireRate
    public float initialFireRate = 0f;
    public float delayFireRate = 1f;

    private float m_fireRate;
    void Start()
    {
        source = GetComponent<AudioSource>();
        m_fireRate = initialFireRate;
    }

    // Update is called once per frame
    void Update()
    {
        //reducing the firerate by delta time
        if (m_fireRate >= 0) {
            m_fireRate -= Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(1) && m_fireRate <=0) {
            float volume = Random.Range(5,10);
            source.PlayOneShot(meleeSounds,volume);

            Vector3 weaponRotation = transform.rotation.eulerAngles;
            weaponRotation.x = 90;

            GameObject weapon = Instantiate(meleeWeapon, transform.position, Quaternion.Euler(weaponRotation));
            /*
            GameObject weapon =ObjectPoolingManager.Instance.GetMeleeWeapon();
            weapon.transform.position = transform.position;
            weapon.transform.rotation = Quaternion.Euler(weaponRotation);
            */
            Rigidbody rb = weapon.GetComponent<Rigidbody>();

            //Launch that shit with the might of zeus
            rb.AddRelativeForce(0, 2000, 0);

            //fireRate is equal to the delay fireRate
            m_fireRate = delayFireRate;
        }
    }
}
