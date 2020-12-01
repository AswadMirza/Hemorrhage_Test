/** 
* Last modified 18/11/2020
* By: Aswad Mirza
*/

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private float m_resetTimer = 3f;
    private bool m_gameOver = false;

    [Header("Game")]
    public Player player;
    public GameObject enemyContainer;

    //Removing ui in game controller due to redundancy
    /*
    [Header("UI")]
    public Text healthText;
    public Text ammoText;
    public Text armourText;
    public Text enemyText;
    public Text infoText;
    */
    public int nextLevelIndex = 1;
    public int currentLevelIndex = 0;

    void Start()
    {
       // infoText.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
       // healthText.text = "Health: " + player.Health;
       // ammoText.text = "Ammo: " + player.Plasma;
       // armourText.text = "Armour: " + player.Armour;
        int aliveEnemies = 0;
        foreach(Enemy enemy in enemyContainer.GetComponentsInChildren<Enemy>())
        {
            if(enemy.IsKilled == false)
            {
                aliveEnemies++;
            }
        }
      //  enemyText.text = "Enemies: " + aliveEnemies;
        if(aliveEnemies == 0)
        {
            m_gameOver = true;
            //   infoText.gameObject.SetActive(true);
            //  infoText.text = "You Win!";
            ActivityLog.AddActivity("You Win!");
        }
        if(player.IsKilled == true)
        {
            m_gameOver = true;
            ActivityLog.AddActivity("You Died");
        }
        if(m_gameOver == true)
        {
            m_resetTimer -= Time.deltaTime;
            if(m_resetTimer <= 0)
            {
                if (!player.IsKilled)
                {
                    SceneManager.LoadScene(nextLevelIndex);
                }
                else {
                    SceneManager.LoadScene(currentLevelIndex);
                }
                 
            }
        }
    }
}
