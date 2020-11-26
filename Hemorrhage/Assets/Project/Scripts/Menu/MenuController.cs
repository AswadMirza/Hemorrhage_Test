/** 
* Last modified 25/11/2020
* By: Sharek Khan
*/

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

    public void PlayGame()
    {
        Debug.Log("Loading level 1...");
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        // Quit the game...
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
