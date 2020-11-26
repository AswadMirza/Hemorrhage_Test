/** 
* Last modified 25/11/2020
* By: Sharek Khan
*/

using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    private Player player = null;
    private GunContainer gunContainer = null;

    [Header("UI")]
    public Text gameInfoText = null;
    public Text armourText = null;
    public Text healthText = null;
    public Image playerImage = null;
    public Text plasmaText = null;
    public Image weaponImage = null;
    // Image for weapon

    // Start is called before the first frame update
    private void Start()
    {
        // Gets the Player script from the Player objects component
        player = GameObject.Find("Player").GetComponent<Player>();
        // Gets the GunContainer scripts from the component of Player objects children
        gunContainer = GameObject.Find("Player").GetComponentInChildren<GunContainer>();
        // gameInfoText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        // Updates the Game Info Text on the UI
        gameInfoText.text = ActivityLog.ReadRecentActivity();
        // Updates the Player Armour on the UI
        armourText.text = player.Armour + "%";
        // Updates the Player Health on the UI
        healthText.text = player.Health + "%";
        
        // Updates the Player Image on the UI
        if (player.Health >= 100)
        {
            // Show Default Player Image
        }
        else if(player.Health >= 75 && player.Health < 100)
        {
            // Show Minor Player Degradation
        }
        else if(player.Health >= 50 && player.Health < 75)
        {
            // Show Some Player Degradation
        }
        else if(player.Health >= 25 && player.Health < 50)
        {
            // Show Plenty Player Degradation
        }
        else if(player.Health > 0 && player.Health < 25)
        {
            // Show Major Player Degradation
        }
        else
        {
            // Show Defeated/Killed Player Image
        }
        
        // Updates the Weapon Plasma on the UI
        plasmaText.text = player.Plasma + "%";
        
        // Updates the Weapon sprite on the UI
        if(gunContainer.SelectedGun == 0)
        {
            // Display Plasma Rifle
        }
        else if (gunContainer.SelectedGun == 1)
        {
            // Display Plasma Shotgun
        }
    }
}