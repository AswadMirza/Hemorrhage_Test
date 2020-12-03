using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public float scrollSpeed = 20;
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
    }

    void OnClick()
    {
        Debug.Log("Loading Main Menu...");
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator CreditsTimer()
    {
        yield return new WaitForSeconds(22);
        Debug.Log("Loading Main Menu....");
        SceneManager.LoadScene("MainMenu");

    }
}
