using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Purpose of this class is to hold all the gun models, and choose which is active
//idea: Each gun has its own fire functionality, and different bullets that they fire. 
//When the player left clicks, they just call the selected gun's fire script
//when the player scrolls up and down, they just select a different 
public class GunContainer : MonoBehaviour
{
    
    public int SelectedGun=0;
    void Start()
    {
        SelectWeapon();
        
    }

    // Update is called once per frame
    void Update()
    {
        // temp variable that only exists to make sure we arent calling the select weapon function every frame
        int previousSelectedGun = SelectedGun;

        //Changing weapon with the scroll wheel
        // if the axis of the scroll wheel is positive, it means the user is scrolling up, if its negative it means they are
        // scrolling down

        //if the user is scrolling up
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) {
            if (SelectedGun >= transform.childCount - 1)
            {
                SelectedGun = 0;
            }
            else {
                SelectedGun++;
            }
        }
        //if the user is scrolling down
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (SelectedGun <= 0)
            {
                SelectedGun = transform.childCount-1;
            }
            else
            {
                SelectedGun--;
            }
        }

        if (previousSelectedGun != SelectedGun) {
            SelectWeapon();
        }


    }

    public void SelectWeapon() {
        //for each child transform in the transform in the gunContainer, we are looping through the 

        int index = 0;
        foreach (Transform weapon in transform) {
            if (SelectedGun == index){

                weapon.gameObject.SetActive(true);
            }
            else {
                weapon.gameObject.SetActive(false);
            
            }
            index++;
        }
    }
}
