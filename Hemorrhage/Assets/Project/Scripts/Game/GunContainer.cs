using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Purpose of this class is to hold all the gun models, and choose which is active
//idea: Each gun has its own fire functionality, and different bullets that they fire. 
//When the player left clicks, they just call the selected gun's fire script
//when the player scrolls up and down, they just select a different 
public class GunContainer : MonoBehaviour
{
    private GameObject selectedGun;
    public GameObject SelectedGun;
    void Start()
    {
        selectedGun = SelectedGun;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
