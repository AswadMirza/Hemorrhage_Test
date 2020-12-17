/** 
 * Created 03/12/2020
 * By: Omer Farkhand
 * Last modified 12/12/2020
 * By: Sharek Khan
 * 
 * Contributors: Omer Farkhand, Sharek Khan
 */

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * This script handles the credit sequence
 */
public class Credits : MonoBehaviour
{
    public float scrollSpeed = 10;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 localVectorUp = transform.TransformDirection(0, 10, 0);
        pos += localVectorUp * scrollSpeed * Time.deltaTime;
        transform.position = pos;

        // Credits stop if interrupted by User input
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Mouse0) ||
            Input.GetKeyDown(KeyCode.Space))
        {
            OnPress();
        }
    }

    //Starts the CreditTimer once the Exit Trigger condition is met
    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.name == "Canvas")
        {
            scrollSpeed = 0;
            StartCoroutine(CreditsTimer());
        }
    }

    //Loads the MainMennu
    void OnPress()
    {
        Debug.Log("Loading Main Menu...");
        SceneManager.LoadScene("MainMenu");
    }

    //Sets up the Timer for Credits
    IEnumerator CreditsTimer()
    {
        yield return new WaitForSeconds(5);
        OnPress();
    }
}