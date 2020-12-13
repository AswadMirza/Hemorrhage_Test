/** 
 * Created By: Omer Farkhand
* Last modified 12/12/2020
* By: Sharek Khan
*/

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public float scrollSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

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

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.name == "Canvas")
        {
            scrollSpeed = 0;
            StartCoroutine(CreditsTimer());
        }
    }

    void OnPress()
    {
        Debug.Log("Loading Main Menu...");
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator CreditsTimer()
    {
        yield return new WaitForSeconds(5);
        OnPress();
    }
}