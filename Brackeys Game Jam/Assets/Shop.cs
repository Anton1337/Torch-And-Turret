using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour {

    [System.Serializable]
    public class Upgrade
    {
        public string name;

        public TextMeshProUGUI levelText;
        public TextMeshProUGUI priceText;

        public int price = 50;
        public int level = 1;
    }

    public static int goldAmount = 0;

    private Player player;
    private Castle castle;
    private Turret turret;

    private void Start()
    {
        goldAmount = 0;
        player = FindObjectOfType<Player>();
        castle = FindObjectOfType<Castle>();
        turret = FindObjectOfType<Turret>();
    }

    public Upgrade[] upgrades;

    public void UpgradeClick(string name)
    {
        foreach (var upgrade in upgrades)
        {
            if(upgrade.name == name && goldAmount >= upgrade.price)
            {
                goldAmount -= upgrade.price;

                upgrade.price += 50;
                upgrade.level += 1;

                upgrade.levelText.text = upgrade.level.ToString();
                upgrade.priceText.text = upgrade.price.ToString() + "G";

                UpgradeStat(name);
            }
        }
    }

    private void UpgradeStat(string name)
    {
        if(name == "TorchLight")
        {
            player.lightRange += 0.5f;
        }
        else if(name == "CastleHealth")
        {
            if(castle.maxHealth < 20)
            {
                castle.health += 1;
                castle.maxHealth += 1;
                castle.UpdateHealthBar();
            }
            else
            {
                Debug.LogError("Health already at max. Upgrade failed!");
            }
        }
        else if(name == "TurretDmg")
        {
            Bullet.damage += 1;
        }
        else if(name == "TurretAtkSpd")
        {
            turret.startTimeBtwShots -= 0.03f;
        }
        else if(name == "PlayerDmg")
        {
            player.damage += 1;
        }
        else if(name == "PlayerSpd")
        {
            player.speed += 0.5f;
        }
    }
}
