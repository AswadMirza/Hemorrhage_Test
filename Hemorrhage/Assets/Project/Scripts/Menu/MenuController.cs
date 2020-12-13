/** 
* Last modified 10/12/2020
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

    public void PlayGame()
    {
        Debug.Log("Loading Level 1...");
        SceneManager.LoadScene("Level01");
    }

    public void StartCredits()
    {
        Debug.Log("Loading Credits...");
        SceneManager.LoadScene("Credits");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        // Quit the game through application...
        Application.Quit();
        // Quit the game through editor...
         UnityEditor.EditorApplication.isPlaying = false;
    }
}
