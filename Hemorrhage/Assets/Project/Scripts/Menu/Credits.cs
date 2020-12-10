/** 
* Last modified 06/12/2020
* By: Sharek Khan
*/

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    public float scrollSpeed = 30;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreditsTimer());
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 localVectorUp = transform.TransformDirection(0, 10, 0);
        pos += localVectorUp * scrollSpeed * Time.deltaTime;
        transform.position = pos;

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Mouse0) || 
            Input.GetKeyDown(KeyCode.Space))
        {
            OnPress();
        }
    }

    void OnPress()
    {
        Debug.Log("Loading Main Menu...");
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator CreditsTimer()
    {
        yield return new WaitForSeconds(28);
        Debug.Log("Loading Main Menu....");
        SceneManager.LoadScene("MainMenu");

    }
}
