using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void OnPlay()
    {
        Debug.Log("Click successful");
        SceneManager.LoadScene("Level1");
    }

    public void PlayLevel1() {
        Debug.Log("Loading level 1");
        SceneManager.LoadScene("Level1");
    }
}
