/** 
* Last modified 02/10/2020
* By: Sharek Khan
*/

using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("Game")]
    public Player player;
    public GameObject enemyContainer;

    [Header("UI")]
    public Text healthText;
    public Text ammoText;
    public Text armourText;
    public Text enemyText;
    public Text infoText;

    private float resetTimer = 3f;
    private bool gameOver = false;
    void Start()
    {
        infoText.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + player.Health;
        ammoText.text = "Ammo: " + player.Ammo;
        armourText.text = "Armour: " + player.Armour;
        int aliveEnemies = 0;
        foreach(Enemy enemy in enemyContainer.GetComponentsInChildren<Enemy>())
        {
            if(enemy.Killed == false)
            {
                aliveEnemies++;
            }
        }
        enemyText.text = "Enemies: " + aliveEnemies;
        if(aliveEnemies == 0)
        {
            gameOver = true;
            infoText.gameObject.SetActive(true);
            infoText.text = "You Win!";
        }
        if(player.Killed == true)
        {
            gameOver = true;
            infoText.gameObject.SetActive(true);
            infoText.text = "You Died!";
        }
        if(gameOver == true)
        {
            resetTimer -= Time.deltaTime;
            if(resetTimer <= 0)
            {
                // SceneManager.LoadScene("Menu");
            }
        }
    }
}
